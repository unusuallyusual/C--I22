using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
  struct Repository
  {
    public Employee[] employees;

    private string path;

    int index;

    public Repository(string Path)
    {
      this.path = Path;
      this.index = 0;
      this.employees = new Employee[2];
    }

    /// <summary>
    /// Изменение размера места хранения данных
    /// </summary>
    private void Resize(bool Flag)
    {
      if (Flag)
      {
        Array.Resize(ref this.employees, this.employees.Length * 2);
      }
    }

    /// <summary>
    /// Добавдение данных
    /// </summary>
    public void Add(Employee ConcreteEmployee)
    {
      this.Resize(index >= this.employees.Length);
      this.employees[index] = ConcreteEmployee;
      this.index++;
    }

    /// <summary>
    /// Загрузка данных
    /// </summary>
    public void Load()
    {
      using (StreamReader sr = new StreamReader(this.path))
      {
        while (!sr.EndOfStream)
        {
          string[] args = sr.ReadLine().Split('#');

          Add(new Employee(Convert.ToInt32(args[0]), Convert.ToDateTime(args[1]), args[2], Convert.ToInt32(args[3]), Convert.ToInt32(args[4]), Convert.ToDateTime(args[5]), args[6]));
        }
      }
    }

    /// <summary>
    /// Вывод всех данных
    /// </summary>
    public void PrintToConsole()
    {
      for (int i = 0; i < index; i++)
      {
        Console.WriteLine(this.employees[i].Print());
      }
    }

    /// <summary>
    /// Вывод данных по номеру строки
    /// </summary>
    public string DataToString(int numStr)
    {
      return this.employees[numStr - 1].Print();
    }

    /// <summary>
    /// Количество сотрудников
    /// </summary>
    public int Count { get { return this.index; } }

    /// <summary>
    /// Заполнение данных нового сотрудника
    /// </summary>
    public Employee InputDataEmployee()
    {

      Employee Structur = new Employee();

      Structur.id = this.employees[Count-1].id + 1;

      Structur.dateTime = DateTime.Now.ToLocalTime();

      Console.WriteLine("Введите Ф.И.О. :");
      Structur.name = Console.ReadLine();

      Console.WriteLine("Введите возраст сотрудника :");
      Structur.Old = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine("Введите рост сотрудника :");
      Structur.Height = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine("Введите дату рождения сотрудника :");
      Structur.birthdate = Convert.ToDateTime(Console.ReadLine());

      Console.WriteLine("Введите место рождения сотрудника :");
      Structur.birthplace = Console.ReadLine();

      Console.Write('\n');
      Console.WriteLine(Structur.Print());

      return Structur;
    }

    /// <summary>
    /// Запись структуры в файл
    /// </summary>
    public void SaveClick(int numStr)
    {
      //Console.Write("   Нажмите клавишу S, чтобы записать изменения в файл.\n");
      //Console.Write("   Или нажмите любую другую клавишу, чтобы НЕ записывать изменения в файл.\n");

      //string x = Console.ReadLine();

      //if (x.ToUpper() == "S")   
        File.AppendAllText(@"D:\С#\data.txt", this.employees[numStr].Print() + "\n");
    }

    /// <summary>
    /// Редактирование данных сотрудника
    /// </summary>
    public Employee EditDataEmployee(int numStr)
    {
      Employee Structur = new Employee();
      char ch;
        Console.WriteLine(this.employees[numStr - 1].Print());
        Structur.id = this.employees[numStr - 1].id;

        Console.WriteLine("Отредактировать Ф.И.О. ?\n   Нажми Y/N :");
        ch = Convert.ToChar(Console.ReadLine());
        if (Char.ToLower(ch) == 'y')
        {
          Console.WriteLine("Введите Ф.И.О. :");
          Structur.name = Console.ReadLine();
          Structur.dateTime = DateTime.Now.ToLocalTime();
          Console.Write("   Данные были отредактированы...\n");
        }
        else
          if (Char.ToLower(ch) == 'n')
        {
          Structur.name = this.employees[numStr - 1].name;
          Console.Write("   Данные НЕ были отредактированы...\n");
        }

        Console.WriteLine("Отредактировать данные о возрасте сотрудника ?\n   Нажми Y/N :");
        ch = Convert.ToChar(Console.ReadLine());
        if (Char.ToLower(ch) == 'y')
        {
          Console.WriteLine("Введите возраст сотрудника :");
          Structur.Old = Convert.ToInt32(Console.ReadLine());
          Structur.dateTime = DateTime.Now.ToLocalTime();
          Console.Write("   Данные были отредактированы...\n");
        }
        else
          if (Char.ToLower(ch) == 'n')
        {
          Structur.Old = this.employees[numStr - 1].Old;
          Console.Write("   Данные НЕ были отредактированы...\n");
        }

        Console.WriteLine("Отредактировать данные о росте сотрудника ?\n   Нажми Y/N :");
        ch = Convert.ToChar(Console.ReadLine());
        if (Char.ToLower(ch) == 'y')
        {
          Console.WriteLine("Введите рост сотрудника :");
          Structur.Height = Convert.ToInt32(Console.ReadLine());
          Structur.dateTime = DateTime.Now.ToLocalTime();
          Console.Write("   Данные были отредактированы...\n");
        }
        else
          if (Char.ToLower(ch) == 'n')
        {
          Structur.Height = this.employees[numStr - 1].Height;
          Console.Write("   Данные НЕ были отредактированы...\n");
        }

        Console.WriteLine("Отредактировать данные о дате рождения сотрудника ?\n   Нажми Y/N :");
        ch = Convert.ToChar(Console.ReadLine());
        if (Char.ToLower(ch) == 'y')
        {
          Console.WriteLine("Введите дату рождения сотрудника :");
          Structur.birthdate = Convert.ToDateTime(Console.ReadLine());
          Structur.dateTime = DateTime.Now.ToLocalTime();
          Console.Write("   Данные были отредактированы...\n");
        }
        else
          if (Char.ToLower(ch) == 'n')
        {
          Structur.birthdate = this.employees[numStr - 1].birthdate;
          Console.Write("   Данные НЕ были отредактированы...\n");
        }

        Console.WriteLine("Отредактировать данные о месте рождения сотрудника ?\n   Нажми Y/N :");
        ch = Convert.ToChar(Console.ReadLine());
        if (Char.ToLower(ch) == 'y')
        {
          Console.WriteLine("Введите место рождения сотрудника :");
          Structur.birthplace = Console.ReadLine();
          Structur.dateTime = DateTime.Now.ToLocalTime();
          Console.Write("   Данные были отредактированы...\n");
        }
        else
          if (Char.ToLower(ch) == 'n')
        {
          Structur.birthplace = this.employees[numStr - 1].birthplace;
          Console.Write("   Данные НЕ были отредактированы...\n");
        }

      Console.Write('\n');
      return Structur;
    }

    /// <summary>
    /// Сортировка данные по возрастанию дат дней рождений
    /// </summary>
    public void SortAscendingBirthdate()
    {
      Employee Structur = new Employee();
      for (int i = 0; i < this.Count; i++)
      {
        for (int j = i + 1; j < this.Count; j++)
        {
          if (this.employees[i].birthdate > this.employees[j].birthdate)
          {
            Structur = this.employees[i];
            this.employees[i] = this.employees[j];
            this.employees[j] = Structur;
          }
        }
        Console.WriteLine(this.employees[i].Print());
      }
    }

    /// <summary>
    /// Сортировка данные по убыванию дат дней рождений
    /// </summary>
    public void SortDescendingBirthdate()
    {
      Employee Structur = new Employee();
      for (int i = 0; i < this.Count; i++)
      {
        for (int j = i + 1; j < this.Count; j++)
        {
          if (this.employees[i].birthdate < this.employees[j].birthdate)
          {
            Structur = this.employees[i];
            this.employees[i] = this.employees[j];
            this.employees[j] = Structur;
          }
        }
        Console.WriteLine(this.employees[i].Print());
      }
    }
  }
}
