using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    class Bakery : Building
    {
        public Bakery()
        {
            cost = 1500;
        }

        public Bakery(Bakery b)
        {
            cost = b.cost;
        }

        public override int GetCost()
        {
            return cost;
        }

        public override Building GetCopy()
        {
            return new Bakery(this);
        }

        public override void ShowBuildingOptions()
        {
            Console.Clear();
            Console.WriteLine("----------------- Bakery -----------------");
            Console.WriteLine("What do You want to do?");
            Console.WriteLine("[1]\tMake new bread");
            Console.WriteLine("[2]\tBack to buildings");
            Console.WriteLine("[3]\tBack to village");
            Console.WriteLine("[4]\tBack to Main Options");
            int answer;
            Console.Write("> ");
            Int32.TryParse(Console.ReadLine(), out answer);
            switch(answer)
            {
                case 1:
                    MakeBread();
                    break;
                case 2:
                    Village.GetVillage().ShowBuildings();
                    break;
                case 3:
                    Village.GetVillage().ShowVillage();
                    break;
                case 4:
                    Program.MainOptions();
                    break;
                default:
                    ShowBuildingOptions();
                    break;
            }
        }

        public void MakeBread()
        {
            if (Village.GetVillage().GetBuildings().Any(item => item.GetType() == new Granary().GetType()))
            {
                try
                {
                    Village v = Village.GetVillage();
                    v.SpendMoney(1);
                    List<Building> granarys = v.GetBuildings().FindAll(item => item.GetType() == new Granary().GetType());
                    bool success_granary = false;
                    foreach (Granary g in granarys)
                    {
                        try
                        {
                            g.TakeFromGranary(new Grain());
                            success_granary = true;
                            break;
                        } catch (NotEnoughResourcesException)
                        {
                            continue;
                        }
                    }
                    if (success_granary)
                    {
                        bool success = false;
                        foreach (Granary g in granarys)
                        {
                            try
                            {
                                g.AddToGranary(new Bread());
                                success = true;
                                break;
                            }
                            catch (FullContainerException)
                            {
                                continue;
                            }
                        }
                        if (success)
                        {
                            Console.WriteLine("Bread moved to granary");
                            Console.WriteLine("Press any key...");
                            Console.ReadKey();
                            ShowBuildingOptions();
                        }
                        else
                        {
                            Console.WriteLine("All your granaries are full!");
                            Console.WriteLine("Press any key...");
                            Console.ReadKey();
                            ShowBuildingOptions();
                        }
                    } else
                    {
                        Console.WriteLine("You can't make bread, You don't have grains!");
                        Console.WriteLine("Press any key...");
                        Console.ReadKey();
                        ShowBuildingOptions();
                    }
                    
                    
                }
                catch (NotEnoughResourcesException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
                }
            } else
            {
                Console.WriteLine("You don't have granary! The bread was thrown away :(");
                Console.WriteLine("Press any key...");
                Console.ReadKey();
                ShowBuildingOptions();
            }
        }
    }
}
