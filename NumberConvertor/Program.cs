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
				int numberBase;
				int targetNumberBase;

				Console.Write("Enter number: ");
				number = Console.ReadLine().Trim();

				Console.Write("Enter its base: ");
				if(!int.TryParse(Console.ReadLine().Trim(), out numberBase) || numberBase < 2) {
					Console.WriteLine("Base has to be whole number greater then 2");
					continue;
				}

				Console.Write("Enter target base: ");
				if (!int.TryParse(Console.ReadLine().Trim(), out targetNumberBase) || targetNumberBase < 2) {
					Console.WriteLine("Base has to be whole number greater then 2");
					continue;
				}

				string resultNumber = Convertor.Convert(number, numberBase, targetNumberBase);
				Console.WriteLine(string.Format("Converted number {0} from base {1} to base {2} is {3}", number, numberBase, targetNumberBase, resultNumber));
			}
		}
	}
}
