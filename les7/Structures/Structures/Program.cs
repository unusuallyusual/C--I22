using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
  class Program
  {
    static void Main()
    {
      int nStr;
      int p;
      DateTime minD = DateTime.MinValue;
      DateTime maxD = DateTime.MaxValue;
      Console.Write("<<<\nДля определения дальнейшего действия введите:\n");
      Console.Write("   R — вывести все данные из файла на экран;\n");
      Console.Write("   I — вывести данные ID на экран;\n");
      Console.Write("   T — вывести данные в выбранном диапазоне дат дней рождений;\n");
      Console.Write("   > — вывести данные по возрастанию дат дней рождений;\n");
      Console.Write("   < — вывести данные по убыванию дат дней рождений;\n");
      Console.Write("   W — заполнить данные и добавить новую запись в конец файла;\n");
      Console.Write("   F — найти номер строки по номеру ID;\n");
      Console.Write("   D — удалить данные из файла.\n");
      Console.Write("   E — редактировать данные в файле.\n>>> \n\n");

      char ch;
      ch = Convert.ToChar(Console.ReadLine());

      switch (Char.ToLower(ch))
      {
        case 'r':
          if (File.Exists(@"D:\С#\data.txt"))
          {
            ReadFile();
            Main();
          }
          else
          {
            Console.WriteLine("Файл отсутствует\n\n");
          }
          Main();
          break;

        case 'i':
          if (File.Exists(@"D:\С#\data.txt"))
          {
            Console.Write("   Введите номер ID, который хотите считать: \n");
            int nId = Convert.ToInt32(Console.ReadLine());
            ReadIdFile(nId);
            Main();
          }
          else
          {
            Console.WriteLine("Заданный ID отсутствует\n\n");
          }
          Main();
          break;

        case 'w':
          Console.WriteLine("Нажмите Enter, чтобы ввести данные о новом сотруднике...");
          Console.ReadKey();
          WriteToFile();
          Main();
          break;

        case 'd':
          Console.Write("   Введите номер ID, который хотите удалить: \n");
          nStr = Convert.ToInt32(Console.ReadLine());
          int[] numStr = FindNumStr(nStr);
          p = 0;
          if (numStr[0] != -1)
          {
            for (int i = 0; i < numStr.Length; i++)
            {
              DeleteData(numStr[i] - p);
              p++;
            }
            Console.Write("   Данные удалены...\n");
          }
          break;

        case 'f':
          Console.Write("   Введите номер ID, который хотите найти: \n");
          int numId = Convert.ToInt32(Console.ReadLine());
          FindNumStr(numId);
          break;

        case 'e':
          Console.Write("   Введите номер строки, которую хотите редактировать: \n");
          nStr = Convert.ToInt32(Console.ReadLine());
          Repository empl = LoadRepository();
          if (nStr > empl.Count)
          {
            Console.WriteLine($"В файле нет строки с таким номером!\n");
          }
          else
          {
            File.WriteAllText(@"D:\С#\data.txt", string.Empty);
            for (int i = 0; i < empl.Count; i++)
            {
              if (i == nStr - 1)
                empl.employees[i] = empl.EditDataEmployee(nStr);
              File.AppendAllText(@"D:\С#\data.txt", empl.DataToString(i + 1) + "\n");
            }
          }
          empl.PrintToConsole();
          Main();
          break;

        case 't':
          Console.WriteLine("   Данные о сотрудниках дни рождения которых, попадают в заданный диапазон.");
          Console.WriteLine("Задать дату начала диапазана ?\n   Нажми Y/N :");
          ch = Convert.ToChar(Console.ReadLine());
          if (Char.ToLower(ch) == 'y')
          {
            Console.Write("   Введите дату начала диапазона: \n");
            minD = Convert.ToDateTime(Console.ReadLine());
          }
          Console.WriteLine("Задать дату конца диапазана ?\n   Нажми Y/N :");
          ch = Convert.ToChar(Console.ReadLine());
          if (Char.ToLower(ch) == 'y')
          {
            Console.Write("   Введите дату конца диапазона: \n");
            maxD = Convert.ToDateTime(Console.ReadLine());
          }
          FindDateRange(minD, maxD);
          break;

        case '>':
          LoadRepository().SortAscendingBirthdate();
          Main();
          break;

        case '<':
          LoadRepository().SortDescendingBirthdate();
          Main();
          break;
      }
    }

    /// <summary>
    /// Загрузить данные из файла
    /// </summary>
    static Repository LoadRepository()
    {
      string path = @"D:\С#\data.txt";
      Repository emp = new Repository(path);
      emp.Load();
      return emp;
    }

    /// <summary>
    /// Прочитать данные из файла
    /// </summary>
    static void ReadFile()
    {
      Repository emp = LoadRepository();
      emp.PrintToConsole();
      Console.WriteLine("Кол-во записей в файле: " + emp.Count);
      Console.Write('\n');
    }

    /// <summary>
    /// Прочитать данные из файла по номеру ID
    /// </summary>
    static void ReadIdFile(int nId)
    {
      Repository emp = LoadRepository();
      int[] nStr = FindNumStr(nId);
      for (int i = 0; i < nStr.Length - 1; i++)
      {
        Console.WriteLine(emp.DataToString(nStr[i]));
      }
    }

    /// <summary>
    /// Добавить данные в файл
    /// </summary>
    static void WriteToFile()
    {
      char ch;
      Repository emp = LoadRepository();
      emp.Add(emp.InputDataEmployee());
      Console.WriteLine("Сохранить запись в файл ?\n   Нажми Y/N :");
      ch = Convert.ToChar(Console.ReadLine());
      if (Char.ToLower(ch) == 'y')
        File.AppendAllText(@"D:\С#\data.txt", emp.DataToString(emp.Count) + "\n");
      Console.Write('\n');
    }

    /// <summary>
    /// Удалить данные из файла
    /// </summary>
    static void DeleteData(int numStr)
    {
      Repository emp = LoadRepository();
      Employee[] employees = new Employee[emp.Count];

      File.WriteAllText(@"D:\С#\data.txt", string.Empty);

      if (numStr == emp.Count)
      {
        for (int i = 0; i < emp.Count - 1; i++)
        {
          for (int j = 0; j < emp.Count; j++)
          {
            employees[j] = emp.employees[i];
          }
          emp.SaveClick(i);
        }
      }
      else
      {
        for (int i = 0; i < emp.Count; i++)
        {
          for (int j = 0; j < emp.Count; j++)
          {
            if (i == numStr - 1)
              i++;
            employees[j] = emp.employees[i];
          }
          emp.SaveClick(i);
        }
      }
    }

    /// <summary>
    /// Найти данные в файла
    /// </summary>
    static int[] FindNumStr(int numId)
    {
      Repository emp = LoadRepository();
      StringBuilder strNum = new StringBuilder(emp.Count);

      for (int i = 0; i < emp.Count; i++)
      {
        if (emp.employees[i].id == numId)
        {
          strNum.Append(i + 1 + "#");
        }
      }
      string[] subs = Convert.ToString(strNum).Split('#');
      int[] SUBS = { };
      if (subs[0] != string.Empty)
      {
        SUBS = new int[subs.Length];
        int k = 0;
        foreach (var sub in subs)
        {
          if (sub != string.Empty)
          {
            SUBS[k] = Convert.ToInt32(sub);
            Console.WriteLine($"Искомые данные находятся в строке: {SUBS[k]}");
            k++;
          }
        }
      }
      else
      {
        SUBS = new int[1] { -1 };
        Console.WriteLine($"Искомые данные НЕ найдены!");
      }
      return SUBS;
    }

    /// <summary>
    /// Вывести данные о сотрудниках дни рождения которых, попадают в заданный диапазон
    /// </summary>
    static void FindDateRange(DateTime minD, DateTime maxD)
    {
      Repository emp = LoadRepository();
      for (int i = 0; i < emp.Count; i++)
      {
        if (emp.employees[i].birthdate >= minD && emp.employees[i].birthdate <= maxD)
          Console.WriteLine(emp.DataToString(i+1));
      }
      Console.Write("\n");
    }
  }
}
