using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace AbstractGeometry
{
	abstract class Shape:IDrawable
	{
		protected static readonly int MIN_START_X = 10;
		protected static readonly int MIN_START_Y = 10;
		protected static readonly int MAX_START_X = 800;
		protected static readonly int MAX_START_Y = 600;
		protected static readonly int MIN_LINE_WIDTH = 3;
		protected static readonly int MAX_LINE_WIDTH = 33;
		protected static readonly int MIN_SIZE = 50;
		protected static readonly int MAX_SIZE = 800;

		int startX;
		int startY;
		int lineWidth;
		public Color Color { get; set; }	//Автосвойства - неявно создают переменную в классе
											//В автосвойствах невозможно реализовать фильрацию данных.
		public int StartX
		{
			get => startX;
			set
			{
				if (value < MIN_START_X) value = MIN_START_X;
				if (value > MAX_START_X) value = MAX_START_X;
				startX = value;
			}
		}
		public int StartY
		{
			get => startY;
			set
			{
				if (value < MIN_START_Y) value = MIN_START_X;
				if (value > MAX_START_Y) value = MAX_START_X;
				startY = value;
			}
		}
		public int LineWidth
		{
			get => lineWidth;
			set
			{
				if (value < MIN_LINE_WIDTH) value = MIN_LINE_WIDTH;
				if (value > MAX_LINE_WIDTH) value = MAX_LINE_WIDTH;
				lineWidth = value;
			}
		}


		public Shape(int startX, int startY, int lineWidth, Color color)
		{
			StartX = startX;
			StartY = startY;
			LineWidth = LineWidth;
			Color = color;
		}
		////////////////////////////////////////////////////////////////////////
		public abstract double GetArea();
		public abstract double GetPerimeter();
		public abstract void Draw(PaintEventArgs e);
		public virtual void Info(PaintEventArgs e)
		{
			Console.WriteLine(this);
			this.Draw(e);
		}
		public override string ToString()
		{
			string result = "";
			result += $"Area:\t\t{GetArea()}\n";
			result += $"Perimeter:\t{GetPerimeter()}\n";
			return result;
		}
	}
}
