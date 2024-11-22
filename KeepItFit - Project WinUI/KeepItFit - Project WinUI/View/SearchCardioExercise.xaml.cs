using KeepItFit___Project_WinUI.Model;
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
using static KeepItFit___Project_WinUI.View.AddFood;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace KeepItFit___Project_WinUI.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchCardioExercise : Page
    {
        private string type { get; set; } = "Cardio";
        public SearchExerciseViewModel viewModel { get; set; }
        public SearchCardioExercise()
        {
            this.InitializeComponent();
            viewModel = new SearchExerciseViewModel();
            viewModel.init();
        }

        private void SearchCaridoExercise_Click(object sender, RoutedEventArgs e)
        {
            var query = CardioExerciseBox.Text;
            viewModel.CardioExerciseSearchList.Clear();

            if (query == null || query == "")
            {
                CardioExerciseSearch.Visibility = Visibility.Collapsed;
                noResult.Visibility = Visibility.Visible;
                return;
            }

            var filteredList = viewModel.getCardioDatabase(query.ToLower());

            if (filteredList.Count == 0)
            {
                CardioExerciseSearch.Visibility = Visibility.Collapsed;
                noResult.Visibility = Visibility.Visible;
                return;
            }

            noResult.Visibility = Visibility.Collapsed;
            CardioExerciseSearch.Visibility = Visibility.Visible;

            foreach (var cardio in filteredList)
            {
                viewModel.CardioExerciseSearchList.Add(cardio);

            }
        }

        private void CardioExerciseSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CardioExerciseSearch.SelectedItem is CardioExercise exercise)
            {
                viewModel._selectedCardioExercise = exercise;
                viewModel.isCardioExerciseSelected = true; // Show details
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is string parameters)
            {

                // Filter the food is chosen
                var filteredList = viewModel.getCardioDatabase(parameters);
                foreach (var cardio in filteredList)
                {
                    viewModel.CardioExerciseSearchList.Add(cardio);
                }
            }
        }

        private void AddExercise_Click(object sender, RoutedEventArgs e)
        {
            var selectedCardio = viewModel._selectedCardioExercise;
            //Check values not equal to 0
            if (selectedCardio._time == 0 && selectedCardio.CaloriesBurned==0)
            {
                this.Frame.Navigate(typeof(ExercisePage));
            }
            else
            {
                this.Frame.Navigate(typeof(ExercisePage), selectedCardio);
            }
            
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ExercisePage));
        }

        private void addCardio_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateExercise), type);
        }

        private void TextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            var pattern = @"^\d+$"; 
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            int cursorPosition = sender.SelectionStart;
            var text = sender.Text;
            if (!regex.IsMatch(text))
            {
                text = Regex.Replace(text, @"[^\d]", string.Empty);
                sender.Text = text;
                sender.SelectionStart = Math.Min(cursorPosition, text.Length);
            }
        }
    }
}
