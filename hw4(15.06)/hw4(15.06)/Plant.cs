using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4_15._06_
{
    class Plant
    {
        private int _strenght;
        private int Strenght { get { return _strenght; } }
        private int StrenghtPerGrowth;
        public string TypeOfPlant { get; }

        public Plant(int strPerGrow, string type)
        {
            TypeOfPlant = type;
            StrenghtPerGrowth = strPerGrow;
            Console.WriteLine($"You plant a {TypeOfPlant}...");
            Growth();
        }

        private void Growth()
        {
            Console.WriteLine($"{TypeOfPlant} starts growing...");
            Console.WriteLine($"Current strenght = {Strenght}");

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine($"{TypeOfPlant} growing...");
                _strenght += StrenghtPerGrowth;
                Console.WriteLine($"Current strenght = {Strenght}");
            }
        }

        public bool TryToExctract(int power)
        {
            if (power < Strenght)
                return false;
            else
                return true;
        }
    }
}
