using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_ApuAnimalPark.Objects.AnimalsGen.FoodScheduleFolder
{
    public class FoodSchedule
    {

        public EaterType EaterType { get; set; }
        private List<string> _foodList;

        public int Count => _foodList.Count;

        public FoodSchedule()
        {
            _foodList = new List<string>();
        }

        public string GetFoodListString()
        {
            string strOut = string.Empty;

            foreach (var item in _foodList)
            {
                strOut += item + "\n";
            }

            return strOut;
        }

        public void Add(string item)
        {
            if(!string.IsNullOrEmpty(item))
                _foodList.Add(item);
        }
    }
}
