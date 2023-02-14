using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Assignment_2_ApuAnimalPark.Data;
using Assignment_2_ApuAnimalPark.FoodItemsWindow;
using Assignment_2_ApuAnimalPark.Objects;
using Assignment_2_ApuAnimalPark.Objects.AnimalsGen;
using Assignment_2_ApuAnimalPark.Objects.AnimalsGen.FoodScheduleFolder;
using Assignment_2_ApuAnimalPark.Objects.AnimalsGen.Insects;
using Assignment_2_ApuAnimalPark.Objects.Birds;
using Assignment_2_ApuAnimalPark.Objects.Food;
using Assignment_2_ApuAnimalPark.Objects.Mammals;
using Assignment_2_ApuAnimalPark.Objects.Marines;
using Microsoft.VisualBasic;
using Microsoft.Win32;

namespace Assignment_2_ApuAnimalPark
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AnimalsManager animalsManager = new AnimalsManager();
        private FoodManager foodManager = new FoodManager();

        public MainWindow()
        {
            InitializeComponent();
            InitializeGUI();
            
        }

        private void InitializeGUI()
        {
            this.Title = "Apu Animal Park by Marcin Junka";
            this.ResizeMode = ResizeMode.CanMinimize;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            // BY DEFAULT VISIBILITY OF INPUT FIELDS IS HIDDEN
            HideAllInputsSpecification();
            HideAllInputsSpecies();
            // SETTING UP COMBOBOX WITH GENDER
            cmbGender.ItemsSource = Enum.GetValues(typeof(GenderTypes));
            cmbGender.SelectedItem = GenderTypes.Unknown;
            // SETTING UP LISTBOX WITH ANIMAL CATEGORY
            lstCategory.ItemsSource = Enum.GetValues(typeof(CategoryType));
            lstCategory.SelectedItem = CategoryType.Mammal;
            // SETTING UP THE DEFAULT SPECIE IN GUI AT THE PROGRAM START
            lstSpecies.SelectedItem = MammalSpecies.Dog;
            // String empty of Eater type
            lblEaterType.Content = string.Empty;

        }

        private void HideAllInputsSpecification()
        {
            grpSpecifications.Header = "";
            lblSpecs1.Visibility = Visibility.Hidden;
            txtSpecs1.Visibility = Visibility.Hidden;

            lblSpecs2.Visibility = Visibility.Hidden;
            txtSpecs2.Visibility = Visibility.Hidden;

            lblSpecs3.Visibility = Visibility.Hidden;
            txtSpecs3.Visibility = Visibility.Hidden;
        }

        private void HideAllInputsSpecies()
        {
            grpSpecies.Header = "";
            lblSpecies1.Visibility = Visibility.Hidden;
            txtSpecies1.Visibility = Visibility.Hidden;

            lblSpecies3.Visibility = Visibility.Hidden;
            txtSpecies3.Visibility = Visibility.Hidden;

            lblSpecies2.Visibility = Visibility.Hidden;
            txtSpecies2.Visibility = Visibility.Hidden;

            cmbSpecies.Visibility = Visibility.Hidden;
            lblComboSpecies.Visibility = Visibility.Hidden;
        }

        private void InitializeCutenessComboBoxData()
        {
            cmbSpecies.ItemsSource = null;
            cmbSpecies.Items.Clear();

            for (int i = 1; i <= 10; i++)
            {
                cmbSpecies.Items.Add(i);
            }
            cmbSpecies.SelectedIndex = 0;
        }

        private void InitializeYesNoComboBoxData()
        {
            // this method changes combobox into yes no enums
            cmbSpecies.ItemsSource = null;
            cmbSpecies.Items.Clear();
            cmbSpecies.ItemsSource = Enum.GetValues(typeof(YesNoEnum));
            cmbSpecies.SelectedIndex = 0;
        }

        private void InitializeAnimalEnvironmentComboBoxData()
        {
            // this method changes combobox into animal environment enums
            cmbSpecies.ItemsSource = null;
            cmbSpecies.Items.Clear();
            cmbSpecies.ItemsSource = Enum.GetValues(typeof(AnimalEnvironment));
            cmbSpecies.SelectedIndex = 0;
        }

        private void lstCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // this clears species listbox everytime selection is changed IMPORTANT!
            lstSpecies.ItemsSource = null;
            lstSpecies.SelectedIndex = -1;

            HideAllInputsSpecies();
            HideAllInputsSpecification();

            CategoryType selection = (CategoryType)lstCategory.SelectedIndex;

            switch (selection)
            {
                case CategoryType.Bird:
                    SelectedBird();
                    break;
                case CategoryType.Insect:
                    SelectedInsect();
                    break;
                case CategoryType.Mammal:
                    SelectedMammal();
                    break;
                case CategoryType.Marine:
                    SelectedMarine();
                    break;
            }
        }

        private void SelectedMammal()
        {
            grpSpecifications.Header = "Specification Mammal";
            lblSpecs1.Content = "Teeth Number: ";
            lblSpecs2.Content = "Tail Length (Cm): ";

            lblSpecs1.Visibility = Visibility.Visible;
            lblSpecs2.Visibility = Visibility.Visible;
            txtSpecs1.Visibility = Visibility.Visible;
            txtSpecs2.Visibility = Visibility.Visible;

            //IF ALL ANIMALS IS CHECKED THEN IT WILL NOT UPDATE lstSpecies WITH VALUES
            if (checkAllAnimals.IsChecked == false)
                lstSpecies.ItemsSource = Enum.GetValues(typeof(MammalSpecies));
        }

        private void SelectedBird()
        {
            grpSpecifications.Header = "Specification Bird";
            lblSpecs1.Content = "Wings Spread (Cm): ";
            lblSpecs2.Content = "Beak length (Cm): ";

            lblSpecs1.Visibility = Visibility.Visible;
            lblSpecs2.Visibility = Visibility.Visible;
            txtSpecs1.Visibility = Visibility.Visible;
            txtSpecs2.Visibility = Visibility.Visible;

            //IF ALL ANIMALS IS CHECKED THEN IT WILL NOT UPDATE lstSpecies WITH VALUES
            if (checkAllAnimals.IsChecked == false)
                lstSpecies.ItemsSource = Enum.GetValues(typeof(BirdSpecies));
        }

        private void SelectedMarine()
        {
            grpSpecifications.Header = "Specification Marine";
            lblSpecs1.Content = "Weight (Kg): ";
            lblSpecs2.Content = "Sound: ";

            lblSpecs1.Visibility = Visibility.Visible;
            lblSpecs2.Visibility = Visibility.Visible;
            txtSpecs1.Visibility = Visibility.Visible;
            txtSpecs2.Visibility = Visibility.Visible;

            //IF ALL ANIMALS IS CHECKED THEN IT WILL NOT UPDATE lstSpecies WITH VALUES
            if (checkAllAnimals.IsChecked == false)
                lstSpecies.ItemsSource = Enum.GetValues(typeof(MarineSpecies));
        }

        private void SelectedInsect()
        {
            grpSpecifications.Header = "Specification Insect";
            lblSpecs1.Content = "Legs number: ";

            lblSpecs1.Visibility = Visibility.Visible;
            txtSpecs1.Visibility = Visibility.Visible;

            //IF ALL ANIMALS IS CHECKED THEN IT WILL NOT UPDATE lstSpecies WITH VALUES
            if (checkAllAnimals.IsChecked == false)
                lstSpecies.ItemsSource = Enum.GetValues(typeof(InsectSpecies));
        }

        private void lstSpecies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HideAllInputsSpecies();

            if (lstSpecies.SelectedIndex >= 0)
            {
                Enum selectedEnum = (Enum)lstSpecies.SelectedItem;

                //string selectedSpecie = selectedEnum.GetType().Name; //this method was used because upper one didnt work and now it works?!

                switch (selectedEnum)
                {
                    case MammalSpecies:
                        SelectedMammalSpecie();

                        if (checkAllAnimals.IsChecked == true) // Reinitializing specifications when checkAllAnimals is checked
                            SelectedMammal();
                        break;
                    case BirdSpecies:
                        SelectedBirdSpecie();

                        if (checkAllAnimals.IsChecked == true) // Reinitializing specifications when checkAllAnimals is checked
                            SelectedBird();
                        break;
                    case MarineSpecies:
                        SelectedMarineSpecie();

                        if (checkAllAnimals.IsChecked == true) // Reinitializing specifications when checkAllAnimals is checked
                            SelectedMarine();
                        break;
                    case InsectSpecies:
                        SelectedInsectSpecie();

                        if (checkAllAnimals.IsChecked == true) // Reinitializing specifications when checkAllAnimals is checked
                            SelectedInsect();
                        break;
                }
            }

        }

        private void SelectedMammalSpecie()
        {
            // THIS METHODS ONLY SETS UP THE GUI. THIS SET UP IS MADE ONLY FOR MAMMALS switch is used for further implementations
            Enum selectedEnum = (Enum)lstSpecies.SelectedItem;

            switch (selectedEnum)
            {
                case MammalSpecies.Cat:
                    InitializeCutenessComboBoxData();
                    Cat cat;
                    grpSpecies.Header = "Cat Specification";
                    lblSpecies1.Content = "Breed: ";
                    lblComboSpecies.Content = "Cuteness: ";

                    lblSpecies1.Visibility = Visibility.Visible;
                    txtSpecies1.Visibility = Visibility.Visible;
                    cmbSpecies.Visibility = Visibility.Visible;
                    lblComboSpecies.Visibility = Visibility.Visible;

                    break;
                case MammalSpecies.Dog:
                    Dog dog;
                    grpSpecies.Header = "Dog Specification";
                    lblSpecies1.Content = nameof(dog.Breed);
                    lblSpecies1.Visibility = Visibility.Visible;
                    txtSpecies1.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void SelectedBirdSpecie()
        {
            // THIS METHODS ONLY SETS UP THE GUI. THIS SET UP IS MADE ONLY FOR BIRDS switch is used for further implementations
            Enum selectedEnum = (Enum)lstSpecies.SelectedItem;

            switch (selectedEnum)
            {
                case BirdSpecies.Eagle:
                    Eagle eagle;
                    grpSpecies.Header = "Eagle Specification";
                    lblSpecies1.Content = "Flight Speed: ";
                    lblSpecies2.Content = "Color: ";

                    lblSpecies1.Visibility = Visibility.Visible;
                    txtSpecies1.Visibility = Visibility.Visible;
                    lblSpecies2.Visibility = Visibility.Visible;
                    txtSpecies2.Visibility = Visibility.Visible;
                    break;
                case BirdSpecies.Ostrich:
                    InitializeYesNoComboBoxData();
                    grpSpecies.Header = "Ostrich Specification";
                    lblSpecies1.Content = "Neck Length(Cm): ";
                    lblComboSpecies.Content = "Buries head ";
                    lblSpecies3.Content = "in sand?";

                    lblSpecies1.Visibility = Visibility.Visible;
                    txtSpecies1.Visibility = Visibility.Visible;
                    lblComboSpecies.Visibility = Visibility.Visible;
                    cmbSpecies.Visibility = Visibility.Visible;
                    lblSpecies3.Visibility = Visibility.Visible;

                    break;
            }
        }

        private void SelectedMarineSpecie()
        {
            // THIS METHODS ONLY SETS UP THE MARINES GUI switch is used for further implementations
            Enum selectedEnum = (Enum)lstSpecies.SelectedItem;

            switch (selectedEnum)
            {
                case MarineSpecies.Seal:
                    InitializeYesNoComboBoxData();
                    Seal seal;
                    grpSpecies.Header = "Seal Specification";
                    lblSpecies2.Content = "Can do tricks?";

                    cmbSpecies.Visibility = Visibility.Visible;
                    lblSpecies2.Visibility = Visibility.Visible;
                    break;
                case MarineSpecies.Dolphin:
                    InitializeAnimalEnvironmentComboBoxData();
                    grpSpecies.Header = "Dolphin Specification";
                    lblSpecies2.Content = "Environment: ";

                    cmbSpecies.Visibility = Visibility.Visible;
                    lblSpecies2.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void SelectedInsectSpecie()
        {
            // THIS METHODS ONLY SETS UP THE INSECTS SPECIE GUI switch is used for further implementations
            Enum selectedEnum = (Enum)lstSpecies.SelectedItem;

            switch (selectedEnum)
            {
                case InsectSpecies.Spider:
                    InitializeYesNoComboBoxData();

                    grpSpecies.Header = "Spider Specification";
                    lblSpecies2.Content = "Is Venomous: ";

                    cmbSpecies.Visibility = Visibility.Visible;
                    lblSpecies2.Visibility = Visibility.Visible;
                    break;
                case InsectSpecies.LadyBug:
                    grpSpecies.Header = "LadyBug Specification";
                    lblSpecies1.Content = "Dots Number: ";

                    lblSpecies1.Visibility = Visibility.Visible;
                    txtSpecies1.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void BtnAddAnimal_Click(object sender, RoutedEventArgs e)
        {
            Animal animal = ReadInputs(); // this ReadInputs() method has checker inside, if inputs are wrong the value returned is null


            if (animal != null && CheckIfFoodItemSelected())
            {
                if (animalImageMainWindow.Source != null) // if image is initialized save the image into animal.AnimalPicture
                    animal.AnimalPicture = animalImageMainWindow.Source.ToString();


                if (lstFoodItems.SelectedIndex > -1) // If user selected FoodItem then it will be saved in Animal
                    animal.FoodItem = (FoodItem)lstFoodItems.SelectedItem;

                animal.Id = animalsManager.IdGenerator(); // Generating unique id for animal

                animalsManager.addToAnimalsList(animal); 

                if(animal.Id > 0 && animal.FoodItem != null) // adding item to dictionary
                    animalsManager.AnimalFoodItemDictionary.Add(animal.Id,animal.FoodItem);

                animalImageMainWindow.Source = null; // erasing the picture from picturebox

                UpdateListOfAnimals();
            }
        }

        private bool CheckIfFoodItemSelected()
        {
            bool proceed = false;

            if (lstFoodItems.SelectedIndex > -1)
            {
                proceed = true;
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("The food item was not selected.\nAre you sure you want to proceed?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    proceed = true;
                }
                else
                {
                    proceed = false;
                }
            }
            return proceed;
        }

        private Animal ReadInputs()
        {
            Animal animal = null;

            var selectedSpecie = lstSpecies.SelectedItem;

            if (MammalSpecies.Dog.Equals(selectedSpecie))
            {
                // Mammal specifications
                int numOfTeeth = 0; // this is label: txtSpecs1.Text
                int tailLength = 0; // this is label: txtSpecs2.Text

                //Specie specification
                string breed = txtSpecies1.Text; // this label represents breed, all those labels are assigned by SelectedMammalSpecie() method at the runtime.

                // VALIDATION FOR ABOVE VARIABLES
                if ((int.TryParse(txtSpecs1.Text, out numOfTeeth)) &&
                    (int.TryParse(txtSpecs2.Text, out tailLength)))
                {
                    animal = new Dog(numOfTeeth, tailLength, breed);
                    ReadCommonValues(ref animal);
                }
                else
                {
                    MessageBox.Show("Number of teeth or Tail Length is invalid");
                }
            }

            if (MammalSpecies.Cat.Equals(selectedSpecie))
            {
                // Mammal specifications
                int numOfTeeth = 0; // this is label: txtSpecs1.Text
                int tailLength = 0; // this is label: txtSpecs2.Text

                // Specie specifications
                int cuteness = (int)cmbSpecies.SelectedValue; // cuteness from combobox
                string breed = txtSpecies1.Text; // this label represents breed, all those labels are assigned by SelectedMammalSpecie() method at the runtime.

                // VALIDATION FOR ABOVE VARIABLES
                if ((int.TryParse(txtSpecs1.Text, out numOfTeeth)) &&
                    (int.TryParse(txtSpecs2.Text, out tailLength)))
                {
                    animal = new Cat(numOfTeeth, tailLength, breed, cuteness);
                    ReadCommonValues(ref animal);
                }
                else
                {
                    MessageBox.Show("Number of teeth or Tail Length is invalid");
                }
            }

            if (BirdSpecies.Eagle.Equals(selectedSpecie))
            {
                // Bird specification
                int wingsSpread = 0; // specs1
                double beakLength = 0; // specs2

                // specie variables
                string color = txtSpecies2.Text;
                int flightSpeed = 0; // this is label: txtSpecies1.Text (species1)

                // VALIDATION FOR ABOVE VARIABLES
                if (!int.TryParse(txtSpecies1.Text, out flightSpeed))
                {
                    MessageBox.Show("Error: Flight speed must be a valid integer.");
                }
                else if (!int.TryParse(txtSpecs1.Text, out wingsSpread))
                {
                    MessageBox.Show("Error: Wings spread must be a valid integer.");
                }
                else if (!double.TryParse(txtSpecs2.Text, out beakLength))
                {
                    MessageBox.Show("Error: Beak length must be a valid double.");
                }
                else
                {
                    animal = new Eagle(flightSpeed, color, wingsSpread, beakLength);
                    ReadCommonValues(ref animal);
                }
            }

            if (BirdSpecies.Ostrich.Equals(selectedSpecie))
            {
                // Bird specification
                int wingsSpread = 0; // specs1
                double beakLength = 0; // specs2

                // specie variables
                int neckLength = 0;
                string buryHead = cmbSpecies.SelectedItem.ToString();

                // VALIDATION FOR ABOVE VARIABLES
                if (!int.TryParse(txtSpecies1.Text, out neckLength))
                {
                    MessageBox.Show("Error: Neck Length must be a valid integer.");
                }
                else if (!int.TryParse(txtSpecs1.Text, out wingsSpread))
                {
                    MessageBox.Show("Error: Wings spread must be a valid integer.");
                }
                else if (!double.TryParse(txtSpecs2.Text, out beakLength))
                {
                    MessageBox.Show("Error: Beak length must be a valid double.");
                }
                else
                {
                    animal = new Ostrich(neckLength, buryHead, wingsSpread, beakLength);
                    ReadCommonValues(ref animal);
                }
            }

            if (MarineSpecies.Seal.Equals(selectedSpecie))
            {
                // Marine specifications
                double weight = 0;
                string sound = txtSpecs2.Text;

                // Specie specifications
                string canTricks = cmbSpecies.SelectedItem.ToString();

                // VALIDATION FOR ABOVE VARIABLES
                if ((double.TryParse(txtSpecs1.Text, out weight)))
                {
                    animal = new Seal(weight, sound, canTricks);
                    ReadCommonValues(ref animal);
                }
                else
                {
                    MessageBox.Show("Weight is invalid");
                }
            }

            if (MarineSpecies.Dolphin.Equals(selectedSpecie))
            {
                // Marine specifications
                double weight = 0;
                string sound = txtSpecs2.Text;

                // Specie specifications
                string Environment = cmbSpecies.SelectedItem.ToString();

                // VALIDATION FOR ABOVE VARIABLES
                if ((double.TryParse(txtSpecs1.Text, out weight)))
                {
                    animal = new Dolphin(weight, sound, Environment);
                    ReadCommonValues(ref animal);
                }
                else
                {
                    MessageBox.Show("Weight is invalid");
                }
            }

            if (InsectSpecies.LadyBug.Equals(selectedSpecie))
            {
                // Insect specifications
                int numberOfLegs = 0;

                //Specie specification
                int numberOfDots = 0;

                // VALIDATION FOR ABOVE VARIABLES
                if (!int.TryParse(txtSpecies1.Text, out numberOfDots))
                {
                    MessageBox.Show("Error: Dots number must be a valid integer.");
                }
                else if (!int.TryParse(txtSpecs1.Text, out numberOfLegs))
                {
                    MessageBox.Show("Error: Legs number must be a valid integer.");
                }
                else
                {
                    animal = new LadyBug(numberOfDots, numberOfLegs);
                    ReadCommonValues(ref animal);
                }
            }

            if (InsectSpecies.Spider.Equals(selectedSpecie))
            {
                // Insect specifications
                int numberOfLegs = 0;

                //Specie specification
                string venomous = cmbSpecies.SelectedItem.ToString();

                // VALIDATION FOR ABOVE VARIABLES
                if (!int.TryParse(txtSpecs1.Text, out numberOfLegs))
                {
                    MessageBox.Show("Error: Legs number must be a valid integer.");
                }
                else
                {
                    animal = new Spider(venomous, numberOfLegs);
                    ReadCommonValues(ref animal);
                }
            }
            return animal;
        }

        private Animal ReadCommonValues(ref Animal animal)
        {
            double age = 0;
            if (!double.TryParse(txtAge.Text, out age))
            {
                MessageBox.Show("Age is not valid");
                animal = null;
                return animal;
            }

            if (!string.IsNullOrEmpty(txtName.Text))
            {
                animal.Name = txtName.Text;
            }
            else
            {
                MessageBox.Show("The Name is empty or not valid");
                animal = null;
                return animal;
            }

            animal.Gender = (GenderTypes)cmbGender.SelectedItem;
            animal.Age = age;

            if (checkAllAnimals.IsChecked == true)
            { // This function reads category depending on to which specie animal belongs to. (check method declaration)
                animal.Category = (CategoryType)ReadCategoryFromSpecie(lstSpecies.SelectedItem);
            }
            else
            {
                animal.Category = (CategoryType)lstCategory.SelectedItem;
            }

            return animal;
        }

        private void UpdateListOfAnimals()
        {
            // THIS METHOD UPDATES THE LISTVIEW OF ALL ANIMALS
            lstAllAnimals.ItemsSource = null;
            lstAllAnimals.Items.Clear();

            List<Animal> animals = GetListOfAnimalsFromManager(); // method which fills up the list with for loop and GetAnimalAt(i) method 

            lstAllAnimals.ItemsSource = animals;
        }

        private void UpdateListOfAnimalsSortByName()
        {
            lstAllAnimals.ItemsSource = null;
            lstAllAnimals.Items.Clear();

            animalsManager.SortListByComparer(new NameComparer()); // sorting the list in animals manager

            List<Animal> animals = GetListOfAnimalsFromManager(); // method which fills up the list with for loop and GetAnimalAt(i) method 

            lstAllAnimals.ItemsSource = animals;
            
        }

        private void UpdateListOfAnimalsSortBySpecie()
        {
            lstAllAnimals.ItemsSource = null;
            lstAllAnimals.Items.Clear();

            animalsManager.SortListByComparer(new SpecieComparer()); // sorting the list in animals manager

            List<Animal> animals = GetListOfAnimalsFromManager(); // method which fills up the list with for loop and GetAnimalAt(i) method 

            lstAllAnimals.ItemsSource = animals;
        }

        private List<Animal> GetListOfAnimalsFromManager() // NOT RETURNING LIST GETTING ANIMALS BY .GetAnimalAt(i)
        {
            List<Animal> animals = new List<Animal>();

            for (int i = 0; i < animalsManager.AnimalsListCount; i++)
            {
                Animal animal = animalsManager.GetAnimalAt(i);
                if (animal != null)
                {
                    animals.Add(animal);
                }
            }
            return animals;
        }

        private void lstAllAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstAnimalDetails.Items.Clear();
            Animal index = (Animal)lstAllAnimals.SelectedItem;

            // if index is null immediately end the whole method.
            if (index == null) return;

            Animal selectedAnimal = index;

            if (selectedAnimal != null)
            {
                var eaterType = selectedAnimal.GetFoodSchedule().EaterType;
                lblEaterType.Content = eaterType; // setting up eater type

                UpdateFoodScheduleList(selectedAnimal);
            }

            lstAnimalDetails.Items.Add(selectedAnimal.ToString());
        }


        private void UpdateFoodScheduleList(Animal selectedAnimal)
        {
            lstFoodSchedule.Items.Clear();
            FoodItem fItem = animalsManager.GetValueFromFoodItemsDictionary(selectedAnimal.Id);

            lstFoodSchedule.Items.Add(fItem);
        }

        private void checkAllAnimals_Checked(object sender, RoutedEventArgs e)
        {
            lstCategory.IsEnabled = false;
            lstCategory.SelectedIndex = -1; // Unselecting the lstCategory 
            lstSpecies.ItemsSource = null;
            lstSpecies.Items.Clear();

            var birds = Enum.GetValues(typeof(BirdSpecies));
            var insects = Enum.GetValues(typeof(InsectSpecies));
            var mammals = Enum.GetValues(typeof(MammalSpecies));
            var marines = Enum.GetValues(typeof(MarineSpecies));

            var combined = birds.Cast<object>().Concat(insects.Cast<object>()).Concat(mammals.Cast<object>()).Concat(marines.Cast<object>()).ToArray();

            lstSpecies.ItemsSource = combined;
        }

        private void checkAllAnimals_UnChecked(object sender, RoutedEventArgs e)
        {
            lstCategory.IsEnabled = true;
            lstCategory.SelectedItem = CategoryType.Mammal;
        }

        private object ReadCategoryFromSpecie(object specie)
        {
            Array birds = Enum.GetValues(typeof(BirdSpecies));
            Array insects = Enum.GetValues(typeof(InsectSpecies));
            Array mammals = Enum.GetValues(typeof(MammalSpecies));
            Array marines = Enum.GetValues(typeof(MarineSpecies));

            if (birds.Cast<object>().Contains(specie))
            {
                return CategoryType.Bird;
            }

            else if (insects.Cast<object>().Contains(specie))
            {
                return CategoryType.Insect;
            }

            else if (mammals.Cast<object>().Contains(specie))
            {
                return CategoryType.Mammal;
            }

            else if (marines.Cast<object>().Contains(specie))
            {
                return CategoryType.Marine;
            }
            else
            {
                MessageBox.Show("This animal specie does not belong to any category");
                return null;
            }
        }

        private void btnLoadImage_Click(object sender, RoutedEventArgs e)
        { // LOADING IMAGE TO THE IMAGE BOX 
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            string filePath = String.Empty;

            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;
                animalImageMainWindow.Source = InitializePicture(filePath);
            }
        }

        private BitmapImage InitializePicture(string filePath)
        { // METHOD FOR INITIALIZING THE PICTURE WITH EXCEPTION HANDLER
            BitmapImage image = new BitmapImage();
            try
            {
                image.BeginInit();
                image.UriSource = new Uri($"{filePath}");
                image.EndInit();
            }
            catch (Exception ex)
            {
                animalImageMainWindow.Source = null;
                MessageBox.Show("Error: " + ex);
            }

            return image;
        }

        private void btnSortName_Click(object sender, RoutedEventArgs e)
        {
            UpdateListOfAnimalsSortByName();
        }

        private void btnSortSpecie_Click(object sender, RoutedEventArgs e)
        {
            UpdateListOfAnimalsSortBySpecie();
        }

        private void btnFoodItems_Click(object sender, RoutedEventArgs e)
        {
            FoodItems foodItemsWindow = new FoodItems();

            var foodItems = foodItemsWindow.ShowDialog();

            if (foodItemsWindow.DialogResult == true)
            {
                FoodItem foodItem = foodItemsWindow.FoodItem; 
                foodManager.Add(foodItem); // adding foodItem from window to manager

                UpdateFoodItemsList();
            }
        }

        private void UpdateFoodItemsList()
        {
            lstFoodItems.Items.Clear();

            for (int i = 0; i < foodManager.Count; i++)
            {
                //The default behavior of the ListBox control is to call the ToString() method on each object in the Items collection and display the resulting string in the list.
                lstFoodItems.Items.Add(foodManager.GetAt(i)); // tostring method is not needed!
            }

        }
    }
}