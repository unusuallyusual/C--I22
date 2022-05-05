using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
  struct Employee
  {
    /// <summary>
    /// ID
    /// </summary>
    public int id;

    /// <summary>
    /// Дата и время добавления записи
    /// </summary>
    public DateTime dateTime;

    /// <summary>
    /// ФИО
    /// </summary>
    public string name;

    /// <summary>
    /// Возраст
    /// </summary>
    private int old;

    public int Old
    {
      get { return this.old; }
      set { this.old = value; }
    }
    /// <summary>
    /// Рост
    /// </summary>
    public int Height { get; set; }  // так и не понял, можно ли так делать или это дурной тон

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime birthdate;

    /// <summary>
    /// Место рождения
    /// </summary>
    public string birthplace;

    //print
    public string Print()
    {
      return $"{id}#{dateTime}#{name}#{old}#{Height}#{birthdate}#{birthplace}";
    }

    //конструктор
    public Employee(int id, DateTime dateTime, string name, int old, int height, DateTime birthdate, string birthplace)
    {
      this.id = id;
      this.dateTime = dateTime;
      this.name = name;
      this.old = old;
      this.Height = height;
      this.birthdate = birthdate;
      this.birthplace = birthplace;
    }

    //конструктор 0.1
    public Employee(int id, DateTime dateTime, string name) :
      this(id, dateTime, name, 0, 0, new DateTime(1900, 1, 1, 0, 0, 0), String.Empty)
    { }
  }
}
