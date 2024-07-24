#undef DEBUG
using System;
using System.Collections;//!!!!!!!!!!!!!!!!!!!!! https://stackoverflow.com/questions/28314845/using-the-generic-type-system-collections-generic-ienumerablet-requires-1-typ
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
	class Tree : IEnumerator, IEnumerable
	//CS0305 Using the generic type 'IEnumerator<T>' requires 1 type arguments BinaryTree
	//https://stackoverflow.com/questions/28314845/using-the-generic-type-system-collections-generic-ienumerablet-requires-1-typ
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
#if DEBUG
				Console.WriteLine($"EConstructor:\t{GetHashCode()}"); 
#endif
			}
			~Element()
			{
#if DEBUG
				Console.WriteLine($"EDestructor:\t{GetHashCode()}"); 
#endif
			}
			public bool isLeaf()
			{
				return pLeft == pRight;
			}
		}
		public Element Root;
		public Tree()
		{
			Console.WriteLine($"TConstructor:\t{GetHashCode()}");
		}
		~Tree()
		{
			Console.WriteLine($"TDestructor:\t{GetHashCode()}");
		}
		public void Add(int Data)
		{
			Insert(Data, Root);
		}
		public IEnumerator GetEnumerator()
		{
			return this;
		}
		/// <summary>
		/// IEnumerator implementation
		public object Current
		{
			get => Root.Data;
		}
		public bool MoveNext()
		{
			return true;
		}
		public void Reset()
		{

		}
		/// </summary>
		/// <param name="Data"></param>
		/// 

		public void Insert(int Data)
		{
			Insert(Data, Root);
		}
		void Insert(int Data, Element Root)
		{
			if (this.Root == null) this.Root = new Element(Data);
			if (Root == null) return;
			if (Data < Root.Data)
			{
				if (Root.pLeft == null) Root.pLeft = new Element(Data);
				else Insert(Data, Root.pLeft);
			}
			else
			{
				if (Root.pRight == null) Root.pRight = new Element(Data);
				else Insert(Data, Root.pRight);
			}
		}
		public void Erase(int Data)
		{
			Erase(Data, ref Root);
		}
		void Erase(int Data, ref Element Root)
		{
			if (Root == null) return;
			Erase(Data, ref Root.pLeft);
			Erase(Data, ref Root.pRight);
			if (Data == Root.Data)
			{
				if (Root.isLeaf())
				{
					Root = null;
				}
				else
				{
					if (Count(Root.pLeft) > Count(Root.pRight))
					{
						Root.Data = Max(Root.pLeft);
						Erase(Max(Root.pLeft), ref Root.pLeft);
					}
					else
					{
						Root.Data = Min(Root.pRight);
						Erase(Min(Root.pRight), ref Root.pRight);
					}
				}
			}
		}
		public void Balance()
		{
			Balance(Root);
		}
		void Balance(Element Root)
		{
			if (Root == null) return;
			if (Math.Abs(Count(Root.pLeft) - Count(Root.pRight)) < 2) return;
			if (Count(Root.pLeft) > Count(Root.pRight))
			{
				if (Root.pRight == null) Root.pRight = new Element(Root.Data);
				else Insert(Root.Data, Root.pRight);
				Root.Data = Max(Root.pLeft);
				Erase(Max(Root.pLeft), ref Root.pLeft);
			}
			else
			{
				if (Root.pLeft == null) Root.pLeft = new Element(Root.Data);
				else Insert(Root.Data, Root.pLeft);
				Root.Data = Min(Root.pRight);
				Erase(Min(Root.pRight), ref Root.pRight);
			}
			Balance(Root.pLeft);
			Balance(Root.pRight);
			Balance(Root);
		}
		public int Min()
		{
			if (Root == null) throw new Exception("No Tree in Min");
			return Min(Root);
		}
		int Min(Element Root)
		{
			return Root.pLeft == null ? Root.Data : Min(Root.pLeft);
			//if (Root.pLeft == null) return Root.Data;
			//else return Min(Root.pLeft);
		}
		public int Max()
		{
			if (Root == null) throw new Exception("No Tree in Max");
			return Max(Root);
		}
		int Max(Element Root)
		{
			return Root.pRight == null ? Root.Data : Max(Root.pRight);
		}
		public int Count()
		{
			return Count(Root);
		}
		int Count(Element Root)
		{
			return Root == null ? 0 : Count(Root.pLeft) + Count(Root.pRight) + 1;
		}
		public int Sum()
		{
			return Sum(Root);
		}
		int Sum(Element Root)
		{
			return Root == null ? 0 : Sum(Root.pLeft) + Sum(Root.pRight) + Root.Data;
		}
		public double Avg()
		{
			return (double)Sum(Root) / Count(Root);
		}
		public int Depth()
		{
			return Depth(Root);
		}
		public int Depth(Element Root)
		{
			if (Root == null) return 0;
			//else return
			//		Depth(Root.pLeft) + 1 > Depth(Root.pRight) + 1 ?
			//		Depth(Root.pLeft) + 1 :
			//		Depth(Root.pRight) + 1;
			int lDepth = Depth(Root.pLeft) + 1;
			int rDepth = Depth(Root.pRight) + 1;
			return Math.Max(lDepth, rDepth);
		}
		public void Print(int depth, int interval = 8)
		{
			Print(Root, depth, interval);
			Console.WriteLine();
		}
		void Print(Element Root, int Depth, int interval)
		{
			if (Root == null)
			{
				if (Depth == 0) Console.Write("".PadLeft(interval));
				return;
			}
			if (Depth == 0)
				Console.Write(Root.Data + "".PadLeft(interval));
			Print(Root.pLeft, Depth - 1, interval);
			if (Depth > 0) Console.Write("".PadLeft(interval));
			Print(Root.pRight, Depth - 1, interval);
		}
		public void TreePrint()
		{
			TreePrint(0, Console.WindowWidth / 4);
		}
		//static readonly int interval = Console.WindowWidth/2;
		void TreePrint(int Depth, int interval)
		{
			if (Depth > this.Depth()) return;
			//int steps = (this.Depth() - Depth);
			//Console.Write("".PadLeft(interval * steps));
			Console.Write("".PadLeft(interval));
			Print(Depth, interval);
			Console.WriteLine("\n\n");
			//if (Depth > 0) Console.Write("".PadLeft(interval));
			TreePrint(Depth + 1, /*interval > 7 ? interval/2 :*/ interval / 2);
		}
		public void Print()
		{
			Print(Root);
			Console.WriteLine();
		}
		void Print(Element Root)
		{
			if (Root == null) return;
			Print(Root.pLeft);
			Console.Write($"{Root.Data}\t");
			Print(Root.pRight);
		}
	}
}
