using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TheGame
{
    class Granary : Building
    {
        [JsonProperty]
        private List<Food> food { get; set; }
        [JsonProperty]
        int capacity { get; set; }

        public Granary()
        {
            cost = 1000;
            capacity = 1000;
            food = new List<Food>();
        }

        public Granary(Granary g)
        {
            cost = g.cost;
            capacity = g.capacity;
            food = g.food;
        }

        public override int GetCost()
        {
            return cost;
        }

        public override Building GetCopy()
        {
            return new Granary();
        }

        public override void ShowBuildingOptions()
        {
            Console.Clear();
            Console.WriteLine("----------------- Granary -----------------");
            if (food.Count == 0)
            {
                Console.WriteLine("Granary is empty!");
            } else
            {
                int i = 1;
                foreach (Food f in food)
                {
                    Console.WriteLine("[" + i + "]\t" + f.ToString().Split('.')[1]);
                    i++;
                }
            }
            //Console.WriteLine("What do You want to do?");
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Village.GetVillage().ShowBuildings();
        }

        public void AddToGranary(Food f)
        {
            Console.WriteLine("Adding food to granary...");
            if (food.Count < capacity)
            {
                food.Add(f);
            } else
            {
                throw new FullContainerException("Granary is full!");
            }
        }

        public void TakeFromGranary(Food f)
        {
            foreach (Food item in food)
            {
                if (item.GetType() == f.GetType())
                {
                    food.Remove(item);
                    return;
                }
            }
            throw new NotEnoughResourcesException("There is no " + f.GetType() + " in this granary!");
        }
    }
}
