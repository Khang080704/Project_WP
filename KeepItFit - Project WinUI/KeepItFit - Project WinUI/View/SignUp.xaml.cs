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
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;



namespace KeepItFit___Project_WinUI.View
{
    public sealed partial class SignUp : Page
    {
        SignUpViewModel viewModel { get; set; }

        public SignUp()
        {
            this.InitializeComponent();
            viewModel = new SignUpViewModel();
        }

        private async void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateSignUpData())
            {
                try
                {
                    viewModel.SaveDataSignUp();
                }
                catch(Exception ex)
                {
                    // Show the error message
                    ContentDialog errorDialog = new ContentDialog
                    {
                        Title = "Error",
                        Content = ex.Message,
                        CloseButtonText = "Ok",
                        XamlRoot = this.Content.XamlRoot
                    };

                    await errorDialog.ShowAsync();
                    return;
                }

                // Show the congratulation dialog
                ContentDialog congratulationDialog = new ContentDialog
                {
                    Title = "Congratulations",
                    Content = "You have successfully signed up!",
                    CloseButtonText = "Ok",
                    XamlRoot = this.Content.XamlRoot
                };

                await congratulationDialog.ShowAsync();

                // After the user presses "Ok", navigate to the SignIn page
                Window signIn = new SignIn();
                signIn.Activate();
                // Close the current window
                App.signIn?.Close();
            }
        }

        private bool ValidateSignUpData()
        {
            if (string.IsNullOrWhiteSpace(viewModel.FirstName))
            {
                ShowErrorMessage("First name is required.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(viewModel.LastName))
            {
                ShowErrorMessage("Last name is required.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(viewModel.Email))
            {
                ShowErrorMessage("Email is required.");
                return false;
            }
            if (!IsValidEmail(viewModel.Email))
            {
                ShowErrorMessage("Email is not valid or does not belong to the correct domain.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(viewModel.Password))
            {
                ShowErrorMessage("Password is required.");
                return false;
            }
            if (!viewModel.DateOfBirth.HasValue)
            {
                ShowErrorMessage("Date of birth is required.");
                return false;
            }
            return true;
        }

        private bool IsValidEmail(string email)
        {
            // Define a regex pattern for a valid email with a specific domain (e.g., example.com)
            string pattern = @"^[^@\s]{3,}@[a-zA-Z0-9.-]{3,}\.com$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        private async void ShowErrorMessage(string message)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Error",
                Content = message,
                CloseButtonText = "Ok",
                XamlRoot = this.Content.XamlRoot
            };
            await dialog.ShowAsync();
        }


    }
}
