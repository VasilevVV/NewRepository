using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DiscountsNamespace 
{
	/// <summary>
	/// ����� ����������� ������ ��� ����� �������� (�� �����������)
	/// </summary>
	public class DiscountNoPeriod : DiscountBase, IDiscount�alculator 
	{
		/// <summary>
		/// �����������, ����� ����� ���
		/// </summary>
		public DiscountNoPeriod()
		{ }

		/// <summary>
		/// ������ ���� ������ �� ������� (�� �����������)
		/// </summary>
		/// <param name="fullPrice">�������� ���� ������</param>
		/// <returns>���� ������ ����� ���������� ������</returns>
		public virtual float GetPrice(float fullPrice)
		{
			if (DiscountValue <= fullPrice)
			{
				float price = fullPrice - DiscountValue;
				DiscountValue = 0.0f;
				return price;
			}
			else
			{
				float price = 0.0f;
				DiscountValue -= fullPrice;
				return price;
			}
		}

		/// <summary>
		/// ���������� ���������� � ������ �� �����������
		/// </summary>
		public override string Information
		{
			get
			{
				return base.Information + " ������.";
			}
		}
	}
}