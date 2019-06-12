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
              ChooseFacility.CollectInput(farm, farm.PlowedFields, new Sesame());

              break;
            case 2:
              ChooseFacility.CollectInput(farm, farm.PlowedFields, farm.NaturalFields, new Sunflower());
              break;
            case 3:
              ChooseFacility.CollectInput(farm, farm.NaturalFields, new WildFlower());

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