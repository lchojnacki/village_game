using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TheGame
{
    class Soldier : Human
    {
        public override void ShowPersonOptions()
        {
            Console.Clear();
            Console.WriteLine("----------------- Soldier -----------------");
            Console.WriteLine("AGRR! I'm a SOLDIER!");
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Village.GetVillage().ShowPeople();
        }
    }
}
