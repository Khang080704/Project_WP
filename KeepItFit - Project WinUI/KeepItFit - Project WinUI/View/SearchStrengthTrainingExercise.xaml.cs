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

            var filteredList = viewModel.strengthTrainingDatabase.Where(training => training.name.ToLower().Contains(query)).ToList();

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
                var filteredList = viewModel.strengthTrainingDatabase.Where(exercise => exercise.name.ToLower().Contains(parameters)).ToList();
                foreach (var strength in filteredList)
                {
                    viewModel.strengthTrainingSearchList.Add(strength);
                }
            }
        }

        private void AddExercise_Click(object sender, RoutedEventArgs e)
        {
            var selectedStrengthTraining = viewModel._selectedStrengthTraining;
            this.Frame.Navigate(typeof(ExercisePage), selectedStrengthTraining);
        }
    }
}
