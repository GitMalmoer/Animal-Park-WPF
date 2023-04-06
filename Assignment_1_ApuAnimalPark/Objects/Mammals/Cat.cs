using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_2_ApuAnimalPark.Objects.AnimalsGen.FoodScheduleFolder;

namespace Assignment_2_ApuAnimalPark.Objects.Mammals
{
    [Serializable]
    public class Cat : Mammal
    {
        private FoodSchedule foodSchedule;
        public string Breed { get; set; }

        public int Cuteness { get; set; }

        public Cat()
        {
            Breed = String.Empty;
            Cuteness = 1;
        }
        public Cat(int numOfTeeth,int tailLength, string breed, int cuteness) : base(numOfTeeth,tailLength)
        {
            this.Breed = breed;
            this.Cuteness = cuteness;
            SetFoodSchedule();
        }
        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += string.Format("Breed: {0,-25}\nCuteness: {1,-25}\nAnimal: {2,-25}\n", Breed, Cuteness, typeof(Cat).Name);

            return strOut;
        }

        private void SetFoodSchedule()
        {
            foodSchedule = new FoodSchedule();
            foodSchedule.EaterType = EaterType.Omnivorous;
            foodSchedule.Add("Morning: cat food");
            foodSchedule.Add("Lunch: milk with fish");
            foodSchedule.Add("Evening: Dont feed, its enough...");
        }
        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }
    }
}
