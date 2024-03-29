﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Assignment_2_ApuAnimalPark.Objects.AnimalsGen;
using Assignment_2_ApuAnimalPark.Objects.AnimalsGen.FoodScheduleFolder;
using Assignment_2_ApuAnimalPark.Objects.Birds;

namespace Assignment_2_ApuAnimalPark.Objects.Marines
{
    [Serializable]
    [XmlInclude(typeof(Dolphin))]
    [XmlInclude(typeof(Seal))]
    public abstract class Marine : Animal
    {
        private double Weight { get;}
        private string Sound { get;}


        public Marine()
        {
            Weight = 0;
            Sound = string.Empty;
        }

        public Marine(double weight, string sound)
        {
            Weight = weight;
            Sound = sound;
        }

        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += string.Format("Weight: {0,-25}\nSound: {1,-25}\n", Weight, Sound);
            return strOut;
        }

        public abstract override FoodSchedule GetFoodSchedule();
    }
}
