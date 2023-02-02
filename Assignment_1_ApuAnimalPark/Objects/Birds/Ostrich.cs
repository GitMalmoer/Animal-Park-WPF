using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_ApuAnimalPark.Objects.Birds
{
    public class Ostrich : Bird
    {
        public int NeckLength { get; set; }
        public string BuryHead { get; set; }

        public Ostrich(int neckLength, string buryHead, int wingsSpread, double beakLength): base(wingsSpread, beakLength)
        {
            NeckLength = neckLength;
            BuryHead = buryHead;
        }

        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += string.Format("Neck Length: {0,-25}\nBuries Head?: {1,-25}\nAnimal: {2,-25}\n", NeckLength, BuryHead, typeof(Ostrich).Name);

            return strOut;
        }

    }
}
