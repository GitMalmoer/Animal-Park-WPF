using Assignment_2_ApuAnimalPark.Objects.Marines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_2_ApuAnimalPark.Objects.AnimalsGen.FoodScheduleFolder;

namespace Assignment_2_ApuAnimalPark.Objects.AnimalsGen.Insects
{
    [Serializable]
    public abstract class Insect : Animal
    {
        private int Number_Of_Legs { get; set; }

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

        public abstract override FoodSchedule GetFoodSchedule();
    }
}
