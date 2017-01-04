using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace dsfdfs
{
	class FormattingStrings
	{
		public static void MyMethod()
		{
			int data = 1321564;
			decimal decimalData = 123456.456789m;

			Console.WriteLine("*** TOSTRING() ***");
			Console.WriteLine("Using {0}", nameof(data));
			Console.WriteLine("4: " + data.ToString("c")); //Currency related to the region of the local computer. 
			Console.WriteLine("1: " + data.ToString("n"));
			Console.WriteLine("3: " + data.ToString("0,0.00"));
			Console.WriteLine("2: " + data.ToString("#,#.###") + " **OBS no decimal"); //OBS doesnt return numbers after comma, but do implement thousand seperator. 


			Console.WriteLine($"\nUsing {nameof(decimalData)}");
			Console.WriteLine("4: " + decimalData.ToString("c")); //Currency related to the region of the local computer. 
			Console.WriteLine("1: " + decimalData.ToString("n"));
			Console.WriteLine("3: " + decimalData.ToString("0,0.00"));
			Console.WriteLine("2: " + decimalData.ToString("#,#.###") + " **Decimals here because data is decimal"); //OBS returns numbers after comma, because data is decimal 

			Console.WriteLine($"\n*** STRING.FORMAT() ***");
			Console.WriteLine("Using {0}", nameof(data));
			Console.WriteLine(string.Format("1: " + "{0:c}", data)); //Currency related to the region of the local computer.
			Console.WriteLine(string.Format("3: " + "{0:N}", data));
			Console.WriteLine(string.Format("2: " + "{0:0,0.00}", data)); // Currency related to the region of the local computer.
			Console.WriteLine(string.Format("4: " + "{0:#,#.###} **OBS no decimals", data)); // OBS doesnt return numbers after comma, but do implement thousand seperator.


			Console.WriteLine($"\nUsing {nameof(decimalData)}");
			Console.WriteLine(string.Format("1: " + "{0:c}", decimalData)); //Currency related to the region of the local computer.
			Console.WriteLine(string.Format("4: " + "{0:N}", decimalData));
			Console.WriteLine(string.Format("2: " + "{0:0,00.00}", decimalData)); //Currency related to the region of the local computer.
			Console.WriteLine(string.Format("3: " + "{0:#,#.###} **Decimals here because data is decimal", decimalData));
			
			Console.WriteLine($"\n*** STRING.FORMAT() -> Controlling spacing ***");
			Console.WriteLine(string.Format("{1,-10}" + "{0,12:n}", data, "1:")); //{1,12:n} = {2. variable, 12 chars long rigthAlign, format as number }
																				  // NegativeNumber = leftalign, PositiveNumber = RightAlign.

			Console.WriteLine($"\n*** STRING.FORMAT() -> Controlling spacing + cultureinfo ***");
			double value = 123456.32;
			string[] Culturenames ={"en-US", "fr-FR", "de-DE", "es-ES", "da-DK"};
			Console.WriteLine();
			Console.WriteLine(string.Format("{0,-15} {1,-30:D} {2,-30:n}", nameof(Culturenames), "Todays Date", nameof(value)));
			for (int i = 0; i < Culturenames.Length; i++)
			{
			var culture = new CultureInfo(Culturenames[i]);
			Console.WriteLine(string.Format(culture,"{0,-15} {1,-30:D} {2,-30:n}", Culturenames[i], DateTime.Today, value));
			}
		}
	}
}
