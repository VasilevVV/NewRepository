using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// интерфейс скидок
    /// </summary>
    public interface IDiscount
    {
        /// <summary>
        /// величина скидки
        /// </summary>
        float DiscountValue { get; set; }

        /// <summary>
        /// магазин где действует скидка
        /// </summary>
        string Company { get; set; }

        /// <summary>
        /// расчет цены товара со скидкой
        /// </summary>
        /// <param name="fullPrice">исходная цена товара</param>
        /// <returns>цена товара после применения скидки</returns>
        float GetPrice(float fullPrice);

    }
}
