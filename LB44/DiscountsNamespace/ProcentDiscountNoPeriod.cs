using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DiscountsNamespace 
{
	/// <summary>
	/// ����� ����������� ���������� ������ ��� ����� ��������
	/// </summary>
	public class ProcentDiscountNoPeriod : DiscountBase, IDiscount
	{

		/// <summary>
		/// �����������, ����� ����� ���
		/// </summary>
		public ProcentDiscountNoPeriod()
		{ }

		/// <summary>
		/// ��������� ������������ ��������
		/// </summary>
		internal const float _minProcent = 0.0F;

		/// <summary>
		/// ��������� ������������� ��������
		/// </summary>
		internal const float _maxProcent = 100.0F;

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
		public virtual float GetPrice(float fullPrice)
		{
			return fullPrice * (1 - _priceDecreaser / 100.0f);
		}

		/// <summary>
		/// ���������� ���������� � ������
		/// </summary>
		public override string Information
		{
			get
			{
				return base.Information + " %.";
			}
		}



	}
}