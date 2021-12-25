using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DiscountsNamespace 
{
	//TODO: coder (V)
	/// <summary>
	/// Базовый класс для скидок
	/// </summary>
	public abstract class DiscountBase : IDiscount
	{
		/// <summary>
		/// Величина скидки
		/// </summary>
		private float _discountValue;

		/// <summary>
		/// Величина скидки
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
				_priceDecreaser = _discountValue;
			}
		}

		/// <summary>
		/// Уменьшитель цены
		/// </summary>
		private protected float _priceDecreaser;


		/// <summary>
		/// Магазин, предоставляющий скидку
		/// </summary>
		private string _shop;

		/// <summary>
		/// Магазин, предоставляющий скидку
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
		/// Период действия скидки
		/// </summary>
		private DiscountPeriod _period;

		/// <summary>
		/// Период дейсвтвия скидки
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
		/// Композиция с DiscountPeriod
		/// </summary>
		public DiscountBase()
		{
			Period = new DiscountPeriod();
		}


		/// <summary>
		/// Проверка величины скидки
		/// </summary>
		/// <param name="discount">Величина скидки</param>
		private protected virtual void CheckDiscount(float discount)
		{
			if (discount < 0)
			{
				throw new ArgumentException($"Величина скидки " +
					$"{discount} должна быть положительным числом.");
			}
		}

		/// <summary>
		/// Информация о скидке
		/// </summary>
		public override string ToString()
        {
			string shop = Shop ?? "Неизвестно";
			return $"В магазине '{shop}' предоставляется скидка " +
				   $"величиной {DiscountValue}";
		}

		/// <summary>
		/// Расчет цены со скидкой
		/// </summary>
		/// <param name="fullPrice">Исходная цена товара</param>
		/// <returns>Цена товара после применения скидки</returns>
        public virtual float GetPrice(float fullPrice)
        {
			return fullPrice - Period.ChekPriceDecreaserForPeriod(_priceDecreaser);
		}

		/// <summary>
		/// Сделать скидку бессрочной
		/// </summary>
		public void DoInfiniteDiscount()
		{
			Period.DateTimeDiscountEnd = DateTime.MaxValue;
			Period.DateTimeDiscountStart = DateTime.Now;
		}
	}
}