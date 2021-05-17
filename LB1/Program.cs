using System;
using Class_Person;

namespace LB1
{
    class Program
    {
        /// <summary>
        /// Вывод на консоль двух списков персон
        /// </summary>
        /// <param name="List1">Первый список</param>
        /// <param name="List2">Второй список</param>
        private static void PrintPersonLists(PersonList List1, PersonList List2)
        {
            Console.WriteLine("Список 1");
            foreach (Person person in List1.PersonArray)
            {
                Console.WriteLine($"Имя: {person.name} Фамилия: {person.surname}  Возраст: {person.age} Пол: {person.gender}");
            }
            Console.WriteLine();

            Console.WriteLine("Список 2");
            foreach (Person person in List2.PersonArray)
            {
                Console.WriteLine($"Имя: {person.name} Фамилия: {person.surname}  Возраст: {person.age} Пол: {person.gender}");
            }
            Console.WriteLine();
        }

        private static void Step()
        {
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine();
        }




        static void Main(string[] args)
        {
            Console.WriteLine("Создайте  программно  два  списка  персон,  в  каждом  из  которых будет по три человека");
            Step();

            PersonList List1 = new PersonList();
            List1.AddPerson("Mark", "Smith", 15, Gender.Мужской);
            List1.AddPerson("Marta", "Swim", 35, Gender.Женский);
            List1.AddPerson("Мэттью", "Макконахи", 50, Gender.Мужской);
            
            PersonList List2 = new PersonList();
            List2.AddPerson("Pitter", "Parker", 22, Gender.Мужской);
            List2.AddPerson("Kate", "Grow", 10, Gender.Женский);
            List2.AddPerson("Анна", "Иановна", 32, Gender.Женский);

            Console.WriteLine("Списки созданы");
            Step();



            Console.WriteLine("Выведите  содержимое  каждого  списка  на  экран  с соответствующими подписями списков");
            Step();

            PrintPersonLists(List1, List2);

            Step(); ;



            Console.WriteLine("Добавьте нового человека в первый список");
            Step();

            List1.AddPerson("Новый", "Человек", 1, Gender.Мужской);

            Console.WriteLine("Новый человек добавлен");
            Step();



            Console.WriteLine("Скопируйте второго человека из первого списка в конец второго списка.");
            Console.WriteLine("Покажите, что один и тот же человек находится в обоих списках.");
            Step();

            List2.AddPerson(List1.GetPersonByIndex(1));

            PrintPersonLists(List1, List2);                      

            foreach (Person person1 in List1.PersonArray)
            {
                foreach (Person person2 in List2.PersonArray)
                {
                    if (person1 == person2)
                    {
                        Console.WriteLine($"Индекс того же человека в 1 списке: {List1.FindPersonIndex(person1.name, person1.surname)}");
                        Console.WriteLine($"Индекс того же человека во 2 списке: {List2.FindPersonIndex(person2.name, person2.surname)}");
                    }
                }
            }

            Step();



            Console.WriteLine("Удалите второго человека  из  первого  списка.");
            Console.WriteLine("Покажите, что удаление человека из первого списка не привело к уничтожению этого же человека во втором списке.");
            Step();

            List1.DeleteByIndex(1);
            PrintPersonLists(List1, List2);

            Step();

            Console.WriteLine("Очистите второй список.");
            Step();

            List2.Clear();
            PrintPersonLists(List1, List2);

            Step();




            Console.WriteLine("SSS");


        }
    }
}
