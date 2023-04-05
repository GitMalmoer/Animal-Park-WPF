using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using Assignment_2_ApuAnimalPark.Objects;
using Assignment_2_ApuAnimalPark.Objects.AnimalsGen;
using Assignment_2_ApuAnimalPark.Objects.Food;
using Assignment_2_ApuAnimalPark.Objects.Mammals;
using Newtonsoft.Json;
using Path = System.IO.Path;

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

        public void saveFileAsJSON(AnimalsManager animalsManager, FoodManager foodManager,string path)
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

        public void DeserializeJSON(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                var version = sr.ReadLine();
                if (version == currentVersion)
                {
                    try
                    {
                        var wholeFile = sr.ReadToEnd();
                        var fileDeserialized = JsonConvert.DeserializeObject<List<Animal>>(wholeFile);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }

            }
        }

        public void SerializeBinary(AnimalsManager animalsManager, FoodManager foodManager, string path)
        {
            FileStream fileStream = null;
            string errorMsg = "";

            try
            {
                for (int i = 0; i < animalsManager.Count; i++)
                {
                    _animals.Add(animalsManager.GetAt(i));
                }

                fileStream = new FileStream(path, mode: FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, _animals);
            }
            catch (Exception e)
            {
                errorMsg = e.Message;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
        }

        public void DeserializeBIN(string path, ref AnimalsManager animalsManager, ref FoodManager foodManager)
        {
            FileStream fileStream = null;
            string errorMsg = "";

            try
            {
                fileStream = new FileStream(path, mode: FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                List<Animal> animalList = (List<Animal>)binaryFormatter.Deserialize(fileStream);
                
                //SETTING THE ANIMAL LIST IN ANIMALS MANAGER
                animalsManager.setAnimalList(animalList);
                
                //List of food items
                List<FoodItem> foodItems = new List<FoodItem>();

                // POPULATING DICTIONARY IN ANIMALS MANAGER
                foreach (Animal animal in animalList)
                {
                    animalsManager.AnimalFoodItemDictionary.Add(animal.Id, animal.FoodItem);

                    if (!foodItems.Contains(animal.FoodItem))
                    {
                        foodItems.Add(animal.FoodItem);
                    }
                }
                foodManager.setFoodList(foodItems);
                

            }
            catch (Exception e)
            {
                errorMsg = e.Message;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
        }

        public void openFile(string path,string extension, ref AnimalsManager animalsManager, ref FoodManager foodManager)
        {
            if (extension.Contains("txt"))
            {
                DeserializeJSON(path);
            }

            if (extension.Contains("bin"))
            {
                DeserializeBIN(path, ref animalsManager, ref foodManager);
            }
        }





    }
}
