using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace tasks
{
  /// <summary>
  /// Менеджер
  /// </summary>
  class Manager : Сonsultant
  {
    public string surname;
    public string name;
    public string patronymic;
    public string passport;
    private string recentchanges;
    public Manager(string DateChanges, string Surname, string Name, string Patronymic,
      string PhoneNumber, string Passport, string RecentChanges)
      : base(DateChanges, Surname, Name, Patronymic, PhoneNumber, Passport, RecentChanges)
    {
      this.surname = Surname;
      this.name = Name;
      this.patronymic = Patronymic;
      this.passport = Passport;
      this.recentchanges = RecentChanges;
    }

    public Manager() : this("сегодня/сейчас", "", "", "", "", "", "")
    {
    }

    private new string Surname { get; set; }

    public new string Name { get; set; }

    public new string Patronymic { get; set; }

    public new string Passport { get; set; }

    /// <summary>
    /// Извлечение данных клиента
    /// </summary>
    private string ClientInfo()
    {
      return $"{DateChanges}#{Surname}#{Name}#{Patronymic}#{PhoneNumber}#{Passport}#{RecentChanges}";
    }

    /// <summary>
    /// Запись данных клиента в файл
    /// </summary>
    private void RecToFile(string path)
    {
      string contents = ClientInfo();
      File.AppendAllText(path, contents);
    }

    /// <summary>
    /// Считывание данных клиента из файла
    /// </summary>
    public new Manager ReadFile(string path)
    {
      string line = File.ReadAllText(path);
      string[] subs = line.Split('#');
      return new Manager(subs[0], subs[1], subs[2], subs[3], subs[4], subs[5], subs[6]);
    }

    /// <summary>
    /// Вывод данных клиента для просмотра
    /// </summary>
    public override string PrintClientInfo()
    {
        return $"{DateChanges} >> {this.surname} {this.name} {this.patronymic}.\n" +
          $"Teл. : {PhoneNumber}, Док-т : {this.passport}\n" +
          $"Последние изменения >> {recentchanges}";
    }

    /// <summary>
    /// Редактирование данных клиента из файла
    /// </summary>
    public override void EditDataClient(string path)
    {
      Console.WriteLine("Изменить данные клиента ?\n   Нажми Y/N :");
      char cha = Convert.ToChar(Console.ReadLine());

      if (Char.ToLower(cha) == 'y')
      {
        int countYes = 0;
        string recentChanges = string.Empty;
        File.WriteAllText(path, string.Empty);

        Console.WriteLine("Изменить фамилию клиента ?\n   Нажми Y/N :");
        char c = Convert.ToChar(Console.ReadLine());
        if (Char.ToLower(c) == 'y')
        {
          Console.WriteLine("Введите фамилию клиента :");
          Surname = Console.ReadLine();
          countYes++;
          recentChanges += "Фамилию\n";
        }
        else
          Surname = this.surname;

        Console.WriteLine("Изменить имя клиента ?\n   Нажми Y/N :");
        c = Convert.ToChar(Console.ReadLine());
        if (Char.ToLower(c) == 'y')
        {
          Console.WriteLine("Введите имя клиента :");
          Name = Console.ReadLine();
          countYes++;
          recentChanges += "Имя\n";
        }
        else
          Name = this.name;

        Console.WriteLine("Изменить отчество клиента ?\n   Нажми Y/N :");
        c = Convert.ToChar(Console.ReadLine());
        if (Char.ToLower(c) == 'y')
        {
          Console.WriteLine("Введите отчество клиента :");
          Patronymic = Console.ReadLine();
          countYes++;
          recentChanges += "Отчество\n";
        }
        else
          Patronymic = this.patronymic;

        Console.WriteLine("Изменить номер телефона клиента ?\n   Нажми Y/N :");
        c = Convert.ToChar(Console.ReadLine());
        if (Char.ToLower(c) == 'y')
        {
          Console.WriteLine("Введите номер телефона клиента :");
          PhoneNumber = Console.ReadLine();
          countYes++;
          recentChanges += "Номер телефона\n";
        }

        Console.WriteLine("Изменить паспортные данные клиента ?\n   Нажми Y/N :");
        c = Convert.ToChar(Console.ReadLine());
        if (Char.ToLower(c) == 'y')
        {
          Console.WriteLine("Введите паспортные данные клиента :");
          Passport = Console.ReadLine();
          countYes++;
          recentChanges += "Паспортные данные\n";
        }
        else
          Passport = this.passport;

        if (countYes > 0)
        {
          Console.Write("   Данные были отредактированы...\n");
          DateChanges = Convert.ToString(DateTime.Now);
          RecentChanges = "\nМенеджер отредактировал следующие данные клиента:\n" + recentChanges;
        }
        else
          Console.Write("   Данные НЕ были отредактированы...\n");
        this.RecToFile(path);
      }
      else
      if (Char.ToLower(cha) == 'n')
        Console.Write("   Данные НЕ были отредактированы...\n");
    }
  }
}
