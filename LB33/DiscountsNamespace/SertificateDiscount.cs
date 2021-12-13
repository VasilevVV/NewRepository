using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DiscountsNamespace 
{
	/// <summary>
	/// класс описывающий скидку без срока действи€ (по сертификату)
	/// </summary>
	public class SertificateDiscount : DiscountBase
	{
		/// <summary>
		/// –асчет цены товара со скидкой (по сертификату)
		/// </summary>
		/// <param name="fullPrice">исходна€ цена товара</param>
		/// <returns>цена товара после применени€ скидки</returns>
		public override float GetPrice(float fullPrice)
		{
			if (_priceDecreaser <= fullPrice)
			{
				return base.GetPrice(fullPrice);
			}
			else
			{
				return 0.0f;
			}
		}

		/// <summary>
		/// ѕоказывает информацию о скидке
		/// </summary>
		public override string ToString()
		{
			string period = Period.DateTimeDiscountEnd == DateTime.MaxValue
				   ? ""
				   : $" {Period}";
			return base.ToString() + " руб." + $"{period}";
		}
	}
}