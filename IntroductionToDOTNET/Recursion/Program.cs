using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Recursion
{
	class Program
	{
		static void Main(string[] args) //Caller - вызывающая функция
		{
			//Function();
			//Stack overflow exception
			//Stack (Стопка) - это модель памяти, 
			//из которой последний записанный элемент считывается первым.
			//Main(args);

			//Console.Write("Введите номер этажа: ");
			//int floor = Convert.ToInt32(Console.ReadLine());
			//Elevator(floor);

			Console.Write("Введите число: ");
			int n = Convert.ToInt32(Console.ReadLine());
			try
			{
				DateTime start = DateTime.Now;
				Console.WriteLine($"\n-----------------------\n{n}! = {Factorial(n)}");
				DateTime end = DateTime.Now;
				TimeSpan duration = end - start;
				Console.WriteLine($"Duration: {duration.ToString("g")}");
			}
			catch (StackOverflowException ex)
			{
				Console.WriteLine($"{ex.GetType()}: {ex.Message}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"{ex.GetType()}: {ex.Message}");
			}
			Console.WriteLine("Calculation DONE");
		}
		static void Function()  //Callee - вызываемая функция
		{
			Console.WriteLine("Привет!");
			Console.WriteLine("Я функция ))");
		}
		static void Elevator(int floor)
		{
			if (floor == 0)
			{
				Console.WriteLine("Вы в подвале");
				return;
			}
			Console.WriteLine($"Вы на {floor} этаже");
			Elevator(floor - 1);
			Console.WriteLine($"Вы на {floor} этаже");
		}
		static BigInteger Factorial(long n)
		{
			BigInteger f = 1;
			for (int i = 1; i < n; i++)
			{
				f *= i;
			}
			return f;
			//if (n == 0) return 1;
			//try
			//{
			//	BigInteger f = n * Factorial(n - 1);
			//	//Console.WriteLine($"{n}! = {f}");
			//	return f;
			//}
			//catch (Exception ex)
			//{
			//	throw ex;
			//}
		}
	}
}
