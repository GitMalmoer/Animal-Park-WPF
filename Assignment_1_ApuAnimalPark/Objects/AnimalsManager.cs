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

        public int AnimalsListCount
        {
            get { return _animals.Count; }
        }

        public AnimalsManager()
        {
            _animals = new List<Animal>();
        }

        public Animal GetAnimalAt(int index)
        {
            if (index >= 0)
            {
                return _animals[index];
            }
            else
            {
                return null;
            }
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

        public List<Animal> SortListByName()
        {
            _animals.Sort(new NameComparer());
            return _animals;
        }

    }
}
