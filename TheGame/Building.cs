using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TheGame
{
    abstract class Building
    {
        [JsonProperty]
        protected int cost;

        public static void BuyNew()
        {
            Console.Clear();
            Console.WriteLine("----------------- Buy new building -----------------");
            List<Building> buildingTypes = new List<Building>
            {
                new Armory(),
                new Bakery(),
                new Castle(),
                new Granary(),
                new House(),
                new Temple()
            };

            Console.WriteLine(" \tBuilding\t| Cost");
            Console.WriteLine("----------------------------------");
            int i = 1;
            foreach (Building building in buildingTypes)
            {
                Console.WriteLine("[" + i + "]\t" + building.ToString().Split('.')[1] + "\t| " + building.GetCost());
                i++;
            }
            int answer;
            Console.Write("> ");
            Int32.TryParse(Console.ReadLine(), out answer);
            try
            {
                Village v = Village.GetVillage();
                v.SpendMoney(buildingTypes[answer - 1].GetCost());
                v.AddBuilding(buildingTypes[answer - 1].GetCopy());
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("New " + buildingTypes[answer - 1].ToString().Split('.')[1] + " added to your village!");
                Console.ResetColor();
                Console.WriteLine("Press any key...");
                Console.ReadKey();
                v.ShowBuildings();
            } catch (NotEnoughResourcesException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                Console.WriteLine("Press any key...");
                Console.ReadKey();
                Village v = Village.GetVillage();
                v.ShowBuildings();
            }
        }

        abstract public int GetCost();
        abstract public Building GetCopy();
        abstract public void ShowBuildingOptions();
    }
}
