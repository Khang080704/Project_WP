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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace KeepItFit___Project_WinUI.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        string today = (DateTime.Today).ToString("yyyy-MM-dd");
        public HomePage()
        {
            this.InitializeComponent();            
            food.Text = (getTotalCaloriesOfQuickAdd(today) + getTotalCaloriesOfAddFood(today)).ToString();
            Remain.Text = (Convert.ToInt32(goal.Text) - Convert.ToInt32(food.Text)).ToString();
        }

        int getTotalCaloriesOfQuickAdd(string today)
        {
            int quickaddBreakfast = getCaloFromQuickAddTable(today, "QUICKADD_BREAKFAST");
            int quickaddLunch = getCaloFromQuickAddTable(today, "QUICKADD_LUNCH");
            int quickaddDinner = getCaloFromQuickAddTable(today, "QUICKADD_DINNER");
            int quickaddSnacks = getCaloFromQuickAddTable(today, "QUICKADD_SNACK");
            return quickaddBreakfast + quickaddDinner + quickaddSnacks + quickaddLunch;
        }

        int getTotalCaloriesOfAddFood(string today)
        {
            int addFoodBreakFast = getCaloFromAddFoodTable(today, "BREAKFASTDIARY");
            int addFoodLunch = getCaloFromAddFoodTable(today, "LUNCHDIARY");
            int addFoodDinner = getCaloFromAddFoodTable(today, "DINNERDIARY");
            int addFoodSnack = getCaloFromAddFoodTable(today, "SNACKDIARY");
            return addFoodBreakFast + addFoodLunch + addFoodDinner + addFoodSnack;

        }

        int getCaloFromQuickAddTable(string day, string tableName)
        {
            var sql = new SQLDao();
            string query = $@"
                Select * from {tableName} where Food_date = @date
                ";
            int value = 0;
            using (SqlConnection connection = new SqlConnection(sql.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@date", day);
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

        int getCaloFromAddFoodTable(string day, string tableName)
        {
            var sql = new SQLDao();
            string query = $@"
                Select f.FOOD_CALORIES, {tableName}.FOOD_QUANTITY
                from {tableName} join FOOD f on {tableName}.FOOD_ID = f.ID
                where {tableName}.Food_date = @date
                ";
            int value = 0;
            using (SqlConnection connection = new SqlConnection(sql.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@date", day);
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            food.Text = (getTotalCaloriesOfQuickAdd(today) + getTotalCaloriesOfAddFood(today)).ToString();
            Remain.Text = (Convert.ToInt32(goal.Text) - Convert.ToInt32(food.Text)).ToString();
        }
    }
}
