using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DiscountsNamespace 
{
	/// <summary>
	/// класс описывающий скидку без срока действи€ (по сертификату)
	/// </summary>
	public class SertificateDiscountNoPeriod : DiscountBase, IDiscount 
	{
		/// <summary>
		///  онструктор, чтобы прост был
		/// </summary>
		public SertificateDiscountNoPeriod()
		{ }

		/// <summary>
		/// –асчет цены товара со скидкой (по сертификату)
		/// </summary>
		/// <param name="fullPrice">исходна€ цена товара</param>
		/// <returns>цена товара после применени€ скидки</returns>
		public virtual float GetPrice(float fullPrice)
		{
			if (_priceDecreaser <= fullPrice)
			{
				float result = fullPrice - _priceDecreaser;
				DiscountValue = 0.0f;
				return result;
			}
			else
			{
				DiscountValue -= fullPrice;
				return 0.0f;
			}
		}

		/// <summary>
		/// ѕоказывает информацию о скидке
		/// </summary>
		public override string Information
		{
			get
			{
				return base.Information + " руб.";
			}
		}
	}
}