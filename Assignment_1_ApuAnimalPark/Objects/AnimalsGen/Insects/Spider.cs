using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_ApuAnimalPark.Objects.AnimalsGen.Insects
{
    public class Spider : Insect
    {
        public string Venomous { get; set; }

        public Spider(string venomous,int numberOfLegs):base(numberOfLegs)
        {
            Venomous = venomous;
        }

        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += string.Format("Venomous: {0,-25}\nAnimal: {1,-25}\n", Venomous, typeof(Spider).Name);
            return strOut;
        }
    }
}
