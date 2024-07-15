using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstractGeometry
{
	class Circle : Shape
	{
		double radius;
		public double Radius
		{
			get => radius;
			set => radius = value < MIN_SIZE ? MIN_SIZE : value > MAX_SIZE ? MAX_SIZE : value;
		}
		public Circle(double radius, int startX, int startY, int lineWidth, System.Drawing.Color color) :
			base(startX, startY, lineWidth, color)
		{
			Radius = radius;
		}
		public override double GetArea()
		{
			return Math.PI*Math.Pow(Radius, 2);
		}
		public override double GetPerimeter()
		{
			return 2*Math.PI*Radius;
		}
		public override void Draw(PaintEventArgs e)
		{
			e.Graphics.DrawEllipse(new System.Drawing.Pen(Color, LineWidth), StartX, StartY, (float)Radius*2, (float)Radius*2);
		}
	}
}
