using System;
using System.Collections.Generic;
using System.Text;

namespace PersonLibrary
{
    /// <summary>
    /// Класс, описывающий абстракцию списка, 
    /// сожержащего объекты класса Person
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Массив, содержащий объекты класса Person
        /// </summary>
        public Person[] PersonArray; // массив персон

        /// <summary>
        /// Конструктор класса PersonList - 
        /// возвращает нулевой список
        /// </summary>
        public PersonList()
        {
            PersonArray = new Person[0];
        }

        /// <summary>
        /// Конструктор класса PersonList - 
        /// возвращает заполненый список
        /// </summary>
        /// <param name="PersonArray">массив с элементами типа 
        /// Person, заполняющий список персон</param>
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
        public void AddPerson(string name, string surname, 
            int age, Gender gender)
        {
            AddPerson(new Person(name, surname, age, gender));
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
            Array.Copy(newArray, index + 1, PersonArray, index,
                newArray.Length - index - 1);
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
                if (!((PersonArray[i].Name == name) && 
                    (PersonArray[i].Surname == surname)))
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
                if ((PersonArray[i].Name == name) && 
                    (PersonArray[i].Surname == surname))
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

}
