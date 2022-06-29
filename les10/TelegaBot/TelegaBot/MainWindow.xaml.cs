using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;
using System.IO;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace TelegaBot
{
  public partial class MainWindow : Window
    {

    private static string token { get; set; } = "5337455860:AAEgRzZG3VZiQ8tCGJyAsp7ii9EyUXkgqv8";
    TelegramMessageClient client;

    public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(KeyPressedDown);
            client = new TelegramMessageClient(this, token);
            logList.ItemsSource = client.BotMessage;
        }
    private void Btn_Click(object sender, RoutedEventArgs e)
    {
      if (textBlock.Text != "")
      {
        client.SendMessage(txtMsgSend.Text, textBlock.Text);
        txtMsgSend.Text = "";
      }
      //  else
      //  {
      //    db.Add(new MessageLog()
      //    {
      //      Msg = txtMsgSend.Text,
      //      FirstName = $"Автор",
      //      Id = ++c,
      //      Time = DateTime.Now
      //    });

      //    this.Title = $"{windoTitle} + {db.Count} новых сообщений";
      //  }
    }

    private void ButtonSave(object sender, RoutedEventArgs e)
    {
      var json = JsonConvert.SerializeObject(client.BotMessage);

      SaveFileDialog dialog = new SaveFileDialog();

      if (dialog.ShowDialog() == true)
      {
        File.WriteAllText($@"{dialog.FileName}", json);
      }
    }

    private void ButtonLoad(object sender, RoutedEventArgs e)
    {
      OpenFileDialog dialog = new OpenFileDialog();

      if (dialog.ShowDialog() == true)
      {
        string foo = File.ReadAllText(dialog.FileName);
        client.BotMessage.Clear();

        var json = JsonConvert.DeserializeObject<List<MessageLog>>(foo);

        foreach (dynamic item in json)
        {
          client.BotMessage.Add(new MessageLog(item.time, item.id, item.message, item.firstName));
        }
      }
    }


    //private static async void OnMessageHandler(object sender, MessageEventArgs e)
    //{
    //  string text = $"{DateTime.Now.ToLongTimeString()}/{e.Message.Chat.Id} {e.Message.Chat.FirstName}: {e.Message.Text}";
    //  Console.WriteLine($"TypeMessage: {e.Message.Type.ToString()}\n{text}");

    //  var msg = e.Message;
    //  string path = @"..\netcoreapp3.1\" + msg.Text;
    //  FileInfo fileInfo = new FileInfo(path);
    //  if (fileInfo.Exists)
    //  {
    //    using (var stream = File.OpenRead(path))
    //    {
    //      InputOnlineFile iof = new InputOnlineFile(stream);
    //      iof.FileName = msg.Text;
    //      await client.SendDocumentAsync(e.Message.Chat.Id, iof);
    //    }
    //  }

    //  if (msg != null)
    //  {
    //    switch (msg.Text)
    //    {
    //      case "Привет":
    //        {
    //          await client.SendTextMessageAsync(
    //            msg.Chat.Id, msg.Text,
    //            replyToMessageId: msg.MessageId);
    //          var sticHello = await client.SendStickerAsync(
    //          chatId: msg.Chat.Id,
    //          sticker: "https://cdn.tlgrm.app/stickers/ccd/a8d/ccda8d5d-d492-4393-8bb7-e33f77c24907/256/1.webp");
    //          break;
    //        }



    //      case "Просмотреть список загруженных файлов":
    //        string dirName = "..\\netcoreapp3.1";
    //        if (Directory.Exists(dirName))
    //        {
    //          string[] files = Directory.GetFiles(dirName);
    //          int i = 1;
    //          await client.SendTextMessageAsync(
    //            msg.Chat.Id,
    //            "Файлы:");
    //          foreach (string s in files)
    //          {
    //            await client.SendTextMessageAsync(
    //              msg.Chat.Id,
    //              i + ") " + Path.GetFileName(s));
    //            i++;
    //          }
    //        }
    //        break;
    //    }

    //    if (e.Message.Text == null) return;
    //  }
    //}


    private void KeyPressedDown(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Enter)
      {
        if (textBlock.Text != "")
        {
          client.SendMessage(txtMsgSend.Text, textBlock.Text);
          txtMsgSend.Text = "";
        }
        else
        {
          MessageBox.Show(
              "Некому отвечать..",
              this.Title,
              MessageBoxButton.OK,
              MessageBoxImage.Information
              );
        }
      }
    }
  }
}

