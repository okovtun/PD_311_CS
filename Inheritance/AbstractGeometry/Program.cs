using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;	//Эта библиотека позволит подключать к нашему файлу другие DLL-фалы, и использовать функции из этих DLL-файлов

namespace AbstractGeometry
{
	class Program
	{
		static void Main(string[] args)
		{
			//Shape shape = new Shape();
			IntPtr hwnd = GetConsoleWindow();
			Graphics graphics = Graphics.FromHwnd(hwnd);
			System.Drawing.Rectangle window_rectangle = new System.Drawing.Rectangle(Console.WindowLeft, Console.WindowTop, Console.WindowWidth, Console.WindowHeight);
			PaintEventArgs e = new PaintEventArgs(graphics, window_rectangle);

			Rectangle rectangle = new Rectangle(100, 80, 200, 100, 5, Color.AliceBlue);
			rectangle.Info(e);
		}
		[DllImport("kernel32.dll")]
		public static extern bool GetStdHandle(int nStdHandle);
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetConsoleWindow();
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetDC(IntPtr hwnd);
	}
}
