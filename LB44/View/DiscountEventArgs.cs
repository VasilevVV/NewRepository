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
        /// Скидка для передачи
        /// </summary>
        public IDiscount SendingDiscount { get; }

        //TODO: XML
        /// <summary>
        /// Конструктор для передачи скидки
        /// </summary>
        /// <param name="sendingFigure">Скидка</param>
        public DiscountEventArgs(IDiscount sendingDiscount)
        {
            SendingDiscount = sendingDiscount;
        }
    }
}
