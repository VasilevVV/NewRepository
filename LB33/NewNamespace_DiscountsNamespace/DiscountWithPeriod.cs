using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DiscountsNamespace 
{
	/// <summary>
	/// класс описывающий скидку  (по сертификату)
	/// действующую в ограниченном периоде времени
	/// </summary>
	public class DiscountWithPeriod : DiscountNoPeriod , IDiscountWithPeriod
	{
		/// <summary>
		/// период действия скидки
		/// </summary>
		private DiscountPeriod _period;

		/// <summary>
		/// период действия скидки
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
		/// конструктор для создания композиции с DiscountPeriod
		/// </summary>
		public DiscountWithPeriod()
		{
			Period = new DiscountPeriod();
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
			float priceDecreaser = DiscountValue;
			_period.ChekPriceDecreaserForPeriod(ref priceDecreaser);
			DiscountValue = priceDecreaser;

			return base.GetPrice(fullPrice);
		}

		/// <summary>
		/// Показывает информацию о скидке по сертификату
		/// </summary>
		public override string Information
		{
			get
			{
				return base.Information + $" {Period}";
			}
		}


	}
}