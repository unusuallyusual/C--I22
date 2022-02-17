using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
      Console.WriteLine("Введите любое целое число: ");
      int number = Convert.ToUInt16(Console.ReadLine());
      string result = (number % 2 == 0) ? " четное" : " нечетное";
      Console.WriteLine("Число " + number + result);
      Console.ReadKey();
    }
    }
}
