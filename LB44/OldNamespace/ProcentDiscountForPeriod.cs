using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// класс описывающий процентную скидку 
    /// действующую в ограниченном периоде времени
    /// </summary>
    public class ProcentDiscountForPeriod : DiscountBase
    {
        /// <summary>
        /// константа минимального процента
        /// </summary>
        private const float _minProcent = 0.0F;

        /// <summary>
        /// константа максимального процента
        /// </summary>
        private const float _maxProcent = 100.0F;

        /// <summary>
        /// конструктор для создания композиции с DiscountPeriod
        /// </summary>
        public ProcentDiscountForPeriod()
        {
            Period = new DiscountPeriod();
        }

        /// <summary>
        /// приватное поле период действия скидки
        /// </summary>
        private DiscountPeriod _period;

        /// <summary>
        /// публичный параметр период действия скидки
        /// </summary>
        public DiscountPeriod Period
        {
            get
            {
                return _period;
            }
            set
            {
                _period = value;
            }
        }

        /// <summary>
        /// расчет цены товара с процентной скидкой
        /// цена товара остается прежней,
        /// если применить скидку вне периода ее действия
        /// </summary>
        /// <param name="fullPrice">исходная цена товара</param>
        /// <returns>цена товара после применения скидки</returns>
        public override float GetPrice(float fullPrice)
        {
            if ((_period.DateTimeDiscountStart <= DateTime.Now) &&
                (DateTime.Now <= _period.DateTimeDiscountEnd))
            {
                return fullPrice * (1 - DiscountValue / 100);
            }
            else
            {
                return fullPrice;
            }
        }

        /// <summary>
        /// проверка величины процента
        /// </summary>
        /// <param name="discountProcent">величина процента</param>
        private protected override void CheckDiscount(float discountProcent)
        {
            if ((discountProcent <= _minProcent) ||
                (discountProcent > _maxProcent))
            {
                throw new ArgumentException($"Процент скидки " +
                    $"{discountProcent} должен быть положительным " +
                    $"числом. Больше {_minProcent}, " +
                    $"но меньше или равен {_maxProcent}");
            }
        }
    }
}
