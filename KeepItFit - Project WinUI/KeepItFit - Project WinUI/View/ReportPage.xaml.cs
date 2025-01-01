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
using KeepItFit___Project_WinUI.Model;
using KeepItFit___Project_WinUI.ViewModel;
using KeepItFit___Project_WinUI.Services;
using System.Data.SqlClient;
using System.Diagnostics;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.Collections.ObjectModel;
using LiveChartsCore.SkiaSharpView.WinUI;
using Microsoft.UI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace KeepItFit___Project_WinUI.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReportPage : Page
    {
        SignInViewModel user {  get; set; }
        DateTime today = DateTime.Now;
        public ReportPage()
        {
            this.InitializeComponent();
            
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if(e.Parameter is SignInViewModel)
            {
                user = (SignInViewModel)e.Parameter;
                
            }
        }

        private void _7Days_Tapped(object sender, TappedRoutedEventArgs e)
        {
            _7DayReport.Visibility = Visibility.Visible;
            _14DayReport.Visibility = Visibility.Collapsed;
            _21DayReport.Visibility = Visibility.Collapsed;
            _30DayReport.Visibility = Visibility.Collapsed;

            //Change Color for textblock
            _7Days.Foreground = new SolidColorBrush(Colors.Blue);
            _14Days.Foreground = new SolidColorBrush(Colors.Black);
            _21Days.Foreground = new SolidColorBrush(Colors.Black);
            _30Days.Foreground = new SolidColorBrush(Colors.Black);

            getReport(_7DayReport, 7);
        }

        private void _30Days_Tapped(object sender, TappedRoutedEventArgs e)
        {
            _30DayReport.Visibility = Visibility.Visible;
            _7DayReport.Visibility = Visibility.Collapsed;
            _21DayReport.Visibility = Visibility.Collapsed;
            _14DayReport.Visibility = Visibility.Collapsed;

            //Change Color for textblock
            _7Days.Foreground = new SolidColorBrush(Colors.Black);
            _14Days.Foreground = new SolidColorBrush(Colors.Black);
            _21Days.Foreground = new SolidColorBrush(Colors.Black);
            _30Days.Foreground = new SolidColorBrush(Colors.Blue);

            getReport(_30DayReport, 30);
        }

        private void _21Days_Tapped(object sender, TappedRoutedEventArgs e)
        {
            _30DayReport.Visibility = Visibility.Collapsed;
            _7DayReport.Visibility = Visibility.Collapsed;
            _21DayReport.Visibility = Visibility.Visible;
            _14DayReport.Visibility = Visibility.Collapsed;

            //Change Color for textblock
            _7Days.Foreground = new SolidColorBrush(Colors.Black);
            _14Days.Foreground = new SolidColorBrush(Colors.Black);
            _21Days.Foreground = new SolidColorBrush(Colors.Blue);
            _30Days.Foreground = new SolidColorBrush(Colors.Black);

            getReport(_21DayReport, 21);
        }

        private void _14Days_Tapped(object sender, TappedRoutedEventArgs e)
        {
            _30DayReport.Visibility = Visibility.Collapsed;
            _7DayReport.Visibility = Visibility.Collapsed;
            _21DayReport.Visibility = Visibility.Collapsed;
            _14DayReport.Visibility = Visibility.Visible;

            //Change Color for textblock
            _7Days.Foreground = new SolidColorBrush(Colors.Black);
            _14Days.Foreground = new SolidColorBrush(Colors.Blue);
            _21Days.Foreground = new SolidColorBrush(Colors.Black);
            _30Days.Foreground = new SolidColorBrush(Colors.Black);

            getReport(_14DayReport, 14);
        }

        void getReport(CartesianChart chart, int days)
        {
            DateTime[] weekDay = new DateTime[days];
            int[] totalByDay = new int[days];
            for (int i = 0; i < days; i++)
            {
                weekDay[i] = today.AddDays(-(days - 1 - i));
                totalByDay[i] = getTotalCaloriesOfQuickAdd(formattedDay(weekDay[i]))
                    + getTotalCaloriesOfAddFood(formattedDay(weekDay[i]));
            }

            ObservableCollection<ISeries> series = new ObservableCollection<ISeries>()
            {
                new ColumnSeries<int>
                {
                    Values = totalByDay.ToList(),

                }
            };

            chart.XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = weekDay.Select(day => day.ToString("dd/MM")).ToArray(),
                    LabelsRotation = 90,
                }
            };
            chart.YAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Total Calories",
                    MinLimit = 0
                }
            };
            chart.Series = series;
        }

        string formattedDay(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
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

        
    }
}
