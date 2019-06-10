using System.Collections.Generic;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Interfaces
{
    public interface IFacility<T> : IStorage
    {
        double Capacity { get; }
        

        void AddResource (T resource);
        void AddResource (List<T> resources);
    }
}