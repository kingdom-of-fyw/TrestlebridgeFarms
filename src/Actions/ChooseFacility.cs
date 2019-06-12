using System;
using System.Linq;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
  public class ChooseFacility
  {
    public static void CollectInput<T>(Farm farm, List<IFacility<T>> List, T Resource)
    {
      Console.Clear();

      var Available =
      from L in List
      where L.GetCount < L.Capacity
      select L;

      List<IFacility<T>> availableList = Available.ToList();

      if (Available.ToList().Count == 0)
      {
        Console.WriteLine($"There are no available facilities! Please create one first. Press enter to return to the main menu.");
        Console.Read();
      }

      else
      {
        foreach (IFacility<T> field in availableList)
        {
          Console.WriteLine($"{availableList.IndexOf(field) + 1}. {field.ToShortString()}");

          foreach (KeyValuePair<string, int> animal in field.GetTypeCount())
          {

            Console.Write($" ({animal.Key}: {animal.Value}) ");

          }
          Console.WriteLine();
        }
        Console.WriteLine();

        // How can I output the type of animal chosen here?
        Console.WriteLine($"Place the {Resource.ToString().Split(" ")[0].ToString()} where?");

        Console.Write("> ");



        int choice = 0;
        while (choice == 0)
        {
          try
          {
            choice = Int32.Parse(Console.ReadLine());
            try
            {
              availableList[choice - 1].AddResource(Resource);
              Console.WriteLine(availableList[choice - 1]);
              Console.WriteLine();
              Console.WriteLine("Press any key to return to the main menu.");
              Console.Read();
            }
            catch (ArgumentOutOfRangeException)
            {
              Console.WriteLine("Invalid Selection!");
              Console.WriteLine($"Place the {Resource.ToString().Split(" ")[0].ToString()} where?");
            }
          }
          catch (FormatException)
          {
            Console.WriteLine("Please input a number!");
            Console.WriteLine();
          }
        }
      }
    }

    public static void CollectInput<T>(Farm farm, List<IFacility<T>> List, List<IFacility<T>> List2, T Resource)
    {
      Console.Clear();

      var twoLists = List.Concat(List2);

      var Available =
      from L in twoLists
      where L.GetCount < L.Capacity
      select L;

      List<IFacility<T>> availableList = Available.ToList();

      if (Available.ToList().Count == 0)
      {
        Console.WriteLine($"There are no available facilities! Please create one first. Press enter to return to the main menu.");
        Console.Read();
      }

      else
      {
        foreach (IFacility<T> field in availableList)
        {
          Console.WriteLine($"{availableList.IndexOf(field) + 1}. {field.ToShortString()}");

          foreach (KeyValuePair<string, int> animal in field.GetTypeCount())
          {

            Console.Write($" ({animal.Key}: {animal.Value}) ");

          }
          Console.WriteLine();
        }
        Console.WriteLine();

        // How can I output the type of animal chosen here?
        Console.WriteLine($"Place the {Resource.ToString().Split(" ")[0].ToString()} where?");

        Console.Write("> ");

        int choice = 0;
        while (choice == 0)
        {
          try
          {
            choice = Int32.Parse(Console.ReadLine());
            try
            {
              availableList[choice - 1].AddResource(Resource);
              Console.WriteLine(availableList[choice - 1]);
              Console.WriteLine();
              Console.WriteLine("Press any key to return to the main menu.");
              Console.Read();
            }
            catch (ArgumentOutOfRangeException)
            {
              Console.WriteLine("Invalid Selection!");
              Console.WriteLine($"Place the {Resource.ToString().Split(" ")[0].ToString()} where?");
            }
          }
          catch (FormatException)
          {
            Console.WriteLine("Please input a number!");
            Console.WriteLine();
          }
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

