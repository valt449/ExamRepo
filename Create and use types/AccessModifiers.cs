using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using OtherNamespace;
using dsfdfs.Create_and_use_types;

namespace dsfdfs.Create_and_use_types
{

	//Protected internal means.
	//If in own assembly, access == internal(),
	//if in other assembly, access == protected 
	public class AccessModifier //Top level classes can only be 'internal' or 'public'
	{
		public string AccessModifierName { get; set; }

		protected class Protec //This is 'private as default, because its a nested class and therefore a member of class AccessModifiers
		{
			public string ProtecName { get; set; }
		}

		//*************

		internal protected class InternalProtec
		{
			public string internalProtecName { get; set; }
		}

		//*************


		internal class ClassInternal
		{
			public string InternalName { get; set; }
		}

		//*************

	//**************** Example access in same container class in same namespace ************//
	public void TryAccess()
		{
			Protec demo = new Protec();
			demo.ProtecName = "I can access a protected class from whithin the containing class"; //No inheritence

			InternalProtec demo1 = new InternalProtec();
			demo1.internalProtecName = "I can access a protected class from whithin the containing class";

			ClassInternal demo3 = new ClassInternal();
			demo3.InternalName = "I can access a protected class from whithin the containing class";

		}
	}

	//**************** Example access in different container class in same namespace ************//
	public class AccessModifier2
	{
		//Cannot inherit from a protected class from another class in same namespace.
		protected class InheritFromProtec : Protec
		{
		}

		public void TryAccess2()
		{
			//I cannot access this class because its proteceted.
			AccessModifier.Protec demo = new AccessModifier.Protec();
			demo.ProtecName = "I can access a protected class from whithin the containing class"; //No inheritence

			AccessModifier.InternalProtec demo1 = new AccessModifier.InternalProtec();
			demo1.internalProtecName = "I can access a internal protected class from whithin another class in same assembly";

			AccessModifier.ClassInternal demo3 = new AccessModifier.ClassInternal();
			demo3.InternalName = "I can access a internal class from whithin another class in same assembly";
		}
	}

	//**************** Example Inherit in own namespace ************//
	public class AccessModifierInherited : AccessModifier
	{
		// Now I can access this class because the containing class has been inherited
		protected class InheritFromProtec : Protec
		{
		}

		public void TryAccess2()
		{
			// Now I can access this class because the containing class has been inherited
			AccessModifier.Protec demo = new AccessModifier.Protec();
			demo.ProtecName = "I can access a protected class from whithin the containing class"; //No inheritence

			AccessModifier.InternalProtec demo1 = new AccessModifier.InternalProtec();
			demo1.internalProtecName = "I can access a internal protected class from whithin another class in same assembly";

			AccessModifier.ClassInternal demo3 = new AccessModifier.ClassInternal();
			demo3.InternalName = "I can access a internal class from whithin another class in same assembly";
		}
	}
}


//**************** Example other namespace ************//
namespace OtherNamespace
{
	public class OtherAccessModifier 
	{
		public void TryAccess2()
		{
			//I cannot access this class because its proteceted.
			AccessModifier.Protec demo = new AccessModifier.Protec();
			demo.ProtecName = "I can access a protected class from whithin the containing class"; //No inheritence

			AccessModifier.InternalProtec demo1 = new AccessModifier.InternalProtec();
			demo1.internalProtecName = "I can access a protected class from whithin another class in same assembly";

			AccessModifier.ClassInternal demo3 = new AccessModifier.ClassInternal();
			demo3.InternalName = "I can access a protected class from whithin another class in same assembly";
		}
	}
}
//**************** Example Inherit in other namespace ************//
namespace OtherNamespace
{
	public class OtherAccessModifier2 : AccessModifier
	{
		public void TryAccess2()
		{
			//I cannot access this class because its proteceted.
			AccessModifier.Protec demo = new AccessModifier.Protec();
			demo.ProtecName = "I can access a protected class from whithin the containing class"; //No inheritence

			AccessModifier.InternalProtec demo1 = new AccessModifier.InternalProtec();
			demo1.internalProtecName = "I can access a protected class from whithin another class in same assembly";

			AccessModifier.ClassInternal demo3 = new AccessModifier.ClassInternal();
			demo3.InternalName = "I can access a protected class from whithin another class in same assembly";
		}
	}
}
