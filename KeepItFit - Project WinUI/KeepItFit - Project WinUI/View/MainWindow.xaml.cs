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

namespace KeepItFit___Project_WinUI
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void nvSample_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var selectionItem = args.SelectedItem as NavigationViewItem;
            string selectedTag = selectionItem.Tag as string;
            if (selectedTag == "FoodDiary")
            {
                contentFrame.Navigate(typeof(FoodDiary));
            }
            else if (selectedTag == "ExercisePage")
            {
                contentFrame.Navigate(typeof(ExercisePage));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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
                }

                await SaveAvatar(file);
            }
        }

        private async Task SaveAvatar(StorageFile file)
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            await file.CopyAsync(localFolder, "user_avatar.png", NameCollisionOption.ReplaceExisting);
        }

        private async void LoadAvatar()
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            try
            {
                var file = await localFolder.GetFileAsync("user_avatar.png");
                if (file != null)
                {
                    using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.Read))
                    {
                        BitmapDecoder decoder = await BitmapDecoder.CreateAsync(fileStream);
                        SoftwareBitmap softwareBitmap = await decoder.GetSoftwareBitmapAsync();

                        var imageSource = new SoftwareBitmapSource();
                        await imageSource.SetBitmapAsync(softwareBitmap);

                        userAvatar.Source = imageSource;
                    }
                }
            }
            catch (FileNotFoundException)
            {
            }
        }
    }
}
