using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DiscountsNamespace 
{
	/// <summary>
	/// ����� ����������� ������ ��� ����� �������� (�� �����������)
	/// </summary>
	public class SertificateDiscount : DiscountBase
	{
		/// <summary>
		/// ������ ���� ������ �� ������� (�� �����������)
		/// </summary>
		/// <param name="fullPrice">�������� ���� ������</param>
		/// <returns>���� ������ ����� ���������� ������</returns>
		public override float GetPrice(float fullPrice)
		{
			if (_priceDecreaser <= fullPrice)
			{
				return base.GetPrice(fullPrice);
			}
			else
			{
				return 0.0f;
			}
		}

		/// <summary>
		/// ���������� ���������� � ������
		/// </summary>
		public override string ToString()
		{
			string period = Period.DateTimeDiscountEnd == DateTime.MaxValue
				   ? ""
				   : $" {Period}";
			return base.ToString() + " ���." + $"{period}";
		}
	}
}