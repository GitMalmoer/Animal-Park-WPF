using System;
using System.Collections.Generic;
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
using Assignment_1_ApuAnimalPark.Data;
using Assignment_1_ApuAnimalPark.Objects;
using Assignment_1_ApuAnimalPark.Objects.AnimalsGen;
using Assignment_1_ApuAnimalPark.Objects.Birds;
using Assignment_1_ApuAnimalPark.Objects.Mammals;
using Assignment_1_ApuAnimalPark.Objects.Marines;
using Microsoft.VisualBasic;

namespace Assignment_1_ApuAnimalPark
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AnimalsManager animalsManager = new AnimalsManager();

        public MainWindow()
        {
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            this.Title = "Apu Animal Park by Marcin Junka";
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

                    break;
                case CategoryType.Mammal:
                    SelectedMammal();
                    break;
                case CategoryType.Marine:
                    SelectedMarine();
                    break;
                case CategoryType.Reptile:

                    break;

            }
        }

        private void SelectedMammal()
        {
            Mammal mammal;
            grpSpecifications.Header = "Specification Mammal";
            lblSpecs1.Content = nameof(mammal.Number_Of_Teeth).Replace("_", " ");
            lblSpecs2.Content = nameof(mammal.Tail_Length).Replace("_", " ") + " (Cm)";

            lblSpecs1.Visibility = Visibility.Visible;
            lblSpecs2.Visibility = Visibility.Visible;
            txtSpecs1.Visibility = Visibility.Visible;
            txtSpecs2.Visibility = Visibility.Visible;

            lstSpecies.ItemsSource = Enum.GetValues(typeof(MammalSpecies));
        }

        private void SelectedBird()
        {
            Bird bird;
            grpSpecifications.Header = "Specification Bird";
            lblSpecs1.Content = nameof(bird.Wings_Spread).Replace("_", " ") + " (Cm)";
            lblSpecs2.Content = nameof(bird.Beak_Length).Replace("_", " ") +" (Cm)";

            lblSpecs1.Visibility = Visibility.Visible;
            lblSpecs2.Visibility = Visibility.Visible;
            txtSpecs1.Visibility = Visibility.Visible;
            txtSpecs2.Visibility = Visibility.Visible;


            lstSpecies.ItemsSource = Enum.GetValues(typeof(BirdSpecies));
        }

        private void SelectedMarine()
        {
            Marine marine;
            grpSpecifications.Header = "Specification Marine";

            lblSpecs1.Content = nameof(marine.Weight) + " (Kg)";
            lblSpecs2.Content = nameof(marine.Sound);

            lblSpecs1.Visibility = Visibility.Visible;
            lblSpecs2.Visibility = Visibility.Visible;
            txtSpecs1.Visibility = Visibility.Visible;
            txtSpecs2.Visibility = Visibility.Visible;

            lstSpecies.ItemsSource = Enum.GetValues(typeof(MarineSpecies));
        }

        private void lstSpecies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HideAllInputsSpecies();

            if (lstSpecies.SelectedIndex >= 0)
            {
                Enum selectedEnum = (Enum)lstSpecies.SelectedItem;

                //string selectedSpecie = selectedEnum.GetType().Name; this method was used because upper one didnt work and now it works?!

                switch (selectedEnum)
                {
                    case MammalSpecies:
                        SelectedMammalSpecie();
                        break;
                    case BirdSpecies:
                        SelectedBirdSpecie();
                        break;
                    case MarineSpecies:
                        SelectedMarineSpecie();
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
                    lblSpecies1.Content = nameof(cat.Breed);
                    lblComboSpecies.Content = nameof(cat.Cuteness);

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
                    lblSpecies1.Content = nameof(eagle.Flight_Speed).Replace("_", " ");
                    lblSpecies2.Content = nameof(eagle.Color);

                    lblSpecies1.Visibility = Visibility.Visible;
                    txtSpecies1.Visibility = Visibility.Visible;
                    lblSpecies2.Visibility = Visibility.Visible;
                    txtSpecies2.Visibility = Visibility.Visible;
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
                    lblSpecies2.Content = nameof(seal.Can_do_tricks).Replace("_", " ");

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

        private void BtnAddAnimal_Click(object sender, RoutedEventArgs e)
        {
            Animal animal = ReadInputs(); // this has checker inside, if inputs are wrong the value returned is null

            if (animal != null)
            {
                animal.Id = animalsManager.IdGenerator();
                animalsManager._animals.Add(animal);
                UpdateListOfAnimals();
            }
        }

        private Animal ReadInputs()
        {
            Animal animal = null;

            string selectedSpecie = lstSpecies.SelectedItem.ToString();

            switch (lstCategory.SelectedItem)
            {
                case CategoryType.Mammal:
                    if (selectedSpecie == MammalSpecies.Dog.ToString())
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

                    if (selectedSpecie == MammalSpecies.Cat.ToString())
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

                    break;

                case CategoryType.Bird:
                    if (selectedSpecie == BirdSpecies.Eagle.ToString())
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

                    break;
                case CategoryType.Marine:
                    if (selectedSpecie == MarineSpecies.Seal.ToString())
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

                    if (selectedSpecie == MarineSpecies.Dolphin.ToString())
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
                    break;


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
            animal.Category = (CategoryType)lstCategory.SelectedItem;

            return animal;
        }

        private void UpdateListOfAnimals()
        {
            // THIS METHOD UPDATES THE LISTBOX OF ALL ANIMALS
            lstAllAnimals.Items.Clear();
            foreach (var animal in animalsManager._animals)
            {
                lstAllAnimals.Items.Add(string.Format($"{animal.Name,-35} {animal.Age,-30} {animal.Gender,-35}"));
            }
        }

        private void lstAllAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lstAllAnimals.SelectedIndex;

            // if index is not selected immediately end the whole method.
            if (index <= -1) return;

            var selectedAnimal = animalsManager._animals[index];

            // this kind of switch works like [if(selectedAnimal is Dog)] but its faster and less code to write.
            //In general, the switch statement is often more readable and maintainable than multiple if statements.
            switch (selectedAnimal)
            {
                case Dog dog:
                    MessageBox.Show(dog.ToString());
                    break;
                case Cat cat:
                    MessageBox.Show(cat.ToString());
                    break;
                case Eagle eagle:
                    MessageBox.Show(eagle.ToString());
                    break;
                case Seal seal:
                    MessageBox.Show(seal.ToString());
                    break;
                case Dolphin dolphin:
                    MessageBox.Show(dolphin.ToString());
                    break;
            }
        }
    }
}