using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TheGame
{
    abstract class Human
    {
        public abstract void ShowPersonOptions();

        public void ConvertTo(Human h)
        {
            try
            {
                Village.GetVillage().SpendMoney(300);
                if (h.GetType() == new Soldier().GetType())
                {
                    Village v = Village.GetVillage();
                    List<Human> soldiers = v.GetPeople().FindAll(item => item.GetType() == new Soldier().GetType());
                    if (soldiers.Count == 6)
                    {
                        Enemy enemy = new WeakEnemy();
                        enemy.Attack();
                    }
                    else if (soldiers.Count == 70)
                    {
                        Enemy enemy = new PowerfulEnemy();
                        enemy.Attack();
                    }
                }
                List<Human> people = Village.GetVillage().GetPeople();
                int index = people.IndexOf(this);
                people[index] = h;
                Village.GetVillage().ShowPeople();
            } catch (NotEnoughResourcesException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
