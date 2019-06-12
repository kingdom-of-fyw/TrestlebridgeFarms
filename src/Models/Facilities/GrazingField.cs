using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using System.Linq;

namespace Trestlebridge.Models.Facilities
{
    public class GrazingField : IFacility<IGrazing>
    {
        private int _capacity = 5;
        private Guid _id = Guid.NewGuid();
          
        private List<IGrazing> _animals = new List<IGrazing>();
        public int GetCount
        {
            get
            {
                return _animals.Count;
            }
        }

        private string _FacilityType = "GrazingField";

        public string FacilityType
        {
            get
            {
                return _FacilityType;
            }
        }
        public Dictionary<string, int> GetTypeCount() 
        {
            return (_animals.GroupBy(o => o.Type).ToDictionary(g=> g.Key, g => g.Count()));
            }



        public double Capacity {
            get {
                return _capacity;
            }
        }

        public void AddResource(IGrazing animal)
        {
            // TODO: implement this...
            // if(_animals.Count >= _capacity)
            // {
            //     // Console.WriteLine("Please select another facility");
            //     // Actions.ChooseGrazingField.CollectInput(animal);
            // }

            try
            {
                _animals.Add(animal);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid Selection!");
            }
            

            // throw new NotImplementedException();
        }

        public void AddResource(List<IGrazing> animals)
        {
            // TODO: implement this...
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Grazing field {shortId} has {this._animals.Count} animals\n");
            this._animals.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
            public string ToShortString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Grazing field {shortId} has {this._animals.Count} animals\n");

            return output.ToString();
        }
    }
}