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
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace KeepItFit___Project_WinUI.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchStrengthTrainingExercise : Page
    {
        private string type { get; set; } = "StrengthTraining";
        public SearchExerciseViewModel viewModel { get; set; }
        public SearchStrengthTrainingExercise()
        {
            this.InitializeComponent();
            viewModel = new SearchExerciseViewModel();
            viewModel.init();
        }

        private void SearchStrengthExercise_Click(object sender, RoutedEventArgs e)
        {
            var query = StrengthExerciseBox.Text;
            viewModel.strengthTrainingSearchList.Clear();

            if (query == null || query == "")
            {
                StrengthExerciseSearch.Visibility = Visibility.Collapsed;
                noResult.Visibility = Visibility.Visible;
                return;
            }

            var filteredList = viewModel.getStrengthTrainDatabase(query.ToLower());

            if (filteredList.Count == 0)
            {
                StrengthExerciseSearch.Visibility = Visibility.Collapsed;
                noResult.Visibility = Visibility.Visible;
                return;
            }

            noResult.Visibility = Visibility.Collapsed;
            StrengthExerciseSearch.Visibility = Visibility.Visible;

            foreach (var training in filteredList)
            {
                viewModel.strengthTrainingSearchList.Add(training);

            }
        }

        private void StrengthExerciseSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StrengthExerciseSearch.SelectedItem is StrengthTraining exercise)
            {
                viewModel._selectedStrengthTraining = exercise;
                viewModel.isStrengthExerciseSelected = true; // Show details
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is string parameters)
            {
                // Filter the food is chosen
                var filteredList = viewModel.getStrengthTrainDatabase(parameters);
                foreach (var strength in filteredList)
                {
                    viewModel.strengthTrainingSearchList.Add(strength);
                }
            }
        }

        private void AddExercise_Click(object sender, RoutedEventArgs e)
        {
            var selectedStrengthTraining = viewModel._selectedStrengthTraining;
            //Check value not equal to 0
            if (selectedStrengthTraining.Sets == 0 && selectedStrengthTraining.Weight_Sets == 0
                && selectedStrengthTraining.Reps_Set == 0)
            {
                this.Frame.Navigate(typeof(ExercisePage));
            }
            else
            {
                this.Frame.Navigate(typeof(ExercisePage), selectedStrengthTraining);
            }
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ExercisePage));
        }

        private void addStrength_Click(object sender, RoutedEventArgs e)
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
