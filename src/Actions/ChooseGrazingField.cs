using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using System.Collections.Generic;

namespace Trestlebridge.Actions {
    public class ChooseGrazingField 
    {
        public static void CollectInput (Farm farm, IGrazing animal) {
            Console.Clear();
            
            for (int i = 0; i < farm.GrazingFields.Count; i++)
            {
                if(farm.GrazingFields[i].GetCount < farm.GrazingFields[i].Capacity)
                {
                    Console.WriteLine ($"{i + 1}. Grazing Field ({farm.GrazingFields[i].GetCount} animals),");
                    foreach(KeyValuePair<string, int> animals in farm.GrazingFields[i].GetTypeCount){
                        Console.Write($" ({animals.Key}: {animals.Value}) ");
                    }
                    Console.WriteLine();
                }
                 
            }

            Console.WriteLine ();

            // How can I output the type of animal chosen here?
            Console.WriteLine ($"Place the {animal} where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());

            farm.GrazingFields[choice - 1].AddResource(animal);

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}