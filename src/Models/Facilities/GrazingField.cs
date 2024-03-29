using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;


namespace Trestlebridge.Models.Facilities
{
    public class GrazingField : IFacility<IResource>
    {
        private int _capacity = 5;
        private Guid _id = Guid.NewGuid();
          
        private List<IResource> _animals = new List<IResource>();
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
            // get
            // {
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

            // }
        }

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public void AddResource(IResource animal)
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

        public void AddResource(List<IResource> animals)
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