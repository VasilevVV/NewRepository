using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DiscountsNamespace 
{

	public class ProcentDiscountWithPeriod : ProcentDiscountNoPeriod , IDiscountWithPeriod
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
		/// �����������, ����� ����� ���
		/// </summary>
		public ProcentDiscountWithPeriod()
		{  }

		/// <summary>
		/// ������ ���� ������ �� ������� (�� �����������)
		/// </summary>
		/// <param name="fullPrice">�������� ���� ������</param>
		/// <returns>���� ������ ����� ���������� ������</returns>
		public override float GetPrice(float fullPrice)
		{
			float priceDecreaser = DiscountValue;
			_period.ChekPriceDecreaserForPeriod(ref priceDecreaser);

			return fullPrice * (priceDecreaser / 100.0f);
		}

		public override string Information
		{
			get
			{
				return base.Information + $" {Period}";
			}
		}


	}
}