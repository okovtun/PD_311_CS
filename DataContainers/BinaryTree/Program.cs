//#define TREE_BASE_CHECK
//#define INITIALIZER_LIST_CHECK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace BinaryTree
{
	class Program
	{
		static void Main(string[] args)
		{
			Random rand = new Random(0);
#if TREE_BASE_CHECK
			try
			{
			Console.Write("Введите размер дерева: ");
			int n = Convert.ToInt32(Console.ReadLine());
				Tree tree = new Tree();
				for (int i = 0; i < n; i++)
				{
					tree.Insert(rand.Next(100));
				}
				tree.Print();
				Console.WriteLine($"Минимальное значение в дереве: {tree.Min()}");
				Console.WriteLine($"Максимальное значение в дереве: {tree.Max()}");
				Console.WriteLine($"Количество элементов дерева: {tree.Count()}");
				Console.WriteLine($"Сумма элементов дерева: {tree.Sum()}");
				Console.WriteLine($"Среднее-арифметическое элементов дерева: {tree.Avg()}");

				UniqueTree unique_tree = new UniqueTree();
				for (int i = 0; i < n; i++)
				{
					unique_tree.Insert(rand.Next(100));
				}
				unique_tree.Print();
				Console.WriteLine($"Минимальное значение в дереве: {unique_tree.Min()}");
				Console.WriteLine($"Максимальное значение в дереве: {unique_tree.Max()}");
				Console.WriteLine($"Количество элементов дерева: {unique_tree.Count()}");
				Console.WriteLine($"Сумма элементов дерева: {unique_tree.Sum()}");
				Console.WriteLine($"Среднее-арифметическое элементов дерева: {unique_tree.Avg()}");

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
#endif
#if INITIALIZER_LIST_CHECK
			try
			{
				Tree tree = new Tree() { 50, 25, 75, 16, 32, 64, 91, 98, 2000 };

				tree.Print();
				Console.WriteLine($"Минимальное значение в дереве: {tree.Min()}");
				Console.WriteLine($"Максимальное значение в дереве: {tree.Max()}");
				Console.WriteLine($"Количество элементов дерева: {tree.Count()}");
				Console.WriteLine($"Сумма элементов дерева: {tree.Sum()}");
				Console.WriteLine($"Среднее-арифметическое элементов дерева: {tree.Avg()}");
				Console.WriteLine($"Глубина дерева: {tree.Depth()}");
				//Tree tree = new Tree() { 3, 5, 8, 13, 21 };
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
#endif
			try
			{
				Console.Write("Введите размер дерева: ");
				int n = Convert.ToInt32(Console.ReadLine());
				Tree tree = new Tree();
				for (int i = 0; i < n; i++)
				{
					tree.Insert(rand.Next(100));
				}
				//tree.Print();

				//Изменяем производительность:

				#region Stupid performance measuring
				//Stopwatch sw = new Stopwatch();
				//Console.Write($"Минимальное значение в дереве: {tree.Min()}");
				//Console.WriteLine($"Максимальное значение в дереве: {tree.Max()}");
				//Console.WriteLine($"Количество элементов дерева: {tree.Count()}");
				//Console.WriteLine($"Сумма элементов дерева: {tree.Sum()}");
				//Console.WriteLine($"Среднее-арифметическое элементов дерева: {tree.Avg()}");
				//sw.Start();
				//Console.Write($"Глубина дерева: {tree.Depth()}");
				////Thread.Sleep(1000);
				//sw.Stop();
				//Console.WriteLine($", вычислено за {sw.Elapsed} ms");
				//Console.WriteLine($", вычислено за {sw.Elapsed.TotalMilliseconds} ms");
				////Tree tree = new Tree() { 3, 5, 8, 13, 21 }; 
				#endregion

				TreePerformance<int>.Measure("Минимальное значение в дереве: ", tree.Min);
				TreePerformance<int>.Measure("Максимальное значение в дереве: ", tree.Max);
				TreePerformance<int>.Measure("Сумма элементов дерева: ", tree.Sum);
				TreePerformance<int>.Measure("Количество элементов дерева: ", tree.Count);
				TreePerformance<double>.Measure("Среднее-арифметическое элементов дерева: ", tree.Avg);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}
	}
}
