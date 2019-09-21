using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    class WeakEnemy : Enemy
    {
        public WeakEnemy()
        {
            Random rnd = new Random();
            int count = rnd.Next(1, 5);
            soldiers = new List<Soldier>();
            for (int i = 0; i < count; i++)
            {
                soldiers.Add(new Soldier());
            }
            money = rnd.Next(1000, 5000);
        }
    }
}
