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
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace KeepItFit___Project_WinUI.View
{
    public sealed partial class AddFood : Page
    {
        private Button _lastClickedButton;

        public AddFood()
        {
            this.InitializeComponent();
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

            if (e.Parameter is string mealName && !string.IsNullOrEmpty(mealName))
            {
                if (mealName == "_BreakFast")
                {
                    meal.Text = "Add Food To Breakfast";
                }
                else if (mealName == "_Lunch")
                {
                    meal.Text = "Add Food To Lunch";
                }
                else if (mealName == "_Dinner")
                {
                    meal.Text = "Add Food To Dinner";
                }
                else if (mealName == "_Snacks")
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
                    _lastClickedButton.Background = new SolidColorBrush(ColorHelper.FromArgb(255, 8, 79, 150));
                    _lastClickedButton.Foreground = new SolidColorBrush(ColorHelper.FromArgb(255, 255, 255, 255)); // White
                }

                clickedButton.Background = new SolidColorBrush(Microsoft.UI.Colors.LightBlue);
                clickedButton.Foreground = new SolidColorBrush(ColorHelper.FromArgb(255, 0, 0, 0)); // Black

                _lastClickedButton = clickedButton;

                string tag = clickedButton.Tag.ToString();

                switch (tag)
                {
                    case "Recent":
                        InfoTextBlock.Text = "Information about Recent";
                        break;
                    case "Frequency":
                        InfoTextBlock.Text = "Information about Frequency";
                        break;
                    case "MyFood":
                        InfoTextBlock.Text = "Information about My Food";
                        break;
                    case "Meal":
                        InfoTextBlock.Text = "Information about Meal";
                        break;
                }
            }
        }


    }
}
