using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

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
        public static IDiscount ReadDiscount(IDiscount readDiscount)
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
                    readDiscount.Company = Console.ReadLine();
                },
            };

            MakeActions(actionsArray);
            return readDiscount;
        }

        /// <summary>
        /// Реализовать действия
        /// </summary>
        /// <param name="actionsArray">Массив реализуемых действий</param>
        public static void MakeActions(Action[] actionsArray)
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
        /// Действия для формирования срока действия скидок
        /// </summary>
        /// <param name="discountPeriod">период для формирования</param>
        /// <returns>Сформированный период</returns>
        public static DiscountPeriod GetPeriodForDiscount
                                     (DiscountPeriod discountPeriod)
        {
            Action[] actionsArray = new Action[]
            {
                () =>
                {
                    Console.WriteLine("Введите дату начала действия " +
                                      "скидки в форматах:\n" +
                                      "--ДД.ММ.ГГГГ ЧЧ:ММ:СС--\n" +
                                      "--ДД.ММ.ГГГГ ЧЧ:ММ--\n" +
                                      "--ДД.ММ--\n" +
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
                                      "--ДД.ММ.ГГГГ ЧЧ:ММ:СС--\n" +
                                      "--ДД.ММ.ГГГГ ЧЧ:ММ--\n" +
                                      "--ДД.ММ--");
                    discountPeriod.DateTimeDiscountEnd =
                                        DateTime.Parse(Console.ReadLine());
                },
            };

            MakeActions(actionsArray);
            
            return discountPeriod;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("ТОЛЬКО СЕГОДНЯ, ТОЛЬКО СЕЙЧАС!!!" +
                "СКИДКИ, СКИДКИ, СКИДКИ!!! ВСЕМ СКИДКИ!!! " +
                "И НА ТУ, И НА ЭТУ, И НА ВОН ТУ!!!\n" +
                "Нажмите любую кнопку, чтобы начать...");
            Console.ReadKey();

            List<IDiscount> discounts = new List<IDiscount>();

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
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Применим скидки\n" +
                                              "Введите цену товара");
                            float originalPrice = 0.0f;
                            bool flag = true;
                            while (originalPrice == 0.0f)
                            {
                                try
                                {
                                    originalPrice = 
                                             float.Parse(Console.ReadLine());
                                    flag = false;
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
                            break;
                        }
                    case "6":
                        {
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Мой дорогой, " +
                                "попробуйте что-нибудь другое");
                            Console.WriteLine("");
                            break;
                        }
                }
            }

            Console.ReadKey();
        }
    }
}
