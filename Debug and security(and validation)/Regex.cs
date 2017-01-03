using System;
using System.CodeDom;
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
			string url = "https://msdn.microsoft.com/en-us/library/h5845fdz(v=vs.110).aspx";
			string data;
			//Get some data 
			HttpWebRequest webRequestData = WebRequest.CreateHttp(url); //Create the request
			using (HttpWebResponse responseData = (HttpWebResponse)webRequestData.GetResponse()) //Send the reqest and recieve the response
			{
				Stream recievedStream = responseData.GetResponseStream();

				using (StreamReader sr = new StreamReader(recievedStream, Encoding.UTF8))
				{
					data = sr.ReadToEnd();

					//Console.WriteLine(test);
					//Console.WriteLine(data);
				}
			}
			
			//Find pattern with regex
			var pattern = @"[A-Z]{30,35}";
			MatchCollection matches; //The collection contains zero or more System.Text.RegularExpressions.Match objects.
			Regex findRegex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled); //Compiled is quicker to use, but takes longer to construct 
			matches = findRegex.Matches(data);//Add matches to matches collection

			//************* WAYS OF ITERATE DATA ************

			int i = 0;
			int z = 0;
			int r = 0;
			List<string> Words = new List<string>();

			Console.WriteLine($"Word with characters ranging from 30-35 from the page: \n{url}");

			//****** 1.  (AND CREATE THE LIST) *********
			Console.WriteLine($"\n1.  (AND CREATE THE LIST)\n");


			foreach (Match item in matches)
			{
				i++;
				Words.Add(item.ToString());
				Console.WriteLine($"{i}: " + item);
			}

			//****** 2.  USING LINQ WITH MULTIPLE LINES OF CODE *********
			Console.WriteLine($"\n2.  USING LINQ WITH MULTIPLE LINES OF CODE \n");

			Words.ForEach(x =>
			{
				z++;
				Console.WriteLine($"{z}: " + x);
			});

			//****** 3.  USING LINQ WITH MULTIPLE LINES OF CODE (alternative for 2.) *********
			Console.WriteLine($"\n3. USING LINQ WITH MULTIPLE LINES OF CODE (alternative for 2.)\n");

			Words.ForEach(delegate (String s)
			{
				r++;
				Console.WriteLine($"{r}: " + s);
			});

			//****** 4.  USING LINQ WITH MULTIPLE LINES OF CODE (alternative for 2.) *********
			Console.WriteLine($"\n4. USING LINQ WITH SINGLE LINE OF CODE\n");
			Words.ForEach(x => Console.WriteLine(x));
			
			//****** 5. USING THE STATIC REGEX CLASS. *********
			Console.WriteLine($"\n5. Using Static Regex class\n");

			foreach (Match item in Regex.Matches(data, pattern, RegexOptions.IgnoreCase)) //Stativ regex class
			{
				Console.WriteLine(item);
			}
		}
	}
}
