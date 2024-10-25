using KeepItFit___Project_WinUI.Model;
using KeepItFit___Project_WinUI.View;
using KeepItFit___Project_WinUI.ViewModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.Extensions.DependencyInjection;

namespace KeepItFit___Project_WinUI
{
    
    public sealed partial class FoodDiary : Page
    {
        public NutritionsViewModel nutri { get; set; }
        public FoodDiary()
        {
            this.InitializeComponent();

            
            nutri = new NutritionsViewModel();
            nutri.initNutrition();
            nutri.initMeal();
            
            
            
        }
        
        private void TextBlock_Tapped_QuickAdd(object sender, TappedRoutedEventArgs e)
        {
            TextBlock mealClicked = sender as TextBlock;
            var meal = mealClicked.DataContext as Meals;
            string mealName = meal.mealName;
            this.Frame.Navigate(typeof(FoodPage), mealName);
        }

        private void TextBlock_Tapped_Meal(object sender, TappedRoutedEventArgs e)
        {
            //Because of changing food layout with MVVM, so you can't define which textblock 
            //is clicked by name. I find which textblock is binding with Meals
            //so that I get the meal's name in that textblock.Text and pass 
            //to Navigate
            TextBlock mealClicked = sender as TextBlock;
            var meal = mealClicked.DataContext as Meals;
            string mealName = meal.mealName;
            this.Frame.Navigate(typeof(AddFood), mealName);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if(e.Parameter is Dictionary<string, int[]>)
            {
                Dictionary<string, int[]> result = e.Parameter as Dictionary<string, int[]>;
                
                string name = result.Keys.First();
                int[] list = result[name];
                int count = 0;

                foreach(var i in nutri.nutrition)
                {
                    i.Total += list[count++];
                    i.Remain = i.Daily - i.Total;
                }

            }

        }



    }
}
