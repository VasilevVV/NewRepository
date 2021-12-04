using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DiscountsNamespace 
{
	/// <summary>
	/// ��������� ��� ������ ���������� ����
	/// ����� ���������� ������
	/// � ����������� �� ���� ��� ����� ���� ������
	/// </summary>
	public interface IDiscount�alculator  
	{
		/// <summary>
		/// ������ ���� ������ �� �������
		/// </summary>
		/// <param name="fullPrice">�������� ���� ������</param>
		/// <returns>���� ������ ����� ���������� ������</returns>
		float GetPrice(float fullPrice);

	}
}