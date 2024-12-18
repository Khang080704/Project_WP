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

namespace KeepItFit___Project_WinUI
{
    
    public sealed partial class MainWindow : Window
    {
        public AvatarViewModel avatarViewModel = new AvatarViewModel();

        public string userEmail { get; set; }

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

            LoadAvatar();
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
                contentFrame.Navigate(typeof(ExercisePage));
            }
            else if(selectedTag == "HomePage")
            {
                contentFrame.Navigate(typeof(HomePage));
            }
            else if (args.IsSettingsSelected)
            {
                contentFrame.Navigate(typeof(SettingsPage));
            }

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
