// The DuckHouse.cs file is a model for the duck house storage facilty.

using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Models.Facilities
{
    public class PlowedField : IFacility<IResource>
    {
        private int _capacity = 13;
        private Guid _id = Guid.NewGuid();
        private List<IResource> _listOfPlants = new List<IResource>();

        private string _FacilityType = "PlowedField";

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
        public Dictionary<string, int> GetTypeCount()
        {
            // get
            // {
            int SesameCount = 0;
            int SunflowerCount = 0;

            foreach (IResource t in _listOfPlants)
            {
                switch (t.GetType().Name)
                {
                    case "Sesame":
                        SesameCount += 1;
                        break;
                    case "Sunflower":
                        SunflowerCount += 1;
                        break;
                    default:
                        break;
                }
            }
            return new Dictionary<string, int>(){
                    {"Sesame", SesameCount}, {"Sunflower", SunflowerCount}
                };

            // }
        }
        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }
        public void AddResource(IResource plant)
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

        public void AddResource(List<IResource> plants)
        {
            _listOfPlants = plants;

            // throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Plowed Field {shortId} has {this._listOfPlants.Count} Plants\n");
            this._listOfPlants.ForEach(p => output.Append($"   {p}\n"));

            return output.ToString();
        }

    }
}