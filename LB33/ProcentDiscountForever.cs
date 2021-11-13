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
    public class ProcentDiscountForever : IDiscount
    {
        /// <summary>
        /// приватное поле величина процентной скидки
        /// </summary>
        private float _discountValue;

        /// <summary>
        /// публичный параметр величина процентной скидки
        /// задается в %
        /// </summary>
        public float DiscountValue
        {
            get
            {
                return _discountValue;
            }
            set
            {
                CheckDiscountProcent(value);
                _discountValue = value;
            }
        }

        /// <summary>
        /// константа минимального процента
        /// </summary>
        private const float _minProcent = 0.0F;

        /// <summary>
        /// константа максимального процента
        /// </summary>
        private const float _maxProcent = 100.0F;

        /// <summary>
        /// приватное поле магазин, предоставляющий скидку
        /// </summary>
        private string _shop;

        /// <summary>
        /// публичный параметр магазин, предоставляющий скидку
        /// </summary>
        public string Company
        {
            get
            {
                return _shop;
            }
            set
            {
                _shop = value;
            }
        }

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
        public virtual float GetPrice(float fullPrice)
        {
            return fullPrice * (1 - DiscountValue / 100);
        }

        /// <summary>
        /// проверка величины процента
        /// </summary>
        /// <param name="discountProcent">величина процента</param>
        private void CheckDiscountProcent(float discountProcent)
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
