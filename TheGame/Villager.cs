using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    class Villager : Human
    {
        public override void ShowPersonOptions()
        {
            Console.Clear();
            Console.WriteLine("What do You want to do?");
            Console.WriteLine("[1]\tConvert to farmer");
            Console.WriteLine("[2]\tConvert to priest");
            Console.WriteLine("[3]\tConvert to soldier");
            Console.WriteLine("[4]\tBack to people list.");
            Console.WriteLine("[5]\tBack to village");
            Console.WriteLine("[6]\tBack to Main Options");
            int answer;
            Console.Write("> ");
            Int32.TryParse(Console.ReadLine(), out answer);
            switch (answer)
            {
                case 1:
                    ConvertTo(new Farmer());
                    break;
                case 2:
                    ConvertTo(new Priest());
                    break;
                case 3:
                    ConvertTo(new Soldier());
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
    }
}
