using System;
using System.IO;

namespace task1
{
  class Program
  {
    static void Main()
    {
      char ch;
      Manager clientt = new Manager("Бондарчук", "Федор", "Сергеевич", "+799911111111", "МУ777");
      Сonsultant client = new Сonsultant("Бондарчук", "Федор", "Сергеевич", "+7999222222", "МУ777");
      string path = @"C:\SKILLBOX\C#\pract\C--I22\les11\data.txt";

      Console.Write("<<<\nДля определения дальнейшего действия введите:\n");
      Console.Write("   R — вывести данные из файла на экран;\n");
      Console.Write("   M — вывести данные из файла на экран;\n");
      Console.Write("   E — редактировать данные в файле.\n>>> \n\n");

      ch = Convert.ToChar(Console.ReadLine());

      switch (Char.ToLower(ch))
      {
        case 'r':
          if (File.Exists(path))
          {
            client = client.ReadFile(path);
            Console.WriteLine(client.PrintClientInfo());
            Main();
          }
          else
          {
            Console.WriteLine("Файл отсутствует\n\n");
          }
          Main();
          break;

        case 'e':
          client = client.ReadFile(path);
          Console.WriteLine(client.PrintClientInfo());
          Console.WriteLine("Изменить данные номера телефона клиента ?\n   Нажми Y/N :");
          ch = Convert.ToChar(Console.ReadLine());
          if (Char.ToLower(ch) == 'y')
          {
            File.WriteAllText(path, string.Empty);
            Console.WriteLine("Введите номер телефона клиента :");
            client.PhoneNumber = Console.ReadLine();
            Console.Write("   Данные были отредактированы...\n");
            client.RecToFile(path);
          }
          else
          if (Char.ToLower(ch) == 'n')
            Console.Write("   Данные НЕ были отредактированы...\n");

          Console.WriteLine(client.PrintClientInfo());
          Main();
          break;

        case 'm':
          Console.WriteLine(clientt.PrintClientInfo());
          clientt = clientt.ReadFile(path);
          Console.WriteLine(clientt.PrintClientInfo());
          clientt.Patronymic = "Vasya";
          Console.WriteLine(clientt.Patronymic);
          Console.WriteLine(clientt.PrintClientInfo());
          Main();
          break;

      }
    }
  }
}
