using KeepItFit___Project_WinUI.View;
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
    public sealed partial class FoodDiary : Page
    {
        public FoodDiary()
        {
            this.InitializeComponent();
        }
        private void TextBlock_Tapped_QuickAdd(object sender, TappedRoutedEventArgs e)
        {
            TextBlock mealClicked = sender as TextBlock;
            string mealName = mealClicked.Name;
            this.Frame.Navigate(typeof(FoodPage), mealName);
        }

        private void TextBlock_Tapped_Meal(object sender, TappedRoutedEventArgs e)
        {
            TextBlock mealClicked = sender as TextBlock;
            string mealName = mealClicked.Name;
            this.Frame.Navigate(typeof(AddFood), mealName);
        }
    }
}
