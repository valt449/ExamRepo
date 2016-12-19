using System;

namespace dsfdfs.Create_and_use_types
{
	/// <summary>
	/// Summary description for Class1
	/// </summary>

	public struct StructStruct
	{
		public string Name { get; set; }

		public StructStruct(string name)
		{
			Name = name;
		}

		public static void Demo()
		{
			var structDemo = new StructStruct();
			structDemo.Name = "CoolName";
			Console.WriteLine(structDemo.Name);
		}

	}
}

