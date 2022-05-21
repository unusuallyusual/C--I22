using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace task4
{
    class Program
    {
        /// <summary>
        /// Метод сериализации Worker
        /// </summary>
        static void SerializeWorker(Worker СoncreteWorker, string Path)
        {
            // Создаем сериализатор на основе указанного типа 
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Worker));

            // Создаем поток для сохранения данных
            Stream fStream = new FileStream(Path, FileMode.Create, FileAccess.Write);

            // Запускаем процесс сериализации
            xmlSerializer.Serialize(fStream, СoncreteWorker);

            // Закрываем поток
            fStream.Close();
        }

        static void Main()
        {
            Worker worker = InputDataWorker();
            Console.ReadKey();

            SerializeWorker(worker, "data.xml");

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
    }
}
