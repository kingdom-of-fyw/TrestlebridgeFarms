using System;
using System.Linq;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
    public class ChooseChickenHouse {
        public static void CollectInput (Farm farm, Chicken chicken) {
            Console.Clear();

            List<ChickenHouse> AvailableChickenHouses = new List<ChickenHouse>();



            for (int i = 0; i < farm.ChickenHouses.Count; i++)
            {
                if (farm.ChickenHouses[i].GetCount < farm.ChickenHouses[i].Capacity)
                {
                //    AvailableChickenHouses.Add(farm.ChickenHouses[i]);
                }
            }

            if(AvailableChickenHouses.Count == 0)
            {
                Console.WriteLine("There are no available Chicken Houses to store a new chicken in. Please create a new chicken house. Press enter to return to the main menu.");
                Console.Read();
            }

            for(int i = 0; i < AvailableChickenHouses.Count; i++)
            {
                Console.WriteLine ($"{i + 1}. Chicken House ({AvailableChickenHouses[i].GetCount} chickens)");

                Console.WriteLine ();

                // How can I output the type of animal chosen here?
                Console.WriteLine ($"Place the animal where?");

                Console.Write ("> ");

                int choice = 0;
                object chickenhouse = null;

                while(choice == 0 || chickenhouse == null)
                {
                    try
                    {
                        choice = Int32.Parse(Console.ReadLine());
                        try
                        {
                            chickenhouse = AvailableChickenHouses[choice - 1];
                            AvailableChickenHouses[choice - 1].AddResource(chicken);
                            Console.WriteLine(AvailableChickenHouses[choice - 1]);
                            Console.WriteLine();
                            Console.WriteLine("Press enter to return to the main menu.");
                            Console.Read();
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Invalid Selection! Please select a number from above.");
                            Console.Write ("> ");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please input a number! Select a number from above.");
                        Console.Write ("> ");
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