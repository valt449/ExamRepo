using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Nico
{

    public struct something
    {
        public string Name { get; set; }

        public something(string name)
        {
            Name = name;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {



            Console.WriteLine("What is happening here world?");
            Console.ReadLine();
        }
    }
}