// The DuckHouse.cs file is a model for the duck house storage facilty.

using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Plants;
using System.Linq;


namespace Trestlebridge.Models.Facilities
{
    public class NaturalField : IFacility<ISeed>
    {
        private int _capacity = 10;
        private Guid _id = Guid.NewGuid();
        private List<ISeed> _listOfPlants = new List<ISeed>();

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
        public Dictionary<string, int> GetTypeCount() 
        {
            return (_listOfPlants.GroupBy(o => o.Type).ToDictionary(g=> g.Key, g => g.Count()));
            }
        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }
        public void AddResource(ISeed plant)
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

        public void AddResource(List<ISeed> plants)
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

            public string ToShortString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Natural Field {shortId} has {this._listOfPlants.Count} Plants\n");

            return output.ToString();
        }

    }
}