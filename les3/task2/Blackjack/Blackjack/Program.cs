using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
      Console.WriteLine("Приветствую! Укажите сколько карт у вас на руках:");
      int cards = Convert.ToUInt16(Console.ReadLine());
      int sum = 0;
      for (int i = 0; i < cards; i++)
      {
        if (i == 0)
        {
          Console.WriteLine("Введите номинал первой карты:");
        }
        else if (i == cards - 1)
        {
          Console.WriteLine("Введите номинал последней карты:");
        }
        else
        {
          Console.WriteLine("Введите номинал следующей карты:");
        }
        string card = Console.ReadLine();
        switch(card)
        {
          case "2":
            sum += Convert.ToInt32(card); break;
          case "3":
            sum += Convert.ToInt32(card); break;
          case "4":
            sum += Convert.ToInt32(card); break;
          case "5":
            sum += Convert.ToInt32(card); break;
          case "6":
            sum += Convert.ToInt32(card); break;
          case "7":
            sum += Convert.ToInt32(card); break;
          case "8":
            sum += Convert.ToInt32(card); break;
          case "9":
            sum += Convert.ToInt32(card); break;
          case "10":
            sum += Convert.ToInt32(card); break;
          case "J":
            sum += 10; break;
          case "Q":
            sum += 10; break;
          case "K":
            sum += 10; break;
          case "T":
            sum += 10; break;
          default:
            Console.WriteLine("Такой карты не существует!");
            break;
        }
      }
      Console.WriteLine("Количество карт: " + cards);
      Console.WriteLine("Сумма всех карт равна: " + sum);
      Console.ReadKey();
    }
    }
}
