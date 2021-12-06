using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Xml.Serialization;

namespace DiscountsNamespace 
{
	/// <summary>
	/// ����������� ����� ������
	/// </summary>
	[Serializable]
	[XmlInclude(typeof(SertificateDiscountNoPeriod))]
	[XmlInclude(typeof(SertificateDiscountWithPeriod))]
	[XmlInclude(typeof(ProcentDiscountNoPeriod))]
	[XmlInclude(typeof(ProcentDiscountWithPeriod))]
	public abstract class DiscountBase
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
		public virtual string Information
		{
			get
			{
				string shop = Shop ?? "����������";
				return $"������ � �������� '{shop}' " +
					   $"�������� {DiscountValue}";
			}
		}


	}
}