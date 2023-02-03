using Assignment_2_ApuAnimalPark.Objects.Mammals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_2_ApuAnimalPark.Objects.AnimalsGen.FoodScheduleFolder;

namespace Assignment_2_ApuAnimalPark.Objects.Birds
{
    public class Eagle : Bird
    {
        private FoodSchedule foodSchedule;
        public string Color { get; set; }
        public int Flight_Speed { get; set; }

        public Eagle(int flightSpeed, string color, int wingsSpread, double beakLength) : base(wingsSpread, beakLength)
        {
            Flight_Speed = flightSpeed;
            Color = color;
            SetFoodSchedule();
        }
        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += string.Format("Color: {0,-25}\nFlight Speed: {1,-25}\nAnimal: {2,-25}\n", Color, Flight_Speed.ToString(), typeof(Eagle).Name);

            return strOut;
        }

        private void SetFoodSchedule()
        {
            foodSchedule = new FoodSchedule();
            foodSchedule.EaterType = EaterType.Omnivorous;
            foodSchedule.Add("Morning: Grain");
            foodSchedule.Add("Lunch: Water with meatballs");
            foodSchedule.Add("Evening: Fried crickets with chips");
        }

        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }
    }
}
