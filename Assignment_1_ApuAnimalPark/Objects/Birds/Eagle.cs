using Assignment_1_ApuAnimalPark.Objects.Mammals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_ApuAnimalPark.Objects.Birds
{
    public class Eagle : Bird
    {
        public string Color { get; set; }
        public int Flight_Speed { get; set; }

        public Eagle(int flightSpeed, string color, int wingsSpread, double beakLength) : base(wingsSpread, beakLength)
        {
            Flight_Speed = flightSpeed;
            Color = color;
        }
        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += string.Format("Color: {0,-25}\nFlight Speed: {1,-25}\nAnimal: {2,-25}\n", Color, Flight_Speed.ToString(), typeof(Eagle).Name);

            return strOut;
        }

    }
}
