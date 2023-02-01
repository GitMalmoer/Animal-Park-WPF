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
        public Cat(int numOfTeeth,int tailLength, string breed) : base(numOfTeeth,tailLength)
        {
            this.Breed = breed;
        }

    }
}
