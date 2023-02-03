using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_2_ApuAnimalPark.Objects.AnimalsGen;

namespace Assignment_2_ApuAnimalPark.Objects
{
    public class AnimalsManager
    {
        private List<Animal> _animals;

        public AnimalsManager()
        {
            _animals = new List<Animal>();
        }

        public List<Animal> GetAnimalsList()
        {
            return _animals;
        }

        public void addToAnimalsList(Animal animal)
        {
            if (animal != null)
            {
                _animals.Add(animal);
            }
        }

        public int IdGenerator()
        {
            return _animals.Count + 1;
        }

    }
}
