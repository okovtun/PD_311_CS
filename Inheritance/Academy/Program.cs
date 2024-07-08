//#define INHERITANCE_1
//#define INHERITANCE_2
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
            Save(group, "group.txt");
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
            StreamWriter writer = new StreamWriter("group.txt");    //Создаем и открываем поток
            for (int i = 0; i < group.Length; i++)
            {
                writer.WriteLine(group[i].ToStringFile());
            }
            writer.Close();
            //string cmd = "group.txt";
            System.Diagnostics.Process.Start("notepad", filename);
        }
    }
}
