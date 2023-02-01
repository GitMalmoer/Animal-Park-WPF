using Assignment_1_ApuAnimalPark.Objects.Marines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_ApuAnimalPark.Objects.AnimalsGen.Insects
{
    public class Insect : Animal
    {
        public int Number_Of_Legs { get; set; }

        public Insect(int numberOfLegs)
        {
            Number_Of_Legs = numberOfLegs;
        }

        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += string.Format("Legs number: {0,-25}\n", Number_Of_Legs);
            return strOut;
        }
    }
}
