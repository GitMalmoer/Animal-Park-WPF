using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_ApuAnimalPark.Objects.AnimalsGen
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Age { get; set; }
        public GenderTypes Gender { get; set; }
        public CategoryType Category { get; set; }

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

        public override string ToString()
        {
            string strOut = string.Format("ID: {0,-25}\nName: {1,-25}\nAge: {2,-25}\nGender: {3,-25}\nCategory: {4,-25}\n",Id,Name,Age.ToString(),Gender.ToString(),Category.ToString());
            return strOut;
        }
    }
}
