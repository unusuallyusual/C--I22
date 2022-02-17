using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberCheck
{
    class Program
    {
        static void Main(string[] args)
        {
      Console.WriteLine("Введите любое целое число: ");
      int number = Convert.ToUInt16(Console.ReadLine());
      if (number == 0)
      {
        Console.WriteLine("Неа, не подходит такое!");
      }
      else if (number == 1 || number == 2)
        {
        Console.WriteLine("Это точно простое число:)");
      }
      else
      {
        int divider = 2;
        bool flag = false;
        while (divider < number)
        {
          flag = (number % divider == 0) ? true : false;
          divider++;
          if (flag == true)
          {
            Console.WriteLine("Число " + number + " НЕ является простым!");
            break;
          }
        }
        if (flag == false)
        {
          Console.WriteLine("Число " + number + " является простым.");
        }
      }
      Console.ReadKey();
    }
    }
}
