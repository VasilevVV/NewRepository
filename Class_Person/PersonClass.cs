using System;

namespace Class_Person
{

    /// <summary>
    /// класс персоны
    /// </summary>
       
    class Person
    {
        public string name; // имя
        public string surname; //фамилия
        public int age; //возраст
        public Gender gender; //пол

        /// <summary>
        /// Имя:Неизвестно Фамилия:Неизвестно Возраст:0 Пол:Неопределен
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

        public void GetInfo()
        {
            Console.WriteLine($"Имя: {name} Фамилия: {surname}  Возраст: {age} Пол: {gender}");
        }
    }
    /// <summary>
    /// класс пол персоны
    /// </summary>
    enum Gender
    {
        Неопределен,
        Мужской,
        Женский            
    }

    class PersonClass
    {
        static void Main(string[] args)
        {
            Person Marta = new Person("Marta", "Swim", -5);
            Person Mark = new Person("Mark", "Smith", 15, Gender.Мужской);

            Mark.GetInfo();      
            Marta.GetInfo();

            
        }
    }
}
