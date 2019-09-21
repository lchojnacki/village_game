using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TheGame
{
    [Serializable]
    class Village
    {
        private static Village village;
        [JsonProperty]
        private List<Building> buildings;
        [JsonProperty]
        private List<Human> people;
        [JsonProperty]
        private int money;
        [JsonProperty]
        private int satisfaction;

        private Village()
        {
            if (village == null)
            {
                village = this;
                village.money = 10000;
                village.satisfaction = 50;
                village.buildings = new List<Building>();
                village.people = new List<Human>();
                for (int i = 0; i < 10; i++)
                {
                    village.people.Add(new Villager());
                }
                village.people.Add(new Soldier());
            }
            else
            {
                Console.WriteLine("Can't create more than one object of this type.");
            }
        }

        public static Village GetVillage()
        {
            if (village != null)
            {
                return village;
            } else
            {
                village = new Village();
                return village;
            }
        }

        public void SetVillageState(List<Building> _buildings, List<Human> _people, int _money)
        {
            buildings = _buildings;
            people = _people;
            money = _money;
        }

        public int CountBuildings()
        {
            return buildings.Count;
        }

        public List<Building> GetBuildings()
        {
            return buildings;
        }

        public int CountPeople()
        {
            return people.Count;
        }

        public List<Human> GetPeople()
        {
            return people;
        }

        public int GetMoney()
        {
            return money;
        }

        public void AddMoney(int amount)
        {
            this.money += amount;
        }

        public int GetSatisfaction()
        {
            return satisfaction;
        }

        public void AddSatisfaction(int amount)
        {
            int before = satisfaction;
            satisfaction += amount;
            if (before/100 < satisfaction/100)
            {
                for (int i = 0; i < 20; i++) {
                    people.Add(new Villager());
                }
            }
        }

        public void AddHuman(Human human)
        {
            people.Add(human);
        }

        public void AddBuilding(Building b)
        {
            this.buildings.Add(b);
        }

        public int SpendMoney(int amount)
        {
            if (amount <= this.money)
            {
                this.money -= amount;
                return amount;
            } else
            {
                throw new NotEnoughResourcesException("Not enough money");
            }
        }

        public void ShowPeople()
        {
            Console.Clear();
            Console.WriteLine("----------------- People -----------------");
            if (people.Count == 0)
            {
                Console.WriteLine("Your village is empty!");
            } else
            {
                int i = 1;
                foreach (Human human in people)
                {
                    Console.WriteLine("[" + i + "]\t" + human.ToString().Split('.')[1]);
                    i++;
                }
                Console.WriteLine("What do You want to do?");
                Console.WriteLine("[1- " + (i - 1) + "]\tInteract with person");
                Console.WriteLine("[" + i + "]\tBack to village");
                Console.WriteLine("[" + (i + 1) + "]\tBack to Main Options");
                int answer;
                Console.Write("> ");
                Int32.TryParse(Console.ReadLine(), out answer);
                if (1 <= answer && answer <= (i - 1))
                {
                    people[answer-1].ShowPersonOptions();
                }
                else if (answer == i)
                {
                    ShowVillage();
                }
                else if (answer == (i + 1))
                {
                    Program.MainOptions();
                }
            }
        }

        public void ShowBuildings()
        {
            Console.Clear();
            Console.WriteLine("----------------- Buildings -----------------");
            if (buildings.Count == 0)
            {
                Console.WriteLine("You have no buildings. Do you want to buy one?");
                Console.WriteLine("[1]\tYes");
                Console.WriteLine("[2]\tNo, go back to my village");
                int answer;
                Console.Write("> ");
                Int32.TryParse(Console.ReadLine(), out answer);
                switch(answer)
                {
                    case 1:
                        Building.BuyNew();
                        break;
                    case 2:
                        ShowVillage();
                        break;
                    default:
                        ShowVillage();
                        break;
                }
            } else
            {
                int i = 1;
                foreach (Building building in buildings)
                {
                    Console.WriteLine("[" + i + "]\t" + building.ToString().Split('.')[1]);
                    i++;
                }
                Console.WriteLine("What do You want to do?");
                Console.WriteLine("[1- " + (i - 1) + "]\tInteract with building");
                Console.WriteLine("[" + i + "]\tBuy new building");
                Console.WriteLine("[" + (i + 1) + "]\tBack to village");
                Console.WriteLine("[" + (i + 2) + "]\tBack to Main Options");
                int answer;
                Console.Write("> ");
                Int32.TryParse(Console.ReadLine(), out answer);
                if (1 <= answer && answer <= (i - 1))
                {
                    buildings[answer-1].ShowBuildingOptions();
                }
                else if (answer == i)
                {
                    Building.BuyNew();
                }
                else if (answer == i + 1)
                {
                    ShowVillage();
                }
                else if (answer == (i + 2))
                {
                    Program.MainOptions();
                }
            }
        }

        public void ShowVillage()
        {
            Console.Clear();
            Console.WriteLine("----------------- Village -----------------");
            Console.WriteLine("Number of buildings: " + CountBuildings());
            Console.WriteLine("Number of people: " + CountPeople());
            Console.WriteLine("Money: " + GetMoney());
            Console.WriteLine("Satisfaction level: " + GetSatisfaction());

            Console.WriteLine("What do You want to do?");
            Console.WriteLine("[1]\tShow People");
            Console.WriteLine("[2]\tShow Buildings");
            Console.WriteLine("[3]\tAttack enemy");
            Console.WriteLine("[4]\tGo to Main Options");
            int answer;
            Console.Write("> ");
            Int32.TryParse(Console.ReadLine(), out answer);
            switch (answer)
            {
                case 1:
                    ShowPeople();
                    break;
                case 2:
                    ShowBuildings();
                    break;
                case 3:
                    Attack();
                    break;
                case 4:
                    Program.MainOptions();
                    break;
                default:
                    this.ShowVillage();
                    break;
            }
        }

        /*public string Serialization()
        {
            string json = JsonConvert.SerializeObject(Village.GetVillage(), Formatting.Indented);
            return json;
        }*/

        public void Attack()
        {
            Console.Clear();
            Console.WriteLine("----------------- Village -----------------");
            Console.WriteLine("Select level of enemy:");
            Console.WriteLine("[1]\tWeak");
            Console.WriteLine("[2]\tMedium");
            Console.WriteLine("[3]\tPowerful");
            int answer;
            Console.Write("> ");
            Int32.TryParse(Console.ReadLine(), out answer);
            switch(answer)
            {
                case 1:
                    WeakEnemy we = new WeakEnemy();
                    we.Defend();
                    break;
                case 2:
                    MediumEnemy me = new MediumEnemy();
                    me.Defend();
                    break;
                case 3:
                    PowerfulEnemy pe = new PowerfulEnemy();
                    pe.Defend();
                    break;
                default:
                    Attack();
                    break;
            }
        }
    }
}
