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
using static KeepItFit___Project_WinUI.View.AddFood;
using static KeepItFit___Project_WinUI.View.SearchFood;
using Windows.UI.Core;
using KeepItFit___Project_WinUI.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections;
using System.Data.SqlClient;

namespace KeepItFit___Project_WinUI
{

    public sealed partial class FoodDiary : Page
    {
        public FoodDiaryViewModel viewModel { get; set; }

        public FoodDiary()
        {
            this.InitializeComponent();
            viewModel = new FoodDiaryViewModel();
        }

        //Navigate to FoodPage button Quick Add
        private void TextBlock_Tapped_QuickAdd(object sender, TappedRoutedEventArgs e)
        {
           
            TextBlock mealClicked = sender as TextBlock;
            string mealName = mealClicked.Name;
            if(mealName == "_BreakFast")
            {
                this.Frame.Navigate(typeof(FoodPage), "BreakFast");
            }
            else if(mealName == "_Lunch")
            {
                this.Frame.Navigate(typeof(FoodPage), "Lunch");
            }
            else if(mealName == "_Dinner")
            {
                this.Frame.Navigate(typeof(FoodPage), "Dinner");
            }
            else
            {
                this.Frame.Navigate(typeof(FoodPage), "Snacks");
            }
            
        }

        //Navigate to AddFood Page
        private void TextBlock_Tapped_Meal(object sender, TappedRoutedEventArgs e)
        {
            //Because of changing food layout with MVVM, so you can't define which textblock 
            //is clicked by name. I find which textblock is binding with Meals
            //so that I get the meal's name in that textblock.Text and pass 
            //to Navigate
            TextBlock mealClicked = sender as TextBlock;
            string mealName = mealClicked.Name;
            this.Frame.Navigate(typeof(AddFood), mealName);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            // Dictionary contains meal's name (breakfast, lunch,...) 
            // and nutrition list (calo, carbs,...)
            if(e.Parameter is Dictionary<string, List<int>>)
            {
                //Data send from FoodPage
                Dictionary<string, List<int>> result = e.Parameter as Dictionary<string, List<int>>;
                
                string name = result.Keys.First(); //Get meal name
                List<int> list = result[name]; //Nutrion data list

                //Check meal's name, call the InputNutritionViewModel respectively
                if (name == "BreakFast")
                {
                    viewModel.Update_QuickAdd(list, "QuickAdd_Breakfast");

                }
                else if(name == "Lunch")
                {
                    viewModel.Update_QuickAdd(list, "QuickAdd_Lunch");
                }
                else if(name == "Dinner")
                {
                    viewModel.Update_QuickAdd(list, "QuickAdd_Dinner");
                }
                else
                {
                    viewModel.Update_QuickAdd(list, "QuickAdd_Snack");
                }

                viewModel.UpdateDataAllMeals();
                viewModel.updateTotal();

            }
            else if (e.Parameter is NavigationParameters_AddFood_RecentOrFrequent_ToFoodDiary parameters_1)
            {
                //AddFood with RecentFood or FrequentFood to FoodDiary
                List<Food> foodList = parameters_1.foodList;
                string mealName = parameters_1.mealName;

                if (mealName == "BreakFast")
                {
                    viewModel.Update_Food(foodList, "BreakfastDiary");
                }
                else if(mealName == "Lunch")
                {
                    viewModel.Update_Food(foodList, "LunchDiary");
                }
                else if(mealName == "Dinner")
                {
                    viewModel.Update_Food(foodList, "DinnerDiary");
                }
                else
                {
                    viewModel.Update_Food(foodList, "SnackDiary");
                }

                viewModel.UpdateDataAllMeals();
                viewModel.updateTotal();

            }
            else if(e.Parameter is NavigationParameters_AddFood_MyFood_ToSearchFood paramaters_2)
            {
                //AddFood with MyFood to FoodDiary
                List<Food> foodList = paramaters_2.foodList;
                string mealName = paramaters_2.mealName;

                if (mealName == "BreakFast")
                {
                    viewModel.Update_Food(foodList, "MyFood_Breakfast");
                }
                else if (mealName == "Lunch")
                {
                    viewModel.Update_Food(foodList, "MyFood_Lunch");
                }
                else if (mealName == "Dinner")
                {
                    viewModel.Update_Food(foodList, "MyFood_Dinner");
                }
                else
                {
                    viewModel.Update_Food(foodList, "MyFood_Snack");
                }

                viewModel.UpdateDataAllMeals();
                viewModel.updateTotal();
            }
            else if (e.Parameter is NavigationParameters_SearchFood parameters_3)
            {
                //Search Food to FoodDiary
                Food food = parameters_3.selectedFood;
                string mealName = parameters_3.selectedMeal.mealName;
                List<Food> foodList = new List<Food>();
                foodList.Add(food);

                if (mealName == "BreakFast")
                {
                    viewModel.Update_Food(foodList, "BreakfastDiary");
                }
                else if (mealName == "Lunch")
                {
                    viewModel.Update_Food(foodList, "LunchDiary");
                }
                else if (mealName == "Dinner")
                {
                    viewModel.Update_Food(foodList, "DinnerDiary");
                }
                else
                {
                    viewModel.Update_Food(foodList, "SnackDiary");
                }

                viewModel.UpdateDataAllMeals();
                viewModel.updateTotal();
            }
            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //Delete 1 line
            var btn = sender as Button;
            var itemToDelete = btn?.Tag as InputNutritionData;
            if (itemToDelete != null)
            {
                if (viewModel.BreakFastNutri.NutritionData.Contains(itemToDelete))
                {
                    viewModel.Delete_FoodBreakfast(itemToDelete);
                }
                else if (viewModel.LunchNutri.NutritionData.Contains(itemToDelete))
                {
                    viewModel.Delete_FoodLunch(itemToDelete);
                }
                else if (viewModel.DinnerNutri.NutritionData.Contains(itemToDelete))
                {
                    viewModel.Delete_FoodDinner(itemToDelete);
                }
                else
                {
                    viewModel.Delete_FoodSnack(itemToDelete);
                }
                
            }

            viewModel.updateTotal();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int result = viewModel.nutri.nutrition[0].Remain;
            var screen = new NutritionResult(result);
            screen.Activate();
        }
    }
}
