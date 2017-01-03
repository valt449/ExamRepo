//#define DEBUG //default preprocessor symbol (only in debug builds)
#undef DEBUG //You can undef a symbol defined in the projects properties page.

//#define TRACE //default preprocessor symbol (in both debug and release builds)
#undef TRACE

//#define BASIC //New PreProcessor symbol defined

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace dsfdfs
{
	class DebugTrace
	{
		public static void MyMethod()
		{
			//var date = new DateTime().Date.TimeOfDay;
			var traceStream = File.Open(@"C:\Users\z6nii\OneDrive - KMD\Tracefile3.txt", FileMode.Append, FileAccess.Write, FileShare.Read);
			
			var textWriterTraceListner = new TextWriterTraceListener(traceStream);
			Trace.Listeners.Add(textWriterTraceListner);
			Trace.AutoFlush = true;
			

			#region (DemoRegion)
			Debug.Assert(false);
			Debug.WriteLine("Here was a Debug.Assert called (not called if DEBUG is undefined)");

			Trace.Assert(false);
			Trace.WriteLine("Here was a Trace.Assert called (not called if TRACE is undefined)");
#if BASIC

//#pragma warning disable 1030 //disable warning 1030
#warning ("This is a Warning") Console.WriteLine("This is BasicMode");

//#error ("This is a error") System.Console.WriteLine("ERROR"); //will not compile if basic is defined and uncommenting this line. 

			Console.WriteLine("This is BasicMode");

//#elif DEBUG == TRACE
			Console.WriteLine("Write this if both DEBUG and TRACE is either defined or Undefined ");
			Trace.WriteLine("Write this if both DEBUG and TRACE is either defined or Undefined ");

#elif DEBUG
			Console.WriteLine("This is DebugMode");
			Trace.WriteLine("This is DebugMode");

#elif TRACE
			Console.WriteLine("This is TraceMode");
			Trace.WriteLine("This is TraceMode");


#else
			System.Console.WriteLine("The statement will not go here except if you remove the DEBUG == TRACE statement, and undef BASIC, DEBUG and TRACE");
#endif
			#endregion

			Stopwatch watch = new Stopwatch();
			watch.Start();
			Trace.WriteLine($"Trace Stopped {DateTime.Now}");
			Trace.WriteLine($"Elapsed time: {watch.Elapsed.TotalSeconds.ToString("00.000")} sec");
			Trace.WriteLine($"\n\n");
			traceStream.Close();
			
			//Trace.Flush(); //not needed because Autoflush is enabled
		}
	}
}
