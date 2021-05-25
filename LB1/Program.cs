using System;
using TPU.LB1.PersonLibrary;


namespace LB1
{
    class Program
    {
        /// <summary>
        /// Вывод на консоль двух списков персон
        /// </summary>
        /// <param name="List1">Первый список</param>
        /// <param name="List2">Второй список</param>
        private static void PrintPersonLists(PersonList List1, 
            PersonList List2)
        {
            Console.WriteLine("Список 1");
            for (int i = 0; i < List1.Number; i++)
            {
                WritePerson(List1.GetPersonByIndex(i));
            }            
            Console.WriteLine();

            Console.WriteLine("Список 2");
            for (int i = 0; i < List2.Number; i++)
            {
                WritePerson(List2.GetPersonByIndex(i));
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
        /// <param name="PersonRead">Персона</param>
        /// <returns>Считанная персона</returns>
        public static Person ReadPerson(Person PersonRead)
        {
            //TODO: Дубли убрать (V)
            Action[] ActionsArray = new Action[4];

            ActionsArray[0] =
                () =>
                {
                    Console.WriteLine("Введите имя");
                    PersonRead.Name = Console.ReadLine();
                };

            ActionsArray[1] =
                () =>
                {
                    Console.WriteLine("Введите фамилию");
                    PersonRead.Surname = Console.ReadLine();
                };

            ActionsArray[2] =
                () =>
                {
                    Console.WriteLine("Введите возраст");
                    PersonRead.Аge = Convert.ToInt32(Console.ReadLine());
                };

            ActionsArray[3] =
                () =>
                {
                    Console.WriteLine("Введите пол м/ж");
                    string gender = Console.ReadLine();

                    //TODO: switch-case               
                    switch (gender)
                    {
                        case "м":
                            PersonRead.Gender = Gender.Male;
                            break;
                        case "ж":
                            PersonRead.Gender = Gender.Female;
                            break;
                        default:
                            throw new ArgumentException("Некорректно введён пол.");                                                     
                    }
                };

            foreach (var Action in ActionsArray)
            {
                while (true)
                {
                    try
                    {
                        Action();
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message}\nПопробуйте снова.");
                    }
                }
            }
            return PersonRead;            
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

            PersonList List1 = new PersonList();
            List1.AddPerson("Mark", "Smith", 15, Gender.Male);
            List1.AddPerson("Marta", "Swim", 35, Gender.Female);
            List1.AddPerson("Мэттью", "Макконахи", 50, Gender.Male);
            
            PersonList List2 = new PersonList();
            List2.AddPerson("Pitter", "Parker", 22, Gender.Male);
            List2.AddPerson("Kate", "Grow", 10, Gender.Female);
            List2.AddPerson("Анна", "Иановна", 32, Gender.Female);

            Console.WriteLine("Списки созданы");
            Step();

            Console.WriteLine("Выведите  содержимое  каждого  списка" +
                "  на  экран  с соответствующими подписями списков");
            Step();

            PrintPersonLists(List1, List2);

            Step(); 

            Console.WriteLine("Добавьте нового человека в первый список");
            Step();

            List1.AddPerson("Новый", "Человек", 1, Gender.Male);

            Console.WriteLine("Новый человек добавлен");
            Step();

            Console.WriteLine("Скопируйте второго человека" +
                " из первого списка в конец второго списка.");
            Console.WriteLine("Покажите, что один и тот же" +
                " человек находится в обоих списках.");
            Step();

            List2.AddPerson(List1.GetPersonByIndex(1));

            PrintPersonLists(List1, List2);

            for (int i = 0; i < List1.Number; i++)
            {
                for (int j = 0; j < List2.Number; j++)
                {
                    if (List1.GetPersonByIndex(i) == List2.GetPersonByIndex(j))
                    {
                        Console.WriteLine($"Индекс того же человека в 1 списке: " +
                            //TODO: RSDN (V)
                            $"{0}", List1.FindPersonIndex(
                                List1.GetPersonByIndex(i).Name, 
                            List1.GetPersonByIndex(i).Surname));
                        Console.WriteLine($"Индекс того же человека во 2 списке: " +
                            //TODO: RSDN (V)
                            $"{0}", List2.FindPersonIndex(
                                List2.GetPersonByIndex(j).Name,
                            List2.GetPersonByIndex(j).Surname));
                    }
                }
            }
            
            Step();

            Console.WriteLine("Удалите второго человека  из " +
                " первого  списка.");
            Console.WriteLine("Покажите, что удаление человека из первого" +
                " списка не привело к уничтожению этого же человека во втором списке.");
            Step();

            List1.DeleteByIndex(1);
            PrintPersonLists(List1, List2);

            Step();

            Console.WriteLine("Очистите второй список.");
            Step();

            List2.Clear();
            PrintPersonLists(List1, List2);

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

            ConsolePerson = RandomPerson.GetRNDperson();
            WritePerson(ConsolePerson);

            ConsolePerson = RandomPerson.GetRNDperson();
            WritePerson(ConsolePerson);

            ConsolePerson = RandomPerson.GetRNDperson();
            WritePerson(ConsolePerson);

            ConsolePerson = RandomPerson.GetRNDperson();
            WritePerson(ConsolePerson);

            Step();

            Console.WriteLine("Нажмите любую клавишу, чтобы закончить");
            Step();
        }
    }
}
