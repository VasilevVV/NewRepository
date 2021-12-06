﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// класс описывающий скидку  по сертификату
    /// действующую в ограниченном периоде времени
    /// </summary>
    public class CertificateDiscountForPeriod : DiscountBase
    {
        /// <summary>
        /// конструктор для создания композиции с DiscountPeriod
        /// </summary>
        public CertificateDiscountForPeriod()
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
        /// расчет цены товара со скидкой по сертификату
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
                //TODO: duplicate (V)
                return base.GetPrice(fullPrice);
            }
            else
            {
                return fullPrice;
            }
        }

            //TODO: duplicate (V)
            
    }
}
