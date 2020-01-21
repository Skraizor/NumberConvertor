using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberConvertor.Services
{
	public class Convertor
	{
		/// <summary>
		/// Converts number from numberBase to targetNumberBase via decimal base
		/// </summary>
		/// <param name="number"></param>
		/// <param name="numberBase"></param>
		/// <param name="targetNumberBase"></param>
		/// <returns></returns>
		public static string Convert(string number, int numberBase, int targetNumberBase) {
			string result = number;
			if (numberBase == targetNumberBase)
				return result;
			string decimalNumber = number;
			if (numberBase != 10) {
				decimalNumber = ConvertToDecimal(number, numberBase);
			}
			result = ConvertFromDecimal(decimalNumber, targetNumberBase);
			return result;
		}

		/// <summary>
		/// Converts number from any base to decimal
		/// </summary>
		/// <param name="number"></param>
		/// <param name="numberBase"></param>
		/// <returns></returns>
		private static string ConvertToDecimal(string number, int numberBase) {
			// check if number is negative
			// check if number is whole number
			// if it is non negative whole number convert vi regular method
			int exponent = number.Length - 1;
			return number;
		}

		private static string ConvertFromDecimal(string decimalNumber, int targetNumberBase) {

		}
	}
}
