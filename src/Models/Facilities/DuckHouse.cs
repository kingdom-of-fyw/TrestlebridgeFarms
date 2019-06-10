// The DuckHouse.cs file is a model for the duck house storage facilty.

using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Models.Facilities
{
    public class DuckHouse : IFacility<Duck>
    {
        private int _capacity = 12;
        private Guid _id = Guid.NewGuid();
        private List<Duck> _listOfDucks = new List<Duck>();

        private string _FacilityType = "DuckHouse";

                public string FacilityType {
            get {
                return _FacilityType;
            }
        }
        public double Capacity {
            get {
                return _capacity;
            }
        }
        public void AddResource(Duck duck)
        {
            _listOfDucks.Add(duck);

            throw new NotImplementedException();
        }

        public void AddResource(List<Duck> ducks)
        {
            _listOfDucks = ducks;

            throw new NotImplementedException();
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