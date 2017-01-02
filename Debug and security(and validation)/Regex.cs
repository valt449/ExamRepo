using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dsfdfs
{
	public class RegexDemo
	{
		public static void MyMethod()
		{
			//Get some data 
			HttpWebRequest webRequestData = (HttpWebRequest)WebRequest.CreateHttp("https://msdn.microsoft.com/en-us/library/h5845fdz(v=vs.110).aspx");
			HttpWebResponse responseData = (HttpWebResponse)webRequestData.GetResponse();

			Stream recievedStream = responseData.GetResponseStream();
			string data;
			using (StreamReader sr = new StreamReader(recievedStream, Encoding.UTF8))
			{
				data = sr.ReadToEnd();

				//Console.WriteLine(test);
				//Console.WriteLine(data);
			}

			//Find pattern with regex
			var pattern = @"[A-Z]{20,25}";
			MatchCollection matches; //The collection contains zero or more System.Text.RegularExpressions.Match objects.
			List<string> Words = new List<string>();

			Regex findRegex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
			matches = findRegex.Matches(data);
			

			//************* WAYS OF ITERATE DATA ************

			int i = 0;
			int z = 0;
			int r = 0;

			Console.WriteLine("Word with characters ranging from 20-25");
			//****** 1.  (AND ADD TO A LIST) *********
			Console.WriteLine($"\n1. Iteration\n");

			foreach (Match item in matches)
			{
				i++;
				Words.Add(item.ToString());
				Console.WriteLine($"{i}: " + item); 
			}

			//****** 2.  USING LINQ WITH MULTIPLE LINES OF CODE *********
			Console.WriteLine($"\n2. Iteration \n");

			Words.ForEach(x =>
			{
				z++;
				Console.WriteLine($"{z}: " + x);
			});

			//****** 3.  USING LINQ WITH MULTIPLE LINES OF CODE (alternative for 2.) *********
			Console.WriteLine($"\n2. Iteration\n");

			Words.ForEach(delegate (String s)
			{
				r++;
				Console.WriteLine($"{r}: " + s);
			});
		}
	}
}
