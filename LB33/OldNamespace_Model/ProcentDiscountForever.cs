using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// класс описывающий процентную скидку без срока действия
    /// </summary>
    public class ProcentDiscountForever : DiscountBase
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
        /// конструктор прост чтобы был
        /// </summary>
        public ProcentDiscountForever()
        { }

        /// <summary>
        /// расчет цены товара с процентной скидкой
        /// </summary>
        /// <param name="fullPrice">исходная цена товара</param>
        /// <returns>цена товара после применения скидки</returns>
        public override float GetPrice(float fullPrice)
        {
            return fullPrice * (1 - DiscountValue / 100);
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
