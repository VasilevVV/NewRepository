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

        public void GetInfo() //в готовом варианте закоментировать полностью
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
        /// <summary>
        /// Класс, описывающий абстракцию списка, сожержащего объекты класса Person
        /// </summary>
        public Person[] PersonArray; // массив персон

        /// <summary>
        /// Конструктор класса PersonList - возвращает нулевой список
        /// </summary>
        public PersonList()
        {
            PersonArray = new Person[0];
        }

        /// <summary>
        /// Конструктор класса PersonList - возвращает заполненый список
        /// </summary>
        /// <param name="PersonArray">массив с элементами типа Person, заполняющий список персон</param>
        public PersonList(Person[] PersonArray)
        {
            this.PersonArray = PersonArray;
        }

        /// <summary>
        /// Количество персон в списке
        /// </summary>
        public int Number
        {
            get
            {
                return PersonArray.Length;
            }
        }

        /// <summary>
        /// Добавляет новую персону в конец списка
        /// </summary>
        /// <param name="person">элемент типа Person</param>
        public void AddPerson(Person person)
        {
            Array.Resize<Person>(ref PersonArray, PersonArray.Length + 1);
            PersonArray[PersonArray.Length - 1] = person;
        }

        /// <summary>
        /// Добавляет новую персону в конец списка по составляющим
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        public void AddPerson(string name, string surname, int age, Gender gender)
        {
            AddPerson(new Person(name, surname, age, gender));
        }
       
        public void GetInfo() //в готовом варианте закоментировать полностью
        {
            foreach (Person p in PersonArray)
            {
                Console.WriteLine($"Имя: {p.name} Фамилия: {p.surname}  Возраст: {p.age} Пол: {p.gender}");
            }
        }

        /// <summary>
        /// Удаляет персону по индексу в списке
        /// </summary>
        /// <param name="index">индекс персоны</param>
        public void DeleteByIndex(int index)
        {
            Person[] newArray = new Person[PersonArray.Length];
            Array.Copy(PersonArray, newArray, PersonArray.Length);
            Array.Resize<Person>(ref PersonArray, PersonArray.Length - 1);
            Array.Copy(newArray, index + 1, PersonArray, index, newArray.Length - index - 1);
        }

        //из однофамильных одноименных персон удалит первую в списке 
        /// <summary>
        /// Удаляет персону по имени и фамилии
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамиля</param>
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

        /// <summary>
        /// Ищет персону по индексу
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Персона</returns>
        /// <exception cref="System.IndexOutOfRangeException">
        /// Возникает при указании индекса вне границ массива.
        /// </exception>
        public Person GetPersonByIndex(int index)
        {
            return PersonArray[index];                       
        }

        /// <summary>
        /// Осуществляет поиск индекса персоны по имени и фамилии
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="surname">фамилия</param>
        /// <returns>Индекс</returns>
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

        /// <summary>
        /// Очищает список персон
        /// </summary>
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
            Person second = ListArray.GetPersonByIndex(1);
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
