using KeepItFit___Project_WinUI.Model;
using KeepItFit___Project_WinUI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KeepItFit___Project_WinUI.View.AddExercisePage;

namespace KeepItFit___Project_WinUI.ViewModel
{
    public class AddExerciseViewModel
    {
        public ObservableCollection<CardioExercise> CardioRecent { get; set; }
        public ObservableCollection<StrengthTraining> StrengthRecent { get; set; }

        public void init()
        {
            CardioRecent = new ObservableCollection<CardioExercise>();
            StrengthRecent = new ObservableCollection<StrengthTraining>();
        }

        public void LoadRecentCardio()
        {
            var sql = new SQLDao();
            string query = @"
            SELECT r.*
            FROM RECENTCARDIO r
            WHERE r.USER_EMAIL = @UserEmail
            ORDER BY r.Cardio_ID DESC";

            using (SqlConnection connection = new SqlConnection(sql.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserEmail", UserSessionService.Instance.UserEmail);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    ObservableCollection<CardioExercise> List = ReadCardioInfo(reader);
                    CardioRecent = List;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error fetching data: {ex.Message}");
                }
            }
        }

        ObservableCollection<CardioExercise> ReadCardioInfo(SqlDataReader reader)
        {
            ObservableCollection<CardioExercise> cardios = new ObservableCollection<CardioExercise>();
            while (reader.Read())
            {
                CardioExercise cardio = new CardioExercise
                {
                    exerciseId = Convert.ToInt32(reader["Cardio_ID"]),
                    name = reader["Cardio_name"].ToString(),
                    _time = Convert.ToInt32(reader["TimeHowLong"]),
                    caloriesPerMinute = Convert.ToInt32(reader["CaloriesPerMinutes"]),
                    CaloriesBurned = Convert.ToInt32(reader["CaloriesBurned"])
                    
                };
                cardios.Add(cardio);
            }
            return cardios;
        }

        public void LoadRecentStrength()
        {
            var sql = new SQLDao();
            string query = @"
            SELECT r.*
            FROM RECENTSTRENGTH r
            WHERE r.USER_EMAIL = @UserEmail
            ORDER BY r.Strength_ID DESC";

            using (SqlConnection connection = new SqlConnection(sql.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserEmail", UserSessionService.Instance.UserEmail);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    ObservableCollection<StrengthTraining> List = new ObservableCollection<StrengthTraining>();
                    while (reader.Read())
                    {
                        StrengthTraining item = new StrengthTraining
                        {
                            exerciseId = Convert.ToInt32(reader["Strength_ID"]),
                            name = reader["Strength_name"].ToString(),
                            Sets = Convert.ToInt32(reader["Sets"]),
                            Reps_Set = Convert.ToInt32(reader["Reps_Set"]),
                            Weight_Sets = Convert.ToInt32(reader["Weight_Set"])

                        };
                        StrengthRecent.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error fetching data: {ex.Message}");
                }
            }
        }
    }
}
