using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace task3
{
    class Program
    {
        static void Main()
        {
          HashSet<int> set1 = new HashSet<int>();
          Random rnd = new Random();

          for(int i = 0; i < 5; i++)
            set1.Add(rnd.Next(10));
          Console.WriteLine("\nКоличество чисел в сгенерированной коллекции = " + set1.Count);

          prog(set1);

          readSet(set1);

          Console.ReadKey();
          Main();
        }

    ///<summary>
    ///Рабочий цикл
    /// </summary>
    static void prog(HashSet<int> set)
    {
      Console.Write("Введите число:\n");
      string str = Console.ReadLine();
      while(str != "")
      {
        int numb = Convert.ToInt32(str);
        addNumb(set, numb);
        prog(set);
        break;
      }
    }
    ///<summary>
    ///Добавление числа в коллекцию
    /// </summary>
    static HashSet<int> addNumb(HashSet<int> set, int numb)
    {
      int i = 0;
      foreach (var e in set)
      {
        if (numb == e)
          i++;
      }
      if (i > 0)
        Console.WriteLine("Число уже присутствует в коллекции.\n");
      else
      {
        set.Add(numb);
        Console.WriteLine("Число успешно сохранено.\n");
      }

      return set;
    }

    ///<summary>
    ///Чтение коллекции
    /// </summary>
    static void readSet(HashSet<int> set)
  {
    foreach (var e in set)
      Console.Write($"{e} ");
      Console.Write("\n");
    }
    }
}
