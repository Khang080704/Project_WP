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
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;


namespace KeepItFit___Project_WinUI.View
{

    public sealed partial class ChangePasswordPage : Page
    {
        ChangePasswordPageViewModel viewModel;

        public ChangePasswordPage()
        {
            this.InitializeComponent();
            viewModel = new ChangePasswordPageViewModel();
        }

        private async void OnChangePasswordClick(object sender, RoutedEventArgs e)
        {
            try
            {
                viewModel.ChangePassword();
                ContentDialog successDialog = new ContentDialog
                {
                    Title = "Success",
                    Content = "Password changed successfully.",
                    CloseButtonText = "Ok",
                    XamlRoot = this.Content.XamlRoot
                };
                await successDialog.ShowAsync();
            }
            catch (Exception ex)
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
            }
        }
    }
}
