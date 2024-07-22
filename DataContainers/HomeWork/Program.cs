using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
	class Tree
	{
		public class Element
		{
			public int Data;
			public Element pLeft;
			public Element pRight;
			public Element(int Data, Element pLeft = null, Element pRight = null)
			{
				this.Data = Data;
				this.pLeft = pLeft;
				this.pRight = pRight;
				Console.WriteLine($"EConstructor : \t {GetHashCode()}");
			}
			~Element()
			{
				Console.WriteLine($"EDestructor: {GetHashCode()}");
			}
		}
		public int MinValue() // Метод для поиска минимального значения
		{
			return FindMinValue(Root);
		}

		private int FindMinValue(Element node) // Вспомогательный метод для поиска минимального значения
		{
			if (node.pLeft == null)
				return node.Data;
			else
				return FindMinValue(node.pLeft);
		}
		public int MaxValue() // Метод для поиска максимального значения
		{
			return FindMaxValue(Root);
		}

		private int FindMaxValue(Element node)
		{
			if (node.pRight == null)
				return node.Data;
			else
				return FindMaxValue(node.pRight);
		}
		public int Count() // Метод для подсчета количества элементов
		{
			return CountNodes(Root);
		}

		private int CountNodes(Element node)
		{
			if (node == null)
				return 0;
			else
				return 1 + CountNodes(node.pLeft) + CountNodes(node.pRight);
		}
		public int Sum() // Метод для подсчета суммы элементов в дереве
		{
			return CalculateSum(Root);
		}

		private int CalculateSum(Element node)
		{
			if (node == null)
				return 0;
			else
				return node.Data + CalculateSum(node.pLeft) + CalculateSum(node.pRight);
		}

		public double Avg() // Метод для вычисления среднего значения элементов в дереве
		{
			return (double)Sum() / Count();
		}
		public Element Root; // Корневой элемент дерева
		public Tree() // Конструктор для дерева
		{
			Console.WriteLine($"TConstructor: {GetHashCode()}");
		}
		~Tree()
		{
			Console.WriteLine($"TDestructor: {GetHashCode()}");
		}
		public void insert(int Data, Element Root) // Метод для вставки элемента
		{
			// Если корень дерева пуст, создаем новый элемент и устанавливаем его как корень дерева
			if (this.Root == null) this.Root = new Element(Data);
			// Если текущий узел (Root) пуст, завершаем рекурсию
			if (Root == null) return;
			if (Data < Root.Data)
			{
				// Если у левого потомка Root нет элемента, создаем новый элемент и устанавливаем его как левого потомка
				if (Root.pLeft == null) Root.pLeft = new Element(Data);
				// Если левый потомок Root уже существует, рекурсивно вызываем insert для вставки в левое поддерево
				else insert(Data, Root.pLeft);
			}
			else
			{
				// Если у правого потомка Root нет элемента, создаем новый элемент и устанавливаем его как правого потомка
				if (Root.pRight == null) Root.pRight = new Element(Data);
				// Если правый потомок Root уже существует, рекурсивно вызываем insert для вставки в правое поддерево
				else insert(Data, Root.pRight);
			}
		}
		//hw2

		public Tree(params int[] initialData) // Конструктор для инициализации дерева
		{
			foreach (int data in initialData)
			{
				insert(data, Root);
			}
		}
		public void Clear() // Метод для очистки дерева
		{
			Root = null;
		}

		public void Erase(int value)
		{
			Root = EraseNode(Root, value);
		}

		private Element EraseNode(Element node, int value)
		{
			// Если текущий узел пуст, возвращаем его же
			if (node == null)
				return node;
			// Сравниваем значение для удаления с данными текущего узла и решаем, в какую сторону двигаться по дереву
			if (value < node.Data)
			{   // Если значение для удаления меньше, рекурсивно вызываем EraseNode для левого потомка 
				node.pLeft = EraseNode(node.pLeft, value);
			}
			else if (value > node.Data)
			{   // Если значение для удаления больше, рекурсивно вызываем EraseNode для правого потомка узла
				node.pRight = EraseNode(node.pRight, value);
			}
			else
			{   // Если значение для удаления совпадает с данными текущего узла
				if (node.pLeft == null)
				{
					// Возвращаем правое поддерево в качестве нового узла
					return node.pRight;
				}
				else if (node.pRight == null)
				{
					// Возвращаем левое поддерево в качестве нового узла
					return node.pLeft;
				}
				// Находим минимальное значение в правом поддереве и заменяем
				// данные текущего узла этим минимальным значением
				node.Data = FindMinValue(node.pRight);
				// Удаляем узел с найденным минимальным значением из правого поддерева
				// путем рекурсивного вызова EraseNode
				node.pRight = EraseNode(node.pRight, node.Data);
			}
			return node;
		}
		public int Depth()
		{
			return CalculateDepth(Root);
		}
		private int CalculateDepth(Element node)
		{
			if (node == null)
				return 0;
			else
			{
				int leftDepth = CalculateDepth(node.pLeft);
				int rightDepth = CalculateDepth(node.pRight);
				return Math.Max(leftDepth, rightDepth) + 1;
				// +1 дляя учета текущего узла
			}
		}

		public void TreePrint()
		{
			PrintTree(Root, 0);
		}

		private void PrintTree(Element node, int space)
		{
			if (node == null)
				return;

			space += 5;

			PrintTree(node.pRight, space);

			Console.Write("\n");
			for (int i = 5; i < space; i++)
			{
				Console.Write(" ");
			}
			Console.Write(node.Data + "\n");

			PrintTree(node.pLeft, space);
		}

		public void Balance()
		{
			// Создаем список для хранения значений узлов
			List<int> nodes = new List<int>();
			// Выполняем обход в порядке возрастания значений,
			// чтобы получить отсортированный список узлов
			InOrderTraversal(Root, nodes);
			// Создаем сбалансированное дерево на основе отсортированного списка узлов
			// Начинаем с передачи списка, индекса начала (0) и индекса конца (количество узлов - 1)
			Root = CreateBalancedTree(nodes, 0, nodes.Count - 1);
		}

		private void InOrderTraversal(Element node, List<int> nodes)
		{
			if (node == null)
				return;

			InOrderTraversal(node.pLeft, nodes);
			// Добавляем значение текущего узла в список
			nodes.Add(node.Data);
			InOrderTraversal(node.pRight, nodes);
		}

		private Element CreateBalancedTree(List<int> nodes, int start, int end)
		{
			if (start > end)
				return null;
			// Находим индекс середины текущего подсписка узлов
			int mid = (start + end) / 2;
			// Создаем узел дерева с данными из середины подсписка узлов
			Element node = new Element(nodes[mid]);
			// -1 чтобы гарантировать, что в левом поддереве узлы будут меньше значения текущего узла.
			node.pLeft = CreateBalancedTree(nodes, start, mid - 1);
			//ну и + 1 от обратного
			node.pRight = CreateBalancedTree(nodes, mid + 1, end);

			return node;
		}
		public void Print(Element Root)
		{
			if (Root == null) return;
			//Print(Root.pLeft);
			Console.Write($"{Root.Data}\t");
			//Print(Root.pRight);

		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Random rand = new Random(0);
			Console.WriteLine("Введите размер дерева: ");
			int n = Convert.ToInt32(Console.ReadLine());
			Tree tree = new Tree();
			for (int i = 0; i < n; i++)
			{
				tree.insert(rand.Next(100), tree.Root);
			}
			tree.Print(tree.Root);

			int min = tree.MinValue();
			int max = tree.MaxValue();
			int count = tree.Count();
			int sum = tree.Sum();
			double avg = tree.Avg();

			Console.WriteLine($"\n\nМинимальное значение: {min}");
			Console.WriteLine($"Максимальное значение: {max}");
			Console.WriteLine($"Количество элементов: {count}");
			Console.WriteLine($"Сумма элементов: {sum}");
			Console.WriteLine($"Среднее арифметическое: {avg}\n");

			//hw2
			Console.WriteLine("Введите размер дерева: ");
			n = Convert.ToInt32(Console.ReadLine());
			Tree tree2 = new Tree();
			for (int i = 0; i < n; i++)
			{
				tree2.insert(rand.Next(100), tree2.Root);
			}
			tree2.Print(tree2.Root);
			bool exit = false;

			while (!exit)
			{
				Console.WriteLine("\nВыберите действие:");
				Console.WriteLine("1. Очистить дерево");
				Console.WriteLine("2. Удалить элемент");
				Console.WriteLine("3. Получить глубину дерева");
				Console.WriteLine("4. Напечатать дерево");
				Console.WriteLine("5. Балансировать дерево");
				Console.WriteLine("6. Выйти");

				int choice = Convert.ToInt32(Console.ReadLine());

				switch (choice)
				{
					case 1:
						tree2.Clear();
						Console.WriteLine("Дерево очищено");
						tree2.Print(tree2.Root);
						break;
					case 2:
						Console.WriteLine("Введите значение для удаления:");
						int valueToDelete = Convert.ToInt32(Console.ReadLine());
						tree2.Erase(valueToDelete);
						Console.WriteLine($"Элемент {valueToDelete} удален из дерева");
						tree2.Print(tree2.Root);
						break;
					case 3:
						int depth = tree2.Depth();
						Console.WriteLine($"Глубина дерева: {depth}");
						tree2.Print(tree2.Root);
						break;
					case 4:
						Console.WriteLine("Дерево:");
						tree2.TreePrint();
						//tree2.Print(tree2.Root);
						break;
					case 5:
						tree2.Balance();
						Console.WriteLine("Дерево сбалансировано");
						tree2.Print(tree2.Root);
						break;
					case 6:
						exit = true;
						break;
					default:
						Console.WriteLine("Неверный выбор. Пожалуйста, выберите существующий вариант.");
						break;
				}
			}
		}
	}

}