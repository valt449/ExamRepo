using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace dsfdfs
{
	public class ConsoleDemo
	{
		public static string directory = @"C:\Users\z6nii\OneDrive - KMD\code\Created text files from ExamPrep\";

		

		public static void MyMethod()
		{
			using (StreamWriter writer = new StreamWriter(directory + "out.txt"))
			{
				Console.SetOut(writer);
				Console.WriteLine("Sker der her ????");
				Console.WriteLine("It's like magic");

				var twriter = new StreamWriter(directory + "trace.txt");

				using (var some = new TextWriterTraceListener(twriter))
				{
					Trace.Listeners.Add(some);
					Trace.AutoFlush = true;
					Trace.WriteLine("Whatup?");
					Trace.WriteLine("Whatup?");
					 
					//var noget = new Math
					int tst = 3;

					Math.Cosh(tst);

				}
					Act();
				//	Trace.Close();

			}
		}

		static void Act()
		{
			Console.WriteLine("This is Console.WriteLine");
			Console.WriteLine("Thanks for playing!");
			Trace.WriteLine("dsdsf");
			//Trace.Flush();
		}
		
	}
}

