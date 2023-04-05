using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_2_ApuAnimalPark.Objects.AnimalsGen;
using Assignment_2_ApuAnimalPark.Objects.ListManager;

namespace Assignment_2_ApuAnimalPark.Objects.Food
{
    public class FoodManager : ListManager<FoodItem>
    {
        /// <summary>
        /// This is used for opening saved file.
        /// </summary>
        /// <param name="foodList"></param>
        public void setFoodList(List<FoodItem> foodList)
        {
            if (foodList.Count > 0)
            {
                _list = foodList;
            }
        }

    }
}
