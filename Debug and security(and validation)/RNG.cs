using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace dsfdfs
{
	class RNG
	{
		public static void MyMethod()
		{
			using (var random = new RNGCryptoServiceProvider())
			{
				byte[] bytes = new byte[2];

				for (int j = 0; j < 10; j++)
				{
					random.GetBytes(bytes);

					Console.WriteLine(BitConverter.ToInt16(bytes, 0));

				}
			}

			Console.WriteLine();
			//foreach (var bytese in list)
			//{
			//	int value2 = bytese;
			//	Console.WriteLine(value2);
			//}
		}
	}
}