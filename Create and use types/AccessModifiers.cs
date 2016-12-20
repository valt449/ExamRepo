using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace dsfdfs.Create_and_use_types
{

	//Protected internal means.
	//If in own assembly, access == internal(),
	//if in other assembly, access == protected 
	internal class AccessModifiers //Top level classes can only be 'internal' or 'public'
	{
		public string Name { get; set; }

		protected class test //This is 'private as default, because its a nested class and therefore a member of class AccessModifiers
		{
			public string Name2 { get; set; }
		}

		protected class test3 : test
		{
			public test something = new test();


		}

		test3 bum = new test3();


	}
}

namespace OtherNamespace
{
	internal class inheriteFromProtInternalClass : dsfdfs.Create_and_use_types.AccessModifiers
	{

		protected class MyClass : dsfdfs.Create_and_use_types.AccessModifiers.test3
		{

		}

	}


}
