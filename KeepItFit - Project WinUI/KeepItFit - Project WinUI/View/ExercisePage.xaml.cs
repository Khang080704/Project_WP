using KeepItFit___Project_WinUI.View;
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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace KeepItFit___Project_WinUI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ExercisePage : Page
    {
        public ExercisePage()
        {
            this.InitializeComponent();
        }

        private void SaveNote_Click(object sender, RoutedEventArgs e)
        {
            Notes.IsReadOnly = true;
            EditNote.Visibility = Visibility.Visible;
            SaveNote.Visibility = Visibility.Collapsed;
        }

        private void EditNote_Click(object sender, RoutedEventArgs e)
        {
            Notes.IsReadOnly = false;
            EditNote.Visibility = Visibility.Collapsed;
            SaveNote.Visibility = Visibility.Visible;
        }

        private void ViewReport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CardioExercise_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddExercisePage));
        }
    }
}
