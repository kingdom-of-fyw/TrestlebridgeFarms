using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class PurchaseStock
    {
        public static void CollectInput(Farm farm)
        {
            Console.WriteLine(@"1. Chicken");
            Console.WriteLine(@"2. Cow");
            Console.WriteLine(@"3. Duck");
            Console.WriteLine(@"4. Goat");
            Console.WriteLine(@"5. Ostrich");
            Console.WriteLine(@"6. Pig");
            Console.WriteLine(@"7. Sheep");


            Console.WriteLine();
            Console.WriteLine("What are you buying today?");

            Console.Write("> ");

            int choice = 0;
            object stock = null;

            while (choice == 0 && stock == null)
            {
                try
                {
                    choice = Int32.Parse(Console.ReadLine());


                    switch (choice)
                    {
                        case 1:
                            ChooseChickenHouse.CollectInput(farm, new Chicken());
                            Console.WriteLine("Chickens do not graze, you fool!");
                            stock = new Chicken();
                            break;
                        case 2:
                            ChooseGrazingField.CollectInput(farm, new Cow());
                            stock = new Cow();
                            break;
                        case 3:
                            ChooseDuckHouse.CollectInput(farm, new Duck());
                            Console.WriteLine("Ducks do not graze, you fool!");
                            stock = new Duck();
                            break;
                        case 4:
                            ChooseGrazingField.CollectInput(farm, new Goat());
                            stock = new Goat();
                            break;
                        case 5:
                            ChooseGrazingField.CollectInput(farm, new Ostrich());
                            stock = new Ostrich();
                            break;
                        case 6:
                            ChooseGrazingField.CollectInput(farm, new Pig());
                            stock = new Pig();
                            break;
                        case 7:
                            ChooseGrazingField.CollectInput(farm, new Sheep());
                            stock = new Chicken();
                            break;
                        default:
                            Console.WriteLine("Invalid selection. Click enter to return to the main menu.");
                            Console.Read();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please input a number from above!");
                    Console.Write("> ");
                }
            }

            

            
        }
    }
}