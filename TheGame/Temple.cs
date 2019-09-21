using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    class Temple : Building
    {
        public Temple()
        {
            cost = 15000;
        }

        public Temple(Temple t)
        {
            cost = t.cost;
        }

        public override int GetCost()
        {
            return cost;
        }

        public override Building GetCopy()
        {
            Village.GetVillage().AddSatisfaction(80);
            return new Temple(this);
        }

        public override void ShowBuildingOptions()
        {
            Console.Clear();
            Console.WriteLine("----------------- Temple -----------------");
            Console.WriteLine("This is temple. It raises the level of satisfaction of people.");
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Village.GetVillage().ShowBuildings();
        }
    }
}
