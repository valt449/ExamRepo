using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace dsfdfs.Create_and_use_types
{
	class FormattingStrings
	{
		public static void MyMethod()
		{
			int data = 1321564;
			decimal decimalData = 123456.456789m;
			

			Console.WriteLine("Using the variable {0}", nameof(data));
			Console.WriteLine("1: " + data.ToString("n"));
			Console.WriteLine("2: " + data.ToString("#,###.###")); //OBS doesnt return numbers after comma, but do implement thoudsend seperator. 
			Console.WriteLine("3: " + data.ToString("0.00"));
			Console.WriteLine("4: " + data.ToString("c")); //Currency related to the region of the local computer. 


			Console.WriteLine($"\nUsing the variable {nameof(decimalData)}");
			Console.WriteLine("1: " + decimalData.ToString("n"));
			Console.WriteLine("2: " + decimalData.ToString("#,###.###")); //OBS do return numbers after comma
			Console.WriteLine("3: " + decimalData.ToString("0.00"));
			Console.WriteLine("4: " + decimalData.ToString("c")); //Currency related to the region of the local computer. 
			Console.WriteLine(string.Format("4: " + "{0:c}", decimalData)); //Currency related to the region of the local computer. 
		}
	}
}
