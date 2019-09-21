using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    class Castle : Building
    {
        public Castle()
        {
            cost = 30000;
        }

        public Castle(Castle c)
        {
            Village.GetVillage().AddSatisfaction(150);
            for (int i = 0; i < 20; i++)
            {
                Village.GetVillage().GetPeople().Add(new Villager());
                Village.GetVillage().GetPeople().Add(new Soldier());
            }
            cost = c.cost;
        }

        public override int GetCost()
        {
            return cost;
        }

        public override Building GetCopy()
        {
            Village.GetVillage().AddSatisfaction(150);
            for (int i = 0; i < 20; i++)
            {
                Village.GetVillage().GetPeople().Add(new Villager());
                Village.GetVillage().GetPeople().Add(new Soldier());
            }
            return new Castle(this);
        }

        public override void ShowBuildingOptions()
        {
            Console.Clear();
            Console.WriteLine("----------------- Castle -----------------");
            Console.WriteLine("This is castle. It raises the level of satisfaction of people.");
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Village.GetVillage().ShowBuildings();
        }
    }
}
