using System;
using System.Threading;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions {
    public class CreateFacility {
        public static void CollectInput (Farm farm) {
            Console.WriteLine ("1. Grazing field");
            Console.WriteLine ("2. Plowed field");
            Console.WriteLine ("3. Natural field");
            Console.WriteLine ("4. Duck House");
            Console.WriteLine ("5. Chicken House");

            Console.WriteLine ();
            Console.WriteLine ("Choose what you want to create");

            Console.Write ("> ");
            string input = Console.ReadLine ();

            switch (Int32.Parse(input))
            {
                case 1:
                    farm.AddGrazingField(new GrazingField());
                    Console.WriteLine("You made a new Grazing Field");
                    Console.WriteLine("Press Enter to return to main menu");
                    Console.ReadKey();

                    break;
                // case 2:
                //     farm.AddGrazingField(new GrazingField());
                //     Console.WriteLine("You made a new Grazing Field");
                //     Console.WriteLine("Press Enter to return to main menu");
                //     Console.ReadKey();

                //     break;
                // case 3:
                //     farm.AddGrazingField(new GrazingField());
                //     Console.WriteLine("You made a new Grazing Field");
                //     Console.WriteLine("Press Enter to return to main menu");
                //     Console.ReadKey();

                //     break;
                case 4:
                    farm.AddDuckHouse(new DuckHouse());
                    Console.WriteLine("A new Duck House has been built.");
                    Console.WriteLine("Press Enter to return to main menu");
                    Console.ReadKey();

                    break;
                case 5:
                    farm.AddChickenHouse(new ChickenHouse());
                    Console.WriteLine("A new Chicken House has been built.");
                    Console.WriteLine("Press Enter to return to main menu");
                    Console.ReadKey();

                    break;
                default:
                    break;
            }
        }
    }
}