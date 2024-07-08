using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	class Teacher : Human
	{
		static readonly int SPECIALITY_WIDTH = 25;
		static readonly int EXPERIENCE_WIDTH = 5;
		string speciality;
		int experience;
		public string Speciality
		{
			get => speciality;
			set => speciality = value;
		}
		public int Experience
		{
			get => experience;
			set => experience = value;
		}
		public Teacher
			(
			string lastName, string firsName, int age,
			string speciality, int experience
			) : base(lastName, firsName, age)
		{
			Speciality = speciality;
			Experience = experience;
			Console.WriteLine($"TConstrcutor:\t{this.GetHashCode()}");
		}
		public Teacher(Human human, string speciality, int experience) : base(human)
		{
			this.Speciality = speciality;
			this.Experience = experience;
			Console.WriteLine($"TConstructor:\t{this.GetHashCode()}");
		}
		~Teacher()
		{
			Console.WriteLine($"TDestrcutor:\t{this.GetHashCode()}");
		}

		public override string ToString()
		{
			return base.ToString() + 
				$"{speciality.PadRight(SPECIALITY_WIDTH)}{experience.ToString().PadRight(EXPERIENCE_WIDTH)}";
		}
        public override string ToStringFile()
        {
            return base.ToStringFile().Replace(';',',')+$"{speciality},{experience};";
        }
		public override void Init(string[] values)
		{
			base.Init(values);
			Speciality = values[4];
			Experience = Convert.ToInt32(values[5]);
		}
	}
}
