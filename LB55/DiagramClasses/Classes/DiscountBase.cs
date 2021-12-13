using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DiscountsNamespace 
{
	/// <summary>
	/// абстрактный класс скидок
	/// </summary>
	[Serializable]
	public abstract class DiscountBase : IDiscount
	{
		/// <summary>
		/// величина скидки
		/// </summary>
		private float _discountValue;

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
				_priceDecreaser = _discountValue;
			}
		}

		/// <summary>
		/// Уменьшатор цены
		/// </summary>
		private protected float _priceDecreaser;


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
		/// конструктор, чтобы прост был
		/// </summary>
		public DiscountBase()
		{
			Period = new DiscountPeriod();
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
		public override string ToString()
        {
			string shop = Shop ?? "неизвестно";
			return $"В магазине '{shop}' предоставляется скидка " +
				   $"размером {DiscountValue}";
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="fullPrice"></param>
		/// <returns></returns>
        public virtual float GetPrice(float fullPrice)
        {
			Period.ChekPriceDecreaserForPeriod(ref _priceDecreaser);
			return fullPrice - _priceDecreaser;
		}

		/// <summary>
		/// Делает скидку неограниченной периодом времени
		/// </summary>
		public void DoInfiniteDiscount()
        {
			Period.DateTimeDiscountEnd = DateTime.MaxValue;
			Period.DateTimeDiscountStart = DateTime.Now;
		}


	}
}