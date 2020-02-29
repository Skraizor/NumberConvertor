using System;

namespace NumberConvertor.Services
{
	/// <summary>
	/// Obsahuje funkce nutné pro převod čísel v číselných soustavách
	/// </summary>
	public class Converter
	{
		/// <summary>
		/// Převádí čísla ze soustavy numberBase do soustavy targetNumberBase a to přes desítkovou soustavu
		/// </summary>
		/// <param name="number">Číslo, které chceme převést</param>
		/// <param name="numberBase">Číselná soustava čísla, které chceme převést</param>
		/// <param name="targetNumberBase">Číselná soustava, do které chceme dané číslo převést</param>
		/// <returns>
		/// Převedené číslo z "numberBase" do "targetNumberBase"
		/// </returns>
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
		/// Převádí číslo z jakékoliv báze do desítkové
		/// </summary>
		/// <param name="number">Číslo v jakékoliv soustavě</param>
		/// <param name="numberBase">Číselná soustava dané čísla</param>
		/// <returns>
		/// Číslo v desítkové soustavě
		/// </returns>
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
		/// Převádí číslo z desítkové soustavy do jakékoliv jiné
		/// </summary>
		/// <param name="decimalNumber">Číslo v desítkové soustavě</param>
		/// <param name="targetNumberBase">Číselná soustava, do které chceme číslo převést</param>
		/// <returns>
		/// Číslo převedené z desítkové soustavy do "targetNumberBase"
		/// </returns>
		private static string ConvertFromDecimal(string decimalNumber, int targetNumberBase) {
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
		/// Kontroluje, zda je zadané číslo z dané soustavy. Pokud není, nekončí chybou, ale program pokračuje dál.
		/// </summary>
		/// <param name="number">Číslo, které chceme ověřit.</param>
		/// <param name="numberBase">Číselná báze, proti které ověřujeme dané číslo.</param>
		/// <returns>
		/// Informaci, zda dané číslo patří do dané soustavy.
		/// </returns>
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
