using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2_Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
      string fullName = "Иванов Иван Иваныч";
      byte age = 44;
      string email = "@Ivanovich";
      float scoresProgramming = 88.5f;
      float scoresMath = 93.7f;
      float scoresPhysics = 91f;

      var sum = scoresProgramming + scoresMath + scoresPhysics;
      var averageScore = sum / 3;

      Console.WriteLine($"Ф.И.О. : {fullName} \nВозраст : {age} \nEmail : {email} \nБаллы по программированию : {scoresProgramming} \nБаллы по математике : {scoresMath} \nБаллы по физике : {scoresPhysics}");
      Console.WriteLine("\nНажми Enter, чтобы вывести сумму баллов..");
      Console.ReadKey();
      Console.WriteLine("Сумма баллов = " + sum);
      Console.ReadKey();
      Console.WriteLine("\nНажми Enter, чтобы вывести средний балл..");
      Console.WriteLine("Средний балл = " + averageScore);
      Console.ReadKey();
    }
    }
}
