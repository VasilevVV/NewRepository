using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountsNamespace
{
    /// <summary>
    /// интерфейс для скидок ограниченных периодом времени
    /// </summary>
    interface IDiscountWithPeriod
    {
        DiscountPeriod Period { get; set; }
    }
}
