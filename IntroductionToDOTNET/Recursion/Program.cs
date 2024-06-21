using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			Console.WriteLine($"\n-----------------------\n{n}! = {Factorial(n)}");
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
		static double Factorial(double n)
		{
			if (n == 0) return 1;
			double f = n * Factorial(n - 1);
			Console.WriteLine($"{n}! = {f}");
			return f;
		}
	}
}
