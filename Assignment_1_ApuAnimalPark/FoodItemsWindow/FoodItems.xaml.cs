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
using System.Windows.Shapes;
using Assignment_2_ApuAnimalPark.Objects.Food;
using Assignment_2_ApuAnimalPark.Objects.ListManager;

namespace Assignment_2_ApuAnimalPark.FoodItemsWindow
{
    /// <summary>
    /// Interaction logic for FoodItems.xaml
    /// </summary>
    public partial class FoodItems : Window
    {
        public FoodItem FoodItem { get; }
        public FoodItems()
        {
            FoodItem = new FoodItem();
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen; // startup at center
            this.Title = "Add Food Item";
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFoodName.Text))
            {
                FoodItem.Name = txtFoodName.Text;
                DialogResult = true;
                MessageBox.Show("Item added sucessfully!");
            }
            else
            {
                MessageBox.Show("The Name cant be empty!");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool ingredientOk = FoodItem.Add(txtIngredientName.Text);
            if (ingredientOk == false)
            {
                MessageBox.Show("Invalid Ingredient");
            }
            UpdateList();
        }

        private void UpdateList()
        {
            lstIngredients.Items.Clear();


            for (int i = 0; i < FoodItem.Ingredients.Count; i++)
            {
                if(!String.IsNullOrEmpty(FoodItem.GetAt(i)))
                    lstIngredients.Items.Add(FoodItem.GetAt(i));
            }
        }


        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            int index = lstIngredients.SelectedIndex;

            if (FoodItem.GetAt(index) != null)
            {
                if (!string.IsNullOrEmpty(txtIngredientName.Text))
                {
                    FoodItem.ChangeAt(txtIngredientName.Text,index);
                    UpdateList();
                }
                else
                {
                    MessageBox.Show("Ingredient name is not valid");
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = lstIngredients.SelectedIndex;

            if (FoodItem.GetAt(index) != null )
            {
                FoodItem.DeleteAt(index);
                UpdateList();
            }
        }
    }
}
