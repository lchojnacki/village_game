using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TheGame
{
    class Farmer : Human
    {
        [JsonProperty]
        FarmerStrategy strategy; 

        public Farmer()
        {
            strategy = new FarmerStrategyFruits();
        }

        public Farmer(FarmerStrategy s)
        {
            strategy = s;
        }

        public override void ShowPersonOptions()
        {
            Console.Clear();
            Console.WriteLine("What do You want to do?");
            Console.WriteLine("[1]\tMake food");
            Console.WriteLine("[2]\tSet strategy to fruits");
            Console.WriteLine("[3]\tSet strategy to grains");
            Console.WriteLine("[4]\tBack to people list.");
            Console.WriteLine("[5]\tBack to village");
            Console.WriteLine("[6]\tBack to Main Options");
            int answer;
            Console.Write("> ");
            Int32.TryParse(Console.ReadLine(), out answer);
            switch (answer)
            {
                case 1:
                    MakeFood();
                    break;
                case 2:
                    SetStrategy(new FarmerStrategyFruits());
                    break;
                case 3:
                    SetStrategy(new FarmerStrategyGrain());
                    break;
                case 4:
                    Village.GetVillage().ShowPeople();
                    break;
                case 5:
                    Village.GetVillage().ShowVillage();
                    break;
                case 6:
                    Program.MainOptions();
                    break;
                default:
                    ShowPersonOptions();
                    break;
            }
        }

        public void MakeFood()
        {
            strategy.MakeFood();
        }

        public void SetStrategy(FarmerStrategy s)
        {
            strategy = s;
            Village.GetVillage().ShowPeople();
        }
    }
}
