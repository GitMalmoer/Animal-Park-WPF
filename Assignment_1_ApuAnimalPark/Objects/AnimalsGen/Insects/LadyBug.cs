using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_ApuAnimalPark.Objects.AnimalsGen.Insects
{
    public class LadyBug : Insect
    {
        public int Number_Of_Dots { get; set; }

        public LadyBug(int numberOfDots,int numberOfLegs ):base(numberOfLegs)
        {
            Number_Of_Dots = numberOfDots;
        }

        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += string.Format("Dots number: {0,-25}\nAnimal: {1,-25}", Number_Of_Dots, typeof(LadyBug).Name);
            return strOut;
        }
    }
}
