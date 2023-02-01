using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_ApuAnimalPark.Objects.Birds
{
    public class Eagle : Bird
    {
        public string _Color { get; set; }
        public int _Flight_Speed { get; set; }

        public Eagle(int flightSpeed, string color, int wingsSpread, double beakLength) : base(wingsSpread, beakLength)
        {
            _Flight_Speed = flightSpeed;
            _Color = color;
        }
    }
}
