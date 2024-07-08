//#define INHERITANCE_1
//#define INHERITANCE_2
//#define SAVE_TO_FILE
#define LOAD_FROM_FILE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Academy
{
	class Program
	{
		static readonly string delimiter = "\n------------------------------------------------\n";
		static Program()
		{
			Directory.SetCurrentDirectory("..\\..");
			Console.WriteLine(Directory.GetCurrentDirectory());
		}
		static void Main(string[] args)
		{
#if INHERITANCE_1
			Human human = new Human("Vercetti", "Tommy", 30);
			Console.WriteLine(human);

			Student student = new Student("Pinkman", "Jessie", 22, "Chemistry", "WW_220", 95, 97);
			Console.WriteLine(student);

			Teacher teacher = new Teacher("White", "Walter", 50, "Chemistry", 25);
			Console.WriteLine(teacher);

			Graduate graduate = new Graduate("Schrader", "Hank", 40, "Criminalistic", "OBN", 80, 70, "How to catch Heizenberg");
			Console.WriteLine(graduate); 
#endif

#if INHERITANCE_2
			Human human = new Human("Vercetti", "Tommy", 30);
			Human human2 = new Human("Diaz", "Ricardo", 50);
			Console.WriteLine(human);
			Console.WriteLine(human2);
			Console.WriteLine(delimiter);
			Student student = new Student(human, "Theft", "Vice", 95, 98);
			Console.WriteLine(student);
			Console.WriteLine(delimiter);
			Graduate graduate = new Graduate(student, "How to make money");
			Console.WriteLine(graduate);
			Console.WriteLine(delimiter);

			Teacher teacher = new Teacher(human2, "Weapons distribution", 20);
			Console.WriteLine(teacher);
			Console.WriteLine(delimiter); 
#endif
			//	Polymorphism:Generalization/Specialization

			//object[] arr = new object[] { 123, '@', true, 3.14 };
			//foreach (object i in arr) Console.Write(i + "\t"); Console.WriteLine();

#if SAVE_TO_FILE
            //Generalization:
            Human[] group = new Human[]
                {
                    new Human("Musk","Elon",50),
                    new Student("Pinkman", "Jessie", 22, "Chemistry", "WW_220", 95, 97),
                    new Teacher("White", "Walter", 50, "Chemistry", 25),
                    new Graduate("Schrader", "Hank", 40, "Criminalistic", "OBN", 80, 70, "How to catch Heizenberg"),
                    new Student("Vercetti", "Tommy", 30, "Theft", "Vice", 95, 98),
                    new Teacher("Diaz", "Ricardo", 50, "Weapons distribution", 20)
                };

            Print(group);
            Save(group, "group.csv");
            //CSV - Comma Separated Values (Значения, разделенные запятой)  
#endif
#if LOAD_FROM_FILE
			Human[] group2 = Load("group.csv");
			Print(group2); 
#endif
		}
		static void Print(Human[] group)
		{
			//Specialization:
			for (int i = 0; i < group.Length; i++)
			{
				Console.WriteLine(group[i].ToString());
				Console.WriteLine(delimiter);
			}
		}
		static void Save(Human[] group, string filename)
		{
			//Directory.SetCurrentDirectory("..\\..");
			StreamWriter writer = new StreamWriter(filename);    //Создаем и открываем поток
			for (int i = 0; i < group.Length; i++)
			{
				writer.WriteLine(group[i].ToStringFile());
			}
			writer.Close();
			//string cmd = "group.txt";
			System.Diagnostics.Process.Start("notepad", filename);
		}
		static Human[] Load(string filename)
		{
			//Directory.SetCurrentDirectory("..\\..");
			List<Human> group = new List<Human>();
			if (File.Exists(filename))
			{
				StreamReader sr = new StreamReader(filename);
				while (!sr.EndOfStream)
				{
					string buffer = sr.ReadLine();
					if (buffer.Length == 0) continue;
					//Console.WriteLine(buffer+"\n");
					string[] values = buffer.Split(':', ',', ';');
					group.Add(HumanFactory(values.First()));
					group.Last().Init(values);
				}
				sr.Close();
			}
			else
			{
				Console.WriteLine("Error: File not found");
			}
			
			return group.ToArray();
		}
		static Human HumanFactory(string type)
		{
			Human human = null;
			switch (type)
			{
				case "Human": human = new Human("", "", 0); break;
				case "Teacher": human = new Teacher("", "", 0, "", 0); break;
				case "Student": human = new Student("", "", 0, "", "", 0,0); break;
				case "Graduate": human = new Graduate("", "", 0, "", "", 0,0,""); break;
			}
			return human;
		}
	}
}
