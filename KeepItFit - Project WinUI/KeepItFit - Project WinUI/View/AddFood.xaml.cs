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
            
            if (checkBox != null)
            {
                Food foodItem = checkBox.DataContext as Food;

                if (foodItem != null)
                {
                    if (viewModel.foodRecent.Contains(foodItem))
                    {
                        //viewModel.foodRecent.Remove(foodItem); 
                    }
                    else if (viewModel.foodFrequent.Contains(foodItem))
                    {
                        //viewModel.foodFrequent.Remove(foodItem);
                    }
                    else if (viewModel.foodMyFood.Contains(foodItem))
                    {
                        //viewModel.foodMyFood.Remove(foodItem);
                    }
                }
            }
        }

        //Add the food you choose to the list of foods in a meal
        private void AddChecked_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HyperlinkToAddCaloriesPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FoodPage), mealName);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            //MainFrame.Navigate(new AddFoodPage());
        }
    }
}
