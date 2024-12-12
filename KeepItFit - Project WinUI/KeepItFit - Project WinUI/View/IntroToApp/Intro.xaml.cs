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
using KeepItFit___Project_WinUI.Services;
using KeepItFit___Project_WinUI.Model;
using System.Data.SqlClient;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace KeepItFit___Project_WinUI.View.IntroToApp
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Intro : Window
    {
        public UserInfo user;
        public Intro()
        {
            this.InitializeComponent();
            user = LoadData();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3); // Set thời gian chờ 3 giây
            timer.Tick += (s, args) =>
            {
                // Ẩn ProgressBar
                process.Visibility = Visibility.Collapsed;

                // Ngừng Timer
                timer.Stop();

                // Chuyển trang mới
                if (user == null)
                {
                    FirstAttemp.Visibility = Visibility.Visible;
                }
                else
                {
                    var mainWindow = new MainWindow(user);
                    mainWindow.Activate();
                    this.Close();
                }
            };

            // Bắt đầu Timer
            timer.Start();
        }

        UserInfo LoadData()
        {
            user = new UserInfo();
            var sql = new SQLDao();
            var query = "Select * from UserInfor";
            int count = 0;

            using (SqlConnection connection = new SqlConnection(sql.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user.Protein = Convert.ToInt32(reader["Protein"]);
                        user.Fat = Convert.ToInt32(reader["Fat"]);
                        user.Calo = Convert.ToInt32(reader["Calo"]);
                        user.Sodium = Convert.ToInt32(reader["Sodium"]);
                        user.Sugar = Convert.ToInt32(reader["Sugar"]);
                        user.Carb = Convert.ToInt32(reader["Carbs"]);
                        count++;
                    }

                    if(count == 0)
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            return user;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var screen = new UserSurvey();
            screen.Activate();
            this.Close();
        }
    }
}
