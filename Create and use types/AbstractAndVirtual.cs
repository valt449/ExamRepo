using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ABSTRACT VS VIRTUAL
//An abstract function cannot have functionality.You're basically saying, any child class MUST give their own version of this method, 
//however it's too general to even try to implement in the parent class.
//(NO IMPLEMENTATION - Must override)

//A virtual function, is basically saying look, here's the functionality that may or may not be good enough for the child class. So if it is good enough, 
//use this method, if not, then override me, and provide your own functionality. 
//(Possible implementation - Possible override)

namespace dsfdfs.Create_and_use_types
{
	class AbstractAndVirtual
	{
		public abstract class myBase
		{
			//If you derive from this class you must implement this method. notice we have no method body here either
			public abstract void YouMustImplement();

			//If you derive from this class you can change the behavior but are not required to
			public virtual void YouCanOverride()
			{
			//The virtual keyword is used to modify a method, property, indexer, or event declaration and allow for it to be overridden in a derived class. 
			//For example, this method can be overridden by any class that inherits it:
			//***NOT CLASSES***
			}
		}

		public class MyBase
		{
			//This will not compile because you cannot have an abstract method in a non-abstract class
			public abstract void YouMustImplement();

			public virtual void YouCanOverride()
			{
			}
		}
	}
}
