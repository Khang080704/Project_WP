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
using KeepItFit___Project_WinUI.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data.SqlClient;
using System.Diagnostics;
using KeepItFit___Project_WinUI.ViewModel;
using Microsoft.UI;


namespace KeepItFit___Project_WinUI.View
{
    public sealed partial class HomePage : Page
    {
        string today = (DateTime.Today).ToString("yyyy-MM-dd");
        SignInViewModel user {  get; set; }
        public HomePage()
        {
            this.InitializeComponent();    
            user = new SignInViewModel();
            
        }

        int getTotalCaloriesOfQuickAdd(string today)
        {
            int quickaddBreakfast = getCaloFromQuickAddTable(today, "QUICKADD_BREAKFAST", user);
            int quickaddLunch = getCaloFromQuickAddTable(today, "QUICKADD_LUNCH", user);
            int quickaddDinner = getCaloFromQuickAddTable(today, "QUICKADD_DINNER", user);
            int quickaddSnacks = getCaloFromQuickAddTable(today, "QUICKADD_SNACK", user);
            return quickaddBreakfast + quickaddDinner + quickaddSnacks + quickaddLunch;
        }

        int getTotalCaloriesOfAddFood(string today)
        {
            int addFoodBreakFast = getCaloFromAddFoodTable(today, "BREAKFASTDIARY", user);
            int addFoodLunch = getCaloFromAddFoodTable(today, "LUNCHDIARY", user);
            int addFoodDinner = getCaloFromAddFoodTable(today, "DINNERDIARY", user);
            int addFoodSnack = getCaloFromAddFoodTable(today, "SNACKDIARY", user);
            return addFoodBreakFast + addFoodLunch + addFoodDinner + addFoodSnack;

        }

        int getCaloFromQuickAddTable(string day, string tableName, SignInViewModel user)
        {
            var sql = new SQLDao();
            string query = $@"
                Select * from {tableName} where Food_date = @date and USER_EMAIL = @mail
                ";
            int value = 0;
            using (SqlConnection connection = new SqlConnection(sql.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@date", day);
                command.Parameters.AddWithValue("@mail", user.Email);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        value += Convert.ToInt32(reader["food_calories"]);
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            return value;
        }

        int getCaloFromAddFoodTable(string day, string tableName, SignInViewModel user)
        {
            var sql = new SQLDao();
            string query = $@"
                Select f.FOOD_CALORIES, {tableName}.FOOD_QUANTITY
                from {tableName} join FOOD f on {tableName}.FOOD_ID = f.ID
                where {tableName}.Food_date = @date and USER_EMAIL = @mail
                ";
            int value = 0;
            using (SqlConnection connection = new SqlConnection(sql.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@date", day);
                command.Parameters.AddWithValue("@mail", user.Email);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int tmpcalo = Convert.ToInt32(reader["FOOD_CALORIES"]);
                        int tmpquantity = Convert.ToInt32(reader["FOOD_QUANTITY"]);
                        value += tmpcalo * tmpquantity;
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            return value;
        }

        int getTotalCaloFromExercise(string day, SignInViewModel user)
        {
            var sql = new SQLDao();
            string query = $@"
                Select CaloriesBurned
                from CardioExerciseDiary
                where exercise_date = @day and USER_EMail = @mail
                ";
            int value = 0;
            using (SqlConnection connection = new SqlConnection(sql.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@day", day);
                command.Parameters.AddWithValue("@mail", user.Email);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int tmpcalo = Convert.ToInt32(reader["CaloriesBurned"]);
                        value += tmpcalo;
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            return value;
        }

        int getGoal(SignInViewModel user)
        {
            var sql = new SQLDao();
            string query = $@"
                select DailyCaloriesGoal from [USER]
                where Email = @mail
                ";
            int goal = 0;
            using (SqlConnection connection = new SqlConnection(sql.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@mail", user.Email);
                try
                {
                    connection.Open();
                    goal = (int)command.ExecuteScalar();

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return goal;
        }

        

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is SignInViewModel)
            {
                user = e.Parameter as SignInViewModel;
                goal.Text = getGoal(user).ToString();

                food.Text = (getTotalCaloriesOfQuickAdd(today) + getTotalCaloriesOfAddFood(today)).ToString();
                exercise.Text = getTotalCaloFromExercise(today, user).ToString();
                Remain.Text = (Convert.ToInt32(goal.Text) - Convert.ToInt32(food.Text) +
                    Convert.ToInt32(exercise.Text)).ToString();

            }
        }

        


    }
}
