using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TheGame
{
    class House : Building
    {
        public House()
        {
            cost = 500;
        }

        public House(House h)
        {
            cost = h.cost;
        }

        public override int GetCost()
        {
            return cost;
        }

        public override Building GetCopy()
        {
            return new House(this);
        }

        public override void ShowBuildingOptions()
        {
            Console.Clear();
            Console.WriteLine("----------------- House -----------------");
            Console.WriteLine("A simple house.");
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Village.GetVillage().ShowBuildings();
        }
    }
}
