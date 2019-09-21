using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    class Armory : Building
    {
        public Armory()
        {
            cost = 5000;
        }

        public Armory(Armory a)
        {
            cost = a.cost;
        }

        public override int GetCost()
        {
            return cost;
        }

        public override Building GetCopy()
        {
            return new Armory(this);
        }

        public override void ShowBuildingOptions()
        {
            Console.Clear();
            Console.WriteLine("----------------- Armory -----------------");
            Village v = Village.GetVillage();
            List<Human> v_soldiers = v.GetPeople().FindAll(item => item.GetType() == new Soldier().GetType());
            Console.WriteLine("You have " + v_soldiers.Count + " soldiers in your village.");
            IteratorSoldiers iterS = new IteratorSoldiers(v.GetPeople());
            int i = 1;
            while(!iterS.IsDone())
            {
                Console.WriteLine("[" + i + "]\t" + iterS.CurrentItem().ToString().Split('.')[1]);
                iterS.Next();
                i++;
            }
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Village.GetVillage().ShowBuildings();
        }
    }
}
