using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TPU.LB1.PersonLibrary
{
    /// <summary>
    /// класс персоны
    /// </summary>
    public class Person
    {
        /// <summary>
        /// приватное поле для имени
        /// </summary>
        private string _name;

        /// <summary>
        /// публичный параметр для имени 
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                NameChecker(value);
                _name = RegisterChanger(value);
            }
        }

        /// <summary>
        /// приватное поле для фамилии
        /// </summary>
        private string _surname;

        /// <summary>
        /// публичный параметр для фамилии 
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                NameChecker(value);
                _surname = RegisterChanger(value);
            }
        }

        /// <summary>
        /// приватное поле для возраста
        /// </summary>
        private int _age;

        /// <summary>
        /// публичный парметр для возраста 
        /// </summary>
        public int Аge
        {
            get
            {
                return _age;
            }
            set
            {
                AgeCheck(value);
                _age = value;
            }
        }

        /// <summary>
        /// Пол персоны
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// персона
        /// </summary>
        public Person() : this("Неизвестно")
        {
        }
        /// <summary>
        /// персона
        /// </summary>
        /// <param name="name">имя</param>
        public Person(string name) : this(name, "Неизвестно")
        {
        }
        /// <summary>
        /// персона
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="surname">фамилия</param>
        public Person(string name, string surname) :
            this(name, surname, 1) // пока для неизвестного возраста
                                   // сделаем 1 год
        {
        }
        /// <summary>
        /// персона
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="surname">фамилия</param>
        /// <param name="age">возраст</param>
        public Person(string name, string surname, int age) :
            this(name, surname, age, Gender.Unknow)
        {
        }
        /// <summary>
        /// персона
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="surname">фамилия</param>
        /// <param name="age">возраст</param>
        /// <param name="gender">пол</param>
        public Person(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Аge = age;
            Gender = gender;
        }

        /// <summary>
        /// Меняет регистр букв имен и фамилий на правильный
        /// </summary>
        /// <param name="name">Имя или фамилия</param>
        /// <returns>Имя или фамилия с правильным регистром</returns>
        private static string RegisterChanger(string name)
        {
            if (name.IndexOf("-") > 0)
            {
                name = name.Substring(0, 1).ToUpper()
                    + name.Substring(1, name.IndexOf("-")).ToLower()
                    + name.Substring(name.IndexOf("-") + 1, 1).ToUpper()
                    + name.Remove(0, name.IndexOf("-") + 2).ToLower();
                return name;
            }
            else
            {
                name = name.Substring(0, 1).ToUpper()
                    + name.Remove(0, 1).ToLower();
                return name;
            }

        }

        /// <summary>
        /// Проверяет имя или фамилию
        /// </summary>
        /// <param name="name">Проверяемое имя или фамилия</param>
        private void NameChecker(string name)
        {
            if (!Regex.IsMatch(name, @"^(\p{L}+\p{Pd}?\p{L}+$)",
                RegexOptions.Multiline))
            {
                throw new ArgumentException("Имя и фамилия должны быть "
                    + "написаны только буквенными символами английского "
                    + "или русского алфавитов. Двойные имена и двойные "
                    + "фамилии пишутся через один дефис посередине");
            }
        }

        /// <summary>
        /// Информации о персоне
        /// </summary>
        public virtual string Infomation
        {
            get
            {
                return $"{Name} {Surname}\n" +
                    $"пол: {Gender}\n" +
                    $"возраст: {Аge}\n";
            }
        }


        /// <summary>
        /// Наименьший допустимый возраст персоны.
        /// </summary>
        public const int MinAge = 0;

        /// <summary>
        /// Наибольший допустимый возраст персоны.
        /// </summary>
        public const int MaxAge = 120;

        /// <summary>
        /// Проверка правильности возраста
        /// </summary>
        /// <param name="age"></param>
        public virtual void AgeCheck(int age)
        {
            if (age <= MinAge || age > MaxAge)
            {
                throw new ArgumentException($"Указан "
                    + $"неправильный возраст. Укажите от {MinAge + 1} до {MaxAge - 1}" +
                    $" включительно");
            }
        }
    }
}
