using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    class FarmerStrategyFruits : FarmerStrategy
    {
        public void MakeFood()
        {
            if (Village.GetVillage().GetBuildings().Any(item => item.GetType() == new Granary().GetType()))
            {
                Village v = Village.GetVillage();
                List<Building> granarys = v.GetBuildings().FindAll(item => item.GetType() == new Granary().GetType());
                bool success = false;
                foreach (Granary g in granarys)
                {
                    try
                    {
                        g.AddToGranary(new Fruit());
                        success = true;
                        break;
                    }
                    catch (FullContainerException)
                    {
                        continue;
                    }
                }
                if (success)
                {
                    Console.WriteLine("Fruit moved to granary");
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
                    v.ShowPeople();
                }
                else
                {
                    Console.WriteLine("All your granaries are full!");
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
                    v.ShowPeople();
                }
            }
            else
            {
                Console.WriteLine("You don't have granary! All fruits thrown away... :(");
                Console.WriteLine("Press any key...");
                Console.ReadKey();
                Village.GetVillage().ShowPeople();
            }
        }
    }
}
