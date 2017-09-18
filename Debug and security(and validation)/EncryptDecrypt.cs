using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace dsfdfs
{
	class EncryptDecrypt
	{
		public static void MyMethod()
		{
			//Create random string with Guid and stringbuilder
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < 10; i++)
			{
				Guid g = Guid.NewGuid();
				sb.Append(g.ToString().Replace("-", string.Empty));
			}
			sb.Append("***** SomeThing Deep And MeaningFul *****");
			
			Console.WriteLine(sb.ToString());
			var test = new UnicodeEncoding();
			var bytedata = test.GetBytes(sb.ToString());

			//********* Asymmetric key ******

		

			//********* Generate public key and private key******
			string xmlKey;
			byte[] cryptoText;
			using (var RSA = new RSACryptoServiceProvider(4096*4))
			{
				cryptoText = RSA.Encrypt(bytedata, false);

				Console.WriteLine(BitConverter.ToString(cryptoText));

				xmlKey = RSA.ToXmlString(true);
				Console.WriteLine(xmlKey);

				var xml = new XmlSerializer(xmlKey.GetType());
				var fs = new FileStream(@"C:\Users\z6nii\OneDrive - KMD\code\Created text files from ExamPrep\Encryptkey.xml",FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
				xml.Serialize(fs,xmlKey);
			}

			using (var rsa2 = new RSACryptoServiceProvider(4096))
			{
				rsa2.FromXmlString(xmlKey);

				var decreptedtext = rsa2.Decrypt(cryptoText, false);

				Console.WriteLine(Encoding.Unicode.GetString(decreptedtext));
			}


			//********* Encrypt the string with public key (assymmetric)******


			//********* Decrypt the string with pricate key ******
		}
	}
}

