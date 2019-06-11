using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions {
    public class ChooseFacility {
        public int CollectInput (Farm farm, string type, int num) {
            Console.Clear();


        switch (type)
        {
          case "Chicken": 
          foreach(ChickenHouse house in farm.ChickenHouses) {
          Console.WriteLine ($"{farm.ChickenHouses.IndexOf(house)+1}. Chicken House {house.ToString()} has {house.GetCount} chickens.");
          }
          break;
          case "Duck": 
          foreach(DuckHouse house in farm.DuckHouses) {
          Console.WriteLine ($"{farm.DuckHouses.IndexOf(house)+1}. Duck House {house.ToString()} has {house.GetCount} ducks.");
          }
          break;
          case "IGrazing": 
          foreach(GrazingField field in farm.GrazingFields) {
          Console.WriteLine ($"{farm.GrazingFields.IndexOf(field)+1}. Grazing field {field.ToString()} has {field.GetCount} animals.");
          }
          break;
          }

          Console.Write ("> ");
          int pick = Int32.Parse(Console.ReadLine()) -1;

          return pick;
        }

        }
        }
        