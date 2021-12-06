using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DiscountsNamespace 
{
	/// <summary>
	/// ����� ����������� ������ ��� ����� �������� (�� �����������)
	/// </summary>
	public class SertificateDiscountNoPeriod : DiscountBase, IDiscount 
	{
		/// <summary>
		/// �����������, ����� ����� ���
		/// </summary>
		public SertificateDiscountNoPeriod()
		{ }

		/// <summary>
		/// ������ ���� ������ �� ������� (�� �����������)
		/// </summary>
		/// <param name="fullPrice">�������� ���� ������</param>
		/// <returns>���� ������ ����� ���������� ������</returns>
		public virtual float GetPrice(float fullPrice)
		{
			if (_priceDecreaser <= fullPrice)
			{
				float result = fullPrice - _priceDecreaser;
				DiscountValue = 0.0f;
				return result;
			}
			else
			{
				DiscountValue -= fullPrice;
				return 0.0f;
			}
		}

		/// <summary>
		/// ���������� ���������� � ������
		/// </summary>
		public override string Information
		{
			get
			{
				return base.Information + " ���.";
			}
		}
	}
}