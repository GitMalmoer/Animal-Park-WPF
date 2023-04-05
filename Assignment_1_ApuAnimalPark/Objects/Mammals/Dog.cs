using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_2_ApuAnimalPark.Objects.AnimalsGen;
using Assignment_2_ApuAnimalPark.Objects.AnimalsGen.FoodScheduleFolder;

namespace Assignment_2_ApuAnimalPark.Objects.Mammals
{
    [Serializable]
    public class Dog : Mammal
    {
        private FoodSchedule foodSchedule;
        public string Breed { get; set; }

        public Dog(int numOfTeeth,int tailLength, string breed) : base(numOfTeeth, tailLength)
        {
            Breed = breed;
            SetFoodSchedule();
        }

        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += string.Format("Breed: {0,-25}\nAnimal: {1,-25}\n",Breed,typeof(Dog).Name);

            return strOut;
        }

        private void SetFoodSchedule()
        {
            foodSchedule = new FoodSchedule();
            foodSchedule.EaterType = EaterType.Omnivorous;
            foodSchedule.Add("Morning: flakes with milk");
            foodSchedule.Add("Lunch: bones and flakes");
            foodSchedule.Add("Evening: Any meat dish");
        }

        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }
    }
}
