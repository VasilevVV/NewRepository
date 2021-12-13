using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountsNamespace
{
    /// <summary>
    /// Класс генерации случайной скидки
    /// </summary>
    public class RandomDiscount
    {
        /// <summary>
        /// Рандомайзер чисел
        /// </summary>
        private readonly static Random _random = new Random();

        /// <summary>
        /// Условный максимальный размер случайной скидки по сертификату
        /// </summary>
        private const float _maxSertificateDiscount = 5000.00f;

        /// <summary>
        /// Список магазинов
        /// </summary>
        private readonly static string[] _shops =
        {
            "ShopBook", "ShopLine", "ShopTech", "ShopCenter",
            "ShopLab", "DailyShop", "StarShop", "SunShop",
            "DreamShop", "GoodShop"
        };


        /// <summary>
        /// Рандомайзер скидок
        /// </summary>
        /// <returns>Рандомная скидка</returns>
        public static IDiscount GetRandomDiscount()
        {
            int discountType = _random.Next(0, 4);

            switch (discountType)
            {
                case 0:
                    {
                        ProcentDiscountNoPeriod discount =
                            new ProcentDiscountNoPeriod();

                        discount = 
                            (ProcentDiscountNoPeriod)RandomParametrs
                            (discount, ProcentDiscountNoPeriod._minProcent,
                            ProcentDiscountNoPeriod._maxProcent);

                        return discount;
                    }
                case 1:
                    {
                        SertificateDiscountNoPeriod discount =
                            new SertificateDiscountNoPeriod();

                        discount =
                            (SertificateDiscountNoPeriod)RandomParametrs
                            (discount, 0, _maxSertificateDiscount);

                        return discount;
                    }
                case 2:
                    {

                        ProcentDiscountWithPeriod discount =
                            new ProcentDiscountWithPeriod();

                        discount =
                            (ProcentDiscountWithPeriod)RandomParametrs
                            (discount, ProcentDiscountWithPeriod._minProcent,
                            ProcentDiscountWithPeriod._maxProcent);

                        discount.Period =
                            GetRandomPeriodForDiscount(discount.Period);

                        return discount;
                    }
                case 3:
                    {
                        SertificateDiscountWithPeriod discount =
                            new SertificateDiscountWithPeriod();

                        discount =
                            (SertificateDiscountWithPeriod)RandomParametrs
                            (discount, 0, _maxSertificateDiscount);

                        discount.Period =
                            GetRandomPeriodForDiscount(discount.Period);

                        return discount;
                    }
                default:
                    {
                        throw new ArgumentException("Скидка отсутствует.");
                    }
            }
        }

        /// <summary>
        /// Рандомайзер параметров скидки
        /// </summary>
        /// <param name="randomDiscount">Скидка</param>
        /// <param name="minValue">Мин значение скидки</param>
        /// <param name="maxValue">Макс значение скидки</param>
        /// <returns></returns>
        private static DiscountBase RandomParametrs
            (DiscountBase randomDiscount, float minValue, float maxValue)
        {
            randomDiscount.DiscountValue = _random.Next((int)minValue, (int)maxValue);
            randomDiscount.Shop = _shops[_random.Next(_shops.Length)];

            return randomDiscount;
        }

        /// <summary>
        /// Рандомайзер периода действия скидки
        /// </summary>
        /// <param name="period">Период действия скидки</param>
        /// <returns>Период действия скидки</returns>
        private static DiscountPeriod GetRandomPeriodForDiscount
            (DiscountPeriod period)
        {
            DateTime endDateTime = period.DateTimeEmergence;
            while (endDateTime <= period.DateTimeEmergence)
            {
                int year = period.DateTimeEmergence.Year + _random.Next(2);
                int month = _random.Next(1, 12);
                int days = _random.Next
                    (1, DateTime.DaysInMonth(year, month) + 1);

                endDateTime =
                    new DateTime
                            (
                            year, month, days,
                            _random.Next(0, 24),
                            _random.Next(0, 60),
                            _random.Next(0, 60),
                            _random.Next(0, 1000)
                            );
            }
            period.DateTimeDiscountEnd = endDateTime;
            period.DateTimeDiscountStart = period.DateTimeEmergence;

            return period;
        }

    }
}
