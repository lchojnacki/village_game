using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace TheGame
{
    class Program
    {
        public static void SaveAndExit()
        {
            Console.Clear();
            string fileName;
            Console.WriteLine("Enter file name: ");
            fileName = Console.ReadLine();
            
            string json = JsonConvert.SerializeObject(Village.GetVillage(), Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
            //Console.WriteLine(json);
            
            File.WriteAllText(fileName + ".json", json);
            Environment.Exit(1);
        }

        public static void LoadFromFile()
        {
            Console.Clear();
            string fileName;
            Console.WriteLine("Enter file name: ");
            fileName = Console.ReadLine();
            //using (Stream stream = File.Open(fileName, FileMode.Open))
            //{
            //    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            //    return (Village)binaryFormatter.Deserialize(stream);
            //}
            Village v = JsonConvert.DeserializeObject<Village>(File.ReadAllText(fileName + ".json"), new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            v.ShowVillage();
        }

        public static void MainOptions()
        {
            Console.Clear();
            Console.WriteLine("----------------- Main Options -----------------");
            Console.WriteLine("What do You want to do?");
            Console.WriteLine("[1]\tShow my village");
            Console.WriteLine("[2]\tLoad village from file");
            Console.WriteLine("[3]\tExit without saving");
            Console.WriteLine("[4]\tSave and exit");

            int answer;
            Console.Write("> ");
            Int32.TryParse(Console.ReadLine(), out answer);
            switch(answer)
            {
                case 1:
                    Village.GetVillage().ShowVillage();
                    break;
                case 2:
                    LoadFromFile();
                    break;
                case 3:
                    Environment.Exit(1);
                    break;
                case 4:
                    SaveAndExit();
                    break;
                default:
                    MainOptions();
                    break;
            }
        }

        public static void UserInterface()
        {
            Console.WriteLine("Welcome in the Game!");
            MainOptions();
        }

        static void Main(string[] args)
        {
            UserInterface();
        }
    }
}
