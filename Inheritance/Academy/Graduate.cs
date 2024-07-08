using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	class Graduate:Student
	{
		string subject;
		public string Subject
		{
			get => subject;
			set => subject = value;
		}
		public Graduate
			(
			string lastName, string firstName, int age,
			string speiality, string group, double rating, double attendance,
			string subject
			) : base(lastName, firstName, age, speiality, group, rating, attendance)
		{
			Subject = subject;
			Console.WriteLine($"GConstructor:\t{this.GetHashCode()}");
		}
		public Graduate(Student student, string subject) : base(student)
		{
			this.Subject = subject;
			Console.WriteLine($"GConstructor:\t{this.GetHashCode()}");
		}
		~Graduate()
		{
			Console.WriteLine($"GDestructor:\t{this.GetHashCode()}");
		}
		public override string ToString()
		{
			return base.ToString() + $" {Subject}";
		}
        public override string ToStringFile()
        {
            return base.ToStringFile().Replace(';',',')+$"{subject};";
        }
		public override void Init(string[] values)
		{
			base.Init(values);
			Subject = values[8];
		}
	}
}
