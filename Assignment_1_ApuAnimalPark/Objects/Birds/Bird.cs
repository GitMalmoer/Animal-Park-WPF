using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_2_ApuAnimalPark.Objects.AnimalsGen;
using Assignment_2_ApuAnimalPark.Objects.AnimalsGen.FoodScheduleFolder;
using Assignment_2_ApuAnimalPark.Objects.Mammals;

namespace Assignment_2_ApuAnimalPark.Objects.Birds
{
    [Serializable]
    public abstract class Bird : Animal
    {
        private int Wings_Spread { get; set; }
        private double Beak_Length { get; set; }

        public Bird(int wingsSpread, double beakLength)
        {
            Wings_Spread = wingsSpread;
            Beak_Length = beakLength;
        }

        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += string.Format("Wings spread: {0,-25}\nBeak Length: {1,-25}\n", Wings_Spread.ToString(),Beak_Length.ToString());

            return strOut;
        }

        public abstract override FoodSchedule GetFoodSchedule();
    }
}
