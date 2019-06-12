using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Models
{


  public class Farm
  {

    public List<IFacility<IGrazing>> GrazingFields { get; } = new List<IFacility<IGrazing>>();
    public List<IFacility<Duck>> DuckHouses { get; } = new List<IFacility<Duck>>();
    public List<IFacility<Chicken>> ChickenHouses { get; } = new List<IFacility<Chicken>>();
    public List<IFacility<ISeed>> NaturalFields { get; } = new List<IFacility<ISeed>>();
    public List<IFacility<ISeed>> PlowedFields { get; } = new List<IFacility<ISeed>>();

    /*
        This method must specify the correct product interface of the
        resource being purchased.
     */
    public void PurchaseResource<T>(IResource resource, int index)
    {
      switch (typeof(T).ToString().Split(".")[3].ToString())
      {
        case "Chicken":
          ChickenHouses[index].AddResource((Chicken)resource);
          break;
        default:
          break;
      }
    }

    public void AddFacility(object facility)
    {
      switch (facility)
      {
        case ChickenHouse C:
          ChickenHouses.Add(C);
          break;
        case DuckHouse D:
          DuckHouses.Add(D);
          break;
        case PlowedField P:
          PlowedFields.Add(P);
          break;
        case GrazingField G:
          GrazingFields.Add(G);
          break;
        case NaturalField N:
          NaturalFields.Add(N);
          break;
      }
    }


    public override string ToString()
    {
      StringBuilder report = new StringBuilder();

      ChickenHouses.ForEach(gf => report.Append(gf));
      DuckHouses.ForEach(gf => report.Append(gf));
      GrazingFields.ForEach(gf => report.Append(gf));


      NaturalFields.ForEach(gf => report.Append(gf));
      PlowedFields.ForEach(gf => report.Append(gf));

      return report.ToString();
    }
  }
}