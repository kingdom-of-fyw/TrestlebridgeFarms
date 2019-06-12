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

            Console.Clear();

            List<IFacility<IResource>> ListOfFacilites = facilities.Where(facility => facility.GetCount < facility.Capacity).ToList();

            List<IFacility<IResource>> copy = ListOfFacilites;

            if(ListOfFacilites.Count == 0)
            {
                Console.WriteLine($"There are no available facilities to store {resource} in. Press enter to return to the main menu and create a new one.");
                Console.Read();
            }

            else
            {

                ListOfFacilites.ForEach(facility => {
                    Console.WriteLine($"{copy.IndexOf(facility) + 1}) {facility}");
                    if(facility.GetTypeCount().Count != 0)
                    {
                        Console.WriteLine($"     List of resources in facility {copy.IndexOf(facility) + 1}:");
                    foreach(KeyValuePair<string, int> kvp in facility.GetTypeCount())
                    {
                        Console.Write($"     {kvp.Key}: {kvp.Value} ");
                    }
                        Console.WriteLine();
                    }
                    
                    Console.WriteLine();
                } );


                Console.WriteLine ();

                // How can I output the type of animal chosen here?
                Console.WriteLine ($"Place the resource where?");

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
                            Console.Clear();
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
        public static void CollectInput(Farm farm, List<IFacility<IResource>> naturalFields, List<IFacility<IResource>> plowedFields, IResource resource)
        {
            Console.Clear();



            //List of available Natural Fields
            List<IFacility<IResource>> AvailableNattyFields = new List<IFacility<IResource>>();

            for (int i = 0; i < farm.NaturalFields.Count; i++)
            {
                if (farm.NaturalFields[i].GetCount < farm.NaturalFields[i].Capacity)
                {
                    AvailableNattyFields.Add(farm.NaturalFields[i]);
                }
            }
            //List of available Plowable fields
            List<IFacility<IResource>> AvailablePlowwyFields = new List<IFacility<IResource>>();

            for (int i = 0; i < farm.PlowedFields.Count; i++)
            {
                if (farm.PlowedFields[i].GetCount < farm.PlowedFields[i].Capacity)
                {
                    AvailablePlowwyFields.Add(farm.PlowedFields[i]);
                }
            }
            //List of available fields of both types: Shared with both IFacility and IResource
            List<IFacility<IResource>> fields = AvailableNattyFields.Concat(AvailablePlowwyFields).ToList();


            if (fields.Count == 0)
            {
                Console.WriteLine("There are no fields with enough space available! Please create either a natural field or a plowed field. Press any key to continue.");
                Console.Read();
            }
            else
            {
                for (int i = 0; i < fields.Count; i++)
                {


                    Console.WriteLine($"{i + 1}. {fields[i].GetType().Name} ({fields[i].GetCount} seeds),");

                    foreach (KeyValuePair<string, int> seeds in fields[i].GetTypeCount())
                    {

                        Console.Write($" ({seeds.Key}: {seeds.Value}) ");

                    }

                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine($"Place the seeds where?");

                Console.Write("> ");


                int choice = 0;
                object field = null;

                while (choice == 0 || field == null)
                {
                    try
                    {
                        choice = Int32.Parse(Console.ReadLine());

                        try
                        {
                            field = fields[choice - 1];
                            fields[choice - 1].AddResource(resource);
                            Console.WriteLine(fields[choice - 1]);
                            Console.WriteLine();
                            Console.WriteLine("Press any key to return to the main menu.");
                            Console.Read();
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Invalid Selection!");
                            Console.WriteLine($"Place the seeds where?");
                        }

                    }
                    catch (FormatException)
                    {

                        Console.WriteLine("Please enter a number!");
                        Console.WriteLine($"Place the seeds where?");
                    }


                }
            }
        }
    }
}