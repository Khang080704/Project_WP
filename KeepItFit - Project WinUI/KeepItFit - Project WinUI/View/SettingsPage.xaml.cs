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


namespace KeepItFit___Project_WinUI.View
{
    public sealed partial class SettingsPage : Page
    {
        DeleteAccountViewModel deleteAccountViewModel;

        public SettingsPage()
        {
            this.InitializeComponent();

            deleteAccountViewModel = new DeleteAccountViewModel();
        }

        private void ChangePassword_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ChangePasswordPage));
        }

        private async void DeleteAccount_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            ContentDialog deleteDialog = new ContentDialog
            {
                Title = "Delete Account",
                Content = "Are you sure you want to delete your account? All of your data will be removed from KeepItFit and cannot be restored.",
                PrimaryButtonText = "Delete",
                CloseButtonText = "Cancel",
                DefaultButton = ContentDialogButton.Close,
                XamlRoot = this.Content.XamlRoot
            };

            ContentDialogResult result = await deleteDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                try
                {
                    deleteAccountViewModel.DeleteAccount();

                    ContentDialog successDialog = new ContentDialog
                    {
                        Title = "Success",
                        Content = "Account deleted successfully. We will close the application",
                        CloseButtonText = "Ok",
                        XamlRoot = this.Content.XamlRoot
                    };

                    await successDialog.ShowAsync();

                    Application.Current.Exit();
                }
                catch (Exception ex) {
                    //anounce the error
                    ContentDialog errorDialog = new ContentDialog
                    {
                        Title = "Error",
                        Content = ex.Message,
                        CloseButtonText = "Ok",
                        XamlRoot = this.Content.XamlRoot
                    };
                    return;
                }

            }
        }

        private void LogOut_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }
}
