using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4_15._06_
{
    static class PersonExt
    {
        public static void TryToExtract(this Person[] squad, Plant plant)
        {
            if(squad == null) return;

            squad[0].TryingExtract = true;
            int countOfExtracting = 0;

            while (countOfExtracting != squad.Length)
            {
                Console.WriteLine("------------------------");
                int squadPower = 0;
                int indexOfHelp = 0;
                countOfExtracting = 0;
                for (int i = 0; i < squad.Length; i++)
                {
                    if (squad[i].TryingExtract)
                    {
                        squadPower += squad[i].Power;
                        countOfExtracting++;
                        Console.WriteLine($"{squad[i].Name} try Extract plant...");
                        Console.WriteLine($"Total Power = {squadPower}\n");
                    }
                    else if (indexOfHelp == 0)
                        indexOfHelp = i;
                }

                if (plant.TryToExctract(squadPower))
                {
                    Console.WriteLine($" !!! You got {plant.TypeOfPlant} !!!");
                }
                else
                {
                    Console.WriteLine("not enough power...");
                    if (countOfExtracting == squad.Length)
                        Console.WriteLine("no more help left, you can't Extract this plant...");
                    else
                    {
                        Console.WriteLine("call help...");
                        squad[indexOfHelp].CallHelp();
                    }
                }
            }
        }
    }
}
