using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    class Program
    {
        static void Main(string[] args)
        {
      Console.Write("Введите максимальное целое число диапазона: ");
      int max = int.Parse(Console.ReadLine());

      Random rnd = new Random();

      int value = rnd.Next(0, max);

      do
      {
        Console.Write("Введите загаданное программой случайное число: ");
        string inputString = Console.ReadLine();
        if (inputString == " ")
        {
          Console.Write("Устал бедолага..\n");
          break;
        }
        else
        {
          int number = Convert.ToInt32(inputString);
          if (number > value)
          {
            Console.Write("Загаданное число МЕНЬШЕ введеного.\n");
          }
          if (number < value)
          {
            Console.Write("Загаданное число БОЛЬШЕ введеного.\n");
          }
          if (number == value)
          {
            Console.Write("Ура! Вы угадали.\n");
            break;
          }
        }
      } while (true);
        
      Console.Write("Было загадано число: ");
      Console.WriteLine(value);
      Console.ReadKey();
    }
  }
}
