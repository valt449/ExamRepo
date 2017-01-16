using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace dsfdfs
{
	class Eventlog
	{
		public static void MyMethod()
		{
			//Two ways of writing to the eventLog, bot start with checking if the source exist.

			//*** 1.
			if (!EventLog.SourceExists("MySource"))
			{
				EventLog.CreateEventSource("MySource", "FirstLog"); // Change 'FirstLog' to 'Application' and make a new source to show the log in Applications in Event Viewer. 
			}
			EventLog.WriteEntry("MySource", $"I added a nice message to the log", EventLogEntryType.Information, 63000);
			// This constructor can only be used without instanciating it(so, as a type - Eventlog), like the next example.

			//*** 2.
			if (!EventLog.SourceExists("MySecoundSource"))
			{
				EventLog.CreateEventSource("MySecoundSource", "FirstLog");
			}
			var Elog = new EventLog();
			Elog.Source = "MySecoundSource";
			Elog.WriteEntry($"I added a nice message to the {Elog.Log.ToString()} log with {Elog.Source.ToString()} as source");


			EventLogTraceListener dmeo = new EventLogTraceListener("FirstLog");
			Trace.Listeners.Add(dmeo);

			Trace.WriteLine("Hold nu op igen ");

		}
	}
}
