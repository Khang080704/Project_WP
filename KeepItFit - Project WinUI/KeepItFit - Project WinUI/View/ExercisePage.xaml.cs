using KeepItFit___Project_WinUI.Model;
using KeepItFit___Project_WinUI.View;
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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace KeepItFit___Project_WinUI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ExercisePage : Page
    {
        public InputExerciseViewModel ViewModel {  get; set; }
        public ExercisePage()
        {
            this.InitializeComponent();
            ViewModel = new InputExerciseViewModel();
            ViewModel.init();
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

        void update_Time_And_Calories_Daily()
        {
            var sumDailyCalories = 0;
            var timeDaily = 0;
            foreach (var i in ViewModel.CardioExerciseData)
            {
                sumDailyCalories += i.CaloriesBurned;
                timeDaily += i._time;
            }
            Daily_Calories.Text = sumDailyCalories.ToString();
            Daily_minutes.Text = timeDaily.ToString();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if(e.Parameter is CardioExercise cardio)
            {
                ViewModel.updateWithCardio(cardio);
                update_Time_And_Calories_Daily();
            }
            else
            {
                if(e.Parameter is StrengthTraining strength)
                {
                    ViewModel.updateWithStrength(strength);
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var itemToDelete = btn?.Tag as CardioExercise;
            if (itemToDelete != null)
            {
                if (ViewModel.CardioExerciseData.Contains(itemToDelete))
                {
                    ViewModel.CardioExerciseData.Remove(itemToDelete);
                    update_Time_And_Calories_Daily();
                }   
            }
        }
        private void DeleteStrengthButton_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var itemToDelete = btn?.Tag as StrengthTraining;
            if (itemToDelete != null)
            {
                if (ViewModel.StrengthTrainingData.Contains(itemToDelete))
                {
                    ViewModel.StrengthTrainingData.Remove(itemToDelete);
                }
            }
        }

        private void StrengthExercise_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddExercisePage), StrengthExercise.Name);
        }

        private void CardioExercise_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddExercisePage), CardioExercise.Name);
        }

        
    }
}
