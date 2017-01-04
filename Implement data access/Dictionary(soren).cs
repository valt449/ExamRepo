using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsfdfs
{
	class Dictionary_soren_
	{
		class Animal
		{
			public string Name { get; set; }
			public string Branch { get; set; }

			public Animal(string name, string branch)
			{
				Name = name;
				Branch = branch;
			}
		}
		public static void MyMethod()
		{
			// Important information about a list: It does not have a key, but it does have an index. Whenever you remove an item it restacks it self
			// Restriving an item from the list does not erase it.

			//Define a List
			List<Animal> Zoo = new List<Animal>();

			// Adding elements to the list
			Zoo.Add(new Animal("Tiger", "Carnivore"));
			Zoo.Add(new Animal("lion", "Carnivore"));
			Zoo.Add(new Animal("Monkey", "Carnivore"));
			Zoo.Add(new Animal("Giraf", "Herbivores"));
			Zoo.Add(new Animal("Elefant", "Herbivores"));

			// List the animals in the zoo. The \t makes the type of animal stand on exact same vertical lines.
			foreach (Animal animal in Zoo)
			{
				Console.WriteLine("Animal name : {0}, \t  Type of Animal:  {1}", animal.Name, animal.Branch);
			}

			// Insert a new item at position 2.
			Zoo.Insert(2, new Animal("Rabbit", "Herbivores"));
			Console.WriteLine(" \n addding a rabbit at index 2 was Succesfull \n");

			// Listing all animals with the rabbit added
			foreach (Animal animal in Zoo)
			{
				Console.WriteLine("Animal name : {0}, \t  Type of Animal:  {1}", animal.Name, animal.Branch);
			}
			// Now we will empty the list.

			Zoo.RemoveAt(3);
			Zoo.RemoveAt(3);


			Console.WriteLine(" \n Listing all the elements in the list after erasing the one at index 3 twice: \n");

			// Listing all animals with the rabbit added
			foreach (Animal animal in Zoo)
			{
				Console.WriteLine("Animal name : {0}, \t  Type of Animal:  {1}", animal.Name, animal.Branch);
			}

			//Erasing the rest

			//alternative way to remove all 
			for (int i = 0; 0 < Zoo.Count; i++)
			{
				Console.WriteLine(Zoo[0] + " Removed!!");
				Zoo.RemoveAt(0);
			}

			Zoo.Clear();

			Console.WriteLine(" \n Listing all the elements in the list after erasing them all: \n");

			// Listing all animals with the rabbit added
			foreach (Animal animal in Zoo)
			{
				Console.WriteLine("Animal name : {0}, \t  Type of Animal:  {1}", animal.Name, animal.Branch);
			}


			Console.WriteLine(" \n Now we focus on dictionaries \n");

			// Create a new dictionary of strings, with string keys. The Key Comes first
			// 
			Dictionary<string, string> Zoo2 = new Dictionary<string, string>();

			// Add some elements to the dictionary. There are no 
			// duplicate keys, but some of the values are duplicates.
			Zoo2.Add("Carnivore", "Tiger");
			Zoo2.Add("Herbivores", "Giraf");
			// The Add method throws an exception if the new key is 
			// already in the dictionary.
			try
			{
				Zoo2.Add("Herbivores", "Rabbit");
			}
			catch (ArgumentException)
			{
				Console.WriteLine("An element with Key = \"Herbivores\" already exists.");
			}

			// You can access the value of an element from its key, and use the key to change its value.
			Console.WriteLine("For key = \"Carnivore\", value = {0}.", Zoo2["Carnivore"]);
			Zoo2["Carnivore"] = "Lion";
			Console.WriteLine("For key = \"Carnivore\", value = {0}.", Zoo2["Carnivore"]);

			// If a key does not exist, setting the indexer for that key
			// adds a new key/value pair.
			Zoo2["NonEating"] = "The Loser Animal";
			Console.WriteLine("For key = \"NonEating\", value = {0}.", Zoo2["NonEating"]);


			// When you use foreach to enumerate dictionary elements,
			// the elements are retrieved as KeyValuePair objects
			Console.WriteLine();
			foreach (KeyValuePair<string, string> pair in Zoo2)
			{
				Console.WriteLine("Key = {0}, Value = {1}",
					pair.Key, pair.Value);
			}

			// Use the Remove method to remove a key/value pair.
			Console.WriteLine("\n Remove(\"NonEating\")");
			Zoo2.Remove("NonEating");

			if (!Zoo2.ContainsKey("NonEating"))
			{
				Console.WriteLine("Key \"NonEating\" Was Succefully Rmoved..");
			}
		}
	}
}
