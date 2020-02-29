using System;
using NumberConvertor.Services;

namespace NumberConvertor
{
	/// <summary>
	/// Contains the Main method of the program.
	/// </summary>
	class Program
	{
		/// <summary>
		/// The main method of program
		/// </summary>
		/// <param name="args"></param>
		private static void Main(string[] args) {
			while (true) {
				Console.Write("Enter number: ");
				var number = Console.ReadLine().Trim();
				if (string.IsNullOrWhiteSpace(number)) {
					Console.WriteLine("Please insert number.");
					continue;
				}

				Console.Write("Enter its base: ");
				if(!int.TryParse(Console.ReadLine().Trim(), out int numberBase) || numberBase < 2) {
					Console.WriteLine("Base has to be whole number greater then 2");
					continue;
				}

				if (!Converter.IsNumberValid(number, numberBase)) {
					Console.WriteLine("Number has to be from its base.");
					continue;
				}

				Console.Write("Enter target base: ");
				if (!int.TryParse(Console.ReadLine().Trim(), out int targetNumberBase) || targetNumberBase < 2) {
					Console.WriteLine("Base has to be whole number greater then 2");
					continue;
				}

				string resultNumber = Converter.Convert(number, numberBase, targetNumberBase);
				Console.WriteLine(
					$"Converted number {number} from base {numberBase} to base {targetNumberBase} is {resultNumber}");
			}
		}
	}
}
