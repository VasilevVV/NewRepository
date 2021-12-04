using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DiscountsNamespace 
{
	/// <summary>
	/// класс описывающий процентную скидку без срока действия
	/// </summary>
	public class ProcentDiscountNoPeriod : DiscountBase, IDiscountСalculator
	{

		/// <summary>
		/// конструктор, чтобы прост был
		/// </summary>
		public ProcentDiscountNoPeriod()
		{ }

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
					$"числом. Больше {_minProcent}, " +
					$"но меньше или равен {_maxProcent}");
			}
		}

		/// <summary>
		/// Расчет цены товара со скидкой (по сертификату)
		/// </summary>
		/// <param name="fullPrice">исходная цена товара</param>
		/// <returns>цена товара после применения скидки</returns>
		public virtual float GetPrice(float fullPrice)
		{
			return fullPrice * (DiscountValue / 100.0f);
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