using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DiscountsNamespace 
{
	/// <summary>
	/// класс описывающий процентную скидку без срока действи€
	/// </summary>
	public class ProcentDiscountNoPeriod : DiscountBase, IDiscount
	{

		/// <summary>
		/// конструктор, чтобы прост был
		/// </summary>
		public ProcentDiscountNoPeriod()
		{ }

		/// <summary>
		/// константа минимального процента
		/// </summary>
		internal const float _minProcent = 0.0F;

		/// <summary>
		/// константа максимального процента
		/// </summary>
		internal const float _maxProcent = 100.0F;

		/// <summary>
		/// проверка величины процента
		/// </summary>
		/// <param name="discountProcent">величина процента</param>
		private protected override void CheckDiscount(float discountProcent)
		{
			if ((discountProcent < _minProcent) ||
				(discountProcent > _maxProcent))
			{
				throw new ArgumentException($"ѕроцент скидки " +
					$"{discountProcent} должен быть положительным " +
					$"числом: от {_minProcent} " +
					$"до {_maxProcent} включительно");
			}
		}

		/// <summary>
		/// –асчет цены товара со скидкой (по сертификату)
		/// </summary>
		/// <param name="fullPrice">исходна€ цена товара</param>
		/// <returns>цена товара после применени€ скидки</returns>
		public virtual float GetPrice(float fullPrice)
		{
			return fullPrice * (1 - _priceDecreaser / 100.0f);
		}

		/// <summary>
		/// ѕоказывает информацию о скидке
		/// </summary>
		public override string Information
		{
			get
			{
				return base.Information + " %.";
			}
		}



	}
}