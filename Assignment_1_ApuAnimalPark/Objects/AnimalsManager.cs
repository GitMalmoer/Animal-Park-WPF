using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_1_ApuAnimalPark.Objects.AnimalsGen;

namespace Assignment_1_ApuAnimalPark.Objects
{
    public class AnimalsManager
    {
        public List<Animal> _animals { get; set; }

        public AnimalsManager()
        {
            _animals = new List<Animal>();
        }


    }
}
