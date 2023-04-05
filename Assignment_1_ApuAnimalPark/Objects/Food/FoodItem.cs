using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_2_ApuAnimalPark.Objects.ListManager;

namespace Assignment_2_ApuAnimalPark.Objects.Food
{
    [Serializable]
    public class FoodItem
    {
        public ListManager<string> Ingredients { get; }
        public string Name { get; set; }

        public FoodItem()
        {
            Ingredients = new ListManager<string>();
        }

        public override string ToString()
        {
            string strOut = Name + " ";
            List<string> stringList = Ingredients.ToStringList();

            StringBuilder sb = new StringBuilder(strOut); // using string builder because its more efficient than converting list to string using loops
            
            if(Ingredients.Count > 0)
                sb.AppendJoin(",",stringList);

            return sb.ToString();
        }
    }
}
