using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    class PowerfulEnemy : Enemy
    {
        public PowerfulEnemy()
        {
            Random rnd = new Random();
            int count = rnd.Next(30, 100);
            soldiers = new List<Soldier>();
            for (int i = 0; i < count; i++)
            {
                soldiers.Add(new Soldier());
            }
            money = rnd.Next(30000, 100000);
        }
    }
}
