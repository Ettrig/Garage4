﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq; 

namespace GarageProject
{
    class GarageHandler
    {
        private Garage<Vehicle> theGarage;

        public void CreateGarage(int capacity)
        {
            theGarage = new Garage<Vehicle>(capacity);
        }

        public bool Initialized() => !(theGarage == null);

        public bool Full()
        {
            return theGarage.Count >= theGarage.Capacity; 
        }

        public bool AddVehicle(Vehicle theVehicle)
        {
            if (theGarage.Count == theGarage.Capacity) return false;
            else
            {
                theGarage.AddVehicle(theVehicle);
                return true;
            }
        }

        public bool RemoveVehicle(string license)
        {
            return theGarage.RemoveVehicle(license);
        }

        public Vehicle FindVehicle(string license)
        {
            return theGarage.FindVehicle(license);
        }

        public IEnumerable<Vehicle> ListVehicles()
        {
            // Handler is not to present data, just to provide the list of vehicles
            return theGarage;
        }

        public IEnumerable<Vehicle> GetCharacterizedVehicles(int wheels, string color) {
            return theGarage.Where(v =>
               (wheels < 0 || v.Wheels == wheels) &&
               (color == null || v.Color == color)
            );
        }

        public List<TypeListItem> ListVehicleTypes()
        {
            var returnVal = new List<TypeListItem>();
            IEnumerable<IGrouping<string, Vehicle>> vehiclsGrouped = theGarage.GroupBy(v => v.GetType().ToString()); 
            foreach (IGrouping<string, Vehicle> g in vehiclsGrouped) returnVal.Add(new TypeListItem(g.Key, g.Count()));
            return returnVal;
        }
    }
}
