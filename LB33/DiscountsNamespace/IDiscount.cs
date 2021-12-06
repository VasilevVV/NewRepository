using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DiscountsNamespace 
{
	/// <summary>
	/// интерфейс для метода вычисления цены
	/// после применения скидки
	/// в зависимости от того или иного типа скидки
	/// </summary>
	public interface IDiscount  
	{
		/// <summary>
		/// расчет цены товара со скидкой
		/// </summary>
		/// <param name="fullPrice">исходная цена товара</param>
		/// <returns>цена товара после применения скидки</returns>
		float GetPrice(float fullPrice);


		/// <summary>
		/// Показывает информацию о скидке
		/// </summary>
		string Information { get; }
	}
}