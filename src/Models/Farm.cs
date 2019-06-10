using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Models
{


  public class Farm
  {

    public List<GrazingField> GrazingFields { get; } = new List<GrazingField>();
    public List<DuckHouse> DuckHouses { get; } = new List<DuckHouse>();
    public List<ChickenHouse> ChickenHouses { get; } = new List<ChickenHouse>();

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

    public void AddFacility(dynamic facility)
    {
      switch (facility.FacilityType)
      {
        case "ChickenHouse":
          ChickenHouses.Add(facility);
          break;
        case "DuckHouse":
        // DuckHouse duckHouse = (DuckHouse) facility;
          DuckHouses.Add(facility);
          break;
        case "GrazingField":
        // GrazingField grazingField = (GrazingField) facility;
          GrazingFields.Add(facility);
          break;
      }
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