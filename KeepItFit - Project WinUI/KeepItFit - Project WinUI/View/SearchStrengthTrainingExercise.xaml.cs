using KeepItFit___Project_WinUI.Model;
using KeepItFit___Project_WinUI.Services;
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
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using static KeepItFit___Project_WinUI.View.AddExercisePage;
using static KeepItFit___Project_WinUI.View.SearchCardioExercise;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            ObservableCollection<StrengthTraining> userCardio = getStrengthFromUserCreation(query.ToLower());
            filteredList = new ObservableCollection<StrengthTraining>(filteredList.Concat(userCardio));

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
            if (e.Parameter is Query parameters)
            {
                viewModel.SignInViewModel = parameters.email;
                // Filter the food is chosen
                var filteredList = viewModel.getStrengthTrainDatabase(parameters.query);
                ObservableCollection<StrengthTraining> userCardio = getStrengthFromUserCreation(parameters.query);
                filteredList = new ObservableCollection<StrengthTraining>(filteredList.Concat(userCardio));
                
                foreach (var strength in filteredList)
                {
                    viewModel.strengthTrainingSearchList.Add(strength);
                }
            }
            else if (e.Parameter is SignInViewModel signInViewModel)
            {
                viewModel.SignInViewModel = signInViewModel;
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
                addToRecent(selectedStrengthTraining);
                this.Frame.Navigate(typeof(ExercisePage), selectedStrengthTraining);
            }
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ExercisePage));
        }

        public class StrengthCreation
        {
            public string Title { get; set; }
            public SignInViewModel user { get; set; }
        }

        private void addStrength_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new StrengthCreation()
            {
                Title = type,
                user = viewModel.SignInViewModel
            };
            this.Frame.Navigate(typeof(CreateExercise), parameters);
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

        ObservableCollection<StrengthTraining> getStrengthFromUserCreation(string keyword)
        {
            var sql = new SQLDao();
            ObservableCollection<StrengthTraining> cardio = new ObservableCollection<StrengthTraining>();
            string query = @"SELECT * FROM UserStrength WHERE StrengthName LIKE @keyword and Email = @mail";

            using (SqlConnection connection = new SqlConnection(sql.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                command.Parameters.AddWithValue("@mail", viewModel.SignInViewModel.Email);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        StrengthTraining temp = new StrengthTraining
                        {
                            exerciseId = Convert.ToInt32(reader["ID"]),
                            name = reader["StrengthName"].ToString(),
                            Sets = Convert.ToInt32(reader["Sets"]),
                            Reps_Set = Convert.ToInt32(reader["Reps_Set"]),
                            Weight_Sets = Convert.ToInt32(reader["Weight_Set"])
                        };
                        cardio.Add(temp);
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return cardio;
        }

        void addToRecent(StrengthTraining data)
        {
            var sql = new SQLDao();
            string queryInsert = @$"Insert into RECENTSTRENGTH (Strength_ID, Strength_name, Sets, Reps_Set ,Weight_Set, USER_EMAIL)
                            values (@id, @name, @sets, @rep_set ,@weight, @mail)
            ";

            string queryExits = @$"Select count(*) from RECENTSTRENGTH where Strength_ID = {data.exerciseId} 
                                and USER_EMAIL = @mail
            ";
            string queryUpdate = @$"Update RECENTSTRENGTH set Sets = {data.Sets}, Reps_Set = {data.Reps_Set}, Weight_Set = {data.Weight_Sets}
            where Strength_ID = {data.exerciseId} and USER_EMAIL = @mail";

            using (SqlConnection connection = new SqlConnection(sql.connectionString))
            {
                //Check Exits
                SqlCommand isExits = new SqlCommand(queryExits, connection);
                isExits.Parameters.AddWithValue("@mail", viewModel.SignInViewModel.Email);


                SqlCommand update = new SqlCommand(queryUpdate, connection);
                update.Parameters.AddWithValue("@mail", viewModel.SignInViewModel.Email);

                SqlCommand commandInsert = new SqlCommand(queryInsert, connection);
                commandInsert.Parameters.AddWithValue("@id", data.exerciseId);
                commandInsert.Parameters.AddWithValue("@name", data.name);
                commandInsert.Parameters.AddWithValue("@sets", data.Sets);
                commandInsert.Parameters.AddWithValue("@rep_set", data.Reps_Set);
                commandInsert.Parameters.AddWithValue("@mail", viewModel.SignInViewModel.Email);
                commandInsert.Parameters.AddWithValue("@weight", data.Weight_Sets);
                try
                {
                    connection.Open();
                    int count = (int)isExits.ExecuteScalar();
                    if (count > 0)
                    {
                        //if cardio is exits
                        update.ExecuteNonQuery();
                    }
                    else
                    {
                        //Insert
                        commandInsert.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }
}
