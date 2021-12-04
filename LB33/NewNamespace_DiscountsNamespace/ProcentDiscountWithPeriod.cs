using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DiscountsNamespace 
{

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
		{  }

		/// <summary>
		/// Расчет цены товара со скидкой (по сертификату)
		/// </summary>
		/// <param name="fullPrice">исходная цена товара</param>
		/// <returns>цена товара после применения скидки</returns>
		public override float GetPrice(float fullPrice)
		{
			float priceDecreaser = DiscountValue;
			_period.ChekPriceDecreaserForPeriod(ref priceDecreaser);

			return fullPrice * (priceDecreaser / 100.0f);
		}

		public override string Information
		{
			get
			{
				return base.Information + $" {Period}";
			}
		}


	}
}