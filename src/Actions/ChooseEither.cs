using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Plants;
using System.Collections.Generic;

namespace Trestlebridge.Actions
{
    public class ChooseEither
    {
        public static void CollectInput(Farm farm, ISeed seed)
        {
            Console.Clear();

            //List of available Natural Fields
            List<IFacility<ISeed>> AvailableNattyFields = new List<IFacility<ISeed>>();

            for (int i = 0; i < farm.NaturalFields.Count; i++)
            {
                if (farm.NaturalFields[i].GetCount < farm.NaturalFields[i].Capacity)
                {
                    // AvailableNattyFields.Add(farm.NaturalFields[i]);
                }
            }
            //List of available Plowable fields
            List<IFacility<ISeed>> AvailablePlowwyFields = new List<IFacility<ISeed>>();

            for (int i = 0; i < farm.PlowedFields.Count; i++)
            {
                if (farm.PlowedFields[i].GetCount < farm.PlowedFields[i].Capacity)
                {
                    // AvailablePlowwyFields.Add(farm.PlowedFields[i]);
                }
            }
            //List of available fields of both types: Shared with both IFacility and ISeed
            List<IFacility<ISeed>> fields = AvailableNattyFields.Concat(AvailablePlowwyFields).ToList();


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
                            fields[choice - 1].AddResource(seed);
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