using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DiscountsNamespace 
{
	/// <summary>
	/// абстрактный класс скидок
	/// </summary>
	public abstract class DiscountBase
	{
		/// <summary>
		/// величина скидки
		/// </summary>
		private protected float _discountValue;

		/// <summary>
		/// величина скидки
		/// </summary>
		public float DiscountValue
		{
			get
			{
				return _discountValue;
			}
			set
			{
				CheckDiscount(value);
				_discountValue = value;
			}
		}

		/// <summary>
		/// магазин, предоставляющий скидку
		/// </summary>
		private string _shop;

		/// <summary>
		/// публичный параметр магазин, предоставляющий скидку
		/// </summary>
		public string Shop
		{
			get
			{
				return _shop;
			}
			set
			{
				_shop = value;
			}
		}

		/// <summary>
		/// проверка величины скидки
		/// </summary>
		/// <param name="discountCertificate">величина скидки</param>
		private protected virtual void CheckDiscount(float discount)
		{
			if (discount < 0)
			{
				throw new ArgumentException($"Величина скидки " +
					$"{discount} должна быть положительным числом");
			}
		}

		/// <summary>
		/// Показывает информацию о скидке
		/// </summary>
		public virtual string Information
		{
			get
			{
				string shop = Shop ?? "неизвестно";
				return $"В магазине '{shop}' предоставляется скидка " +
					   $"размером {DiscountValue}";
			}
		}


	}
}