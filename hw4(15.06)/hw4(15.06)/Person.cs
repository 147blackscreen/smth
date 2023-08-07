using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace hw4_15._06_
{
    class Person
    {
        public string Name { get; }
        public int Power { get; }
        public bool TryingExtract;

        public Person(string name, int power)
        {
            TryingExtract = false;
            Name = name;
            Power = power;
            Console.WriteLine($"Created new Person - {Name}...");
        }
        
        public void CallHelp()
        {
            Console.WriteLine($"{Name} come to help extract plant...");
            TryingExtract = true;
        }

    }
}
