using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{

	//Protected internal means.
	//If in own assembly, access == internal(),
	//if in other assembly, access == protected 
	public class AssemblyOneClassOne //Top level classes can only be 'internal' or 'public'
	{
		public string PublicName { get; set; }
		private string PrivateName { get; set; }
		protected string ProtectedName { get; set; }
		protected internal string ProtectedInternalName { get; set; }
		internal string InternalName { get; set; }

		

		public class AssemblyOneClassTwo //Nested class = all succes!!
		{
			public void MyMethod()
			{
				AssemblyOneClassOne demo = new AssemblyOneClassOne();
				demo.PublicName = "succces";
				demo.PrivateName = "succces";
				demo.ProtectedName = "succces";
				demo.ProtectedInternalName = "succces";
				demo.InternalName = "succces";
			}
		}
	}

	//************* // OUTSIDE CONTAINED CLASS

	public class AssemblyOneClassThree // New class outside the contained class "AssemblyOneClassOne".
	{
		public void MyMethod()
		{
			AssemblyOneClassOne demo = new AssemblyOneClassOne();
			demo.PublicName = "succces";
			demo.PrivateName = "failure";
			demo.ProtectedName = "failure";
			demo.ProtectedInternalName = "succces";
			demo.InternalName = "succces";
		}
	}

	//************* // OUTSIDE CONTAINED CLASS - Inherite from AssemblyOneClassOne

	public class AssemblyOneClassFour : AssemblyOneClassOne
	{
		public void MyMethod()
		{
			AssemblyOneClassFour demo = new AssemblyOneClassFour(); //****OBS***** Instance of AssemblyOneClassFour - Class FOUR!!
			demo.PublicName = "succces";
			demo.PrivateName = "failure";
			demo.ProtectedName = "sucess"; //Because this is a derived class 
			demo.ProtectedInternalName = "succces";
			demo.InternalName = "succces";
		}
	}
}
