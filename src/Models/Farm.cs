using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Models
{


  public class Farm
  {
    public List<IStorage> FarmFacilities { get; set; } = new List<IStorage>();
    public List<GrazingField> GrazingFields { get; } = new List<GrazingField>();
    public List<IStorage> DuckHouses { get; } = new List<IStorage>();
    public List<IStorage> ChickenHouses { get; } = new List<IStorage>();

    /*
        This method must specify the correct product interface of the
        resource being purchased.
     */
    public void PurchaseResource<T>(IResource resource, int index)
    {
      Console.WriteLine(typeof(T).ToString());
      switch (typeof(T).ToString())
      {
        case "Cow":
          GrazingFields[index].AddResource((IGrazing)resource);
          break;
        default:
          break;
      }
    }

    public void AddFacility(IStorage facility)
    {
      switch (facility.FacilityType)
      {
        case "ChickenHouse":
          ChickenHouses.Add(facility);
          break;
        case "DuckHouse":
          DuckHouses.Add(facility);
          break;
        case "GrazingField":
          GrazingFields.Add(facility);
          break;
      }
    }

    public void AddDuckHouse(DuckHouse duckHouse)
    {
      DuckHouses.Add(duckHouse);
    }
    public void AddChickenHouse(ChickenHouse chickenHouse)
    {
      ChickenHouses.Add(chickenHouse);
    }

    public override string ToString()
    {
      StringBuilder report = new StringBuilder();

      GrazingFields.ForEach(gf => report.Append(gf));
      DuckHouses.ForEach(gf => report.Append(gf));
      ChickenHouses.ForEach(gf => report.Append(gf));

      return report.ToString();
    }
  }
}