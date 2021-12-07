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
	[Serializable]
	public class SertificateDiscountWithPeriod : SertificateDiscountNoPeriod , IDiscountWithPeriod
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
		public SertificateDiscountWithPeriod()
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
			_period.ChekPriceDecreaserForPeriod(ref _priceDecreaser);
			return base.GetPrice(fullPrice);
		}

		/// <summary>
		/// ���������� ���������� � ������
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