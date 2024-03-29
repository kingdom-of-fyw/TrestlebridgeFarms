using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals{
    public class Goat : IResource, IGrazing, IComposting  {
        private Guid _id = Guid.NewGuid();
        public string Type { get; } = "Goat";
        public double GrassPerDay { get; set; } = 4.1;

        private double _compostProduced = 7.5;

        public double Compost() 
        {
            return _compostProduced;
        }

        private string _shortId
        {
            get
            {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }
        public void Graze()
        {
            Console.WriteLine($"Goat {this._shortId} just ate {this.GrassPerDay}kg of grass");
        }
         public override string ToString () {
            return $"Goat {this._shortId}. Baa'aa'aaa!";
        }
    }
}