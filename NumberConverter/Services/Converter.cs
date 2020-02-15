using System;

namespace NumberConvertor.Services
{
	public class Converter
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
			string converted = "";
			do {
				int wholeRest = result % targetNumberBase;
				result /= targetNumberBase;
				converted = wholeRest > 9 ? string.Concat(converted, (char)(wholeRest + 55)) : string.Concat(converted, wholeRest.ToString());
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
			if (numberBase <= 10)
			{
				foreach (char n in number)
					if (!(n >= '0' &&
					      n < ('0' + numberBase))) 
						return false;
			}

			// If base is below or equal to 16, then all 
			// digits should be from 0 to 9 or from 'A'  
			else
			{
				foreach (char n in number)
					if (!((n >= '0' &&
					       n < ('0' + numberBase)) ||
					      (n >= 'A' &&
					       n < ('A' + numberBase - 10))
						))
						return false;
			}
			return true;
		}
	}
}
