using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static void Main()
        {
          List<int> list = new List<int>();
          PrintList(RandomList(list, 100, 100));
          Console.Write("\n");
          Console.ReadKey();

          PrintList(DeleteElementList(list, 25, 50));
          Console.ReadKey();
        }
    /// <summary>
    /// Выводит коллекцию чисел на экран
    /// </summary>
    static void PrintList(List<int> list)
    {
      for (int i = 0; i < list.Count; i++)
      {
        Console.Write($"{list[i]} ");
        if ((i + 1) % 10 == 0 || (i + 1) == list.Count)
          Console.Write("\n");
      }
      Console.Write("\n");
      Console.Write("Количесвто чисел в листе = " + list.Count);
      Console.Write("\n");
    }

    /// <summary>
    /// Заполняет коллекцию рандомными числами
    /// </summary>
    static List<int> RandomList(List<int> list, int j, int maxl)
    {
      Random rnd = new Random();
      for (int i = 0; i < j; i++)
      {
        list.Add(rnd.Next(maxl));
      }
      return list;
    }

    /// <summary>
    /// Удаляет из листа числа, которые больше входят в диапазон 
    /// </summary>
    static List<int> DeleteElementList(List<int> list, int minl, int maxl)
    {
      for (int i = 0; i < list.Count; i++)
      {
        if (list[i] > minl && list[i] < maxl)
          list.RemoveAt(i);
      }
      return list;
    }
  }
}
