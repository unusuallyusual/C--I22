using System;
using System.IO;
using System.Text;

namespace DirectoryEmployees
{
  class Program
  {
    static void Main()
    {
      Console.Write("Для определения дальнейшего действия введите:\n");
      Console.Write("1 — вывести данные на экран;\n");
      Console.Write("2 — заполнить данные и добавить новую запись в конец файла.\n");

      int x = int.Parse(Console.ReadLine());
      if (x == 2)
      {
        string[] lines = File.ReadAllLines(@"C:\Users\med11\Documents\skillbox\C#\practice\les6\data.txt");
        string strDataEmployee = (lines.Length + 1) + "#" + DateTime.Now.ToLocalTime() + "#" + InputDataEmployee();
        Console.WriteLine(strDataEmployee);
       // File.AppendAllLines(@"C:\Users\med11\Documents\skillbox\C#\practice\les6\data.txt", strDataEmployee);
        Main();
      }
      if (x == 1)
      {
        if (File.Exists(@"C:\Users\med11\Documents\skillbox\C#\practice\les6\data.txt"))
        {
          ReadFile();
          Main();
        }
        else
        {
          Console.WriteLine("Файл отсутствует\n\n");
        }
        Main();
      }
      Console.ReadKey();
    }

    static void ReadFile()
    {
      string[] lines = File.ReadAllLines(@"C:\Users\med11\Documents\skillbox\C#\practice\les6\data.txt");
      foreach (var line in lines)
      {
        Console.WriteLine($">>{line.Replace('#', ' ')}<<");
        Console.Write('\n');
      }
    }

    static StringBuilder InputDataEmployee()
    {
      StringBuilder dataEmployee = new StringBuilder(100);

      Console.WriteLine("Введите Ф.И.О. :");
      dataEmployee.Append(Console.ReadLine() + "#");
      Console.WriteLine("Введите ваш возраст :");
      dataEmployee.Append(Console.ReadLine() + "#");
      Console.WriteLine("Введите ваш рост :");
      dataEmployee.Append(Console.ReadLine() + "#");
      Console.WriteLine("Введите вашу дату рождения :");
      dataEmployee.Append(Console.ReadLine() + "#");
      Console.WriteLine("Введите ваше место рождения :");
      dataEmployee.Append(Console.ReadLine());
      return dataEmployee;
    }
  }
}
