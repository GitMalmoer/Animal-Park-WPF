using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_1_ApuAnimalPark.Objects.AnimalsGen;

namespace Assignment_1_ApuAnimalPark.Objects.Marines
{
    public class Marine : Animal
    {
        public double Weight { get; set; }
        public string Sound { get; set; }


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
    }
}
