using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace task1
{
  /// <summary>
  /// Менеджер
  /// </summary>
  class Manager : Сonsultant
  {
    public Manager(string Surname, string Name, string Patronymic, string PhoneNumber, string Passport)
      : base(Surname, Name, Patronymic, PhoneNumber, Passport) { }

    public new string Patronymic { get; set; }

    public new Manager ReadFile(string path)
    {
      string line = File.ReadAllText(path);
      string[] subs = line.Split('#');
      return new Manager(subs[0], subs[1], subs[2], subs[3], subs[4]);
    }
  }
}
