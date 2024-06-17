//#deine INTEGRAL_TYPES
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
	class Program
	{
		static readonly string delimiter = "\n------------------------------------------------\n";
		static void Main(string[] args)
		{
#if INTEGRAL_TYPES
			Console.WriteLine("ushort");
			Console.WriteLine($"Занимает {sizeof(ushort)} Байта");
			Console.WriteLine($"Диапазон принимаемых значений: {ushort.MinValue} ... {ushort.MaxValue}");
			Console.WriteLine(delimiter);

			Console.WriteLine("short");
			Console.WriteLine($"Занимает {sizeof(short)} Байта");
			Console.WriteLine($"Диапазон принимаемых значений: {short.MinValue} ... {short.MaxValue}");
			Console.WriteLine(delimiter);

			Console.WriteLine("uint");
			Console.WriteLine($"Занимает {sizeof(uint)} Байта");
			Console.WriteLine($"Диапазон принимаемых значений: {uint.MinValue} ... {uint.MaxValue}");
			Console.WriteLine(delimiter);

			Console.WriteLine("uint");
			Console.WriteLine($"Занимает {sizeof(int)} Байта");
			Console.WriteLine($"Диапазон принимаемых значений: {int.MinValue} ... {int.MaxValue}");
			Console.WriteLine(delimiter);

			Console.WriteLine("ulong");
			Console.WriteLine($"Занимает {sizeof(ulong)} Байта");
			Console.WriteLine($"Диапазон принимаемых значений: {ulong.MinValue} ... {ulong.MaxValue}");
			Console.WriteLine(delimiter); 
#endif

			//	float, double, decimal

			Console.WriteLine("float");
			Console.WriteLine($"Занимает {sizeof(float)} Байта");
			Console.WriteLine($"Диапазон принимаемых значений: {float.MinValue} ... {float.MaxValue}");
			Console.WriteLine(delimiter);

			Console.WriteLine("double");
			Console.WriteLine($"Занимает {sizeof(double)} Байта");
			Console.WriteLine($"Диапазон принимаемых значений: {double.MinValue} ... {double.MaxValue}");
			Console.WriteLine(delimiter);

			Console.WriteLine("decimal");
			Console.WriteLine($"Занимает {sizeof(decimal)} Байта");
			Console.WriteLine($"Диапазон принимаемых значений: {decimal.MinValue} ... {decimal.MaxValue}");
			Console.WriteLine(delimiter);

		}
	}
}
