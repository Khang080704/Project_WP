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

namespace KeepItFit___Project_WinUI.View
{
    public sealed partial class AddFood : Page
    {
        public class DashBoardViewModel
        {
            public List<Food> foodRecent { get; set; }
            public List<Food> foodFrequent { get; set; }
            public List<Food> foodMyFood { get; set; } //Update later -> don't understand what its function
            public List<Food> foodMeal { get; set; } //Update later -> don't understand what its function

            public void init()
            {
                IDao dao = new MockDAO();
                foodRecent = dao.GetFoodRecent();
                foodFrequent = dao.GetFoodFrequent();
            }

        }

        public DashBoardViewModel viewModel { get; set; }

        private Button _lastClickedButton;

        public AddFood()
        {
            this.InitializeComponent();
            viewModel = new DashBoardViewModel();
            viewModel.init();
        }

        private void HyperlinkToAddCaloriesPage_Click(object sender, RoutedEventArgs e)
        {
            //MainFrame.Navigate(new AddFoodPage());
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            //MainFrame.Navigate(new AddFoodPage());
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            //Get the parameter passed from the previous page
            if (e.Parameter is string mealName && !string.IsNullOrEmpty(mealName))
            {
                if (mealName == "BreakFast")
                {
                    meal.Text = "Add Food To Breakfast";
                }
                else if (mealName == "Lunch")
                {
                    meal.Text = "Add Food To Lunch";
                }
                else if (mealName == "Dinner")
                {
                    meal.Text = "Add Food To Dinner";
                }
                else if (mealName == "Snacks")
                {
                    meal.Text = "Add Food To Snacks";
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
                foodMealListView.Visibility = Visibility.Collapsed;

                //Get the tag of the clicked button
                string tag = clickedButton.Tag.ToString();
                

                switch (tag)
                {
                    case "Recent":
                        foodRecentListView.Visibility = Visibility.Visible;
                        break;
                    case "Frequency":
                        foodFrequentListView.Visibility = Visibility.Visible;
                        break;
                    case "MyFood":
                        foodMealListView.Visibility = Visibility.Visible;
                        break;
                    case "Meal":
                        foodMealListView.Visibility = Visibility.Visible;
                        break;
                }
            }
        }

        


    }
}
