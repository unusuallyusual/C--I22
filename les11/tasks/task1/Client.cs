using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace tasks
{
  /// <summary>
  /// Клиент
  /// </summary>
  class Client
  {
    private string phonenumber;
    /// <summary>
    /// Создание экземпляра клиента
    /// </summary>
    /// <param name="DateChanges">Время создание записи/param>
    /// <param name="Surname">Фамилия</param>
    /// <param name="Name">Имя</param>
    /// <param name="Patronymic">Отчество</param>
    /// <param name="PhoneNumber">Номер телефона</param>
    /// <param name="Passport">Паспорт</param>
    public Client(string DateChanges, string Surname, string Name, string Patronymic, string PhoneNumber, string Passport)
    {
      this.DateChanges = DateChanges;
      this.Surname = Surname;
      this.Name = Name;
      this.Patronymic = Patronymic;
      this.Passport = Passport;
      this.PhoneNumber = PhoneNumber;
    }

    public Client() : this("сегодня/сейчас", "", "", "", "", "")
    {
    }

    public string DateChanges;

    /// <summary>
    /// Фамилия
    /// </summary>
    protected string Surname;

    /// <summary>
    /// Имя
    /// </summary>
    protected string Name;

    /// <summary>
    /// Отчество
    /// </summary>
    protected string Patronymic;

    /// <summary>
    /// Номер телефона
    /// </summary>
    public string PhoneNumber
    {
      get
      {
        return phonenumber;
      }
      set
      {
        if (value != String.Empty)
          this.phonenumber = value;
        else
          phonenumber = "нет данных..";
      }
    }

    /// <summary>
    /// Серия и номер паспорта
    /// </summary>
    protected string Passport;
  }
}
