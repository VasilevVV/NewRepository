using System;

namespace Class_Person
{

    class Person
    {
        public string name; // имя
        public string surname; //фамилия
        public int age; //возраст
        public Gender gender; //пол

        public Person() : this("Неизвестно")
        {
        }
        public Person(string name) : this(name, "Неизвестно")
        {
        }
        public Person(string name, string surname) : this(name, surname, 0)//пока для неизвестного возраста сделаем 0 лет
        {
        }
        public Person(string name, string surname, int age) : this(name, surname, age, Gender.Неопределен)
        {
        }
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
            Person Mark = new Person();

            Mark.GetInfo();      // Имя: Фамилия: Возраст: 0

            /*Mark.name = "Mark";
            Mark.surname = "Smith";
            Mark.age = 31;
            Mark.GetInfo();  // Имя: Mark Фамилия: Smith Возраст: 34
            Console.ReadKey();*/

            //Console.WriteLine("Hello World!");
        }
    }
}
