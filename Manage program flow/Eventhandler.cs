﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsfdfs
{
	class EventhandlerDemo
	{
		public static void MyMethod()
		{
			Counter c = new Counter(new Random().Next(10));
			c.ThresholdReached += DemoEvent;
			c.ThresholdReached += c_ThresholdReached;

			Console.WriteLine("press 'a' key to increase total");
			while (Console.ReadKey(true).KeyChar == 'a')
			{
				Console.WriteLine("adding one");
				c.Add(1);
			}
		}

		static void c_ThresholdReached(object sender, ThresholdReachedEventArgs e)
		{
			Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached);
			Environment.Exit(0);
		}

		static void DemoEvent(object sender, ThresholdReachedEventArgs e)
		{
			Console.WriteLine("JUhuu det virker");
		}
	}

	class Counter
	{
		private int threshold;
		private int total;

		public Counter(int passedThreshold)
		{
			threshold = passedThreshold;
		}

		public void Add(int x)
		{
			total += x;
			if (total >= threshold)
			{
				ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();
				args.Threshold = threshold;
				args.TimeReached = DateTime.Now;
				OnThresholdReached(args);
			}
		}

		protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
		{
			if (ThresholdReached != null)
			{
				ThresholdReached(this, e);
			}
		}
		public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;
	}
	public class ThresholdReachedEventArgs : EventArgs
	{
		public int Threshold { get; set; }
		public DateTime TimeReached { get; set; }
	}
}



