using System;
using System.Collections.Generic;
using System.Text;

namespace PersonLibrary
{
    /// <summary>
    /// класс персоны
    /// </summary>
    public class Person
    {
        public string name { get; set; } // имя
        public string surname { get; set; } //фамилия      
        public int age { get; set; } //возраст       
        public Gender gender { get; set; } //пол

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
        public Person(string name, string surname) : this(name, surname, 0)//пока для неизвестного возраста сделаем 0 лет
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
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.gender = gender;
        }

        /*public void GetInfo() //в готовом варианте закоментировать полностью
        {
            Console.WriteLine($"Имя: {name} Фамилия: {surname}  Возраст: {age} Пол: {gender}");
        } */

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
