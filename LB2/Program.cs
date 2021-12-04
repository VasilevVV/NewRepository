using System;
using TPU.LB2.PersonLibrary;


namespace LB2
{
    /// <summary>
    /// Программа
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Демонтстрация работы новых классов
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.WriteLine("a. Создание списка PersonList, " +
                              "состоящий из семи человек, среди " + 
                              "которых - взрослые и дети " +
                              "в случайном порядке.");
            Console.ReadLine();
            PersonList people = new PersonList();
            Random randomNum = new Random();
            const int peopleNum = 7;
            for (int i = 0; i < peopleNum; i++)
            {
                int personType = randomNum.Next(0, 4);
                switch (personType)
                {
                    case 0:
                        {
                            people.AddPerson(RandomChildAndAdult.
                                GetRandomSingleChild());
                            break;
                        }
                    case 1:
                        {
                            people.AddPerson(RandomChildAndAdult.
                                GetRandomFullFamilyChild());
                            break;
                        }
                    case 2:
                        {
                            people.AddPerson(RandomChildAndAdult.
                                GetRandomSingleAdult());
                            break;
                        }
                    case 3:
                        {
                            people.AddPerson(RandomChildAndAdult.
                                GetRandomFullFamilyAdult());
                            break;
                        }
                }
            }
            Console.WriteLine("PersonList создан");
            Console.WriteLine();

            Console.ReadLine();
            Console.WriteLine("b. Вывод на экран описания " +
                              "всех людей списка.");
            Console.ReadLine();
            for (int i = 0; i < people.Number; i++)
            {
                Console.WriteLine($"-------{i + 1}-------");
                Console.WriteLine(people.
                    GetPersonByIndex(i).Infomation);
            }

            Console.ReadLine();
            Console.WriteLine("c. Программное определение " +
                              "типа четвёртого человека " +
                              "в списке.");
            Console.ReadLine();
            switch (people.GetPersonByIndex(3))
            {
                case Adult adult:
                    {
                        Console.WriteLine("Тип четвёртого человека " +
                            "в списке - Adult");
                        Console.WriteLine(adult.
                            GetJob("Преподаватель ТПУ"));
                        break;
                    }
                case Child child:
                    {
                        Console.WriteLine("Тип четвёртого человека " +
                            "в списке - Child");
                        Console.WriteLine(child.
                            GetEducation("Лицей ТПУ"));
                        break;
                    }
            }

            Console.ReadKey();
        }
    }
}
