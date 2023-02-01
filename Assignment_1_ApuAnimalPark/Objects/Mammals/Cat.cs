using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_ApuAnimalPark.Objects.Mammals
{
    public class Cat : Mammal
    {
        public string Breed { get; set; }

        public int Cuteness { get; set; }

        public Cat(int numOfTeeth,int tailLength, string breed, int cuteness) : base(numOfTeeth,tailLength)
        {
            this.Breed = breed;
            this.Cuteness = cuteness;
        }
        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += string.Format("Breed: {0,-25}\nCuteness: {1,-25}\nAnimal: {2,-25}\n", Breed, Cuteness, typeof(Cat).Name);

            return strOut;
        }

    }
}
