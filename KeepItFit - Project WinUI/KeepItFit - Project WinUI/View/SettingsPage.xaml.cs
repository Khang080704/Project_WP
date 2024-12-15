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
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
        }

        private void ChangePassword_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(ChangePasswordPage));
        }

        private void DeleteAccount_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(DeleteAccountPage));
        }

        private void LogOut_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(LogOutPage));
        }
    }
}
