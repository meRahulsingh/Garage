﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Subclasses
{
  public class Boat:Vehicles
    {
        public Boat()
        { }

        public Boat(string name, int noeng, string ftype, int noseats)
        {
            Name = name;
            NoOfEngines = noeng;
            FuelType = ftype;
            NoOfSeats = noseats;

        }
        public override string GarageInfo()
        {
            return base.GarageInfo();
            //"THE REG.NO OF THE BOAT YOU HAVE PARKED IS :" + Name +
            //    "\nTHE NO. OF ENGINES IN THIS VEHICLE  :" + NoOfEngines +
            //    "\nTHIS VEHICLE RUNS ON :" + FuelType + "\nTHIS VEICLE HAS  ::" + NoOfSeats + " :: SEAT" + "\n ------------------------------------------------------------------";

        }

    }
}
