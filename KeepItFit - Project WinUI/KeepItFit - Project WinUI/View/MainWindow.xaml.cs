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
    }
}
