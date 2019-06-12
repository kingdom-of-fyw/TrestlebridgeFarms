using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
  public class PurchaseStock
  {

    private static void NewMethod(Farm farm)
    {
      foreach (GrazingField field in farm.GrazingFields)
      {
        Console.WriteLine($"{farm.GrazingFields.IndexOf(field) + 1}. Grazing field {field.ToString()} has {field.GetCount} animals.");
      }
    }

    public static void CollectInput(Farm farm)
    {
      Console.WriteLine("1. Chicken");
      Console.WriteLine("2. Cow");
      Console.WriteLine("3. Duck");
      Console.WriteLine("4. Goat");
      Console.WriteLine("5. Ostrich");
      Console.WriteLine("6. Pig");
      Console.WriteLine("7. Sheep");


      Console.WriteLine();
      Console.WriteLine("What are you buying today?");

      Console.Write("> ");

      int choice = 0;

      while (choice == 0)
      {
        try
        {
          choice = Int32.Parse(Console.ReadLine());

          Console.Clear();
          switch (choice)

          {
            case 1:
              foreach (ChickenHouse house in farm.ChickenHouses)
              {
                Console.WriteLine($"{farm.ChickenHouses.IndexOf(house) + 1}. Chicken House {house.ToString()} has {house.GetCount} chickens.");
              }
              farm.ChickenHouses[Int32.Parse(Console.ReadLine()) - 1].AddResource(new Chicken());

              break;
            case 2:
              NewMethod(farm);
              farm.GrazingFields[Int32.Parse(Console.ReadLine()) - 1].AddResource(new Cow());
              break;
            case 3:
              foreach (DuckHouse house in farm.DuckHouses)
              {
                Console.WriteLine($"{farm.DuckHouses.IndexOf(house) + 1}. Duck House {house.ToString()} has {house.GetCount} ducks.");
              }
              farm.DuckHouses[Int32.Parse(Console.ReadLine()) - 1].AddResource(new Duck());
              break;
            case 4:
              NewMethod(farm);
              farm.GrazingFields[Int32.Parse(Console.ReadLine()) - 1].AddResource(new Goat());
              break;
            case 5:
              NewMethod(farm);
              farm.GrazingFields[Int32.Parse(Console.ReadLine()) - 1].AddResource(new Ostrich());
              break;
            case 6:
              NewMethod(farm);
              farm.GrazingFields[Int32.Parse(Console.ReadLine()) - 1].AddResource(new Pig());
              break;
            case 7:
              NewMethod(farm);
              farm.GrazingFields[Int32.Parse(Console.ReadLine()) - 1].AddResource(new Sheep());
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
