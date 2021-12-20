using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DiscountsNamespace 
{
	/// <summary>
	/// класс описывающий скидку без срока действия (по сертификату)
	/// </summary>
	public class SertificateDiscount : DiscountBase
	{
		/// <summary>
		/// Расчет цены товара со скидкой (по сертификату)
		/// </summary>
		/// <param name="fullPrice">исходная цена товара</param>
		/// <returns>цена товара после применения скидки</returns>
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
		/// Показывает информацию о скидке
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