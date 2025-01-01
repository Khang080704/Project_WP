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
using static KeepItFit___Project_WinUI.ExercisePage;
using KeepItFit___Project_WinUI.ViewModel;
using KeepItFit___Project_WinUI.Model;
using System.Text.RegularExpressions;

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
        SignInViewModel user {  get; set; }
        public AddExerciseViewModel viewModel { get; set; }
        List<CardioExercise> cardioList { get; set; } = new List<CardioExercise>();
        List<StrengthTraining> strList { get; set; } = new List<StrengthTraining>();
        public AddExercisePage()
        {
            this.InitializeComponent();
            viewModel = new AddExerciseViewModel();
            viewModel.init();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if(e.Parameter is string)
            {
                exerciseType = (string)e.Parameter;
            }
            else if(e.Parameter is Navigations p)
            {
                exerciseType = (string)p.Name;
                user = (SignInViewModel)p.navigateUser;
                if(exerciseType == "CardioExercise")
                {
                    addCheckedCardio.Visibility = Visibility.Visible;
                    addCheckedStrength.Visibility = Visibility.Collapsed;
                    viewModel.LoadRecentCardio();
                    CardioRecentListView.Visibility = Visibility.Visible;
                    StrRecentListView.Visibility = Visibility.Collapsed;
                }
                else
                {
                    addCheckedStrength.Visibility= Visibility.Visible;
                    addCheckedCardio.Visibility= Visibility.Collapsed;
                    viewModel.LoadRecentStrength();
                    StrRecentListView.Visibility= Visibility.Visible;
                    CardioRecentListView.Visibility = Visibility.Collapsed;
                }
            }
        }
        public class Query
        {
            public string query { get; set; }
            public SignInViewModel email { get; set; }
        }

        //Navigate to Search Page
        private void Search_Click(object sender, RoutedEventArgs e)
        {

            string query = SearchText.Text.ToLower();
            var navigation = new Query()
            {
                query = query,
                email = user
            };
            if(exerciseType == "CardioExercise")
            {
                this.Frame.Navigate(typeof(SearchCardioExercise), navigation);
            }
            else
            {
                this.Frame.Navigate(typeof(SearchStrengthTrainingExercise), navigation);
            }
            
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ExercisePage));
        }

        private void cardioCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            CardioExercise item = checkBox.DataContext as CardioExercise;

            if (viewModel.CardioRecent.Contains(item))
            {
                cardioList.Add(item);
            }
        }

        private void cardioCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            CardioExercise foodItem = checkBox.DataContext as CardioExercise;

            if (viewModel.CardioRecent.Contains(foodItem))
            {
                cardioList.Remove(foodItem);
            }
        }

        private void addCheckedCardio_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ExercisePage), cardioList);
        }

        private void addCheckedStrength_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ExercisePage), strList);
        }

        private void StrCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            StrengthTraining item = checkBox.DataContext as StrengthTraining;

            if (viewModel.StrengthRecent.Contains(item))
            {
                strList.Add(item);
            }
        }

        private void StrCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            StrengthTraining item = checkBox.DataContext as StrengthTraining;

            if (viewModel.StrengthRecent.Contains(item))
            {
                strList.Remove(item);
            }
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
