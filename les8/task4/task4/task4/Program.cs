using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace task4
{
    public class Program
    {
        static void Main()
        {
            Worker worker = InputDataWorker();
            SaveWorkerData(worker);
            Console.ReadKey();
        }

        /// <summary>
        /// Заполнение данных нового работника
        /// </summary>
        static Worker InputDataWorker()
        {

            Worker Structur = new Worker();

            Console.WriteLine("Введите Ф.И.О. :");
            Structur.name = Console.ReadLine();

            Console.WriteLine("Введите улицу :");
            Structur.street = Console.ReadLine();

            Console.WriteLine("Введите номер дома :");
            Structur.houseNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите номер квартиры :");
            Structur.flatNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите Мобильный телефон:");
            Structur.mobilePhone = Console.ReadLine();

            Console.WriteLine("Введите Домашний телефон:");
            Structur.flatPhone = Console.ReadLine();

            Console.Write('\n');
            Console.WriteLine(Structur.Print());

            return Structur;
        }

        /// <summary>
        /// Сохранение Worker-данных в файл
        /// </summary>
        static void SaveWorkerData(Worker СoncreteWorker)
        {
            XDocument xdoc = new XDocument(new XElement("people",
              new XElement("Person",
                new XAttribute("name", СoncreteWorker.name),
                new XElement("Address",
                new XElement("Street", СoncreteWorker.street),
                new XElement("HouseNumber", СoncreteWorker.houseNumber),
                new XElement("FlatNumber", СoncreteWorker.flatNumber)),
                new XElement("Phones",
                new XElement("MobilePhone", СoncreteWorker.mobilePhone),
                new XElement("FlatPhone", СoncreteWorker.flatPhone)))));

            xdoc.Save("people.xml");
            Console.WriteLine("Данные сохранены.");
        }
    }
}
