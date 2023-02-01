using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_1_ApuAnimalPark.Objects.AnimalsGen;

namespace Assignment_1_ApuAnimalPark.Objects.Birds
{
    public class Bird : Animal
    {
        public int Wings_Spread { get; set; }
        public double Beak_Length { get; set; }

        public Bird(int wingsSpread, double beakLength)
        {
            Wings_Spread = wingsSpread;
            Beak_Length = beakLength;
        }
    }
}
