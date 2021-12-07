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
	[Serializable]
	public class SertificateDiscountWithPeriod : SertificateDiscountNoPeriod , IDiscountWithPeriod
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
		public SertificateDiscountWithPeriod()
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