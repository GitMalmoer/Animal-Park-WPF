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
using System.Windows.Documents;
using System.Windows.Shapes;
using System.Xml.Serialization;
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

        public void SerializeJSON(AnimalsManager animalsManager, FoodManager foodManager,string path)
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
            // abstract class exception
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

        public bool SerializeBinary(AnimalsManager animalsManager, FoodManager foodManager, string path)
        {
            bool serializeOk = false;
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
                serializeOk = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                errorMsg = e.Message;
                serializeOk = false;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }

            return serializeOk;
        }

        public bool DeserializeBinary(string path, ref AnimalsManager animalsManager, ref FoodManager foodManager)
        {
            bool deserializeOK = false;

            FileStream fileStream = null;
            string errorMsg = "";

            try
            {
                fileStream = new FileStream(path, mode: FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                List<Animal> animalList = (List<Animal>)binaryFormatter.Deserialize(fileStream);

                if (animalList.Count > 0)
                {
                    //SETTING THE ANIMAL LIST IN ANIMALS MANAGER
                    animalsManager.setAnimalList(animalList);

                    //LIST OF FOOD ITEMS
                    List<FoodItem> foodItems = new List<FoodItem>();

                    // POPULATING DICTIONARY IN ANIMALS MANAGER
                    foreach (Animal animal in animalList)
                    {
                        animalsManager.AnimalFoodItemDictionary.Add(animal.Id, animal.FoodItem);

                        // POPULATING foodItems with no repeating items
                        if (!foodItems.Contains(animal.FoodItem))
                        {
                            foodItems.Add(animal.FoodItem);
                        }
                    }
                    // SETTING FOOD MANAGER 
                    foodManager.setFoodList(foodItems);

                    deserializeOK = true;
                }
            }
            catch (Exception e)
            {
                errorMsg = e.Message;
                MessageBox.Show(errorMsg);
                deserializeOK = false;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }

            return deserializeOK;
        }

        public void SerializeXml(AnimalsManager animalsManager, FoodManager foodManager, string path)
        {
            string fileName = Path.GetFileName(path);
            string FolderAnimals = Path.Combine(Environment.CurrentDirectory, $"{fileName.Split('.')[0]}Folder", "Animals.xml");
            string folderFoodItems = Path.Combine(Environment.CurrentDirectory, $"{fileName.Split('.')[0]}Folder", "FoodItems.xml");
            string folderPath = Path.Combine(Environment.CurrentDirectory, $"{fileName.Split('.')[0]}Folder");

            Directory.CreateDirectory(folderPath);

            try
            {
                List<Animal> animals = new List<Animal>();
                List<FoodItem> foodItems = new List<FoodItem>();

                for (int i = 0; i < animalsManager.Count; i++)
                {
                    animals.Add(animalsManager.GetAt(i));
                }

                for (int i = 0; i < foodManager.Count; i++)
                {
                    foodItems.Add(foodManager.GetAt(i));
                }

                XmlSerializer serializerAnimals = new XmlSerializer(typeof(List<Animal>));
                XmlSerializer serializerFoodItems = new XmlSerializer(typeof(List<FoodItem>));

                using (StreamWriter writer = new StreamWriter(FolderAnimals))
                {
                    serializerAnimals.Serialize(writer,animals);
                }

                using (StreamWriter writer = new StreamWriter(folderFoodItems))
                {
                    serializerFoodItems.Serialize(writer, foodItems);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageBox.Show(e.Message);
                throw;
            }
        }

        public bool DeserializeXml(string path, ref AnimalsManager animalsManager, ref FoodManager foodManager)
        {
            bool deserializeOk = false;
            FileStream fileStream = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Animal>));

                using (fileStream = new FileStream(path, FileMode.Open))
                {
                    List<Animal> animals = (List<Animal>)serializer.Deserialize(fileStream);
                    if (animals != null && animals.Count > 0)
                    {
                        deserializeOk = true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                deserializeOk = false;
                throw;
            }
            finally
            {
                if(fileStream != null)
                { fileStream.Close(); }
            }


            return deserializeOk;
        }

        public void openFile(string path,string extension, ref AnimalsManager animalsManager, ref FoodManager foodManager)
        {
            if (extension.Contains("txt") || extension.Contains("json"))
            {
                DeserializeJSON(path);
            }

            else if (extension.Contains("bin"))
            {
                var deserialize = DeserializeBinary(path, ref animalsManager, ref foodManager);
                if (deserialize) MessageBox.Show("Opened: " + path);
            }

            else if (extension.Contains("xml"))
            {
                var deserialize = DeserializeXml(path, ref animalsManager, ref foodManager);
                if (deserialize) MessageBox.Show("Opened: " + path);
            }
        }





    }
}
