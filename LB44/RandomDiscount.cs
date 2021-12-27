using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DiscountsNamespace;

namespace Model
{
    /// <summary>
    /// Класс генерации случайной скидки
    /// </summary>
    public class RandomDiscount
    {
        /// <summary>
        /// Рандомайзер чисел
        /// </summary>
        private static readonly Random _random = new Random();

        /// <summary>
        /// Условный максимальный размер случайной скидки по сертификату
        /// </summary>
        private const float _maxSertificateDiscount = 5000.00f;

        /// <summary>
        /// Список магазинов
        /// </summary>
        private static readonly string[] _shops =
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
                        ProcentDiscount discount =
                            new ProcentDiscount();

                        discount = 
                            (ProcentDiscount)RandomParametrs
                            (discount, ProcentDiscount._minProcent,
                            ProcentDiscount._maxProcent);

                        return discount;
                    }
                case 1:
                    {
                        SertificateDiscount discount =
                            new SertificateDiscount();

                        discount =
                            (SertificateDiscount)RandomParametrs
                            (discount, 0, _maxSertificateDiscount);

                        return discount;
                    }
                case 2:
                    {

                        ProcentDiscount discount =
                            new ProcentDiscount();

                        discount =
                            (ProcentDiscount)RandomParametrs
                            (discount, ProcentDiscount._minProcent,
                            ProcentDiscount._maxProcent);

                        discount.Period =
                            GetRandomPeriodForDiscount(discount.Period);

                        return discount;
                    }
                case 3:
                    {
                        SertificateDiscount discount =
                            new SertificateDiscount();

                        discount =
                            (SertificateDiscount)RandomParametrs
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
            randomDiscount.Period.DateTimeDiscountEnd = DateTime.MaxValue;
            randomDiscount.Period.DateTimeDiscountStart = randomDiscount.Period.DateTimeEmergence;

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

            return period;
        }

    }
}
