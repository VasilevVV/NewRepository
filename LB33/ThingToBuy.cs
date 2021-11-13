using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// класс описывающий покупаемую вищичку
    /// </summary>
    public class ThingToBuy
    {
        /// <summary>
        /// приватное поле исходная цена вещички
        /// </summary>
        private float _originalPrice;

        /// <summary>
        /// публичный параметр исходная цена вещички
        /// </summary>
        public float OriginalPrice
        {
            get
            {
                return _originalPrice;
            }
            set
            {
                CheckPrice(value);
                _originalPrice = value;
            }
        }

        /// <summary>
        /// приватное поле магазин, продающий вещичку
        /// </summary>
        private string _shop;

        /// <summary>
        /// публичный параметр магазин, продающий вещичку
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
        /// приватное поле название вещички
        /// </summary>
        private string _name;

        /// <summary>
        /// публичный параметр название вещички
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// конструктор прост чтобы был
        /// </summary>
        public ThingToBuy()
        { }

        /// <summary>
        /// приватное поле скидки, применяемые к вещичке
        /// </summary>
        private List<IDiscount> _discounts = new List<IDiscount>();

        /// <summary>
        /// публичный параметр скидки, применяемые к вещичке
        /// </summary>
        public List<IDiscount> Discounts
        {
            get
            {
                return _discounts;
            }
        }


        public float GetPriceWithDiscount(IDiscount discount)
        {
            float priceAllDiscounts = OriginalPrice;
            var ie = Discounts.GetEnumerator();
            while (ie.MoveNext())
            {
                priceAllDiscounts = ie.Current.GetPrice(priceAllDiscounts);
            }
            ie.Dispose();
            return priceAllDiscounts;
        }

        /// <summary>
        /// расчитать цену со всеми скидками на вещичку
        /// </summary>
        /// <returns></returns>
        public float GetPriceAllDiscounts()
        {
            float priceAllDiscounts = OriginalPrice;
            var ie = Discounts.GetEnumerator();
            while (ie.MoveNext())
            {
                priceAllDiscounts = ie.Current.GetPrice(priceAllDiscounts);
            }
            ie.Dispose();
            return priceAllDiscounts;
        }

        /// <summary>
        /// проверка цены вещички
        /// </summary>
        /// <param name="somePrice">цена вещички</param>
        private void CheckPrice(float somePrice)
        {
            if (somePrice < 0)
            {
                throw new ArgumentException($"Цена " +
                    $"{somePrice} должна быть " +
                    $"положительным числом");
            }
        }


    }
}
