using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPU.LB1.PersonLibrary
{
    /// <summary>
    /// класс взрослой персоны
    /// </summary>
    public class Adult : Person
    {
        /// <summary>
        /// публичный парметр для номера паспорта
        /// </summary>
        public uint PassportNumber { get; set; }

        /// <summary>
        /// публичный парметр партнера по браку
        /// </summary>
        public Adult Partner { get; set; }

        /// <summary>
        /// публичный парметр о состоянии брака
        /// </summary>
        public bool IsMarried
        {
            get
            {
                return (Partner != null);
            }
        }

        /// <summary>
        /// публичный парметр о работе
        /// </summary>
        public string Job { get; set; }

        /// <summary>
        /// публичный парметр о детях
        /// </summary>
        public Child Child { get; set; }

        /// <summary>
        /// конструктор взрослой персоны
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="surname">фамилия</param>
        /// <param name="age">возраст</param>
        /// <param name="gender">пол</param>
        /// <param name="passportNumber">номер паспорта</param>
        public Adult(string name, string surname, int age,
            Gender gender, uint passportNumber) : base(name, surname, age, gender)
        {
            PassportNumber = passportNumber;
        }

        /// <summary>
        /// конструктор взрослой персоны
        /// </summary>
        /// <param name="passportNumber">номер паспорта</param>
        public Adult(uint passportNumber) : base()
        {
            PassportNumber = passportNumber;
        }

        /// <summary>
        /// конструктор взрослой персоны
        /// </summary>
        public Adult() : base()
        {
        }

        /// <summary>
        /// конструктор взрослой персоны
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="surname">фамилия</param>
        /// <param name="age">возраст</param>
        /// <param name="gender">пол</param>
        public Adult(string name, string surname, int age, Gender gender) 
            : this(name, surname, age, gender, 0)
        {
        }

        /// <summary>
        /// Информации о взрослой персоне
        /// </summary>
        public override string Infomation
        {
            get
            {
                string child = Child != null
                    ? $"{Child.Name} {Child.Surname}"
                    : "нет детей";
                string job = Job != null
                    ? $"{Job}"
                    : "безработный";
                string partner = Partner != null
                    ? $"{Partner.Name} {Partner.Surname}"
                    : "нет";

                return base.Infomation +
                    $"паспортные данные: {PassportNumber}\n" +
                    $"место работы: {job}\n" +
                    $"муж/жена: {partner}\n" +
                    $"дети: {child}\n";
            }
        }

        /// <summary>
        /// Наименьший возраст взрослого
        /// </summary>
        private const int MinAdultAge = 18;

        /// <summary>
        /// проверка правильности возраста
        /// </summary>
        /// <param name="Age">возраст</param>
        public override void AgeChecker(int Age)
        {
            if ((Age >= MaxAge) || (Age < MinAdultAge))
            {
                throw new ArgumentException($"Возраст взрослого должен " +
                    $"быть от {MinAdultAge + 1} до {MaxAge - 1} включительно");
            }
        }
    }
}
