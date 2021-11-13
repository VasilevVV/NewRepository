using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// класс описывающий скидку по сертификату без срока действия
    /// </summary>
    public class CertificateDiscountForever : IDiscount
    {
        /// <summary>
        /// приватное поле величина скидки по сертификату
        /// </summary>
        private float _discountValue;

        /// <summary>
        /// публичный параметр величина скидки по сертификату
        /// </summary>
        public float DiscountValue
        {
            get
            {
                return _discountValue;
            }
            set
            {
                CheckDiscountCertificate(value);
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
        public CertificateDiscountForever()
        { }

        /// <summary>
        /// расчет цены товара со скидкой по сертификату
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
        /// проверка величины скидки по сертификату
        /// </summary>
        /// <param name="discountCertificate">величина скидки</param>
        private void CheckDiscountCertificate(float discountCertificate)
        {
            if (discountCertificate <= 0)
            {
                throw new ArgumentException($"Величина скидки " +
                    $"по сертификату {discountCertificate} " +
                    $"должна быть положительным числом");
            }
        }
    }
}
