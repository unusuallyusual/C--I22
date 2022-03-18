using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplittingStringIntoWords
{
  class Program
    {
    private string[] subs = { };

    static string[] SplitStringIntoWords(string myText)
    {
      char[] separators = new char[] { ' ', '.' };

      string[] subs = myText.Split(separators, StringSplitOptions.RemoveEmptyEntries);
      return subs;
    }
    static void PrintWordsFromArr(string[] subs)
    {
      foreach (var sub in subs)
      {
        Console.WriteLine(sub);
      }
    }
  static void Main(string[] args)
        {
      Console.WriteLine("Введите свой текст:");
      string myText = Console.ReadLine();
      //
      string[] subs = SplitStringIntoWords(myText);
      PrintWordsFromArr(subs);
      //or
      //PrintWordsFromArr(SplitStringIntoWords(myText));
      Console.ReadKey();
    }
    }
}
