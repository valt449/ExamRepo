using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml;
using Newtonsoft;


namespace dsfdfs
{
	class SerializeDemo
	{
		public static void MyMethod()
		{
			string directory = @"C:\Users\z6nii\OneDrive - KMD\code\Created text files from ExamPrep\";
			//************ Serializer To files from objects ***********

			//** XML **
			var XMLDemo = new SerializeToXML("FirstDemo"); //Instanciate object to serialize


			var xmlSerializer = new XmlSerializer(typeof(SerializeToXML)); //Instanciate the XMlSerializer
			//FileStream ffs = new FileStream(directory + "FirstDemo.xml", FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read); // Alternative creation of file and stream
			StreamWriter streamWriter = new StreamWriter(directory + "FirstDemo.xml"); // Easiest creation of file and stream
			xmlSerializer.Serialize(streamWriter, XMLDemo); // Write XMLDemo til streamWriter(object) and file
			
			// USING XMLROOT - Look at class and file to see the output of this syntax -> XMLROOTAttribute and XMLElement and XMLAttribute gives more control then without.
			var XmlDemoWithXMLRoot = new SerializeToXMLWithXMLRoot("There should be no Age or Name");

			var xmlSerializer1 = new XmlSerializer(typeof(SerializeToXMLWithXMLRoot));
			StreamWriter streamWriter1 = new StreamWriter(directory + "FirstDemoXmlRoot.xml");
			xmlSerializer1.Serialize(streamWriter1, XmlDemoWithXMLRoot);

			// USING DataContract - Works as well, but can serialize members thats private, protected, etc. when serialized theese access modifiers will restrict access as normal. (look at Deserialize.cs)
			var XmlDemoWithDataContract = new SerializeToXMLWithDataContract("All properties should be included");

			var xmlserializer2 = new DataContractSerializer(typeof(SerializeToXMLWithDataContract));
			var s = new FileStream(directory + "FirstDemoWithDataContract.xml",FileMode.Create);
			xmlserializer2.WriteObject(s, XmlDemoWithDataContract);
			
			//** JSON **
			//Using the same DataContract Object as above. 
			var ffs1 = new FileStream(directory + "FirstJson.json", FileMode.Create);
			var ser = new DataContractJsonSerializer(typeof(SerializeToXMLWithDataContract));
			ser.WriteObject(ffs1, XmlDemoWithDataContract); //Data contract needs a filestream object 
			
			//** Binary **
			var formatter = new BinaryFormatter();
			var ff2 = new FileStream(directory + "FirstBinary.bin", FileMode.Create,FileAccess.ReadWrite,FileShare.ReadWrite);
			formatter.Serialize(ff2, XMLDemo);
			
		}
	}
	//Clean class - all will be serialized
	[Serializable] //Binary serializer needs this, XMLSerializer does NOT need it!!
	public class SerializeToXML
	{
		//[NonSerialized] can be used on fields
		public string Name { get; set; }
		public int Age { get; set; }
		public string Message { get; set; }

		//inherit from other ctor
		public SerializeToXML()
		{
		}

		public SerializeToXML(string message, string name = "DefaultNameOfTheDemo", int age = 15)
		{
			Name = name;
			Age = age;
			Message = message;
		}
	}
	// Use of XML attributeds
	[XmlRoot]
	public class SerializeToXMLWithXMLRoot //OBS Message is an attribute
	{
		
		[XmlElement]
		public string Name { get; set; }
		[XmlAttribute]
		protected int Age { get; }
		[XmlAttribute] //Check how to make an atribute to a element
		public string Message { get; set; }

		public SerializeToXMLWithXMLRoot()
		{
		}

		public SerializeToXMLWithXMLRoot(string message, string name = "DefaultNameOfTheDemo", int age = 15)
		{
			Name = name;
			Age = age;
			Message = message;
		}
	}
	// Use of Datacontract - all members with [DataMember] gets included -> Even private fields or ** Not props with no set'er**
	[DataContract]
	public class SerializeToXMLWithDataContract
	{
		[DataMember(Order = 4)] //Lowest number is top. 
		private string something; //OBS AccessLevel
		[DataMember (Order = 2, Name = "WHAT")] //Change name with name. 
		protected string Name { get; set; } //OBS AccessLevel
		[DataMember (Order = 3)]
		private int Age { get; set; } //OBS AccessLevel
		[DataMember(Order = 0)]
		public string Message { get; set; } //OBS AccessLevel

		//inherit from other ctor
		public SerializeToXMLWithDataContract()
		{
		}

		public SerializeToXMLWithDataContract(string message, string name = "DefaultNameOfTheDemo", int age = 15, string something = "test")
		{
			Name = name;
			Age = age;
			Message = message;
			this.something = something;
		}
	}

}
