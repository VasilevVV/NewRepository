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
        /// Реализовать действия
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
                        Console.WriteLine($"{ex.Message}\n" +
                                          $"Попробуйте снова.");
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
                                  "ДД.ММ\n");
            Action[] actionsArray = new Action[]
            {
                () =>
                {
                    //TODO: duplicate (V)
                    Console.WriteLine("Введите дату начала действия " +
                                      "скидки в форматах:\n" +
                                      dataFormats +
                                      "Или введите: now, сейчас -" +
                                      " чтобы получить текущее время");
                    string readString = Console.ReadLine();
                    if (readString == "now" || readString == "сейчас")
                    {
                        discountPeriod.DateTimeDiscountStart = DateTime.Now;
                    }
                    else
                    {
                        discountPeriod.DateTimeDiscountStart =
                                        DateTime.Parse(Console.ReadLine());
                    }
                },
                () =>
                {
                    Console.WriteLine("Введите дату окончания действия " +
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
            ProcentDiscountNoPeriod discountWithPeriod = new ProcentDiscountNoPeriod();
            /*discountWithPeriod.Period.DateTimeDiscountStart = DateTime.Now;
            discountWithPeriod.Period.DateTimeDiscountEnd = DateTime.Now.AddDays(7);*/
            discountWithPeriod.DiscountValue = 10;
            Console.WriteLine($"{ discountWithPeriod.Information}");
            Console.WriteLine($"////////////////");
            float asdf = discountWithPeriod.GetPrice(300);
            Console.WriteLine($"////////////////");
            Console.WriteLine($"{ discountWithPeriod.Information}");
            Console.WriteLine($"{ asdf}");



           /*
           Console.WriteLine("ТОЛЬКО СЕГОДНЯ, ТОЛЬКО СЕЙЧАС!!!" +
               "СКИДКИ, СКИДКИ, СКИДКИ!!! ВСЕМ СКИДКИ!!! " +
               "И НА ТУ, И НА ЭТУ, И НА ВОН ТУ!!!");
           DoAgainConsoleMessage();

           List<DiscountBase> discounts = new List<DiscountBase>();

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
                           ProcentDiscountForever discount = 
                                               new ProcentDiscountForever();
                           discount = 
                             (ProcentDiscountForever)ReadDiscount(discount);
                           discounts.Add(discount);
                           Console.WriteLine("Скидка добавлена");
                           DoAgainConsoleMessage();
                           break;
                       }
                   case "2":
                       {
                           Console.WriteLine("Отличный выбор: " +
                               "временная процентная скидка");
                           ProcentDiscountForPeriod discount = 
                                             new ProcentDiscountForPeriod();
                           discount = (ProcentDiscountForPeriod)
                                       ReadDiscount(discount);
                           Console.WriteLine("");
                           discount.Period = 
                                      GetPeriodForDiscount(discount.Period);
                           discounts.Add(discount);
                           Console.WriteLine("Скидка добавлена");
                           DoAgainConsoleMessage();
                           break;
                       }
                   case "3":
                       {
                           Console.WriteLine("Отличный выбор: " +
                               "бессрочная скидка по сертификату");
                           CertificateDiscountForever discount = 
                                           new CertificateDiscountForever();
                           discount = (CertificateDiscountForever)
                                       ReadDiscount(discount);
                           discounts.Add(discount);
                           Console.WriteLine("Скидка добавлена");
                           DoAgainConsoleMessage();
                           break;
                       }
                   case "4":
                       {
                           Console.WriteLine("Отличный выбор: " +
                               "временная скидка по сертификату");
                           CertificateDiscountForPeriod discount = 
                                         new CertificateDiscountForPeriod();
                           discount = (CertificateDiscountForPeriod)
                                       ReadDiscount(discount);
                           Console.WriteLine("");
                           discount.Period = 
                                      GetPeriodForDiscount(discount.Period);
                           discounts.Add(discount);
                           Console.WriteLine("Скидка добавлена");
                           DoAgainConsoleMessage();
                           break;
                       }
                   case "5":
                       {
                           Console.WriteLine("Применим скидки\n" +
                                             "Введите цену товара");
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
                           var ie = discounts.GetEnumerator();
                           while (ie.MoveNext())
                           {
                               priceAllDiscounts = 
                                     ie.Current.GetPrice(priceAllDiscounts);
                           }
                           ie.Dispose();
                           Console.WriteLine($"Отлично!!!\n" +
                               $"Теперь цена {priceAllDiscounts}\n" +
                               $"вместо {originalPrice}");
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
           */



           Console.ReadKey();
        }
    }
}
