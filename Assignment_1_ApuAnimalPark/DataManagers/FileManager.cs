using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows;
using Assignment_2_ApuAnimalPark.Objects;
using Assignment_2_ApuAnimalPark.Objects.AnimalsGen;
using Assignment_2_ApuAnimalPark.Objects.Food;
using Assignment_2_ApuAnimalPark.Objects.Mammals;
using Newtonsoft.Json;

namespace ApuAnimalPark.DataManagers
{
    class FileManager
    {
        private List<Animal> _animals;
        private string defaultPath = "../SavedFiles/";
        private string currentVersion = "Version 1";
        public FileManager()
        {
             _animals = new List<Animal>();
        }

        public void saveFileAs(AnimalsManager animalsManager, FoodManager foodManager,string path)
        {
            for (int i = 0; i < animalsManager.Count; i++)
            {
                _animals.Add(animalsManager.GetAt(i));
            }

            var animalsListSerialized = JsonConvert.SerializeObject(_animals,formatting:Formatting.Indented);

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(currentVersion);
                sw.Write(animalsListSerialized);
            }
        }

        public void openFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                var version = sr.ReadLine();
                if (version == currentVersion)
                {
                    var wholeFile = sr.ReadToEnd();
                    var fileDeserialized = JsonConvert.DeserializeObject<List<Animal>>(wholeFile);

                 
                }



            }
        }





    }
}
