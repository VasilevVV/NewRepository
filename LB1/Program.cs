using System;
using TPU.LB1.PersonLibrary;


namespace LB1
{
    /// <summary>
    /// Программа проверки
    /// </summary>
    class Program
    {
        /// <summary>
        /// Вывод на консоль двух списков персон
        /// </summary>
        /// <param name="list1">Первый список</param>
        /// <param name="list2">Второй список</param>
        private static void PrintPersonLists(PersonList list1,
            PersonList list2)
        {
            Console.WriteLine("Список 1");
            for (int i = 0; i < list1.Number; i++)
            {
                WritePerson(list1.GetPersonByIndex(i));
            }
            Console.WriteLine();

            Console.WriteLine("Список 2");
            for (int i = 0; i < list2.Number; i++)
            {
                WritePerson(list2.GetPersonByIndex(i));
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Шаг выполняемый по нажатию любой клавиши
        /// </summary>
        private static void Step()
        {
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine();
        }

        /// <summary>
        /// Считывает персону, вводимую с клавиатуры в консоле
        /// </summary>
        /// <param name="personRead">Персона</param>
        /// <returns>Считанная персона</returns>
        public static Person ReadPerson(Person personRead)
        {
            Action[] actionsArray = new Action[]
            {
                () =>
                {
                    Console.WriteLine("Введите имя");
                    personRead.Name = Console.ReadLine();
                },
                () =>
                {
                    Console.WriteLine("Введите фамилию");
                    personRead.Surname = Console.ReadLine();
                },
                () =>
                {
                    Console.WriteLine("Введите возраст");
                    personRead.Аge = Convert.ToInt32(Console.ReadLine());
                },
                () =>
                {
                    Console.WriteLine("Введите пол м/ж");
                    string gender = Console.ReadLine();
                    switch (gender)
                    {
                        case "м":
                            personRead.Gender = Gender.Male;
                            break;
                        case "ж":
                            personRead.Gender = Gender.Female;
                            break;
                        default:
                            throw new ArgumentException("Некорректно" +
                                " введён пол.");
                    }
                }
            };

            foreach (var action in actionsArray)
            {
                while (true)
                {
                    try
                    {
                        action();
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}\nПопробуйте снова.");
                    }
                }
            }
            return personRead;
        }

        /// <summary>
        /// Выводит персону в консоль
        /// </summary>
        /// <param name="PersonWritten">Выводимая персона</param>
        /// <returns>Выведенная персона</returns>
        public static Person WritePerson(Person PersonWritten)
        {
            Console.WriteLine($"Имя: {PersonWritten.Name} " +
                $"Фамилия: {PersonWritten.Surname}  " +
                $"Возраст: {PersonWritten.Аge} " +
                $"Пол: {PersonWritten.Gender}");

            return PersonWritten;
        }


        /// <summary>
        /// Программа проверки классов
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Создайте  программно  два  списка  персон," +
                "  в  каждом  из  которых будет по три человека");
            Step();

            PersonList list1 = new PersonList();
            list1.AddPerson("Mark", "Smith", 15, Gender.Male);
            list1.AddPerson("Marta", "Swim", 35, Gender.Female);
            list1.AddPerson("Мэттью", "Макконахи", 50, Gender.Male);

            PersonList list2 = new PersonList();
            list2.AddPerson("Pitter", "Parker", 22, Gender.Male);
            list2.AddPerson("Kate", "Grow", 10, Gender.Female);
            list2.AddPerson("Анна", "Иановна", 32, Gender.Female);

            Console.WriteLine("Списки созданы");
            Step();

            Console.WriteLine("Выведите  содержимое  каждого  списка" +
                "  на  экран  с соответствующими подписями списков");
            Step();

            PrintPersonLists(list1, list2);

            Step();

            Console.WriteLine("Добавьте нового человека в первый список");
            Step();

            list1.AddPerson("Новый", "Человек", 1, Gender.Male);

            Console.WriteLine("Новый человек добавлен");
            Step();

            Console.WriteLine("Скопируйте второго человека" +
                " из первого списка в конец второго списка.");
            Console.WriteLine("Покажите, что один и тот же" +
                " человек находится в обоих списках.");
            Step();

            list2.AddPerson(list1.GetPersonByIndex(1));

            PrintPersonLists(list1, list2);

            for (int i = 0; i < list1.Number; i++)
            {
                for (int j = 0; j < list2.Number; j++)
                {
                    if (list1.GetPersonByIndex(i) == list2.GetPersonByIndex(j))
                    {
                        Console.WriteLine($"Индекс того же человека в 1 списке: " +
                            $"{0}", list1.FindPersonIndex(
                                list1.GetPersonByIndex(i).Name,
                            list1.GetPersonByIndex(i).Surname));
                        Console.WriteLine($"Индекс того же человека во 2 списке: " +
                            $"{0}", list2.FindPersonIndex(
                                list2.GetPersonByIndex(j).Name,
                            list2.GetPersonByIndex(j).Surname));
                    }
                }
            }

            Step();

            Console.WriteLine("Удалите второго человека  из " +
                " первого  списка.");
            Console.WriteLine("Покажите, что удаление человека из первого" +
                " списка не привело к уничтожению этого же человека во втором списке.");
            Step();

            list1.DeleteByIndex(1);
            PrintPersonLists(list1, list2);

            Step();

            Console.WriteLine("Очистите второй список.");
            Step();

            list2.Clear();
            PrintPersonLists(list1, list2);

            Step();

            Console.WriteLine("Чтение персоны с клавиатуры");
            Person ConsolePerson = new Person();
            ReadPerson(ConsolePerson);

            Step();

            Console.WriteLine("Вывод считанной персоны");
            WritePerson(ConsolePerson);

            Step();

            Console.WriteLine("Работа рандомайзера персон.");
            Console.WriteLine("Переназначает один и тот же экземпляр" +
                " класса Person разными данными");

            ConsolePerson = RandomPerson.GetRandomPerson();
            WritePerson(ConsolePerson);

            ConsolePerson = RandomPerson.GetRandomPerson();
            WritePerson(ConsolePerson);

            ConsolePerson = RandomPerson.GetRandomPerson();
            WritePerson(ConsolePerson);

            ConsolePerson = RandomPerson.GetRandomPerson();
            WritePerson(ConsolePerson);

            Step();

            Console.WriteLine("Нажмите любую клавишу, чтобы закончить");
            Step();
        }
    }
}
