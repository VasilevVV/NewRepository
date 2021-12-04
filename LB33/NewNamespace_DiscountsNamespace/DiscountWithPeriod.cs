using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DiscountsNamespace 
{
	/// <summary>
	/// ����� ����������� ������  (�� �����������)
	/// ����������� � ������������ ������� �������
	/// </summary>
	public class DiscountWithPeriod : DiscountNoPeriod , IDiscountWithPeriod
	{
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
		/// ����������� ��� �������� ���������� � DiscountPeriod
		/// </summary>
		public DiscountWithPeriod()
		{
			Period = new DiscountPeriod();
		}

		/// <summary>
		/// ������ ���� ������ �� ������� �� �����������
		/// ���� ������ �������� �������,
		/// ���� ��������� ������ ��� ������� �� ��������
		/// </summary>
		/// <param name="fullPrice">�������� ���� ������</param>
		/// <returns>���� ������ ����� ���������� ������</returns>
		public override float GetPrice(float fullPrice)
		{
			float priceDecreaser = DiscountValue;
			_period.ChekPriceDecreaserForPeriod(ref priceDecreaser);
			DiscountValue = priceDecreaser;

			return base.GetPrice(fullPrice);
		}

		/// <summary>
		/// ���������� ���������� � ������ �� �����������
		/// </summary>
		public override string Information
		{
			get
			{
				return base.Information + $" {Period}";
			}
		}


	}
}