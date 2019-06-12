using System.Collections.Generic;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Interfaces
{
    public interface IFacility<T> 
    {
        double Capacity { get; }
        
        int GetCount {get;}

        Dictionary<string, int> GetTypeCount();
        void AddResource (T resource);
        void AddResource (List<T> resources);
    }
}