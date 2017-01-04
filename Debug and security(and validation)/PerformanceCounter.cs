using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsfdfs
{ 
	public class PerformanceCounterDemo
	{
		public static void MyMethod()
		{
		PerformanceCounter PerformanceTest = new PerformanceCounter();
			PerformanceTest.CategoryName = "DemoCounter";
			PerformanceTest.CounterName = "Times called in a method";
			PerformanceTest.MachineName = ".";
			PerformanceTest.ReadOnly = false;

			for (int i = 0; i < 145000; i++)
			{
				PerformanceTest.Increment();
				Console.WriteLine("DemoCounter incremented!");
			}


		}
	}
}
