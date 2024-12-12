using KeepItFit___Project_WinUI.ViewModel;
using Microsoft.UI.Windowing;
using Microsoft.UI;
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
using Microsoft.UI.Xaml.Documents;
using System.Diagnostics;
using KeepItFit___Project_WinUI.Services;
using KeepItFit___Project_WinUI.View.IntroToApp;


namespace KeepItFit___Project_WinUI.View
{
    public sealed partial class SignIn : Window
    {
        SignInViewModel viewModel {  get; set; }

        public SignIn()
        {
            this.InitializeComponent();
            viewModel = new SignInViewModel();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle sign-in logic here using viewModel properties
            if (viewModel.VerifyDataSignIn() == false)
            {
                viewModel.IsErrorMessageVisible = Visibility.Visible;
                return;
            }

            // Set the UserEmail in the UserSessionService
            UserSessionService.Instance.SetUserEmail(viewModel.Email);

            // Close the SignIn window and navigate to the MainWindow
            NavigateToMainWindow();
        }

        private void SignUpButton_Click(Hyperlink sender, HyperlinkClickEventArgs args)
        {
            // Navigate to the SignUp page
            ContentFrame.Navigate(typeof(SignUp));
        }

        private void NavigateToMainWindow()
        {
            var mainWindow = new Intro(viewModel);
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(mainWindow);
            var windowId = Win32Interop.GetWindowIdFromWindow(hWnd);
            var appWindow = AppWindow.GetFromWindowId(windowId);

            var presenter = appWindow.Presenter as OverlappedPresenter;
            if (presenter != null)
            {
                presenter.Maximize();
            }

            mainWindow.Activate();
            this.Close();
        }

        public void CloseSignInWindow()
        {
            Debug.WriteLine("dsd");
            this.Close();
        }
    }
}
