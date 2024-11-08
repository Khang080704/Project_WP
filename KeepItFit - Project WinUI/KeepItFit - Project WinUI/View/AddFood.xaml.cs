using KeepItFit___Project_WinUI.Model;
using KeepItFit___Project_WinUI.ViewModel;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Hosting;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace KeepItFit___Project_WinUI.View
{
    public sealed partial class AddFood : Page
    {
        public AddFoodViewModel viewModel { get; set; }

        private Button _lastClickedButton;

        private string mealName; //Breakfast, Lunch, Dinner, Snacks

        private List<Food> foodListRecent_Checked = new List<Food>();
        private List<Food> foodListFrequent_Checked = new List<Food>();
        private List<Food> foodListMyFood_Checked = new List<Food>();

        public AddFood()
        {
            this.InitializeComponent();
            viewModel = new AddFoodViewModel();
            viewModel.init();

            SetDefaultButtonChoose_Recent();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            //Get the parameter passed from the previous page
            if (e.Parameter is string mealName && !string.IsNullOrEmpty(mealName))
            {
                this.mealName = mealName;
                meal.Text = $"Add Food To {this.mealName}";
            }

            viewModel.LoadRecentFood(); // Load the newest recent food items
            viewModel.LoadFrequentFood(); // Load the newest frequent food items
        }

        //Set the default button to "Recent" when the page is loaded
        private void SetDefaultButtonChoose_Recent()
        {
            _lastClickedButton = RecentButton;

            RecentButton.Background = new SolidColorBrush(Microsoft.UI.Colors.LightBlue);
            RecentButton.Foreground = new SolidColorBrush(ColorHelper.FromArgb(255, 0, 0, 0));

            if (viewModel.foodRecent == null)
            {   //List Recent is empty
                firstRunFoodRecent.Text = $"You have not added any {mealName} foods yet.";
                showNoneAnouncementFoodRecent.Visibility = Visibility.Visible;
            }
            else
            {
                foodRecentListView.Visibility = Visibility.Visible;
            }
        }

        //Button choose betwwen "Recent", "Frequent", "My Food" Items
        private void ButtonRecentFrenquencyMyFood_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button clickedButton)
            {
                if (_lastClickedButton != null)
                {
                    //Reset the background of the last clicked button
                    _lastClickedButton.Background = new SolidColorBrush(ColorHelper.FromArgb(255, 8, 79, 150));
                    _lastClickedButton.Foreground = new SolidColorBrush(ColorHelper.FromArgb(255, 255, 255, 255)); // White
                }

                //Set the background of the clicked button
                clickedButton.Background = new SolidColorBrush(Microsoft.UI.Colors.LightBlue);
                clickedButton.Foreground = new SolidColorBrush(ColorHelper.FromArgb(255, 0, 0, 0)); // Black

                _lastClickedButton = clickedButton;

                //Reset the visibility of the listviews
                foodRecentListView.Visibility = Visibility.Collapsed;
                foodFrequentListView.Visibility = Visibility.Collapsed;
                foodMyFoodListView.Visibility = Visibility.Collapsed;

                //Reset the visibility of the announcement texts
                showNoneAnouncementFoodRecent.Visibility = Visibility.Collapsed;
                showNoneAnouncementFoodFrequent.Visibility = Visibility.Collapsed;
                showNoneAnouncementFoodFMyFood.Visibility = Visibility.Collapsed;

                //Get the tag of the clicked button
                string tag = clickedButton.Tag.ToString();
                
                switch (tag)
                {
                    case "Recent":
                        if(viewModel.foodRecent == null)
                        {   //List Recent is empty
                            firstRunFoodRecent.Text = $"You have not added any {mealName} foods yet.";                            
                            showNoneAnouncementFoodRecent.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            foodRecentListView.Visibility = Visibility.Visible;
                        }
                        break;
                    case "Frequency":
                        if (viewModel.foodFrequent == null)
                        {   //List Frequent is empty
                            firstRunFoodFrequent.Text = $"You have not added any {mealName} foods yet.";
                            showNoneAnouncementFoodFrequent.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            foodFrequentListView.Visibility = Visibility.Visible;
                        }
                        break;
                    case "MyFood":
                        if (viewModel.foodMyFood == null)
                        {   //List MyFood is empty
                            showNoneAnouncementFoodFMyFood.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            foodMyFoodListView.Visibility = Visibility.Visible;
                        }
                        break;
                }
            }
        }

        //CheckBox for each food item in a list
        private void FoodCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            Food foodItem = checkBox.DataContext as Food;

            if (viewModel.foodRecent.Contains(foodItem))
            {
                foodListRecent_Checked.Add(foodItem);
            }
            else if (viewModel.foodFrequent.Contains(foodItem))
            {
                foodListFrequent_Checked.Add(foodItem);
            }
            else if (viewModel.foodMyFood.Contains(foodItem))
            {
                foodListMyFood_Checked.Add(foodItem);
            }
        }

        //Uncheck the CheckBox for each food item in a list
        private void FoodCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            Food foodItem = checkBox.DataContext as Food;

            if (viewModel.foodRecent.Contains(foodItem))
            {
                foodListRecent_Checked.Remove(foodItem);
            }
            else if (viewModel.foodFrequent.Contains(foodItem))
            {
                foodListFrequent_Checked.Remove(foodItem);
            }
            else if (viewModel.foodMyFood.Contains(foodItem))
            {
                foodListMyFood_Checked.Remove(foodItem);
            }

        }

        public class NavigationParameters_AddFood_ToFoodDiary
        {
            public List<Food> foodList { get; set; }
            public string mealName { get; set; }

        }

        //Add the food you choose to the list of foods in a meal (navigate to FoodDiary)
        private void AddChecked_Click(object sender, RoutedEventArgs e)
        {
            // parameters to pass to the next page
            var parameters = new NavigationParameters_AddFood_ToFoodDiary
            {
                foodList = new List<Food>(),
                mealName = mealName
            };
            if (_lastClickedButton == RecentButton)
            {
                if (foodListRecent_Checked.Count == 0)
                {
                    return;
                }
                parameters.foodList = foodListRecent_Checked;
                this.Frame.Navigate(typeof(FoodDiary), parameters);
            }
            else if (_lastClickedButton == FrequentButton)
            {
                if (foodListFrequent_Checked.Count == 0)
                {
                    return;
                }
                parameters.foodList = foodListFrequent_Checked;
                this.Frame.Navigate(typeof(FoodDiary), parameters);
            }
            else if (_lastClickedButton == MyFoodButton)
            {
                if (foodListMyFood_Checked.Count == 0)
                {
                    return;
                }
                parameters.foodList = foodListMyFood_Checked;
                this.Frame.Navigate(typeof(FoodDiary), parameters);
            }
        }

        //Move to the page to add calories to the food (navigate to FoodPage)
        private void HyperlinkToAddCaloriesPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FoodPage), mealName);
        }

        //Delete the food items you choose
        private void DeleteItems_Click(object sender, RoutedEventArgs e)
        {
            if (_lastClickedButton == RecentButton)
            {
                RemoveFoodItems(foodListRecent_Checked, viewModel.foodRecent);
            }
            else if (_lastClickedButton == FrequentButton)
            {
                RemoveFoodItems(foodListFrequent_Checked, viewModel.foodFrequent);
            }
            else if (_lastClickedButton == MyFoodButton)
            {
                RemoveFoodItems(foodListMyFood_Checked, viewModel.foodMyFood);
            }
        }

        private void RemoveFoodItems(List<Food> foodListChecked, ObservableCollection<Food> foodCollection)
        {
            foreach (Food food in foodListChecked)
            {
                foodCollection.Remove(food);
                viewModel.DeleteFrequentOrRecentFood(food);
            }
            foodListChecked.Clear();
            viewModel.LoadFrequentFood(); // Update the list of frequent food items
            viewModel.LoadRecentFood(); // Update the list of recent food items
        }

        // Check if the input is a number (text changed)
        private void FoodQuantity_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && textBox.DataContext is Food food)
            {
                if (int.TryParse(textBox.Text, out int quantity) && quantity > 0)
                {
                    food.foodQuantityErrorVisibility = Visibility.Collapsed;
                }
                else
                {
                    food.foodQuantityErrorVisibility = Visibility.Visible;
                    textBox.Focus(FocusState.Programmatic);
                }
            }
        }

        private void FoodQuantity_TextChanged(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && textBox.DataContext is Food food)
            {
                if (int.TryParse(textBox.Text, out int quantity) && quantity > 0)
                {
                    food.foodQuantityErrorVisibility = Visibility.Collapsed;
                }
                else
                {
                    food.foodQuantityErrorVisibility = Visibility.Visible;
                    textBox.Focus(FocusState.Programmatic);
                }
            }
        }

        public class NavigationParameters_AddFood
        {
            public string Query { get; set; }
            public string MealName { get; set; }
        }

        // Search for food in the Database (navigate to SearchFood)
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string query = searchBox.Text.ToLower();
            var parameters = new NavigationParameters_AddFood
            {
                Query = query,
                MealName = mealName
            };
            this.Frame.Navigate(typeof(SearchFood), parameters);
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
