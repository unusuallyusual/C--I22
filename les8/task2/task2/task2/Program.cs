using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        static void Main()
        {
          Dictionary<string, string> telBook = new Dictionary<string, string>();

          addTel(telBook);

          foreach(KeyValuePair<string, string> tel in telBook)
          Console.WriteLine($"{tel} ");
          Console.WriteLine("\n");

          readKeyData(telBook);
          Console.ReadKey();
    }
    /// <summary>
    /// Ввод данных в программу
    /// </summary>
    static Dictionary<string, string> addTel(Dictionary<string, string> telBook)
    {
      Console.Write("   Введите данные в программу\n");
      Console.Write("Введите номер телефона:\n");
      string telephone = Console.ReadLine();
      if (telephone != "")
      {
        Console.Write("Введите имя:\n");
        string name = Console.ReadLine();
        telBook.Add(telephone, name);
        addTel(telBook);
      }
      return telBook;
    }

    /// <summary>
    /// Чтение данных по ключу
    /// </summary>
    static void readKeyData(Dictionary<string, string> telBook)
    {
      Console.Write("Введите номер телефона:\n");
      string key = Console.ReadLine();
      if (key != "")
      {
        if (telBook.TryGetValue(key, out string value))
          Console.WriteLine("ФИО владельца: " + value);
        else
          Console.WriteLine("...владельца по такому номеру телефона не зарегистрировано.");

        readKeyData(telBook);
      }
    }
  }
}
