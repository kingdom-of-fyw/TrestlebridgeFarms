using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;


namespace Trestlebridge.Models.Facilities
{
    public class GrazingField : IFacility<IGrazing>
    {
        private int _capacity = 50;
        private Guid _id = Guid.NewGuid();

        private string _FacilityType = "GrazingField";           
        private List<IGrazing> _animals = new List<IGrazing>();
        public int GetCount
        {
            get
            {
                return _animals.Count;
            }
        }
        public Dictionary<string, int> GetTypeCount
        {
            get
            {
                int CowCount = 0;
                int GoatCount = 0;
                int OstrichCount = 0;
                int PigCount = 0;
                int SheepCount = 0;

                foreach (IGrazing t in _animals)
                {
                    switch (t.GetType().Name)
                    {
                        case "Cow":
                            CowCount += 1;
                            break;
                        case "Goat":
                            GoatCount += 1;
                            break;
                        case "Ostrich":
                            OstrichCount += 1;
                            break;
                        case "Sheep":
                            SheepCount += 1;
                            break;
                        case "Pig":
                            PigCount += 1;
                            break;
                        default:
                            break;
                    }
                }
                return new Dictionary<string, int>(){
                    {"Cow", CowCount}, {"Goat", GoatCount}, {"Ostrich", OstrichCount}, {"Sheep", SheepCount},
                    {"Pig", PigCount}
                };

            }
        }

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

        public void AddResource(IGrazing animal)
        {
            // TODO: implement this...
            // if(_animals.Count >= _capacity)
            // {
            //     // Console.WriteLine("Please select another facility");
            //     // Actions.ChooseGrazingField.CollectInput(animal);
            // }

            _animals.Add(animal);

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
    }
}