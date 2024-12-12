﻿using Microsoft.UI.Xaml;
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
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.UI.Windowing;
using Microsoft.UI;
using KeepItFit___Project_WinUI.Services;
using System.Data.SqlClient;
using System.Linq.Expressions;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace KeepItFit___Project_WinUI.View.IntroToApp
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    
    public sealed partial class UserSurvey : Window
    {
        public UserInfo data { get; set; }
        public UserSurvey()
        {
            this.InitializeComponent();
            data = new UserInfo();
            // Lấy AppWindow từ WindowHandle
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            var windowId = Win32Interop.GetWindowIdFromWindow(hWnd);
            var appWindow = AppWindow.GetFromWindowId(windowId);

            // Sử dụng OverlappedPresenter để chỉnh trạng thái cửa sổ
            var presenter = appWindow.Presenter as OverlappedPresenter;
            if (presenter != null)
            {
                presenter.Maximize();  // Phóng to cửa sổ
            }
        }

        bool checkNull(string[] data)
        {
            foreach (var item in data)
            {
                if (item is null)
                {
                    return true;
                }
            }
            return false;
        }

        async void makeADialog()
        {
            var dialog = new ContentDialog()
            {
                XamlRoot = Content.XamlRoot,
                Title = "Error",
                Content = "Please fill out all of fields",
                PrimaryButtonText = "Ok",
            };

            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {

            }
            else
            {
                Console.WriteLine("No");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var gender = (GenderComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            var height = HeightTextBox.Text;
            var weight = WeightTextBox.Text;
            var activityLevel = (ActivityLevelComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            var mealsPerDay = (MealsPerDayComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            var nightEating = (NightEatingComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            var chronicDiseases = (ChronicDiseasesComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            var foodAllergies = (FoodAllergiesComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            var nutritionGoals = (NutritionGoalsComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            var array = new String[] {gender, height,weight, activityLevel,
            mealsPerDay, nightEating, chronicDiseases, foodAllergies, nutritionGoals};
            if (checkNull(array))
            {
                makeADialog();
                return;
            }

            data.Birthdate = (DateTime)Birthdate.Date.Value.Date;
            data.Gender = gender;
            data.Height = Convert.ToInt32(height);
            data.Weight = Convert.ToInt32(weight);
            data.ActivityLevel = activityLevel;
            data.MealsPerDay = Convert.ToInt32(mealsPerDay[0]);
            data.NightEating = (nightEating.ToLower() == "yes") ? true : false;
            data.NutritionGoal = nutritionGoals;

            //Calculate nutrition
            data.CalculateTDEE();
            data.calculateNutritionNeed();

            passToDataBase(data);

            process.Visibility = Visibility.Visible;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3); // Set thời gian chờ 3 giây
            timer.Tick += (s, args) =>
            {
                // Ẩn ProgressBar
                process.Visibility = Visibility.Collapsed;

                // Ngừng Timer
                timer.Stop();

                // Chuyển trang mới
                var screen = new MainWindow(data);
                screen.Activate();
                this.Close();
            };

            // Bắt đầu Timer
            timer.Start();
        }

        //Pass user data to Database
        void passToDataBase(UserInfo data)
        {
            var sql = new SQLDao();
            var query = $"""
                         Insert into UserInFor(Calo, Carbs, Fat, Sodium, Sugar, Protein)
                         values ({data.Calo}, {data.Carb}, {data.Fat}, {data.Sodium},{data.Sugar}, {data.Protein}) 
                         """;

            using (SqlConnection connection = new SqlConnection(sql.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        private void HeightTextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
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
