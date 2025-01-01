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
using KeepItFit___Project_WinUI.ViewModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace KeepItFit___Project_WinUI.View.IntroToApp
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Intro : Window
    {
        public SignInViewModel user;
        public Intro(SignInViewModel data)
        {
            this.InitializeComponent();
            user = LoadData(data);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3); // Set thời gian chờ 3 giây
            timer.Tick += (s, args) =>
            {
                // Ẩn ProgressBar
                process.Visibility = Visibility.Collapsed;

                // Ngừng Timer
                timer.Stop();

                // Chuyển trang mới
                if (user.user.Protein == 0 && user.user.Carb == 0 && user.user.Calo == 0
                        && user.user.Sodium == 0 && user.user.Fat == 0)
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

        SignInViewModel LoadData(SignInViewModel data)
        {
            user = new SignInViewModel();
            var sql = new SQLDao();
            var query = $"Select email, calo, carbs, fat, sodium, sugar, protein from [User] where Email = @email";

            using (SqlConnection connection = new SqlConnection(sql.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@email", data.Email);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user.Email = reader["Email"].ToString();
                        user.user.Protein = Convert.ToInt32(reader["Protein"]);
                        user.user.Fat = Convert.ToInt32(reader["Fat"]);
                        user.user.Calo = Convert.ToInt32(reader["Calo"]);
                        user.user.Sodium = Convert.ToInt32(reader["Sodium"]);
                        user.user.Sugar = Convert.ToInt32(reader["Sugar"]);
                        user.user.Carb = Convert.ToInt32(reader["Carbs"]);
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
            var screen = new UserSurvey(user);
            screen.Activate();
            this.Close();
        }
    }
}
