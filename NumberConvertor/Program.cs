using NumberConvertor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberConvertor
{
	class Program
	{
		static void Main(string[] args) {
			while (true) {
				string number;

				Console.Write("Enter number: ");
				number = Console.ReadLine().Trim();
				if (string.IsNullOrWhiteSpace(number)) {
					Console.WriteLine("Please insert number.");
					continue;
				}

				Console.Write("Enter its base: ");
				if(!int.TryParse(Console.ReadLine().Trim(), out int numberBase) || numberBase < 2) {
					Console.WriteLine("Base has to be whole number greater then 2");
					continue;
				}

				if (!Convertor.IsNumberValid(number, numberBase)) {
					Console.WriteLine("Number has to be from its base.");
					continue;
				}

				Console.Write("Enter target base: ");
				if (!int.TryParse(Console.ReadLine().Trim(), out int targetNumberBase) || targetNumberBase < 2) {
					Console.WriteLine("Base has to be whole number greater then 2");
					continue;
				}

				string resultNumber = Convertor.Convert(number, numberBase, targetNumberBase);
				Console.WriteLine(string.Format("Converted number {0} from base {1} to base {2} is {3}", number, numberBase, targetNumberBase, resultNumber));
			}
		}
	}
}
