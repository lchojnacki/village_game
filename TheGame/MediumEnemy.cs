using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    class MediumEnemy : Enemy
    {
        public MediumEnemy()
        {
            Random rnd = new Random();
            int count = rnd.Next(10, 25);
            soldiers = new List<Soldier>();
            for (int i = 0; i < count; i++)
            {
                soldiers.Add(new Soldier());
            }
            money = rnd.Next(10000, 25000);
        }
    }
}
