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
        private string _discountInformation;

        public string DiscountInformation
        {
            get
            {
                return _discountInformation;
            }
        }

        public DataGridViewDataDiscount(IDiscount discount)
        {
            _discountInformation = discount.ToString();
        }
    }
}
