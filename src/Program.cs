using System;
using System.Linq;
using Trestlebridge.Actions;
using Trestlebridge.Models;

namespace Trestlebridge
{
    class Program
    {
        static void DisplayBanner ()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(@"
        +-++-++-++-++-++-++-++-++-++-++-++-++-+
        |T||r||e||s||t||l||e||b||r||i||d||g||e|
        +-++-++-++-++-++-++-++-++-++-++-++-++-+
                    |F||a||r||m||s|
                    +-++-++-++-++-+");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
			Console.BackgroundColor = ConsoleColor.DarkMagenta;

            Farm Trestlebridge = new Farm();

            while (true)
            {
                DisplayBanner();
                Console.WriteLine(@"1. Create Facility");
                Console.WriteLine(@"2. Purchase Animals");
                Console.WriteLine(@"3. Purchase Seeds");
                Console.WriteLine(@"4. Processing Options");
                Console.WriteLine(@"5. Display Farm Status");
                Console.WriteLine(@"6. Exit");
                Console.WriteLine();

                Console.WriteLine("Choose a FARMS option");
                Console.Write("> ");

                int option = 0;

                while(option == 0)
                {
                    try
                    {
                        option = Int32.Parse(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                DisplayBanner();
                                CreateFacility.CollectInput(Trestlebridge);
                                break;
                            case 2:
                                DisplayBanner();
                                PurchaseStock.CollectInput(Trestlebridge);
                                break;
                            case 3:
                                DisplayBanner();
                                PurchaseSeed.CollectInput(Trestlebridge);
                                break;
                            case 4:
                                DisplayBanner();
                                Console.WriteLine("You've hit processing! There's nothing to do here yet... hit enter to return to the main menu.");
                                Console.Read();
                                break;
                            case 5:
                                DisplayBanner();
                                Console.WriteLine(Trestlebridge);
                                Console.WriteLine("\n\n\n");
                                Console.WriteLine("Press return key to go back to main menu.");
                                Console.ReadLine();
                                break;
                            case 6:
                                Console.WriteLine("Today is a great day for farming!");
                                System.Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine($"Invalid option: {option}. Press enter to return to the main menu.");
                                Console.Read();
                                break;
                        } 
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine("Please input a number!");
                    }
                }
            }
        }
    }
}
