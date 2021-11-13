using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ConsoleLoader
{
    class Program
    {
        public static IDiscount ReadDiscount(IDiscount readDiscount)
        {
            Action[] actionsArray = new Action[]
            {
                () =>
                {
                    Console.WriteLine("Введите величину скидки");
                    readDiscount.DiscountValue = float.Parse(Console.ReadLine());
                },
                () =>
                {
                    Console.WriteLine("Введите магазин/предприятие/организацию/");
                    readDiscount.Company = Console.ReadLine();
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
            return readDiscount;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("ТОЛЬКО СЕГОДНЯ, ТОЛЬКО СЕЙЧАС!!!" +
                "СКИДКИ, СКИДКИ, СКИДКИ!!! ВСЕМ СКИДКИ!!! " +
                "И НА ТУ, И НА ЭТУ, И НА ВОН ТУ!!!\n" +
                "Нажмите любую кнопку, чтобы начать...");
            Console.ReadLine();

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Какую скидочку хотите?");
                Console.WriteLine("1 - Бессрочную процентную СКИДИЩЕ " +
                                  "!!!до 100%!!!");
                Console.WriteLine("2 - Временную процентную скидочку " +
                                  "!!!до 100%!!!");
                Console.WriteLine("3 - Бессрочную скидку по сертификату " +
                                  "!!!на ЛЮБУЮ сумму!!!");
                Console.WriteLine("4 - Временную скидку по сертификату " +
                                  "!!!на ЛЮБУЮ сумму!!!");
                Console.WriteLine("5 - Вам не нужны скидки? " +
                                  "Вы теряете свой уникальный шанс разбогатеть");
                Console.WriteLine("");
                var consoleKey = Console.ReadLine();



                switch (consoleKey)
                {
                    case "1":
                        {
                            ReadDiscount();
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Пирожочек");
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Вареник");
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Катлетка");
                            break;
                        }
                    case "5":
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Мой дорогой, попробуйте что-нибудь другое");
                            Console.WriteLine("");
                            break;
                        }
                }
            }

            Console.ReadKey();
        }
    }
}
