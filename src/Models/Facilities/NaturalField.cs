// The DuckHouse.cs file is a model for the duck house storage facilty.

using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Models.Facilities
{
  public class NaturalField : IStorage, IFacility<INaturalFieldSeed>
  {
    private int _capacity = 10;
    private Guid _id = Guid.NewGuid();
    private List<INaturalFieldSeed> _listOfPlants = new List<INaturalFieldSeed>();

    private string _FacilityType = "NaturalField";

    public string FacilityType
    {
      get
      {
        return _FacilityType;
      }
    }
    public int GetCount
    {
      get
      {
        return _listOfPlants.Count;
      }
    }
    public double Capacity
    {
      get
      {
        return _capacity;
      }
    }
    public void AddResource(INaturalFieldSeed plant)
    {

      try
      {
        _listOfPlants.Add(plant);
      }
      catch
      {
        // throw new NotImplementedException();
      }


    }

    public void AddResource(List<INaturalFieldSeed> plants)
    {
      _listOfPlants = plants;

      // throw new NotImplementedException();
    }

    public override string ToString()
    {
      StringBuilder output = new StringBuilder();
      string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

      output.Append($"Natural Field {shortId} has {this._listOfPlants.Count} Plants\n");
      this._listOfPlants.ForEach(p => output.Append($"   {p}\n"));

      return output.ToString();
    }

  }
}