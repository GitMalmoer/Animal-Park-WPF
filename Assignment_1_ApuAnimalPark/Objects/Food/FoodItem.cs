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
        // no more ListManager - xmlserializer is not able to do it right when we use ListManager class
        public List<string> Ingredients { get; }
        
        public string Name { get; set; }

        public FoodItem()
        {
            Name = string.Empty;
            Ingredients = new List<string>();
        }

        public bool Add(string type)
        {
            if (type == null) return false;
            Ingredients.Add(type);
            return true;

        }

        public bool ChangeAt(string type, int index)
        {
            bool changed = false;

            if (CheckIndex(index))
            {
                try
                {
                    Ingredients.RemoveAt(index);
                    Ingredients.Insert(index, type);
                    changed = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    changed = false;
                }
            }

            return changed;
        }

        public bool DeleteAt(int index)
        {
            if (CheckIndex(index))
            {
                Ingredients.RemoveAt(index);
                return true;
            }
            return false;
        }

        public string GetAt(int index)
        {
            if (CheckIndex(index))
            {
                if (Ingredients[index] != null)
                {
                    return Ingredients[index];
                }
            }

            return null;
        }

        public bool CheckIndex(int index)
        {
            if (index < 0) return false;
            return true;
        }

        public List<string> ToStringList()
        {
            List<string> stringList = new List<string>();

            foreach (var item in Ingredients)
            {
                stringList.Add(item.ToString());
            }
            return stringList;
        }

        // ALTHOUGH YOU SEE 0 REFERERENCES - LISTVIEW AUTOMATICALLY CALLS THIS METHOD VERY IMPORANT!
        public override string ToString()
        {
            string strOut = Name + " ";
            List<string> stringList = ToStringList();

            StringBuilder sb = new StringBuilder(strOut); // using string builder because its more efficient than converting list to string using loops

            if (Ingredients.Count > 0)
                sb.AppendJoin(",", stringList);

            return sb.ToString();
        }

     
    }
}
