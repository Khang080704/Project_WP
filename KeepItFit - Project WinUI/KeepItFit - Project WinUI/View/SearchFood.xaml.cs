﻿using KeepItFit___Project_WinUI.ViewModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using static KeepItFit___Project_WinUI.View.AddFood;

namespace KeepItFit___Project_WinUI.View
{
    public sealed partial class SearchFood : Page
    {
        public SearchFoodViewModel viewModel { get; set; }

        private string mealName; //Breakfast, Lunch, Dinner, Snacks

        public SearchFood()
        {
            this.InitializeComponent();
            viewModel = new SearchFoodViewModel();
            viewModel.init();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            //Get the parameter passed from the previous page
            if (e.Parameter is NavigationParameters_AddFood parameters)
            {
                string query = parameters.Query;

                this.mealName = parameters.MealName;
                meal.Text = $"Add Food To {this.mealName}";

                // Filter the food is chosen
                var filteredList = viewModel.foodDatabase.Where(food => food.foodName.ToLower().Contains(query)).ToList();
                foreach (var food in filteredList)
                {
                    viewModel.foodSearchList.Add(food);
                }
            }
        }

        private void HyperlinkToAddCaloriesPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FoodPage), mealName);
        }

        // Search for food in the Database
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string query = searchBox.Text;
            viewModel.foodSearchList.Clear();

            if (query == null || query == "")
            {
                foodSearchListView.Visibility = Visibility.Collapsed;
                noResult.Visibility = Visibility.Visible;
                return;
            }
            
            var filteredList = viewModel.foodDatabase.Where(food => food.foodName.ToLower().Contains(query)).ToList();
            
            if (filteredList.Count == 0)
            {
                foodSearchListView.Visibility = Visibility.Collapsed;
                noResult.Visibility = Visibility.Visible;
                return;
            }

            noResult.Visibility = Visibility.Collapsed;
            foodSearchListView.Visibility = Visibility.Visible;

            foreach (var food in filteredList)
            {
                viewModel.foodSearchList.Add(food);

            }
        }

        //Show the table for user to choose all the nessessary information about the food
        private void FoodSearchListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (foodSearchListView.SelectedItem is Food selectedFood)
            {
                viewModel.SelectedFood = selectedFood;
                viewModel.IsFoodSelected = true; // Show details
            }
            else
            {
                viewModel.IsFoodSelected = false; // Hide
            }
        }

        public class NavigationParameters_SearchFood
        {
            public Food selectedFood { get; set; }
            public Meals selectedMeal { get; set; }
        }

        // Add the food to Page "FoodDiary" (navigate to the FoodDiary)
        private void AddToJournal_Click(object sender, RoutedEventArgs e)
        {
            // parameters to pass to the next page
            var parameters = new NavigationParameters_SearchFood
            {
                selectedFood = viewModel.SelectedFood, 
                selectedMeal = viewModel.SelectedMeal
            };

            this.Frame.Navigate(typeof(FoodDiary), parameters);
        }

        // Check if the input is a number (text changed)
        private void FoodQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // check if the input is a number
                if (!double.TryParse(textBox.Text, out _))
                {
                    // If not a number, show error message
                    foodQuantityError.Visibility = Visibility.Visible;
                    textBox.Focus(FocusState.Programmatic);
                }
                else
                {
                    // if it is a number, hide the error message
                    foodQuantityError.Visibility = Visibility.Collapsed;
                }
            }
        }

        //check if the input is a number (lost focus)
        private void FoodQuantity_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // check if the input is a number
                if (!double.TryParse(textBox.Text, out _))
                {
                    // If not a number, show error message
                    foodQuantityError.Visibility = Visibility.Visible;
                    textBox.Focus(FocusState.Programmatic);
                }
                else
                {
                    // if it is a number, hide the error message
                    foodQuantityError.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}