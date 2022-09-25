using System;
using System.IO;

namespace tasks
{
  class Program
  {
    static void Main()
    {
      string path = @"C:\SKILLBOX\C#\pract\C--I22\les11\data.txt";

      Console.Write("<<<\nКто вы?\nНажми   \n C - консультант, M - менеджер :\n>>>\n");
      char ch = Convert.ToChar(Console.ReadLine());
      StartWork(path, ch);
    }
    static void StartWork(string path, char ch)
    {
      Client client = new Client();
      Console.Write("<<<\nДля определения дальнейшего действия введите:\n");
      Console.Write("   R — вывести данные из файла на экран;\n");
      Console.Write("   E — редактировать данные в файле;\n");
      Console.Write("   X — выйти из режима редактора.\n>>> \n\n");

      char cha = Convert.ToChar(Console.ReadLine());

      if(ch == 'm')
        client = new Manager();
      else
      if(ch == 'c')
        client = new Сonsultant();

      switch (Char.ToLower(cha))
      {
        case 'r':
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
            StartWork(path, ch);
          }
          else
            Console.WriteLine("Файл отсутствует\n\n");
          StartWork(path, ch);
          break;

        case 'e':
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
          StartWork(path, ch);
          break;

        case 'x':
          Main();
          break;
      }
    }
  }
}
