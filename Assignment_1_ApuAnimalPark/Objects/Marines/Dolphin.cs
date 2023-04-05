using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_2_ApuAnimalPark.Objects.AnimalsGen.FoodScheduleFolder;

namespace Assignment_2_ApuAnimalPark.Objects.Marines
{
    [Serializable]
    public class Dolphin : Marine
    {
        private FoodSchedule foodSchedule;
        public string WildOrCaptivity { get; set; }

        public Dolphin(double weight, string sound, string wildOrCaptivity) : base(weight, sound)
        {
            WildOrCaptivity = wildOrCaptivity;
            SetFoodSchedule();
        }
        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += string.Format("Wild or Captivity?: {0,-25}\nAnimal: {1,-25}", WildOrCaptivity, typeof(Dolphin).Name);
            return strOut;
        }

        private void SetFoodSchedule()
        {
            foodSchedule = new FoodSchedule();
            foodSchedule.EaterType = EaterType.Carnivore;
            foodSchedule.Add("Morning: Little fishes and baby pike");
            foodSchedule.Add("Lunch: little bigger fishes than little fishes");
            foodSchedule.Add("Evening: big fat catfish");
        }

        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }
    }
}
