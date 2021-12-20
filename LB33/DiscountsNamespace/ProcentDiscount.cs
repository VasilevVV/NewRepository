using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DiscountsNamespace 
{
	/// <summary>
	/// класс описывающий процентную скидку без срока действия
	/// </summary>
	public class ProcentDiscount : DiscountBase
	{
		/// <summary>
		/// константа минимального процента
		/// </summary>
		private const float _minProcent = 0.0F;

		/// <summary>
		/// константа максимального процента
		/// </summary>
		private const float _maxProcent = 100.0F;

		/// <summary>
		/// проверка величины процента
		/// </summary>
		/// <param name="discountProcent">величина процента</param>
		private protected override void CheckDiscount(float discountProcent)
		{
			if ((discountProcent < _minProcent) ||
				(discountProcent > _maxProcent))
			{
				throw new ArgumentException($"Процент скидки " +
					$"{discountProcent} должен быть положительным " +
					$"числом: от {_minProcent} " +
					$"до {_maxProcent} включительно");
			}
		}

		/// <summary>
		/// Расчет цены товара со скидкой (по сертификату)
		/// </summary>
		/// <param name="fullPrice">исходная цена товара</param>
		/// <returns>цена товара после применения скидки</returns>
		public override float GetPrice(float fullPrice)
		{
			_priceDecreaser = fullPrice * _priceDecreaser / 100.0f;
			return base.GetPrice(fullPrice);
		}

		/// <summary>
		/// Показывает информацию о скидке
		/// </summary>
		public override string ToString()
		{
			string period = Period.DateTimeDiscountEnd == DateTime.MaxValue
				   ? ""
				   : $" {Period}";
			return base.ToString() + " %." + $"{period}";
		}

	}
}