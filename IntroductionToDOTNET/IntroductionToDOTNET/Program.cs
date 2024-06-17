//#define CLASS_CONSOLE
//#define STRINGS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToDOTNET
{
	class Program
	{
		static void Main(string[] args)
		{
#if CLASS_CONSOLE
            Console.Title = "Введение в .NET";
            Console.WriteLine("\t\t\tHello .NET");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.CursorLeft = 32;
            Console.CursorTop = 11;
            Console.Beep(137, 2000);
            Console.Clear();
            //Console.SetCursorPosition(22, 11);
            Console.WriteLine("Привет .NET");
            Console.ResetColor(); 
#endif

#if STRINGS
			Console.Write("Введите Ваше имя: ");
			string first_name = Console.ReadLine();

			Console.Write("Введите Вашу фамилию: ");
			string last_name = Console.ReadLine();

			Console.Write("Введите Ваш возраст:");
			int age = Convert.ToInt32(Console.ReadLine());

			#region ConsoleWriteRegion
			/*Console.Write(first_name + " ");
                Console.Write(last_name + " ");
                Console.Write(age);
                Console.WriteLine();*/    //cout << endl; 
			#endregion

			//Console.WriteLine(last_name + " " + first_name + " " + age);    //Strings concatenation

			//Console.WriteLine(string.Format("{0} {1} {2}", last_name, first_name, age));    //String formatting

			//Console.WriteLine($"{last_name} {first_name} {age}");	//Strings interpolation

#endif
			//object
		}
	}
}
