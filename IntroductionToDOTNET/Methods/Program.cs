using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
	class Program
	{
		static void Main(string[] args)
		{
			//int len = args.Length;
			//int[] arr = new int[] { };
			//Console.WriteLine(arr.Length);
			////Console.WriteLine(Sum(new int[] { 3,5,8,13,21,34 }));
			//foreach (string i in args)
			//{
			//	Console.Write(i+"\t");
			//}

			List<int> l_numbers = new List<int>();
			foreach (string i in args) l_numbers.Add(Convert.ToInt32(i));
			Console.WriteLine(Sum(l_numbers.ToArray()));
			//Console.WriteLine(Sum(new int[] { 3,5,8,13,21,34}));
			int a, b;
			Input(out a, out b);
			Console.WriteLine($"{a}\t{b}");
			Exchange(ref a, ref b);
			Console.WriteLine($"{a}\t{b}");
		}
		//ref должны быть проиницализированы до передачи в функцию
		//out функция инициализирует принимаемые параметры
		static void Input(out int a, out int b)
		{
			Console.Write("Введите значение переменной 'a': ");
			a = Convert.ToInt32(Console.ReadLine());
			Console.Write("Введите значение переменной 'b': ");
			b = Convert.ToInt32(Console.ReadLine());
		}
		static void Exchange(ref int a, ref int b)
		{
			int buffer = a;
			a = b;
			b = buffer;
		}
		static int Sum(params int[] numbers)
		{
			int sum = 0;
			foreach (int i in numbers) sum += i;
			return sum;
		}
	}
}
