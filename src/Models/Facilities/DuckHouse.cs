// The DuckHouse.cs file is a model for the duck house storage facilty.

using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Models.Facilities
{
    public class DuckHouse : IFacility<IResource>
    {
        private int _capacity = 12;
        private Guid _id = Guid.NewGuid();
        private List<IResource> _listOfDucks = new List<IResource>();

        private string _FacilityType = "DuckHouse";

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
                return _listOfDucks.Count;
            }
        }
        public Dictionary<string, int> GetTypeCount()
        {
            return new Dictionary<string, int>();
        }
        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }
        public void AddResource(IResource duck)
        {

            try
            {
                _listOfDucks.Add(duck);
            }
            catch
            {
                // throw new NotImplementedException();
            }


        }

        public void AddResource(List<IResource> ducks)
        {
            _listOfDucks = ducks;

            // throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Duck House {shortId} has {this._listOfDucks.Count} ducks\n");
            this._listOfDucks.ForEach(d => output.Append($"   {d}\n"));

            return output.ToString();
        }

    }
}