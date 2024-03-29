using System;
using System.Threading;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class CreateFacility
    {
        public static void CollectInput(Farm farm)
        {
            Console.WriteLine(@"1. Grazing field");
            Console.WriteLine(@"2. Plowed field");
            Console.WriteLine(@"3. Natural field");
            Console.WriteLine(@"4. Duck House");
            Console.WriteLine(@"5. Chicken House");

            Console.WriteLine();
            Console.WriteLine("Choose what you want to create");

            Console.Write("> ");

            int option = 0;

            while (option == 0)
            {
                try
                {
                    option = Int32.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            farm.AddFacility(new GrazingField());

                            Console.WriteLine("You made a new Grazing Field");
                            returnStatement();

                            break;
                        case 2:
                            farm.AddFacility(new PlowedField());
                            Console.WriteLine("You made a new Plowed Field");
                            returnStatement();

                            break;
                        case 3:
                            farm.AddFacility(new NaturalField());
                            Console.WriteLine("You made a new Natural Field");
                            returnStatement();
                            break;
                        case 4:
                            farm.AddFacility(new DuckHouse());
                            Console.WriteLine("A new Duck House has been built.");
                            returnStatement();
                            break;
                        case 5:
                            farm.AddFacility(new ChickenHouse());
                            Console.WriteLine("A new Chicken House has been built.");
                            returnStatement();
                            break;
                        default:
                            Console.WriteLine("Invalid selection. Hit Enter to return to the main menu.");
                            Console.Read();
                            break;
                    }

                }
                catch (FormatException)
                {
                  Console.WriteLine("Please select a valid number from above.");
                  Console.Write(" >");
                }
            }
        }


        private static void returnStatement()
        {
            Console.WriteLine("Press Enter to return to main menu");
            Console.ReadKey();
        }
    }
}