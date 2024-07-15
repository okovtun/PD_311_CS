using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace AbstractGeometry
{
	class Rectangle : Shape
	{
		double width;
		double height;
		public double Width
		{
			get => width;
			protected set => width = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
		}
		public double Height
		{
			get => height;
			protected set => height = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
		}
		public Rectangle(double width, double height, int startX, int startY, int lineWidth, Color color)
			: base(startX, startY, lineWidth, color)
		{
			Width = width;
			Height = height;
		}
		public override double GetArea()
		{
			return Width*Height;
		}
		public override double GetPerimeter()
		{
			return (Width + Height) * 2;
		}
		public override void Draw(PaintEventArgs e)
		{
			e.Graphics.DrawRectangle(new Pen(Color, LineWidth),StartX, StartY, (float)Width, (float)Height);
		}
		public override string ToString()
		{
			string result = "";
			result += $"Width:\t{Width}\n";
			result += $"Height:\t{Height}\n";
			result += base.ToString();
			return result;
		}
	}
}
