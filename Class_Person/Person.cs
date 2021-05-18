using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PersonLibrary
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
                if (value > 0 && value < 120)
                {
                    _age = value;
                }
                else
                {
                    throw new ArgumentException("Указан неправильный возраст");
                }
            }
        }
         
        
        public Gender Gender { get; set; } //пол


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
        public Person(string name, string surname) : this(name, surname, 1)//пока для неизвестного возраста сделаем 1 год
        {
        }
        /// <summary>
        /// персона
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="surname">фамилия</param>
        /// <param name="age">возраст</param>
        public Person(string name, string surname, int age) : this(name, surname, age, Gender.Неопределен)
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
            this.Gender = gender;
        }

        /// <summary>
        /// Меняет регистр букв имен и фамилий на правильный
        /// </summary>
        /// <param name="Name">Имя или фамилия</param>
        /// <returns>Имя или фамилия с правильным регистром</returns>
        private static string RegisterChanger(string Name)
        {
            if (Name.IndexOf("-") > 0)
            {
                Name = Name.Substring(0, 1).ToUpper() 
                    + Name.Substring(1, Name.IndexOf("-")).ToLower() 
                    + Name.Substring(Name.IndexOf("-") + 1, 1).ToUpper() 
                    + Name.Remove(0, Name.IndexOf("-") + 2).ToLower();
                return Name;
            }            
            else
            {
                Name = Name.Substring(0, 1).ToUpper() 
                    + Name.Remove(0, 1).ToLower();
                return Name;
            }
            
        }

        /// <summary>
        /// Проверяет имя или фамилию
        /// </summary>
        /// <param name="Name">Проверяемое имя или фамилия</param>
        private void NameChecker (string Name)
        {
            if (!Regex.IsMatch(Name, @"^(\p{L}+\p{Pd}?\p{L}+$)", RegexOptions.Multiline))
            {
                throw new ArgumentException("Имя и фамилия должны быть написаны только"
                    + "буквенными символами английского или русского алфавитов. "
                    + "Двойные имена и двойные фамилии пишутся через один дефис посередине");
            } 
        }
    }

    /// <summary>
    /// класс пол персоны
    /// </summary>
    public enum Gender
    {
        Неопределен,
        Мужской,
        Женский
    }


}
