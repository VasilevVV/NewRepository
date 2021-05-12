using System;


namespace Class_Person
{

    /// <summary>
    /// класс персоны
    /// </summary>

    public class Person
    {
        public string name { get; set; } // имя
        public string surname { get; set; } //фамилия
      
        private int age; //возраст
        public int AGE //гетер и сетер для возраста
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 0)
                {
                    
                    Console.WriteLine("Возраст не может быть отрицательным, присвоено значение 0");//сообщение об ошибке
                    age = 0;
                    return;
                }
                else
                {
                    age = value;
                }                
            }
        }

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
            this.AGE = age;
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
    public enum Gender
    {
        Неопределен,
        Мужской,
        Женский            
    }

    public class PersonList
    {
        public Person[] PersonArray; // массив персон

        public PersonList()
        {
            PersonArray = new Person[0];
        }
        public PersonList(Person[] PersonArray)
        {
            this.PersonArray = PersonArray;
        }

        public int Number
        {
            get
            {
                return PersonArray.Length;
            }
        }

        public void AddPerson(Person person)
        {
            Array.Resize<Person>(ref PersonArray, PersonArray.Length + 1);
            PersonArray[PersonArray.Length - 1] = person;
        }

        public void AddPerson(string name, string surname, int age, Gender gender)
        {
            AddPerson(new Person(name, surname, age, gender));
        }

        public void GetInfo()
        {
            foreach (Person p in PersonArray)
            {
                Console.WriteLine($"Имя: {p.name} Фамилия: {p.surname}  Возраст: {p.AGE} Пол: {p.gender}");
            }
        }

        public void DeleteByIndex(int index)
        {
            Person[] newArray = new Person[PersonArray.Length];
            Array.Copy(PersonArray, newArray, PersonArray.Length);
            Array.Resize<Person>(ref PersonArray, PersonArray.Length - 1);
            Array.Copy(newArray, index + 1, PersonArray, index, newArray.Length - index - 1);
        }

        public void DeleteByNameSurname(string name, string surname)
        {
            Person[] newArray = new Person[0];
            for (int i = 0; i < PersonArray.Length; i++)
            {
                if (!((PersonArray[i].name == name) && (PersonArray[i].surname == surname)))
                {
                    Array.Resize<Person>(ref newArray, newArray.Length + 1);
                    newArray[newArray.Length - 1] = PersonArray[i];
                }                
            }
            PersonArray = newArray;
        }

        public Person GetPersonByIndex(int index)
        {
            if (index >= 0)
                {
                if (index + 1 <= PersonArray.Length)
                {
                    return PersonArray[index];
                }
                else
                {
                    Console.WriteLine("Задан неправильный индекс - больше количества элементов, возвращено последнее значение");
                    return PersonArray[PersonArray.Length - 1];
                }
            }
            else
            {
                Console.WriteLine("Задан неправильный индекс - отрицательный, возвращено первое значение");
                return PersonArray[0];
            }
        }

        public int FindPersonIndex(string name, string surname)
        {            
            for (int i = 0; i < PersonArray.Length; i++)
            {
                if ((PersonArray[i].name == name) && (PersonArray[i].surname == surname))
                {                    
                    return i;
                }

            }
            return -1;            
        }

        public void Clear()
        {
            Array.Resize<Person>(ref PersonArray, 0);
        }

    }


    class PersonClass
    {
        static void Main(string[] args)
        {
            Person Marta = new Person("Marta", "Swim", -5);
            Person Mark = new Person("Mark", "Smith", 15, Gender.Мужской);

            Console.WriteLine(Mark.name);      
            Marta.GetInfo();

            Console.WriteLine();
            Console.WriteLine();

            Person[] list = new Person[2];
            list[0] = Marta;
            list[1] = Mark;

            PersonList ListArray = new PersonList(list);

            
            ListArray.GetInfo();
            Console.WriteLine();
            Console.WriteLine(ListArray.Number);
            Console.WriteLine();
            Person Kent = new Person("Kent", "Klark", 35, Gender.Мужской);
            ListArray.AddPerson(Kent);
            ListArray.GetInfo();
            Console.WriteLine();
            ListArray.AddPerson("Gloria", "Loli", 14, Gender.Женский);
            ListArray.AddPerson("Gloria", "Lokerenta", 60, Gender.Женский);
            ListArray.GetInfo();
            Console.WriteLine(ListArray.Number);
            Console.WriteLine();
            ListArray.DeleteByIndex(2);
            ListArray.GetInfo();
            Console.WriteLine(ListArray.Number);
            Console.WriteLine();
            ListArray.DeleteByNameSurname("Gloria", "Loli");
            ListArray.GetInfo();
            Console.WriteLine(ListArray.Number);
            Console.WriteLine();
            Person second = ListArray.GetPersonByIndex(2);
            second.GetInfo();
            Console.WriteLine();
            Console.WriteLine("ИНДЕКС");
            Console.WriteLine(ListArray.FindPersonIndex("Gloria", "Lokerena"));
            Console.WriteLine();
            Console.WriteLine("Очищение");
            ListArray.Clear();
            ListArray.GetInfo();
            Console.WriteLine("Очищение");
        }
    }
}
