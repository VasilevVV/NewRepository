using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPU.LB1.PersonLibrary
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
        private Person[] _personArray;


        /// <summary>
        /// Конструктор класса PersonList - 
        /// возвращает нулевой список.
        /// Используется в Program в начале void Main
        /// </summary>
        public PersonList()
        {
            _personArray = new Person[0];
        }

        /// <summary>
        /// Количество персон в списке
        /// </summary>
        public int Number
        {
            get
            {
                return _personArray.Length;
            }
        }

        /// <summary>
        /// Добавляет новую персону в конец списка
        /// </summary>
        /// <param name="person">элемент типа Person</param>
        public void AddPerson(Person person)
        {
            Array.Resize<Person>(ref _personArray, _personArray.Length + 1);
            _personArray[_personArray.Length - 1] = person;
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
            Person[] newArray = new Person[_personArray.Length];
            Array.Copy(_personArray, newArray, _personArray.Length);
            Array.Resize<Person>(ref _personArray, _personArray.Length - 1);
            Array.Copy(newArray, index + 1, _personArray, index,
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
            for (int i = 0; i < _personArray.Length; i++)
            {
                if (!((_personArray[i].Name == name) &&
                    (_personArray[i].Surname == surname)))
                {
                    Array.Resize<Person>(ref newArray, newArray.Length + 1);
                    newArray[newArray.Length - 1] = _personArray[i];
                }
            }
            _personArray = newArray;
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
            return _personArray[index];
        }

        /// <summary>
        /// Осуществляет поиск индекса персоны по имени и фамилии
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="surname">фамилия</param>
        /// <returns>Индекс</returns>
        public int FindPersonIndex(string name, string surname)
        {
            for (int i = 0; i < _personArray.Length; i++)
            {
                if ((_personArray[i].Name == name) &&
                    (_personArray[i].Surname == surname))
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
            Array.Resize<Person>(ref _personArray, 0);
        }

    }
}
