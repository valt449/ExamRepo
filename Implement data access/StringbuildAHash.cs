using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace dsfdfs
{
    public class StringbuildAHash
    {
		public static void Hashbuild()
		{
			int i = 0;
			// We will start to build a string using stringbuilder and then hash the string with a hashing algoritme.
            StringBuilder sb = new StringBuilder();
	        Console.WriteLine("This line shows info of a empty stringbuilder\n");
			
			ShowSBInfo(sb, ref i);
			
			Console.WriteLine("\nThis shows info about the stringbuilder when a sentence is appended to the stringbuilder in a loop 12times. \n");
            sb.Append("This is a sentence.");
            ShowSBInfo(sb, ref i);
            // Adding more text 11 times.
			for (int ctr = 0; ctr <= 10; ctr++)
            {
                sb.Append("This is an additional sentence.");
                // This shows the capacity, maxcapacity and lengh of our string.
                ShowSBInfo(sb, ref i);
            }
            Console.WriteLine("\nWe now write out the string: \n");
            Console.WriteLine(sb);
			Console.WriteLine("******* END OF STRING **********\n");

            Console.WriteLine("Some information about the string using typeof and GetType \n");
            var a = typeof(StringBuilder).Attributes;
            var b = sb.GetType().Attributes;
			Console.WriteLine("{0, -50} \n{1,-80} \n", "***** typeof(StringBuilder).Attributes *****", a);
			Console.WriteLine("{0, -50} \n{1,-80} \n", "***** sb.GetType().Attributes *****", b);


            //Now we hash the string
            Console.WriteLine("The hash of the string is:");
            
            var hash = GetStringSha256Hash(sb.ToString());
            Console.WriteLine(hash);
        }

        //This Method hashes a string using the SHA256 hashing algorithme which is considered safe.
       private static string GetStringSha256Hash(string text)
        {
            // Check if the string is empty since you cannot hash an empty string.
            if (String.IsNullOrEmpty(text))
                return String.Empty;

            using (var sha = new SHA256CryptoServiceProvider())
            {
                byte[] textData = Encoding.UTF8.GetBytes(text);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }
     
        // The method prints the information of the stringbuilder sb.
	    private static void ShowSBInfo(StringBuilder sb, ref int i)
	    {
		    i++;
		    Console.Write("{0,2}: ", i);
	    foreach

	    (var prop in sb.GetType().GetProperties())
            {
				if (prop.GetIndexParameters().Length == 0) //Measn that its not indexed
                    Console.Write("{0}: {1,3:N0}  ", prop.Name, prop.GetValue(sb));

            }
            Console.WriteLine();
        }
    }
}
