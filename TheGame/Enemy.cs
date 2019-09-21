using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TheGame
{
    abstract class Enemy
    {
        protected List<Soldier> soldiers;
        protected int money;

        private void Battle()
        {
            Village v = Village.GetVillage();
            List<Human> v_soldiers = v.GetPeople().FindAll(item => item.GetType() == new Soldier().GetType());
            if (v_soldiers.Count > soldiers.Count)
            {
                Console.WriteLine("Congratulations, You win!");
                Random rnd = new Random();
                int new_people = rnd.Next(1, 5);
                Console.WriteLine(new_people + " new people are coming to your village.");
                for (int i = 0; i < new_people; i++)
                {
                    v.AddHuman(new Villager());
                }
                Console.WriteLine("You get " + money + " money!");
                v.AddMoney(money);
                Console.WriteLine("Press any key...");
                Console.ReadKey();
                v.ShowPeople();
            }
            else if (v_soldiers.Count == soldiers.Count)
            {
                Console.WriteLine("It's a draw!");
                Console.WriteLine("Press any key...");
                Console.ReadKey();
                v.ShowPeople();
            }
            else
            {
                Console.WriteLine("You loose!");
                Console.WriteLine("GAME OVER");
                Console.WriteLine("Press any key...");
                Console.ReadKey();
                Environment.Exit(1);
            }
        }

        public void Attack()
        {
            Console.Clear();
            Console.WriteLine("----------------- Battle -----------------");
            Console.WriteLine("You are under attack!");
            Console.WriteLine("...");
            Thread.Sleep(1000);
            Battle();
        }
        public void Defend()
        {
            Console.Clear();
            Console.WriteLine("----------------- Battle -----------------");
            Console.WriteLine("ATTACK!");
            Console.WriteLine("...");
            Thread.Sleep(1000);
            Battle();
        }
    }
}
