using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_ApuAnimalPark.Objects.Marines
{
    public class Dolphin : Marine
    {
        public string WildOrCaptivity { get; set; }

        public Dolphin(double weight, string sound, string wildOrCaptivity) : base(weight, sound)
        {
            WildOrCaptivity = wildOrCaptivity;
        }
        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += string.Format("Wild or Captivity?: {0,-25}\nAnimal: {1,-25}", WildOrCaptivity, typeof(Dolphin).Name);
            return strOut;
        }
    }
}
