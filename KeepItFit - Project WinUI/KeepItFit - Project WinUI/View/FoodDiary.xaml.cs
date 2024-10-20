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
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace KeepItFit___Project_WinUI
{
    public sealed partial class FoodDiary : Page
    {
        public class DashBoardNutritions
        {
            public List<Nutritions> nutrition { get; set; }
            public List<Meals> mealList { get; set; }
            public void initNutrition()
            {
                IDao dao = new MockDAO();
                nutrition = dao.GetAllNutrtion();

            }
            public void initMeal()
            {
                IDao dao = new MockDAO();
                mealList = dao.GetAllMeals();
            }
        }

        public DashBoardNutritions nutri { get; set; }
        public FoodDiary()
        {
            this.InitializeComponent();
            nutri = new DashBoardNutritions();
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

    }
}
