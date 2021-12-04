using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DiscountsNamespace 
{
	/// <summary>
	/// класс описывающий скидку без срока действия (по сертификату)
	/// </summary>
	public class DiscountNoPeriod : DiscountBase, IDiscountСalculator 
	{
		/// <summary>
		/// конструктор, чтобы прост был
		/// </summary>
		public DiscountNoPeriod()
		{ }

		/// <summary>
		/// Расчет цены товара со скидкой (по сертификату)
		/// </summary>
		/// <param name="fullPrice">исходная цена товара</param>
		/// <returns>цена товара после применения скидки</returns>
		public virtual float GetPrice(float fullPrice)
		{
			if (DiscountValue <= fullPrice)
			{
				float price = fullPrice - DiscountValue;
				DiscountValue = 0.0f;
				return price;
			}
			else
			{
				float price = 0.0f;
				DiscountValue -= fullPrice;
				return price;
			}
		}

		/// <summary>
		/// Показывает информацию о скидке по сертификату
		/// </summary>
		public override string Information
		{
			get
			{
				return base.Information + " рублей.";
			}
		}
	}
}