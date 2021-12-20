using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DiscountsNamespace 
{
	//TODO: coder (V)
	/// <summary>
	/// ����������� ����� ������
	/// </summary>
	public abstract class DiscountBase : IDiscount
	{
		/// <summary>
		/// �������� ������
		/// </summary>
		private float _discountValue;

		/// <summary>
		/// �������� ������
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
		/// ���������� ����
		/// </summary>
		private protected float _priceDecreaser;


		/// <summary>
		/// �������, ��������������� ������
		/// </summary>
		private string _shop;

		/// <summary>
		/// ��������� �������� �������, ��������������� ������
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
		/// ������ �������� ������
		/// </summary>
		private DiscountPeriod _period;

		/// <summary>
		/// ������ �������� ������
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
		/// �����������, ����� ����� ���
		/// </summary>
		public DiscountBase()
		{
			Period = new DiscountPeriod();
		}


		/// <summary>
		/// �������� �������� ������
		/// </summary>
		/// <param name="discountCertificate">�������� ������</param>
		private protected virtual void CheckDiscount(float discount)
		{
			if (discount < 0)
			{
				throw new ArgumentException($"�������� ������ " +
					$"{discount} ������ ���� ������������� ������");
			}
		}

		/// <summary>
		/// ���������� ���������� � ������
		/// </summary>
		public override string ToString()
        {
			string shop = Shop ?? "����������";
			return $"� �������� '{shop}' ��������������� ������ " +
				   $"�������� {DiscountValue}";
		}

		/// <summary>
		/// ������ ���� �� ������
		/// </summary>
		/// <param name="fullPrice">���� ������</param>
		/// <returns>���� ������ ����� ���������� ������</returns>
        public virtual float GetPrice(float fullPrice)
        {
			Period.ChekPriceDecreaserForPeriod(ref _priceDecreaser);
			return fullPrice - _priceDecreaser;
		}

		/// <summary>
		/// ������ ������ �������������� �������� �������
		/// </summary>
		public void DoInfiniteDiscount()
		{
			Period.DateTimeDiscountEnd = DateTime.MaxValue;
			Period.DateTimeDiscountStart = DateTime.Now;
		}
	}
}