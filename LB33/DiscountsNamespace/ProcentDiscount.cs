using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DiscountsNamespace 
{
	/// <summary>
	/// ����� ����������� ���������� ������ ��� ����� ��������
	/// </summary>
	public class ProcentDiscount : DiscountBase
	{
		/// <summary>
		/// ��������� ������������ ��������
		/// </summary>
		private const float _minProcent = 0.0F;

		/// <summary>
		/// ��������� ������������� ��������
		/// </summary>
		private const float _maxProcent = 100.0F;

		/// <summary>
		/// �������� �������� ��������
		/// </summary>
		/// <param name="discountProcent">�������� ��������</param>
		private protected override void CheckDiscount(float discountProcent)
		{
			if ((discountProcent < _minProcent) ||
				(discountProcent > _maxProcent))
			{
				throw new ArgumentException($"������� ������ " +
					$"{discountProcent} ������ ���� ������������� " +
					$"������: �� {_minProcent} " +
					$"�� {_maxProcent} ������������");
			}
		}

		/// <summary>
		/// ������ ���� ������ �� ������� (�� �����������)
		/// </summary>
		/// <param name="fullPrice">�������� ���� ������</param>
		/// <returns>���� ������ ����� ���������� ������</returns>
		public override float GetPrice(float fullPrice)
		{
			_priceDecreaser = fullPrice * _priceDecreaser / 100.0f;
			return base.GetPrice(fullPrice);
		}

		/// <summary>
		/// ���������� ���������� � ������
		/// </summary>
		public override string ToString()
		{
			string period = Period.DateTimeDiscountEnd == DateTime.MaxValue
				   ? ""
				   : $" {Period}";
			return base.ToString() + " %." + $"{period}";
		}

	}
}