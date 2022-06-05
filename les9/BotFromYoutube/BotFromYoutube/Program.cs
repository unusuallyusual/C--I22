using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotFromYoutube
{
    class Program
    {
    private static string token { get; set; } = "секретный токен";
    private static TelegramBotClient client;

        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            client.StopReceiving();
        }

    private static async void OnMessageHandler(object sender, MessageEventArgs e)
    {
      string text = $"{DateTime.Now.ToLongTimeString()}/{e.Message.Chat.Id} {e.Message.Chat.FirstName}: {e.Message.Text}";
      Console.WriteLine($"TypeMessage: {e.Message.Type.ToString()}\n{text}");

      if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Document)
      {
        await client.SendTextMessageAsync(
          e.Message.Chat.Id,
          $"Файл {e.Message.Document.FileName} {e.Message.Document.FileSize} байт был загружен.");
        DownLoad(e.Message.Document.FileId, e.Message.Document.FileName);
      }
      
        var msg = e.Message;
        string path = @"..\netcoreapp3.1\" + msg.Text;
        FileInfo fileInfo = new FileInfo(path);
        if (fileInfo.Exists)
        {
          Console.WriteLine(path);
          string newPath = @"..\загрузка\" + msg.Text;
          FileInfo fileInfoNew = new FileInfo(newPath);
        if (fileInfoNew.Exists)
          fileInfo.Replace(path, newPath); // ну почему так не перезаписывает файл???
        else
          fileInfo.CopyTo(newPath);
          await client.SendTextMessageAsync(
            msg.Chat.Id,
            "Файл сохранен в " + fileInfoNew.Directory);
        }

      if (msg != null)
        {
          switch (msg.Text)
          {
            case "Привет":
              {
                await client.SendTextMessageAsync(
                  msg.Chat.Id, msg.Text,
                  replyToMessageId: msg.MessageId,
                  replyMarkup: GetButtons());
                var sticHello = await client.SendStickerAsync(
                chatId: msg.Chat.Id,
                sticker: "https://cdn.tlgrm.app/stickers/ccd/a8d/ccda8d5d-d492-4393-8bb7-e33f77c24907/256/1.webp");
                break;
              }

            case "Кнопки":
              await client.SendTextMessageAsync(
                msg.Chat.Id,
                "Выберите команду: ",
                replyMarkup: GetButtons());
              break;

            case "Стикер":
              await client.SendTextMessageAsync(
                msg.Chat.Id, "Вот тебе стикер!",
                replyToMessageId: msg.MessageId,
                replyMarkup: GetButtons());
              var sticStiker = await client.SendStickerAsync(
                chatId: msg.Chat.Id,
                sticker: "https://cdn.tlgrm.app/stickers/fff/693/fff693c2-fdd4-39ad-82ee-b9ad8f587af8/192/1.webp",
                replyMarkup: GetButtons());
              break;

            case "Скинь картинку)":
              var pic = await client.SendPhotoAsync(
                chatId: msg.Chat.Id,
                photo: "https://avatars.mds.yandex.net/get-znatoki/1506847/2a00000173b0befeeed7a11684b36652497a/w1200",
                replyMarkup: GetButtons());
              break;

            case "Работа с файлами":
              await client.SendTextMessageAsync(
                msg.Chat.Id,
                "Выберите команду для работы с файлами: ",
                replyMarkup: GetButtonsFile());
              break;

            case "Просмотреть список загруженных файлов":
            string dirName = "..\\netcoreapp3.1";
            if (Directory.Exists(dirName))
            {
              string[] files = Directory.GetFiles(dirName);
              int i = 1;
              await client.SendTextMessageAsync(
                msg.Chat.Id,
                "Файлы:");
              foreach (string s in files)
              {
                await client.SendTextMessageAsync(
                  msg.Chat.Id,
                  i + ") " + Path.GetFileName(s));
                i++;
              }
            }
              break;

              case "Скачать выбранный файл":
              await client.SendTextMessageAsync(
                msg.Chat.Id,
                "Введите имя файла, который хотите скачать: ");
              break;

              default:
              await client.SendTextMessageAsync(
                msg.Chat.Id,
                "Ааа-а-а, выберите команду: ",
                replyMarkup: GetButtons());
              break;
          }

        if (e.Message.Text == null) return;
      }
    }

    private static IReplyMarkup GetButtons()
    {
      return new ReplyKeyboardMarkup
      {
        Keyboard = new List<List<KeyboardButton>>
        {
          new List<KeyboardButton>{new KeyboardButton { Text = "Привет"}, new KeyboardButton { Text = "Скинь картинку)"} },
          new List<KeyboardButton>{new KeyboardButton { Text = "Пока"}, new KeyboardButton { Text = "Стикер"} },
          new List<KeyboardButton>{new KeyboardButton { Text = "Работа с файлами"}, new KeyboardButton { Text = "/start"} }
        }
      };
    }

    private static IReplyMarkup GetButtonsFile()
    {
      return new ReplyKeyboardMarkup
      {
        Keyboard = new List<List<KeyboardButton>>
        {
          new List<KeyboardButton>{new KeyboardButton { Text = "Просмотреть список загруженных файлов" }, new KeyboardButton { Text = "Скачать выбранный файл" } }
        }
      };
    }

    static async void DownLoad(string fileId, string path)
    {
      var file = await client.GetFileAsync(fileId);
      FileStream fs = new FileStream(path, FileMode.Create);
      await client.DownloadFileAsync(file.FilePath, fs); // как сохранить в нужную мне папку ??
      //new WebClient().DownloadFile(file.FilePath, "..\\загрузка\\" + path);

      fs.Close();
      fs.Dispose();
    }
  }
}
