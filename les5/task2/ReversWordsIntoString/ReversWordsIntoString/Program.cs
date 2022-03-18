using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversWordsIntoString
{
    class Program
    {
    private string[] subs = { };

    static string[] SplitStringIntoWords(string myText)
    {
      string[] subs = myText.Split(' ');
      return subs;
    }
    static void ReversWords(string[] subs)
    {
      string newText = string.Empty;
     for (int i = subs.Length; i > 0; i--)
      {
        newText += subs[i-1] + " ";
      }
      Console.WriteLine(newText);
    }

    static void Main(string[] args)
        {
      Console.WriteLine("Введите свой текст:");
      string myText = Console.ReadLine();
      ReversWords(SplitStringIntoWords(myText));
      Console.ReadKey();
    }
    }
}
