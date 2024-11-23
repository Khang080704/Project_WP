using KeepItFit___Project_WinUI.ViewModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Gaming.Input.ForceFeedback;

namespace KeepItFit___Project_WinUI.View
{
    public sealed partial class CreateMyFood : Page
    {
        public CreateMyFoodViewModel viewModel { get; set; }

        public CreateMyFood()
        {
            this.InitializeComponent();
            viewModel = new CreateMyFoodViewModel();
        }

        private async void Create_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;

            // Validate Food Name
            if (string.IsNullOrWhiteSpace(viewModel.foodName))
            {
                FoodNameError.Visibility = Visibility.Visible;
                isValid = false;
            }
            else
            {
                FoodNameError.Visibility = Visibility.Collapsed;
            }

            // Validate each nutrition input
            foreach (var nutrition in viewModel.nutritions)
            {
                if (!float.TryParse(nutrition.input, out float value) || value < 0)
                {
                    nutrition.ErrorVisibility = Visibility.Visible;
                    isValid = false;
                }
                else
                {
                    nutrition.ErrorVisibility = Visibility.Collapsed;
                }
            }

            if (isValid)
            {
                viewModel.AddMyFoodToDatabase();

                // Show success dialog
                ContentDialog successDialog = new ContentDialog
                {
                    Title = "Success",
                    Content = "Your food has been successfully created.",
                    CloseButtonText = "OK",
                    XamlRoot = this.Content.XamlRoot // Ensure the dialog is shown in the correct context
                };

                await successDialog.ShowAsync();
            }
        }
    }
}
