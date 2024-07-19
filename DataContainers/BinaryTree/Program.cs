#define TREE_BASE_CHECK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
	class Program
	{
		static void Main(string[] args)
		{
			Random rand = new Random(0);
#if TREE_BASE_CHECK
			Console.Write("Введите размер дерева: ");
			int n = Convert.ToInt32(Console.ReadLine());
			try
			{
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
			//Tree tree = new Tree() { 3, 5, 8, 13, 21 };
		}
	}
}
