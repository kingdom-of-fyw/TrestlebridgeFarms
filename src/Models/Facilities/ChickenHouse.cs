// The ChickenHouse.cs file contains the model for the chicken house storage facility.

using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Models.Facilities
{
  public class ChickenHouse : IStorage, IFacility<Chicken>
  {
    private int _capacity = 15;
    private Guid _id = Guid.NewGuid();
    private List<Chicken> _chickens = new List<Chicken>();

    private string _FacilityType = "ChickenHouse";

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
        return _chickens.Count;
      }
    }

    public Dictionary<string, int> GetTypeCount(){
      return new Dictionary<string, int>();
    }
    public double Capacity
    {
      get
      {
        return _capacity;
      }
    }
    public void AddResource(Chicken chicken)
    {
      _chickens.Add(chicken);


    }
    public void AddResource(List<Chicken> chickens)
    {
      _chickens = chickens;

    }
    public override string ToString()
    {
      StringBuilder output = new StringBuilder();
      string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

      output.Append($"Chicken House {shortId} has {this._chickens.Count} chickens\n");
      this._chickens.ForEach(c => output.Append($"   {c}\n"));

      return output.ToString();
    }
  }
}