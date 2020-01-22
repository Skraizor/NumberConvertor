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
			if (numberBase == targetNumberBase)
				return number;
			string decimalNumber = number;
			if (numberBase != 10) {
				decimalNumber = ConvertToDecimal(number, numberBase);
			}
			if (targetNumberBase == 10) {
				return ConvertToDecimal(number, numberBase);
			}
			return ConvertFromDecimal(decimalNumber, targetNumberBase);
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
			// number * base ^ exponent
			int result = 0;
			foreach (char n in number) {
				int numFromChar = (n >= '0' && n <= '9') ? n - '0' : n - 55;
				result += numFromChar * (int)Math.Pow(numberBase, exponent);
				exponent -= 1;
			}
			return result.ToString();
		}

		/// <summary>
		/// Converts number from decimal to any base
		/// </summary>
		/// <param name="decimalNumber"></param>
		/// <param name="targetNumberBase"></param>
		/// <returns></returns>
		private static string ConvertFromDecimal(string decimalNumber, int targetNumberBase) {
			// number / base = result - modulo
			int result = int.Parse(decimalNumber);
			int wholeRest;
			string converted = "";
			do {
				wholeRest = result % targetNumberBase;
				result = result / targetNumberBase;
				if (wholeRest > 9) {
					converted = string.Concat(converted, (char)(wholeRest + 55));
				}
				else {
					converted = string.Concat(converted, wholeRest.ToString());
				}
			} while (result != 0);
			char[] res = converted.ToCharArray();
			Array.Reverse(res);
			return new string(res);
		}

		/// <summary>
		/// Checks if number is in given base
		/// </summary>
		/// <param name="number"></param>
		/// <param name="numberBase"></param>
		/// <returns></returns>
		public static bool IsNumberValid(string number, int numberBase) {
			// If base is below or equal to 10, then all 
			// digits should be from 0 to 9. 
			else if (numberBase <= 10) {
				for (int i = 0; i < number.Length; i++)
					if (!(number[i] >= '0' &&
						 number[i] < ('0' + numberBase))) 
            return false;
			}

			// If base is below or equal to 16, then all 
			// digits should be from 0 to 9 or from 'A'  
			else {
				for (int i = 0; i < number.Length; i++)
					if (!((number[i] >= '0' &&
							number[i] < ('0' + numberBase)) ||
							(number[i] >= 'A' &&
							 number[i] < ('A' + numberBase - 10))
						))
						return false;
			}
			return true;
		}
	}
}
