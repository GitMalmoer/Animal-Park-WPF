using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_2_ApuAnimalPark.Objects.AnimalsGen.FoodScheduleFolder;

namespace Assignment_2_ApuAnimalPark.Objects.AnimalsGen
{
    public interface IAnimal
    {
        int Id { get; set; }
        string Name { get; set; }
        GenderTypes Gender { get; set; }

        FoodSchedule GetFoodSchedule();

    }
}
