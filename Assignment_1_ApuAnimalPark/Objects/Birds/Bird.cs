using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_1_ApuAnimalPark.Objects.AnimalsGen;
using Assignment_1_ApuAnimalPark.Objects.Mammals;

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

        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += string.Format("Wings spread: {0,-25}\nBeak Length: {1,-25}\nAnimal: {2,-25}\n", Wings_Spread.ToString(),Beak_Length.ToString(),typeof(Dog).Name);

            return strOut;
        }
    }
}
