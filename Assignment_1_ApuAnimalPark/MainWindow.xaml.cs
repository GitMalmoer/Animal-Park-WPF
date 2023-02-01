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
using Assignment_1_ApuAnimalPark.Objects;
using Assignment_1_ApuAnimalPark.Objects.AnimalsGen;
using Assignment_1_ApuAnimalPark.Objects.Birds;
using Assignment_1_ApuAnimalPark.Objects.Mammals;
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
            lblSpecs2.Content = nameof(mammal.Tail_Length).Replace("_", " ");

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
            lblSpecs1.Content = nameof(bird.Wings_Spread).Replace("_", " ");
            lblSpecs2.Content = nameof(bird.Beak_Length).Replace("_", " ");

            lblSpecs1.Visibility = Visibility.Visible;
            lblSpecs2.Visibility = Visibility.Visible;
            txtSpecs1.Visibility = Visibility.Visible;
            txtSpecs2.Visibility = Visibility.Visible;


            lstSpecies.ItemsSource = Enum.GetValues(typeof(BirdSpecies));
        }

        private void lstSpecies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HideAllInputsSpecies();

            if (lstSpecies.SelectedIndex >= 0)
            {
                Enum selectedEnum = (Enum)lstSpecies.SelectedItem;

                string selectedSpecie = selectedEnum.GetType().Name;

                switch (selectedSpecie)
                {
                    case "MammalSpecies":
                        SelectedMammalSpecie();
                        break;
                    case "BirdSpecies":
                        SelectedBirdSpecie();
                        break;
                }
            }

        }

        private void SelectedMammalSpecie()
        {
            // THIS METHODS ONLY SETS UP THE GUI. THIS SET UP IS MADE ONLY FOR MAMMALS
            Enum selectedEnum = (Enum)lstSpecies.SelectedItem;

            switch (selectedEnum)
            {
                case MammalSpecies.Cat:
                    Cat cat;
                    grpSpecies.Header = "Cat Specification";
                    lblSpecies1.Content = nameof(cat.Breed);
                    lblSpecies1.Visibility = Visibility.Visible;
                    txtSpecies1.Visibility = Visibility.Visible;
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
            // THIS METHODS ONLY SETS UP THE GUI. THIS SET UP IS MADE ONLY FOR BIRDS
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

        private void BtnAddAnimal_Click(object sender, RoutedEventArgs e)
        {
            Animal animal = ReadInputs(); // this has checker inside, if inputs are wrong the value returned is null

            if (animal != null)
            {
                animalsManager._animals.Add(animal);
                UpdateListOfAnimals();
            }

            //MessageBox.Show(((Dog)animal).Breed);


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
                        int numOfTeeth = 0; // this is label: txtSpecs1.Text
                        int tailLength = 0; // this is label: txtSpecs2.Text
                        string breed = txtSpecies1.Text; // this label represents breed, all those labels are assigned by SelectedMammalSpecie() method at the runtime.

                        // VALIDATION FOR ABOVE VARIABLES
                        if ((int.TryParse(txtSpecs1.Text, out numOfTeeth)) && (int.TryParse(txtSpecs2.Text, out tailLength)))
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
                        int numOfTeeth = 0; // this is label: txtSpecs1.Text
                        int tailLength = 0; // this is label: txtSpecs2.Text
                        string breed = txtSpecies1.Text; // this label represents breed, all those labels are assigned by SelectedMammalSpecie() method at the runtime.

                        // VALIDATION FOR ABOVE VARIABLES
                        if ((int.TryParse(txtSpecs1.Text, out numOfTeeth)) && (int.TryParse(txtSpecs2.Text, out tailLength)))
                        {
                            animal = new Cat(numOfTeeth, tailLength, breed);
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
            }
        }
    }
}