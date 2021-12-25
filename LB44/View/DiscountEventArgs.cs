using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountsNamespace;

namespace View
{
    /// <summary>
    /// Класс аргумента для передачи данныых
    /// </summary>
    public class DiscountEventArgs : EventArgs
    {
        /// <summary>
        /// Скидки для передачи
        /// </summary>
        public List<IDiscount> SendingDiscounts { get; }
        
        /// <summary>
        /// Конструктор для передачи скидок
        /// </summary>
        /// <param name="sendingDiscounts">Скидки</param>
        public DiscountEventArgs(List<IDiscount> sendingDiscounts)
        {
            SendingDiscounts = sendingDiscounts;
        }
    }
}
