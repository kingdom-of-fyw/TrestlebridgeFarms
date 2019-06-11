using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Plants;
using System.Collections.Generic;


namespace Trestlebridge.Actions
{
    public class ChoosePlowedField
    {
        public static void CollectInput(Farm farm, ISeed seed)
        {
            Console.Clear();

            List<PlowedField> AvailableFields = new List<PlowedField>();

            for (int i = 0; i < farm.PlowedFields.Count; i++)
            {
                if (farm.PlowedFields[i].GetCount < farm.PlowedFields[i].Capacity)
                {
                    AvailableFields.Add(farm.PlowedFields[i]);
                }
            }

            if (AvailableFields.Count == 0)
            {
                Console.WriteLine("There are no plowed fields with enough space available! Please create another plowed field. Press any key to continue.");
                Console.Read();
            }

            else

            {
                for (int i = 0; i < AvailableFields.Count; i++)
                {

                    Console.WriteLine($"{i + 1}. Plowed Field ({AvailableFields[i].GetCount} seeds),");

                    foreach (KeyValuePair<string, int> seeds in AvailableFields[i].GetTypeCount())
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
                            field = AvailableFields[choice - 1];
                            AvailableFields[choice - 1].AddResource(seed);
                            Console.WriteLine(AvailableFields[choice - 1]);
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

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}