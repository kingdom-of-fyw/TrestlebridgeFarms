using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Plants;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class PurchaseSeed
    {
        public static void CollectInput(Farm farm)
        {
            Console.WriteLine(@"1. Sesame");
            Console.WriteLine(@"2. Sunflower");
            Console.WriteLine(@"3. Wildflower");



            Console.WriteLine();
            Console.WriteLine("Choose seed to Purchase");

            Console.Write("> ");

            int choice = 0;

            while (choice == 0)
            {
                try
                {
                    choice = Int32.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            ChoosePlowedField.CollectInput(farm, new Sesame());
                            Console.WriteLine("Chickens do not graze, you fool!");
                            break;
                        case 2:
                            ChooseEither.CollectInput(farm, new Sunflower());
                            break;
                        case 3:
                            ChooseNaturalField.CollectInput(farm, new WildFlower());
                            Console.WriteLine("Ducks do not graze, you fool!");
                            break;
                        default:
                            Console.WriteLine("That was an invalid selection. Hit enter to continue to the main menu");
                            Console.Read();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please input a valid number from the above menu.");
                    Console.Write(" >");
                }
            }






        }
    }
}