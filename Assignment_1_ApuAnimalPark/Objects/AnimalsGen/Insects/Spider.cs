using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_2_ApuAnimalPark.Objects.AnimalsGen.FoodScheduleFolder;

namespace Assignment_2_ApuAnimalPark.Objects.AnimalsGen.Insects
{
    [Serializable]
    public class Spider : Insect
    {
        private FoodSchedule foodSchedule;
        public string Venomous { get; set; }

        public Spider()
        {
            Venomous = string.Empty;
        }
        public Spider(string venomous,int numberOfLegs):base(numberOfLegs)
        {
            Venomous = venomous;
            SetFoodSchedule();
        }

        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += string.Format("Venomous: {0,-25}\nAnimal: {1,-25}\n", Venomous, typeof(Spider).Name);
            return strOut;
        }

        private void SetFoodSchedule()
        {
            foodSchedule = new FoodSchedule();
            foodSchedule.EaterType = EaterType.Carnivore;
            foodSchedule.Add("Morning: Little bugs");
            foodSchedule.Add("Lunch: Crickets");
            foodSchedule.Add("Evening: grub and fly larvas");
        }

        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }
    }
}
