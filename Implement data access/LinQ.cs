using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep
{
	class LinQ
	{
		public static void MyMethod()
		{
		List<int> demo = new List<int>();
			for (int i = 0; i < 50; i++)
			{
				demo.Add(i);
			}

			// Query expression
			var test = from d in demo
					   where d % 2 == 0
					   select d;

		//Method-based query
		var test2 = demo.Where(e => e % 2 == 0);

		Console.WriteLine("Query Expression\n");
			foreach (var i in test)
			{
				Console.Write(i + " ");
			}

	Console.WriteLine("\n\nMethod-based Query\n");
			foreach (var i in test2)
			{
				Console.Write(i +" ");
			}
		}
	}
}
