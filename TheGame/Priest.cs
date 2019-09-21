using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    class Priest : Human
    {
        public Priest()
        {
            Village.GetVillage().AddSatisfaction(5);
        }
        public override void ShowPersonOptions()
        {
            Console.Clear();
            Console.WriteLine("----------------- Priest -----------------");
            Console.WriteLine("Do you want to talk about Jesus?");
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Village.GetVillage().ShowPeople();
        }
    }
}
