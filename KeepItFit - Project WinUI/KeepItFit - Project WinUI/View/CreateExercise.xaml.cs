using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using KeepItFit___Project_WinUI.Model;
using KeepItFit___Project_WinUI.Services;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.RegularExpressions;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace KeepItFit___Project_WinUI.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateExercise : Page
    {
        string type {  get; set; } //Type of exercise
        public CreateExercise()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if(e.Parameter is string parameter && parameter == "Cardio")
            {
                type = "Cardio";
                createCardio.Visibility = Visibility.Visible;
            }
            else
            {
                type = "Strength";
                createStrength.Visibility = Visibility.Visible;
            }
        }

        bool checkIsNull(TextBox[] value)
        {
            foreach(TextBox t in value)
            {
                if (string.IsNullOrEmpty(t.Text))
                {
                    return true;
                }
            }
            return false;
        }

        private void Cardio_Click(object sender, RoutedEventArgs e)
        {
            TextBox[] info = { CardioName, CardioCalo, CardioMinutes };
            if (checkIsNull(info))
            {
                Warning.Visibility = Visibility.Visible;
                return;
            }
            CardioExercise data = new CardioExercise()
            {
                name = CardioName.Text,
                caloriesPerMinute = (1.0f * Convert.ToInt32(CardioCalo.Text) / (1.0f * Convert.ToInt32(CardioMinutes.Text))),
                CaloriesBurned = Convert.ToInt32(CardioCalo.Text),
                _time = Convert.ToInt32(CardioMinutes.Text),
            };

            var sql = new SQLDao();
            string query = """
                Insert into CardioExercise (Cardio_name, TimeHowLong,CaloriesBurned, CaloriesPerminutes) 
                values (@name, @time, @caloBurned, @caloPerMinutes) 
                """;

            using (SqlConnection connection = new SqlConnection(sql.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", data.name);
                command.Parameters.AddWithValue("@time", 0);
                command.Parameters.AddWithValue("@caloBurned", 0);
                command.Parameters.AddWithValue("@caloPerMinutes", data.caloriesPerMinute);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            //query to get id for new exercise
            string getIDquery = @"
                SELECT max(id)
                FROM CardioExercise
                ";
            using (SqlConnection connection = new SqlConnection(sql.connectionString))
            {
                SqlCommand command = new SqlCommand(getIDquery, connection);

                try
                {
                    connection.Open();
                    data.exerciseId = (int)command.ExecuteScalar();
                    
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            this.Frame.Navigate(typeof(ExercisePage), data);
        }

        private void Strength_Click(object sender, RoutedEventArgs e)
        {
            TextBox[] info = { StrengthName, Sets, rep_set, weight_set};
            //check one of them is null, show warning
            if (checkIsNull(info))
            {
                Warning.Visibility = Visibility.Visible; return;
            }
            StrengthTraining data = new StrengthTraining()
            {
                name = StrengthName.Text,
                Sets = Convert.ToInt32(Sets.Text),
                Reps_Set = Convert.ToInt32(rep_set.Text),
                Weight_Sets = Convert.ToInt32(weight_set.Text)
            };

            var sql = new SQLDao();
            string query = """
                Insert into StrengthTraining (Strength_name, Sets, Reps_Set, Weigth_Set) 
                values (@name, @sets, @rep_set, @weigth) 
                """;
            using (SqlConnection connection = new SqlConnection(sql.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", data.name);
                command.Parameters.AddWithValue("@sets", 0);
                command.Parameters.AddWithValue("@rep_set", 0);
                command.Parameters.AddWithValue("@weigth", 0);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            //query to get id for new exercise
            string getIDquery = @"
                SELECT max(id)
                FROM StrengthTraining
                ";
            using (SqlConnection connection = new SqlConnection(sql.connectionString))
            {
                SqlCommand command = new SqlCommand(getIDquery, connection);

                try
                {
                    connection.Open();
                    data.exerciseId = (int)command.ExecuteScalar();

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }


            this.Frame.Navigate(typeof(ExercisePage), data);
        }

        private void CardioName_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
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

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if(type == "Cardio")
            {
                this.Frame.Navigate(typeof(SearchCardioExercise));
            }
            else
            {
                this.Frame.Navigate(typeof(SearchStrengthTrainingExercise));
            }
        }
    }
}
