using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    public struct Worker
    {
        /// <summary>
        /// ФИО
        /// </summary>
        public string name;

        /// <summary>
        /// Улица
        /// </summary>
        public string street;

        /// <summary>
        /// Номер дома
        /// </summary>
        public int houseNumber;

        /// <summary>
        /// Номер квартиры
        /// </summary>
        public int flatNumber;

        /// <summary>
        /// Мобильный телефон
        /// </summary>
        public string mobilePhone;

        /// <summary>
        /// Домашний телефон
        /// </summary>
        public string flatPhone;

        //print
        public string Print()
        {
            return $"{name}#{street}#{houseNumber}#{flatNumber}#{mobilePhone}#{flatPhone}";
        }
        public Worker(string name, string street, int houseNumber, int flatNumber, string mobilePhone, string flatPhone)
        {
            this.name = name;
            this.street = street;
            this.houseNumber = houseNumber;
            this.flatNumber = flatNumber;
            this.mobilePhone = mobilePhone;
            this.flatPhone = flatPhone;
        }
    }
}
