using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestElement
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.Write("Введите длину последовательности: ");
      int l = int.Parse(Console.ReadLine());

      int[] sub = new int[l];
      int min = int.MaxValue;

      for (int i = 0; i < l; i++)
      {
        Console.Write("Введите элемент последовательности: ");
        sub[i] = int.Parse(Console.ReadLine());
        if (sub[i] < min) min = sub[i];
      }
      Console.Write("Введенная послдеовательность: \n");
      for (int i = 0; i < l; i++)
      {
        Console.Write($"{sub[i]} ");
      }
      Console.Write("\nНаименьшее число из последовательности: " + min);
      Console.ReadKey();
    }
  }
}
