using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// класс описывающий процентную скидку 
    /// действующую в ограниченном периоде времени
    /// </summary>
    public class ProcentDiscountForPeriod : ProcentDiscountForever
    {
        /// <summary>
        /// конструктор для создания композиции с DiscountPeriod
        /// </summary>
        public ProcentDiscountForPeriod() : base()
        {
            Period = new DiscountPeriod();
        }

        /// <summary>
        /// приватное поле период действия скидки
        /// </summary>
        private DiscountPeriod _period;

        /// <summary>
        /// публичный параметр период действия скидки
        /// </summary>
        public DiscountPeriod Period
        {
            get
            {
                return _period;
            }
            set
            {
                _period = value;
            }
        }

        /// <summary>
        /// расчет цены товара с процентной скидкой
        /// цена товара остается прежней,
        /// если применить скидку вне периода ее действия
        /// </summary>
        /// <param name="fullPrice">исходная цена товара</param>
        /// <returns>цена товара после применения скидки</returns>
        public override float GetPrice(float fullPrice)
        {
            if ((_period.DateTimeDiscountStart <= DateTime.Now) &&
                (DateTime.Now <= _period.DateTimeDiscountEnd))
            {
                return base.GetPrice(fullPrice);
            }
            else
            {
                return fullPrice;
            }
        }
    }
}
