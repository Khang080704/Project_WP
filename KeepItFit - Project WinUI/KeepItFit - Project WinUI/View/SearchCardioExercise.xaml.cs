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
using Windows.Devices.Radios;
using Windows.Foundation;
using Windows.Foundation.Collections;
using static KeepItFit___Project_WinUI.View.AddExercisePage;
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
            ObservableCollection<CardioExercise> userCardio = getCardioFromUserCreation(query.ToLower());
            filteredList = new ObservableCollection<CardioExercise>(filteredList.Concat(userCardio));

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
            if (e.Parameter is Query parameters)
            {
                viewModel.SignInViewModel = parameters.email;

                // Filter the food is chosen
                var filteredList = viewModel.getCardioDatabase(parameters.query);
                ObservableCollection<CardioExercise> userCardio = getCardioFromUserCreation(parameters.query);
                filteredList = new ObservableCollection<CardioExercise>(filteredList.Concat(userCardio));

                foreach (var cardio in filteredList)
                {
                    viewModel.CardioExerciseSearchList.Add(cardio);
                }
            }
            else if(e.Parameter is SignInViewModel signInViewModel)
            {
                viewModel.SignInViewModel = signInViewModel;
            }
        }

        //Add Exercise to Main exercise Page
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
                addToRecent(selectedCardio);
                this.Frame.Navigate(typeof(ExercisePage), selectedCardio);
            }
            
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ExercisePage));
        }

        public class CardioCreation
        {
            public string Title { get; set; }
            public SignInViewModel user {  get; set; }
        }
        //Navigate to Create Exercise Page
        private void addCardio_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new CardioCreation()
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

        //function get Cardio from UserCardio table
        ObservableCollection<CardioExercise> getCardioFromUserCreation(string keyword)
        {
            var sql = new SQLDao();
            ObservableCollection<CardioExercise> cardio = new ObservableCollection<CardioExercise>();
            string query = @"SELECT * FROM UserCardio WHERE CardioName LIKE @keyword and Email = @mail";

            using (SqlConnection connection = new SqlConnection(sql.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                command.Parameters.AddWithValue("@mail", viewModel.SignInViewModel.Email);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        CardioExercise temp = new CardioExercise
                        {
                            exerciseId = Convert.ToInt32(reader["ID"]),
                            name = reader["CardioName"].ToString(),
                            _time = Convert.ToInt32(reader["TimeHowLong"]),
                            CaloriesBurned = Convert.ToInt32(reader["CaloriesBurned"]),
                            caloriesPerMinute = Convert.ToSingle(reader["CaloriesPerMinutes"])

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

        void addToRecent(CardioExercise data)
        {
            var sql = new SQLDao();
            string queryInsert = @$"Insert into RECENTCARDIO (Cardio_ID,Cardio_name, TimeHowLong, CaloriesPerMinutes ,CaloriesBurned, USER_EMAIL)
                            values (@id, @name, @time, @caloPer ,@calo, @mail)";

            string queryExits = @$"Select count(*) from RECENTCARDIO where Cardio_ID = {data.exerciseId} 
                                and USER_EMAIL = @mail";

            string queryUpdate = @$"Update RECENTCARDIO set TimeHowLong = {data._time}, CaloriesBurned = {data.CaloriesBurned}
            where Cardio_ID = {data.exerciseId} and USER_EMAIL = @mail";

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
                commandInsert.Parameters.AddWithValue("@time", data._time);
                commandInsert.Parameters.AddWithValue("@calo", data.CaloriesBurned);
                commandInsert.Parameters.AddWithValue("@mail", viewModel.SignInViewModel.Email);
                commandInsert.Parameters.AddWithValue("@caloPer", data.caloriesPerMinute);
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
