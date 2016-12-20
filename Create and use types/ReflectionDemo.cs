using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection; //Reflection Namespace
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

//***********
//Reflection
//***********
//These BindingFlags control binding for a great many classes in the System, System.Reflection, and System.Runtime namespaces that invoke, create, get, set, and find members and types.
//You must specify 'Instance' or 'Static' along with 'Public' or 'NonPublic' or no members will be returned.

namespace dsfdfs.Create_and_use_types
{
	public class Reflection
	{
		internal class something
		{
			
		}

		 protected class MyClass : something
		{
			
		}

		public static void Demo()
		{
			Type t = Type.GetType("dsfdfs.Create_and_use_types.ReflectionDemo");

			Console.WriteLine("Construtors:");
			ConstructorInfo[] constructors = t.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
			foreach (ConstructorInfo constructor in constructors)
			{
				Console.WriteLine(constructor);
			}
			Console.WriteLine("\t");
			Console.WriteLine("Properties:");
			PropertyInfo[] properties = t.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

			foreach (PropertyInfo property in properties)
			{
				if (property.GetGetMethod(true).IsPrivate)
				{
					Console.Write("Private ");
				}
				Console.WriteLine(property.MemberType + " " + property.PropertyType);
			}
		}
	}

	//public class ReflectionDemo
	//{
	//	public string Name { get; set; }
	//	private int Quantity { get; set; }

	//	public ReflectionDemo(string name, int quantity)
	//	{
	//		this.Name = name;
	//		this.Quantity = +quantity;
	//	}
	//}
}
