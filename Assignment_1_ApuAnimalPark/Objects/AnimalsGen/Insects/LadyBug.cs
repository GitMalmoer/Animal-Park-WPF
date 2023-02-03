using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_2_ApuAnimalPark.Objects.AnimalsGen.FoodScheduleFolder;

namespace Assignment_2_ApuAnimalPark.Objects.AnimalsGen.Insects
{
    public class LadyBug : Insect
    {
        private FoodSchedule foodSchedule;
        public int Number_Of_Dots { get; set; }

        public LadyBug(int numberOfDots,int numberOfLegs ):base(numberOfLegs)
        {
            Number_Of_Dots = numberOfDots;
            SetFoodSchedule();
        }

        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += string.Format("Dots number: {0,-25}\nAnimal: {1,-25}", Number_Of_Dots, typeof(LadyBug).Name);
            return strOut;
        }

        private void SetFoodSchedule()
        {
            foodSchedule = new FoodSchedule();
            foodSchedule.EaterType = EaterType.Omnivorous;
            foodSchedule.Add("Morning: Green plants");
            foodSchedule.Add("Lunch: Yellow roses");
            foodSchedule.Add("Evening: Little mosquitoes ");
        }

        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }
    }
}
