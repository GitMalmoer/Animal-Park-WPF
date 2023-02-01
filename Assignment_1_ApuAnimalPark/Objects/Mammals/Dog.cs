using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_1_ApuAnimalPark.Objects.AnimalsGen;

namespace Assignment_1_ApuAnimalPark.Objects.Mammals
{
    public class Dog : Mammal
    {
        public string Breed { get; set; }

        public Dog(int numOfTeeth, int tailLength) : base(numOfTeeth, tailLength)
        {
            Breed = "Unknown";
        }

        public Dog(int numOfTeeth,int tailLength, string breed) : base(numOfTeeth, tailLength)
        {
            Breed = breed;
        }

        public override string ToString()
        {
            string strOut = base.ToString();
            strOut += string.Format("Breed: {0,-25}\nAnimal: {1,-25}\n",Breed,typeof(Dog).Name);

            return strOut;
        }
    }
}
