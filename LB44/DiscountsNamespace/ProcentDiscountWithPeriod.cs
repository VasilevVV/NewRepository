using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DiscountsNamespace 
{
	/// <summary>
	/// класс описывающий процентную скидку 
	/// действующую в ограниченном периоде времени
	/// </summary>
	public class ProcentDiscountWithPeriod : ProcentDiscountNoPeriod , IDiscountWithPeriod
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
		/// конструктор, чтобы прост был
		/// </summary>
		public ProcentDiscountWithPeriod()
		{
			Period = new DiscountPeriod();
		}

		/// <summary>
		/// Расчет цены товара со скидкой (по сертификату)
		/// </summary>
		/// <param name="fullPrice">исходная цена товара</param>
		/// <returns>цена товара после применения скидки</returns>
		public override float GetPrice(float fullPrice)
		{
			_period.ChekPriceDecreaserForPeriod(ref _priceDecreaser);
			return base.GetPrice(fullPrice);
		}

		/// <summary>
		/// Показывает информацию о скидке
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