using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.Storage;
using System.Threading.Tasks;
using KeepItFit___Project_WinUI.View;
using System.Diagnostics;
using KeepItFit___Project_WinUI.Services;
using Microsoft.UI.Windowing;
using Microsoft.UI;
using KeepItFit___Project_WinUI.Model;
using KeepItFit___Project_WinUI.ViewModel;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Emit;

namespace KeepItFit___Project_WinUI
{

    public sealed partial class MainWindow : Window
    {
        public AvatarViewModel avatarViewModel = new AvatarViewModel();

        public string userEmail { get; set; }

        public class EncourageSentence
        {
            public string[] Sentences = new string[]
            {
                "Health is the greatest wealth",
                "Take care of your body. It's the only place you have to live",
                "The first wealth is health",
                "A healthy outside starts from the inside\r\n",
                "Your body is your most priceless possession. Take care of it",
                "Health is not about the weight you lose, but the life you gain",
                "When you feel like quitting, remember why you started",
                "Invest in your health now, or you’ll pay for it later",
                "It’s not about being the best. It’s about being better than you were yesterday",
                "Small changes can make a big difference in your health",
                "Don’t work so hard to make a living that you forget to make a life",
                "You don’t have to be extreme, just consistent",
                "Exercise not only changes your body, it changes your mind, your attitude, and your mood",
                "Every step you take is a step towards better health",
                "Good health is not something we can buy, but it is something we can invest in"
            };

            public string getRandomSentence()
            {
                Random generator = new Random();
                int index = generator.Next(Sentences.Length);
                return Sentences[index];
            }
        }
        DateTime today = DateTime.Today;
        public SignInViewModel UserInfo { get; set; }
        public MainWindow()
        {
            this.InitializeComponent();
            userEmail = UserSessionService.Instance.UserEmail;
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

            LoadAvatar();
        }

        public MainWindow(SignInViewModel data)
        {
            this.InitializeComponent();
            userEmail = UserSessionService.Instance.UserEmail;
            UserInfo = data;
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

            //get streak day
            KeyValuePair<DateTime, int> streakDay = getStreak(UserInfo).First();
            if (today == streakDay.Key.AddDays(1))
            {
                var root = this.Content as FrameworkElement;
                if (root != null)
                    root.Loaded += async (s, e) => await ShowHealthDialog(streakDay.Value + 1);

                updateStreak(UserInfo, today.ToString("yyyy-MM-dd"));
            }
            else
            {

                LoadAvatar();
            }

        }



        private void nvSample_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var selectionItem = args.SelectedItem as NavigationViewItem;
            string selectedTag = selectionItem.Tag as string;
            if (selectedTag == "FoodDiary")
            {
                contentFrame.Navigate(typeof(FoodDiary), UserInfo);
            }
            else if (selectedTag == "ExercisePage")
            {
                contentFrame.Navigate(typeof(ExercisePage), UserInfo);
            }
            else if (selectedTag == "HomePage")
            {
                contentFrame.Navigate(typeof(HomePage), UserInfo);
            }
            else if (selectedTag == "ReportPage")
            {
                contentFrame.Navigate(typeof(ReportPage), UserInfo);
            }
            else if (args.IsSettingsSelected)
            {
                contentFrame.Navigate(typeof(SettingsPage));
            }

        }

        void updateStreak(SignInViewModel user, string today)
        {
            var sql = new SQLDao();
            string query = $@"
                update [USER] set streak = streak + 1, StreakDay = @today
                where Email = @mail
                ";
            using (SqlConnection connection = new SqlConnection(sql.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@mail", user.Email);
                command.Parameters.AddWithValue("@today", today);
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
        }

        Dictionary<DateTime, int> getStreak(SignInViewModel user)
        {
            var sql = new SQLDao();
            string query = $@"
                select  StreakDay,Streak from [USER]
                where Email = @mail
                ";
            Dictionary<DateTime, int> streak = new Dictionary<DateTime, int>();
            using (SqlConnection connection = new SqlConnection(sql.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@mail", user.Email);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        streak[reader.GetDateTime(0)] =
                            Convert.ToInt32(reader["Streak"]);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return streak;
        }

        private async Task ShowHealthDialog(int streak)
        {
            // Style for ContentDialog
            var dialogStyle = new Style(typeof(ContentDialog));
            dialogStyle.Setters.Add(new Setter(ContentDialog.BackgroundProperty, new SolidColorBrush(Colors.LightCyan))); // Xanh nhạt
            dialogStyle.Setters.Add(new Setter(ContentDialog.ForegroundProperty, new SolidColorBrush(Colors.DarkGreen))); // Màu chữ xanh đậm
            dialogStyle.Setters.Add(new Setter(ContentDialog.BorderBrushProperty, new SolidColorBrush(Colors.LightGreen))); // Viền xanh lá nhạt
            dialogStyle.Setters.Add(new Setter(ContentDialog.BorderThicknessProperty, new Thickness(3)));
            dialogStyle.Setters.Add(new Setter(ContentDialog.CornerRadiusProperty, new CornerRadius(15))); // Bo góc

            // Style for button
            var cancelButton = new Button
            {
                Content = "Great!",
                HorizontalAlignment = HorizontalAlignment.Center,
                Background = new SolidColorBrush(Colors.MediumSeaGreen),
                Foreground = new SolidColorBrush(Colors.White),
                BorderBrush = new SolidColorBrush(Colors.SeaGreen),
                BorderThickness = new Thickness(2),
                CornerRadius = new CornerRadius(10),
                Padding = new Thickness(20, 10, 20, 10)
            };


            var encouragement = new EncourageSentence();
            // content for ContentDialog
            var dialogContent = new StackPanel
            {
                Spacing = 15,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            var healthImage = new Image
            {
                Source = new Microsoft.UI.Xaml.Media.Imaging.BitmapImage(new Uri("ms-appx:///Assets/streak.png")), // Thay đường dẫn ảnh
                Height = 100,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            var messageText = new TextBlock
            {
                Text = encouragement.getRandomSentence(),
                TextAlignment = TextAlignment.Center,
                FontSize = 16,
                Foreground = new SolidColorBrush(Colors.ForestGreen)
            };

            dialogContent.Children.Add(healthImage);
            dialogContent.Children.Add(messageText);
            dialogContent.Children.Add(cancelButton);

            // create ContentDialog
            var healthDialog = new ContentDialog()
            {
                XamlRoot = this.Content.XamlRoot,
                Title = $"Congratulation you have streak for {streak} days",
                Content = dialogContent,
                Style = dialogStyle,

            };
            cancelButton.Click += (s, e) =>
            {
                // close dialog
                healthDialog.Hide();
            };
            // show ContentDialog
            await healthDialog.ShowAsync();

        }


        private async void changeAvatar_Click(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker();

            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hwnd);

            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            //Domain support
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.Read))
                {
                    //Change image to SoftwareBitmap
                    BitmapDecoder decoder = await BitmapDecoder.CreateAsync(fileStream);
                    SoftwareBitmap softwareBitmap = await decoder.GetSoftwareBitmapAsync();

                    // change SoftwareBitmap to bitmapImage
                    var imageSource = new SoftwareBitmapSource();
                    if (softwareBitmap.PixelWidth > 0 && softwareBitmap.PixelHeight > 0)
                    {
                        // Change pixel to BRGA8
                        if (softwareBitmap.BitmapPixelFormat != BitmapPixelFormat.Bgra8 ||
                            softwareBitmap.BitmapAlphaMode != BitmapAlphaMode.Premultiplied)
                        {
                            // Change BRGA8 with multiple alpha
                            var convertedBitmap = SoftwareBitmap.Convert(softwareBitmap, BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied);
                            await imageSource.SetBitmapAsync(convertedBitmap);
                        }
                        else
                        {
                            // Nếu đã đúng định dạng, sử dụng trực tiếp
                            await imageSource.SetBitmapAsync(softwareBitmap);
                        }
                    }

                    userAvatar.Source = imageSource;

                    // Convert SoftwareBitmap to byte array and save to database
                    avatarViewModel.imageBytes = await ConvertSoftwareBitmapToByteArray(softwareBitmap);
                    await avatarViewModel.SaveAvatarAsync();
                }
            }
        }

        private async Task<byte[]> ConvertSoftwareBitmapToByteArray(SoftwareBitmap softwareBitmap)
        {
            using (var stream = new InMemoryRandomAccessStream())
            {
                BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
                encoder.SetSoftwareBitmap(softwareBitmap);
                await encoder.FlushAsync();

                using (var reader = new DataReader(stream.GetInputStreamAt(0)))
                {
                    var bytes = new byte[stream.Size];
                    await reader.LoadAsync((uint)stream.Size);
                    reader.ReadBytes(bytes);
                    return bytes;
                }
            }
        }

        private async Task<SoftwareBitmap> ConvertByteArrayToSoftwareBitmap(byte[] imageBytes)
        {
            using (var stream = new InMemoryRandomAccessStream())
            {
                await stream.WriteAsync(imageBytes.AsBuffer());
                stream.Seek(0);

                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
                SoftwareBitmap softwareBitmap = await decoder.GetSoftwareBitmapAsync();

                // Convert to Bgra8 and Premultiplied if necessary
                if (softwareBitmap.BitmapPixelFormat != BitmapPixelFormat.Bgra8 ||
                    softwareBitmap.BitmapAlphaMode != BitmapAlphaMode.Premultiplied)
                {
                    softwareBitmap = SoftwareBitmap.Convert(softwareBitmap, BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied);
                }

                return softwareBitmap;
            }
        }

        private async void LoadAvatar()
        {
            byte[] imageBytes = await avatarViewModel.GetAvatarAsync();
            if (imageBytes != null)
            {
                SoftwareBitmap softwareBitmap = await ConvertByteArrayToSoftwareBitmap(imageBytes);

                // Check properties
                if (softwareBitmap.PixelWidth > 0 && softwareBitmap.PixelHeight > 0 &&
                    softwareBitmap.BitmapPixelFormat == BitmapPixelFormat.Bgra8 &&
                    (softwareBitmap.BitmapAlphaMode == BitmapAlphaMode.Premultiplied || softwareBitmap.BitmapAlphaMode == BitmapAlphaMode.Ignore))
                {
                    var imageSource = new SoftwareBitmapSource();
                    await imageSource.SetBitmapAsync(softwareBitmap);
                    userAvatar.Source = imageSource;
                }
                else
                {
                    // Handle invalid SoftwareBitmap
                    Debug.WriteLine("Invalid SoftwareBitmap properties");
                }
            }
        }

    }
}

