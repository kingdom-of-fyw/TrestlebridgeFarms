using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Animals;
using System.Collections.Generic;

namespace Trestlebridge.Actions
{
    public class ChooseGrazingField
    {
        public static void CollectInput(Farm farm, IGrazing animal)
        {
            Console.Clear();

            List<GrazingField> AvailableFields = new List<GrazingField>();

            for (int i = 0; i < farm.GrazingFields.Count; i++)
            {
                if (farm.GrazingFields[i].GetCount < farm.GrazingFields[i].Capacity)
                {
                    AvailableFields.Add(farm.GrazingFields[i]);
                }
            }

            if(AvailableFields.Count == 0)
            {
                Console.WriteLine("There are no grazing fields with enough space available! Please create another grazing field. Press any key to continue.");
                Console.Read();
            }

            else
            
            {
                for (int i = 0; i < AvailableFields.Count; i++)
                {

                    Console.WriteLine($"{i + 1}. Grazing Field ({AvailableFields[i].GetCount} animals),");

                    foreach (KeyValuePair<string, int> animals in AvailableFields[i].GetTypeCount())
                    {

                        Console.Write($" ({animals.Key}: {animals.Value}) ");
                    
                    }

                    Console.WriteLine();

                    // How can I output the type of animal chosen here?   
                }
                Console.WriteLine($"Place the animal where?");

                Console.Write("> ");

                
                int choice = 0;
                object field = null;

                while(choice == 0 || field == null)
                {
                    try
                    {
                        choice = Int32.Parse(Console.ReadLine());
                            
                        try
                        {
                            field = AvailableFields[choice-1];
                            AvailableFields[choice-1].AddResource(animal);
                            Console.WriteLine(AvailableFields[choice - 1]);
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
                    catch(FormatException)
                    {
                        
                        Console.WriteLine("Please enter a number!");
                        Console.WriteLine($"Place the animal where?");
                    }
                    
                }              
            }

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice)

        }
    }
}