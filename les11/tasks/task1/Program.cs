using System;
using System.IO;

namespace tasks
{
  class Program
  {
    static void Main()
    {
      Console.Write("<<<\nКто вы?\nНажми   \n C - консультант, M - менеджер :\n>>>\n");
      char ch = Convert.ToChar(Console.ReadLine());
      StartWork(ch);
    }
    static void StartWork(char ch)
    {
      Client client = new Client();
      string path;

      Console.Write("<<<\nДля определения дальнейшего действия введите:\n");
      Console.Write("   R — вывести данные из файла на экран;\n");
      Console.Write("   E — редактировать данные в файле;\n");
      if (ch == 'm')
      {
        client = new Manager();
        Console.Write("   C — создать файл с данными нового клиента;\n");
      }
      else
      if (ch == 'c')
        client = new Сonsultant();
      Console.Write("   X — выйти из режима редактора.\n>>> \n\n");

      char cha = Convert.ToChar(Console.ReadLine());

      switch (Char.ToLower(cha))
      {
        case 'r':
          path = FileName();
          if (File.Exists(path))
          {
            if (client.GetType() == typeof(Сonsultant))
            {
              client = (client as Сonsultant).ReadFile(path);
              Console.WriteLine((client as Сonsultant).PrintClientInfo());
            }
            else
              if (client.GetType() == typeof(Manager))
            {
              client = (client as Manager).ReadFile(path);
              Console.WriteLine((client as Manager).PrintClientInfo());
            }
            StartWork(ch);
          }
          else
            Console.WriteLine("Файл отсутствует\n\n");
          StartWork(ch);
          break;

        case 'e':
          path = FileName();
          if (File.Exists(path))
          {
            if (client.GetType() == typeof(Сonsultant))
            {
              client = (client as Сonsultant).ReadFile(path);
              (client as Сonsultant).EditDataClient(path);
            }
            else
              if (client.GetType() == typeof(Manager))
            {
              client = (client as Manager).ReadFile(path);
              (client as Manager).EditDataClient(path);
            }
          }
          else
            Console.WriteLine("Файл отсутствует\n\n");
          StartWork(ch);
          break;

        case 'x':
          Main();
          break;

        case 'c':
          if (ch == 'm')
          {
            Console.WriteLine("Создание файла для нового клиента..\n");
            string newPath = FileName();
            if (!File.Exists(newPath))
              using (StreamWriter sw = File.CreateText(newPath))
              {
                sw.Write(Convert.ToString(DateTime.Now) + "#");
                Console.WriteLine("Введите фамилию клиента :");
                sw.Write(Console.ReadLine() + "#");
                Console.WriteLine("Введите имя клиента :");
                sw.Write(Console.ReadLine() + "#");
                Console.WriteLine("Введите отчество клиента :");
                sw.Write(Console.ReadLine() + "#");
                Console.WriteLine("Введите номер телефона клиента :");
                sw.Write(Console.ReadLine() + "#");
                Console.WriteLine("Введите паспортные данные клиента :");
                sw.Write(Console.ReadLine() + "#");
                Console.Write("\n   Данные были записаны.\n");
              }
            else
              Console.Write("Файл с таким именем существует в реестре.\n");
          }
          StartWork(ch);
          break;
      }
    }

    /// <summary>
    /// Ввод имени файла
    /// </summary>
    static string FileName()
    {
      Console.WriteLine("Введите имя файла: ");
      string prepath = Console.ReadLine();
      string path = prepath + @".txt";
      return path;
    }
  }
}
