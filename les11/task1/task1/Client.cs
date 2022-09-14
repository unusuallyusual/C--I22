using System;
using System.Collections.Generic;
using System.Text;

namespace task1
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
    /// <param name="Surname">Фамилия</param>
    /// <param name="Name">Имя</param>
    /// <param name="Patronymic">Отчество</param>
    /// <param name="PhoneNumber">Номер телефона</param>
    /// <param name="Passport">Паспорт</param>
    public Client(string Surname, string Name, string Patronymic, string PhoneNumber, string Passport)
    {
      this.Surname = Surname;
      this.Name = Name;
      this.Patronymic = Patronymic;
      this.Passport = Passport;
      this.PhoneNumber = PhoneNumber;
    }

    /// <summary>
    /// Фамилия
    /// </summary>
    protected string Surname { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    protected string Name { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    protected string Patronymic { get; set; }

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
    protected string Passport { get; set; }
  }
}
