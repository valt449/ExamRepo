using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace dsfdfs.Implement_data_access
{
	class DeserializeDemo
	{
		public static void MyMethod()
		{
			string directory = @"C:\Users\z6nii\OneDrive - KMD\code\Created text files from ExamPrep\";

			//************ DeSerializer from files to objects ***********

			//** Frmo XML **
			XmlSerializer Deserializer = new XmlSerializer(typeof(SerializeToXML));
			FileStream fs = new FileStream(directory + "FirstDemo.xml", FileMode.Open);
			var DeserializedXMLDemo = (SerializeToXML)Deserializer.Deserialize(fs);

			////Deserialization works, but cant find the values for the properties in the type. ****** This is due to access level of properties and use of XMLAttributeAttribute ****
			//var Deserializer1 = new XmlSerializer(typeof(SerializeToXMLWithXMLRoot));
			//var fs1 = new FileStream(directory + "FirstDemoWithXMLRoot.xml", FileMode.Open);
			//var DeserializedXMLDemoWithXMLRoot = Deserializer1.Deserialize(fs1);
			
			var Deserializer2 = new DataContractSerializer(typeof(SerializeToXMLWithDataContract));
			var fs2 = new FileStream(directory + "FirstDemoWithDataContract.xml", FileMode.Open);
			var DeserializedXMLWtihDataContract = (SerializeToXMLWithDataContract)Deserializer2.ReadObject(fs2);
			
			//** From JSON **
			var deser = new DataContractJsonSerializer(typeof(SerializeToXMLWithDataContract));
			var fs3 = new FileStream(directory + "FirstJson.json", FileMode.Open);
			var DeserializedJson = (SerializeToXMLWithDataContract)deser.ReadObject(fs3);
			
			//** Binary **
			var bfor = new BinaryFormatter();
			var ffs4 = new FileStream(directory + "FirstBinary.bin",FileMode.Open);
			var DeserializedBinary = (SerializeToXML)bfor.Deserialize(ffs4);

			//**Write all objects to console: 
			Console.WriteLine("{3,-35}{0,-35} {1,-25}{2,-25}\n","Message", "AgeProp", "NameProp","ObjectName");
			Console.WriteLine("{3,-35}{0,-35} {1,-25}{2,-25}", DeserializedXMLDemo.Message, DeserializedXMLDemo.Age | 5, DeserializedXMLDemo.Name, nameof(DeserializedXMLDemo));
			//Console.WriteLine("{3,-25}{0,-25} {1,-25}{2,-52}", DeserializedXMLDemoWithXMLRoot.Message, DeserializedXMLDemoWithXMLRoot.Age | 5, DeserializedXMLDemoWithXMLRoot.Name, nameof(DeserializedXMLDemoWithXMLRoot));
			Console.WriteLine("{3,-35}{0,-35} {1,-25}{2,-25}", DeserializedXMLWtihDataContract.Message, 5, "No name beacause of protectionlevel", nameof(DeserializedXMLWtihDataContract));
			Console.WriteLine("{3,-35}{0,-35} {1,-25}{2,-25}", DeserializedJson.Message, 5, "No name beacause of protectionlevel", nameof(DeserializedJson));
			Console.WriteLine("{3,-35}{0,-35} {1,-25}{2,-25}", DeserializedBinary.Message, DeserializedBinary.Age, DeserializedBinary.Name, nameof(DeserializedBinary));
		}
	}
}
