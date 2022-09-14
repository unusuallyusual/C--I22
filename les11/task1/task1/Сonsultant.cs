using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace task1
{
  /// <summary>
  /// Консультант
  /// </summary>
  class Сonsultant : Client
  {
    private readonly string surname;
    private readonly string name;
    private readonly string patronymic;

    /// <summary>
    /// Создание экземпляра клиента
    /// </summary>
    /// <param name="Surname">Фамилия</param>
    /// <param name="Name">Имя</param>
    /// <param name="Patronymic">Отчество</param>
    /// <param name="PhoneNumber">Номер телефона</param>
    /// <param name="Passport">Паспорт</param>
    public Сonsultant(string Surname, string Name, string Patronymic, string PhoneNumber, string Passport)
      : base(Surname, Name, Patronymic, PhoneNumber, Passport)
    {
      this.surname = Surname;
      this.name = Name;
      this.patronymic = Patronymic;
    }

    /// <summary>
    /// Фамилия
    /// </summary>
    public new string Surname { get { return this.surname; } }

    /// <summary>
    /// Имя
    /// </summary>
    public new string Name { get { return this.name; } }

    /// <summary>
    /// Отчество
    /// </summary>
    public new string Patronymic { get { return this.patronymic; } }

    /// <summary>
    /// Серия и номер паспорта. Данные не доступны для просмотра.
    /// </summary>
    private new string Passport()
    {
      return new string('*', base.Passport.Length);
    }

    private string ClientInfo()
    {
      return $"{Surname}#{Name}#{Patronymic}#{PhoneNumber}#{base.Passport}";
    }

    /// <summary>
    /// Запись данных клиента в файл
    /// </summary>
    public void RecToFile(string path)
    {
      string contents = this.ClientInfo();
      File.AppendAllText(path, contents + "\n");
    }

    /// <summary>
    /// Вывод данных клиента для просмотра.
    /// </summary>
    public string PrintClientInfo()
    {
      return $"{Surname} {Name} {Patronymic}. Teл. : {PhoneNumber}, Док-т : {Passport()}";
    }

    public Сonsultant ReadFile(string path)
    {
      string line = File.ReadAllText(path);
      string[] subs = line.Split('#');
      return new Сonsultant(subs[0], subs[1], subs[2], subs[3], subs[4]);
      }
    }
  }

