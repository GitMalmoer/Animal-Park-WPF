using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Assignment_2_ApuAnimalPark.Objects.ListManager;
using Assignment_2_ApuAnimalPark.Objects.Mammals;

namespace Assignment_2_ApuAnimalPark.Objects.Food
{
    [Serializable]
    [XmlInclude(typeof(ListManager<string>))]
    public class FoodItem
    {
        [XmlElement("Ingredients")]
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
