using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// абстрактный класс скидок
    /// </summary>
    public abstract class DiscountBase
    {
        /// <summary>
        /// величина скидки
        /// </summary>
        private float _discountValue;

        /// <summary>
        /// величина скидки
        /// </summary>
        public float DiscountValue
        {
            get
            {
                return _discountValue;
            }
            set
            {
                CheckDiscount(value);
                _discountValue = value;
            }
        }

        /// <summary>
        /// приватное поле магазин, предоставляющий скидку
        /// </summary>
        private string _shop;

        /// <summary>
        /// публичный параметр магазин, предоставляющий скидку
        /// </summary>
        public string Shop
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
        /// расчет цены товара со скидкой
        /// </summary>
        /// <param name="fullPrice">исходная цена товара</param>
        /// <returns>цена товара после применения скидки</returns>
        public virtual float GetPrice(float fullPrice)
        {
            if (DiscountValue <= fullPrice)
            {
                float price = fullPrice - DiscountValue;
                DiscountValue = 0.0f;
                return price;
            }
            else
            {
                float price = 0.0f;
                DiscountValue -= fullPrice;
                return price;
            }
        }
        

        /// <summary>
        /// проверка величины скидки
        /// </summary>
        /// <param name="discountCertificate">величина скидки</param>
        private protected virtual void CheckDiscount(float discount)
        {
            if (discount < 0)
            {
                throw new ArgumentException($"Величина скидки " +
                    $"{discount} должна быть положительным числом");
            }
        }



    }
}
