using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep
{
	class Reflection
	{
		public static void MyMethod()
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(@"c:\");

			Debug.WriteLine("\n Files\n ");
			foreach (var fileInfo in directoryInfo.GetFiles())
			{
				Debug.WriteLine(fileInfo);
			}
			Debug.WriteLine(" \n Directories\n ");
			foreach (var directoryinfo in directoryInfo.GetDirectories())
			{
				Debug.WriteLine(directoryinfo);
			}
			Console.ReadLine();
		}
	}
}
