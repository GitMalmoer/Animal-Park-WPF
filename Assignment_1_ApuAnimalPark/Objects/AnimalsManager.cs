using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Assignment_2_ApuAnimalPark.Objects.AnimalsGen;
using Assignment_2_ApuAnimalPark.Objects.Food;

namespace Assignment_2_ApuAnimalPark.Objects
{
    public class AnimalsManager
    {
        private List<Animal> _animals;

        public Dictionary<int, FoodItem> AnimalFoodItemDictionary { get; set; }
        public int AnimalsListCount
        {
            get { return _animals.Count; }
        }

        private int AnimalsCounter; // This is used to generate unique animal ID

        public AnimalsManager()
        {
            _animals = new List<Animal>();
            AnimalFoodItemDictionary = new Dictionary<int, FoodItem>();
            AnimalsCounter = 0;
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
            AnimalsCounter += 1;
            return AnimalsCounter;
        }

        public void SortListByComparer(IComparer<Animal> sorter)
        {
            if(_animals.Count > 1)
                _animals.Sort(sorter);
        }

        public FoodItem GetValueFromFoodItemsDictionary(int animalId)
        {
            FoodItem foodItem = null;
            try
            {
                FoodItem FoodItem = (FoodItem)AnimalFoodItemDictionary.First(x => x.Key == animalId).Value;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
            }
            return foodItem;
        }


    }
}
