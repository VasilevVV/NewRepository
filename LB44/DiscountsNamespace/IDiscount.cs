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
	public interface IDiscount  
	{
		/// <summary>
		/// ������ ���� ������ �� �������
		/// </summary>
		/// <param name="fullPrice">�������� ���� ������</param>
		/// <returns>���� ������ ����� ���������� ������</returns>
		float GetPrice(float fullPrice);


		/// <summary>
		/// ���������� ���������� � ������
		/// </summary>
		string Information { get; }
	}
}