using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
	class UniqueTree : Tree
	{
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
			else if (Data > Root.Data)
			{
				if (Root.pRight == null) Root.pRight = new Element(Data);
				else Insert(Data, Root.pRight);
			}
		}
	}
}
