using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Assignment_2_ApuAnimalPark.Objects.AnimalsGen;
using Assignment_2_ApuAnimalPark.Objects.Food;
using Assignment_2_ApuAnimalPark.Objects.ListManager;

namespace Assignment_2_ApuAnimalPark.Objects
{
    public class AnimalsManager : ListManager<Animal>
    {
        public Dictionary<int, FoodItem> AnimalFoodItemDictionary { get; set; }

        private int AnimalsCounter; // This is used to generate unique animal ID

        public AnimalsManager()
        {
            AnimalFoodItemDictionary = new Dictionary<int, FoodItem>();
            AnimalsCounter = 0;
        }

        public int IdGenerator()
        {
            AnimalsCounter += 1;
            return AnimalsCounter;
        }

        public FoodItem GetValueFromFoodItemsDictionary(int animalId)
        {
            var result = AnimalFoodItemDictionary.GetValueOrDefault(animalId, null);
            return result;
        }


    }
}
