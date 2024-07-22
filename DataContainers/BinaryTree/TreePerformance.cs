using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BinaryTree
{
	class TreePerformance
	{
		public delegate int Method();
		public static void Measure(string message, Method method)
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			int value = method();
			sw.Stop();
			Console.WriteLine($"{message}: {value}, вычислено за {sw.Elapsed.TotalMilliseconds} ms");
		}
	}
}
