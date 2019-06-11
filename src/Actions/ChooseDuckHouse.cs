using System;
using System.Linq;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class ChooseDuckHouse
    {
        public static void CollectInput(Farm farm, Duck duck)
        {
            Console.Clear();

            List<DuckHouse> AvailableDuckHouses = new List<DuckHouse>();

            for(int i = 0; i < farm.DuckHouses.Count; i++)
            {
                if(farm.DuckHouses[i].GetCount < farm.DuckHouses[i].Capacity)
                {
                    AvailableDuckHouses.Add(farm.DuckHouses[i]);
                }
            }

            if (AvailableDuckHouses.Count == 0)
            {
                Console.WriteLine("There are no available duckhouses! Please create a new duckhouse. Press enter to return to the main menu.");
                Console.Read();
            }

            else
            {
                for (int i = 0; i < AvailableDuckHouses.Count; i++)
                {
                
                    Console.WriteLine($"{i + 1}. Duck House ({AvailableDuckHouses[i].GetCount} ducks)");

                    Console.WriteLine();

                    // How can I output the type of animal chosen here?
                    Console.WriteLine($"Place the animal where?");

                    Console.Write("> ");

                    int choice = 0;
                    object duckhouse = null;

                    while(choice == 0 || duckhouse == null)
                    {
                        try
                        {
                            choice = Int32.Parse(Console.ReadLine());
                            try
                            {
                                duckhouse = AvailableDuckHouses[choice - 1];
                                AvailableDuckHouses[choice - 1].AddResource(duck);
                                Console.WriteLine(AvailableDuckHouses[choice - 1]);
                                Console.WriteLine();
                                Console.WriteLine("Press any key to return to the main menu.");
                                Console.Read();
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine("Invalid Selection!");
                                Console.WriteLine($"Place the animal where?");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please input a number!");
                            Console.WriteLine();
                        }
                    }
                }
            }



            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}