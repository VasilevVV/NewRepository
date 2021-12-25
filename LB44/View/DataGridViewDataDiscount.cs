using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountsNamespace;

namespace View
{
    /// <summary>
    /// Класс для записи информации о скидки в DataGridView
    /// </summary>
    public class DataGridViewDataDiscount
    {
        /// <summary>
        /// Информация о скидке
        /// </summary>
        private string _discountInformation;

        /// <summary>
        /// Информация о скидке
        /// </summary>
        public string DiscountInformation
        {
            get
            {
                return _discountInformation;
            }
        }

        /// <summary>
        /// Информация о скидке
        /// </summary>
        /// <param name="discount">Скидка</param>
        public DataGridViewDataDiscount(IDiscount discount)
        {
            _discountInformation = discount.ToString();
        }

    }
}
