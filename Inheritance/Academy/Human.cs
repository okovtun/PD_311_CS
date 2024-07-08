using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	class Human
	{
		static readonly int LAST_NAME_WIDTH = 15;
		static readonly int FIRS_NAME_WIDTH = 15;
		static readonly int AGE_WIDTH = 5;
		string lastName;
		string firstName;
		int age;
		public string LastName
		{
			get => lastName;
			set { lastName = value; }
		}
		public string FirstName
		{
			get => firstName;
			set { firstName = value; }
		}
		public int Age
		{
			get => age;
			set { age = value; }
		}
		public Human(string lastName, string firsName, int age)
		{
			LastName = lastName;
			FirstName = firsName;
			Age = age;
			Console.WriteLine($"HConstructor:\t{this.GetHashCode()}");
		}
		public Human(Human other)
		{
			this.LastName = other.LastName;
			this.FirstName = other.FirstName;
			this.Age = other.Age;
			Console.WriteLine($"HCopyConstructor:{this.GetHashCode()}");
		}
		~Human()
		{
			Console.WriteLine($"HDestructor:\t{this.GetHashCode()}");
		}
		public override string ToString()
		{
			//string result = $"{GetType()}: ".PadRight(16) + $"{LastName} {FirstName} {Age} y/o";
			return $"{GetType().ToString().Split('.').Last()}: ".PadRight(12) + $"{LastName.PadRight(LAST_NAME_WIDTH)} {FirstName.PadRight(FIRS_NAME_WIDTH)} {Age.ToString().PadRight(AGE_WIDTH)}";
			//return base.ToString() + $"{LastName} {FirstName} {Age}";
		}
        public virtual string ToStringFile()
		{
			//string result = $"{GetType()}: ".PadRight(16) + $"{LastName} {FirstName} {Age} y/o";
			return $"{GetType().ToString().Split('.').Last()}:" + $"{LastName},{FirstName},{Age.ToString()};";
			//return base.ToString() + $"{LastName} {FirstName} {Age}";
		}

	}
}
