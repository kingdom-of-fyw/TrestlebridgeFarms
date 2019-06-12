using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Animals;
using System.Collections.Generic;

namespace Trestlebridge.Actions
{
    public class ChooseFacility
    {
        public static void CollectInput(Farm farm, List<IFacility<IResource>> facilities, IResource resource)
        {
            List<IFacility<IResource>> ListOfFacilites = facilities.Where(facility => facility.GetCount < facility.Capacity).ToList();

            List<IFacility<IResource>> copy = ListOfFacilites;

            if(ListOfFacilites.Count == 0)
            {
                Console.WriteLine($"There are no available facilities to store {resource} in. Press enter to return to the main menu and create a new one.");
                Console.Read();
            }

            else
            {

                ListOfFacilites.ForEach(facility => Console.WriteLine($"{copy.IndexOf(facility) + 1}) {facility}"));


                Console.WriteLine ();

                // How can I output the type of animal chosen here?
                Console.WriteLine ($"Place the animal where?");

                Console.Write ("> ");

                int choice = 0;
                object facilityO = null;

                while(choice == 0 || facilityO == null)
                {
                    try
                    {
                        choice = Int32.Parse(Console.ReadLine());
                        try
                        {
                            facilityO = ListOfFacilites[choice - 1];
                            ListOfFacilites[choice - 1].AddResource(resource);
                            Console.WriteLine(ListOfFacilites[choice - 1]);
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

            
        }
    }
}