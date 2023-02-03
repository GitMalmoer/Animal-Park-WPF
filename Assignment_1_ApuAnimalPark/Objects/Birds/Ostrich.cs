using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_2_ApuAnimalPark.Objects.AnimalsGen.FoodScheduleFolder;

namespace Assignment_2_ApuAnimalPark.Objects.Birds
{
    public class Ostrich : Bird
    {
        private FoodSchedule foodSchedule;
        public int NeckLength { get; set; }
        public string BuryHead { get; set; }

        public Ostrich(int neckLength, string buryHead, int wingsSpread, double beakLength): base(wingsSpread, beakLength)
        {
            NeckLength = neckLength;
            BuryHead = buryHead;
            SetFoodSchedule();
        }

        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += string.Format("Neck Length: {0,-25}\nBuries Head?: {1,-25}\nAnimal: {2,-25}\n", NeckLength, BuryHead, typeof(Ostrich).Name);

            return strOut;
        }

        private void SetFoodSchedule()
        {
            foodSchedule = new FoodSchedule();
            foodSchedule.EaterType = EaterType.Omnivorous;
            foodSchedule.Add("Morning: Little bugs");
            foodSchedule.Add("Lunch: Some green-yellow plants");
            foodSchedule.Add("Evening: Chicken eggs with grass pasta");
        }

        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }
    }
}
