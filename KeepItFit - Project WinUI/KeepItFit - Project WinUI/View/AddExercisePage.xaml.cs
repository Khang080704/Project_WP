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

namespace KeepItFit___Project_WinUI.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddExercisePage : Page
    {
        string exerciseType {  get; set; }
        public AddExercisePage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if(e.Parameter is string)
            {
                exerciseType = (string)e.Parameter;
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string query = SearchText.Text.ToLower();
            if(exerciseType == "CardioExercise")
            {
                this.Frame.Navigate(typeof(SearchCardioExercise), query);
            }
            else
            {
                this.Frame.Navigate(typeof(SearchStrengthTrainingExercise), query);
            }
            
        }
    }
}
