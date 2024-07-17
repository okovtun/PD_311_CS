using System;
using System.Collections.Generic;
using System.Linq;
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
				Console.WriteLine($"EConstructor:\t{GetHashCode()}");
			}
			~Element()
			{
				Console.WriteLine($"EDestructor:\t{GetHashCode()}");
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

		public void Insert(int Data, Element Root)
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
		public void Print(Element Root)
		{
			if (Root == null) return;
			Print(Root.pLeft);
			Console.Write($"{Root.Data}\t");
			Print(Root.pRight);
		}
	}
}
