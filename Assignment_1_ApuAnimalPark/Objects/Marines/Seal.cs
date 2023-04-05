using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_2_ApuAnimalPark.Objects.AnimalsGen.FoodScheduleFolder;

namespace Assignment_2_ApuAnimalPark.Objects.Marines
{
    [Serializable]
    public class Seal : Marine
    {
        private FoodSchedule foodSchedule;
        public string Can_do_tricks { get; set; }

        public Seal(double weight,string sound,string canDoTricks) : base(weight,sound)
        {
            Can_do_tricks = canDoTricks;
            SetFoodSchedule();
        }

        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += string.Format("Can do tricks?: {0,-25}\nAnimal: {1,-25}", Can_do_tricks, typeof(Seal).Name);
            return strOut;
        }

        private void SetFoodSchedule()
        {
            foodSchedule = new FoodSchedule();
            foodSchedule.EaterType = EaterType.Omnivorous;
            foodSchedule.Add("Morning: Fish and chips");
            foodSchedule.Add("Lunch: Fish with cavior");
            foodSchedule.Add("Evening: Makrill med surstroming");
        }

        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }
    }
}
