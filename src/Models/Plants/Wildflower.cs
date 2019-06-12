using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
    public class WildFlower : IResource, IComposting, ISeed
    {
        private int _seedsProduced = 40;
        public string Type { get; } = "WildFlower";

        private double _compostProduced = 30.3;

        public double Compost() 
        {
            return _compostProduced;
        }

        public override string ToString () {
            return $"WildFlower. Yum!";
        }
    }
}