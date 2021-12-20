using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountsNamespace;

namespace ConsoleLoader
{
    /// <summary>
    /// Тестирование библиотеки классов Model
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Действия для формирования скидки
        /// </summary>
        /// <param name="readDiscount">скидка для формирования</param>
        /// <returns>Сформированная скидка</returns>
        public static DiscountBase ReadDiscount(DiscountBase readDiscount)
        {
            Action[] actionsArray = new Action[]
            {
                () =>
                {
                    Console.WriteLine("Введите величину скидки");
                    readDiscount.DiscountValue = 
                                        float.Parse(Console.ReadLine());
                },
                () =>
                {
                    Console.WriteLine("Введите магазин/предприятие/" +
                                "организацию/компанию выдавшего скидку");
                    readDiscount.Shop = Console.ReadLine();
                },
            };

            DoActions(actionsArray);
            return readDiscount;
        }

        /// <summary>
        /// Делать действия
        /// </summary>
        /// <param name="actionsArray">Массив реализуемых действий</param>
        public static void DoActions(Action[] actionsArray)
        {
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
                        Console.WriteLine($"\n{ex.Message}\n" +
                                          $"Попробуйте снова.\n");
                    }
                }
            }
        }

        /// <summary>
        /// стоп сообщения в консоль
        /// </summary>
        public static void DoAgainConsoleMessage()
        {
            Console.WriteLine("Нажмите любую кнопку, чтобы продолжить");
            Console.ReadKey();
        }


        /// <summary>
        /// Действия для формирования срока действия скидок
        /// </summary>
        /// <param name="discountPeriod">период для формирования</param>
        /// <returns>Сформированный период</returns>
        public static DiscountPeriod GetPeriodForDiscount
                                     (DiscountPeriod discountPeriod)
        {
            const string dataFormats = ("ДД.ММ.ГГГГ ЧЧ:ММ:СС\n" +
                                  "ДД.ММ.ГГГГ ЧЧ:ММ\n" +
                                  "ДД.ММ");
            var actionsArray = new Action[]
            {
                () =>
                {
                    Console.WriteLine("Введите дату начала действия " +
                                      "скидки в форматах:\n" +
                                      dataFormats +
                                      "\nИли введите: now, сейчас -" +
                                      " чтобы получить текущее время");
                    string readString = Console.ReadLine();
                    if (readString == "now" || readString == "сейчас")
                    {
                        discountPeriod.DateTimeDiscountStart = DateTime.Now;
                    }
                    else
                    {
                        discountPeriod.DateTimeDiscountStart =
                                        DateTime.Parse(readString);
                    }
                },
                () =>
                {
                    Console.WriteLine("\nВведите дату окончания действия " +
                                      "скидки в форматах:\n" +
                                      dataFormats);
                    discountPeriod.DateTimeDiscountEnd =
                                        DateTime.Parse(Console.ReadLine());
                },
            };

            DoActions(actionsArray);
            
            return discountPeriod;
        }

        /// <summary>
        /// процедура проверки программы
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
           Console.WriteLine("ТОЛЬКО СЕГОДНЯ, ТОЛЬКО СЕЙЧАС!!!" +
               "СКИДКИ, СКИДКИ, СКИДКИ!!! ВСЕМ СКИДКИ!!! " +
               "И НА ТУ, И НА ЭТУ, И НА ВОН ТУ!!!");
           DoAgainConsoleMessage();

           var discounts = new List<IDiscount>();

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
               Console.WriteLine("5 - Заканчиваем со скидками " +
                                 "и переходим к покупке!");
               Console.WriteLine("6 - Вам не нужны скидки? " +
                                 "Вы теряете свой уникальный шанс " +
                                 "разбогатеть");
               Console.WriteLine("");
               var consoleKey = Console.ReadLine();

               switch (consoleKey)
               {
                   case "1":
                       {
                            Console.WriteLine("Отличный выбор: " +
                               "бессрочная процентная скидка");
                            //TODO: (V)
                            var discount = (ProcentDiscount)
                                       ReadDiscount(new ProcentDiscount());
                            discount.DoInfiniteDiscount();
                            discounts.Add(discount);
                            Console.WriteLine($"\nДобавлено:\n{discount}");
                            DoAgainConsoleMessage();
                            break;
                       }
                   case "2":
                       {
                            Console.WriteLine("Отличный выбор: " +
                               "временная процентная скидка");
                            //TODO: (V)
                            var discount = (ProcentDiscount)
                                       ReadDiscount(new ProcentDiscount());
                            Console.WriteLine("");
                            discount.Period = 
                                      GetPeriodForDiscount(discount.Period);
                            discounts.Add(discount);
                            Console.WriteLine($"\nДобавлено:\n{discount}");
                            DoAgainConsoleMessage();
                            break;
                       }
                   case "3":
                       {
                            Console.WriteLine("Отличный выбор: " +
                               "бессрочная скидка по сертификату");
                            //TODO: (V)
                            var discount = (SertificateDiscount)
                                       ReadDiscount(new SertificateDiscount());
                            discount.DoInfiniteDiscount();
                            discounts.Add(discount);
                            Console.WriteLine($"\nДобавлено:\n{discount}");
                            DoAgainConsoleMessage();
                            break;
                       }
                   case "4":
                       {
                            Console.WriteLine("Отличный выбор: " +
                               "временная скидка по сертификату");
                            //TODO: (V)
                            var discount = (SertificateDiscount)
                                        ReadDiscount(new SertificateDiscount());
                            discount = (SertificateDiscount)
                                       ReadDiscount(discount);
                            Console.WriteLine("");
                            discount.Period = 
                                      GetPeriodForDiscount(discount.Period);
                            discounts.Add(discount);
                            Console.WriteLine($"\nДобавлено:\n{discount}");
                            DoAgainConsoleMessage();
                            break;
                       }
                   case "5":
                       {
                            Console.WriteLine("Применим скидки. " +
                                             "Введите цену:");
                            float originalPrice = 0.0f;
                            while (originalPrice == 0.0f)
                            {
                               try
                               {
                                   originalPrice = 
                                            float.Parse(Console.ReadLine());
                               }
                               catch (Exception ex)
                               {
                                   Console.WriteLine($"{ex.Message}\n" +
                                                     $"Попробуйте снова.");
                               }
                            }
                            float priceAllDiscounts = originalPrice;
                            //TODO: RSDN (V)
                            for (int i = 0; i < discounts.Count; i++)
                            {
                                discounts[i].GetPrice(priceAllDiscounts);
                                Console.WriteLine($"\n{i + 1} - " +
                                    $"{discounts[i]}\n" +
                                    $"Цена после применения " +
                                    $"этой скидки: {priceAllDiscounts} рублей.");
                            }
                            Console.WriteLine($"\nОтлично!!!\n" +
                               $"После применения всех выбранных скидок " +
                               $"цена стала {priceAllDiscounts} рублей.\n" +
                               $"Список скидок будет очищен");
                            discounts.Clear();
                            DoAgainConsoleMessage();
                            break;
                       }
                   case "6":
                       {
                            return;
                       }
                   default:
                       {
                            Console.WriteLine("Попробуйте " +
                               "что-нибудь другое");
                            Console.WriteLine("");
                            break;
                       }
               }
           }
        }
    }
}
