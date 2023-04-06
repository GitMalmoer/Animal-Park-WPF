using Assignment_2_ApuAnimalPark.Objects.AnimalsGen.FoodScheduleFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Assignment_2_ApuAnimalPark.Objects.Food;
using Newtonsoft.Json;
using Assignment_2_ApuAnimalPark.Objects.Mammals;
using System.Xml.Serialization;
using Assignment_2_ApuAnimalPark.Objects.AnimalsGen.Insects;
using Assignment_2_ApuAnimalPark.Objects.Birds;
using Assignment_2_ApuAnimalPark.Objects.Marines;

namespace Assignment_2_ApuAnimalPark.Objects.AnimalsGen
{
    [Serializable]
    [XmlInclude(typeof(Mammal))]
    [XmlInclude(typeof(Insect))]
    [XmlInclude(typeof(Marine))]
    [XmlInclude(typeof(Bird))]
    [XmlInclude(typeof(FoodItem))]
    public abstract class Animal : IAnimal, IComparable<Animal>
    {
        // WHEN YOU ADD NEW ANIMAL SPECIE REMEMBER TO ADD IT INTO <ANIMAL_NAME>SPECIES ENUM!
        public int Id { get; set; }
        public string Name { get; set; }
        public double Age { get; set; }
        public GenderTypes Gender { get; set; }
        public CategoryType Category { get; set; }
        public string AnimalPicture { get; set; }

        [JsonRequired]
        [XmlElement("FoodItem")]
        public FoodItem FoodItem { get; set; } = new FoodItem();

        public Animal()
        {
            Reset();
        }
        
        private void Reset()
        {
            Gender = GenderTypes.Unknown;
            Category = CategoryType.Mammal;
        }

        public Animal(string name, string description, double age, GenderTypes gender, CategoryType category, int id)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Category = category;
            Id = id;
        }

        public override string ToString() // this works as getextrainfo method
        {
            string strOut = string.Format("ID: {0,-25}\nName: {1,-25}\nAge: {2,-25}\nGender: {3,-25}\nCategory: {4,-25}\n", Id, Name, Age.ToString(), Gender.ToString(), Category.ToString());
            return strOut;
        }

        public abstract FoodSchedule GetFoodSchedule();

        public int CompareTo(Animal? other)
        {
            return Name.CompareTo(other.Name);
        }
    }

    public class NameComparer : IComparer<Animal>
    {
        public int Compare(Animal? x, Animal? y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }

    public class SpecieComparer : IComparer<Animal>
    {
        public int Compare(Animal? x, Animal? y)
        {
            return x.Category.CompareTo(y.Category);
        }
    }
}
