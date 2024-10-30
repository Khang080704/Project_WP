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

namespace KeepItFit___Project_WinUI
{
    
    public sealed partial class FoodDiary : Page
    {
        public NutritionsViewModel nutri { get; set; }
        public InputNutritionViewModel BreakFastNutri { get; set; }
        public InputNutritionViewModel LunchNutri { get; set; }
        public InputNutritionViewModel DinnerNutri { get; set; }
        public InputNutritionViewModel SnackNutri { get; set; }

        public FoodDiary()
        {
            this.InitializeComponent();
            nutri = new NutritionsViewModel();
            nutri.initNutrition();
            nutri.initMeal();

            BreakFastNutri = new InputNutritionViewModel();
            LunchNutri = new InputNutritionViewModel();
            DinnerNutri = new InputNutritionViewModel();
            SnackNutri = new InputNutritionViewModel();

            BreakFastNutri.NutritionData = BreakFastNutri.init();
            LunchNutri.NutritionData = LunchNutri.init();
            DinnerNutri.NutritionData = DinnerNutri.init();
            SnackNutri.NutritionData = SnackNutri.init();

            
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
            // Dictionary chứa ten bữa ăn (breakfast, lunch,...) 
            // và danh sách thông số chất dinh dưỡng (calo, carbs,...)
            if(e.Parameter is Dictionary<string, List<int>>)
            {
                Dictionary<string, List<int>> result = e.Parameter as Dictionary<string, List<int>>;
                
                string name = result.Keys.First(); //Get meal name
                List<int> list = result[name]; //Nutrion data list

                if (name == "BreakFast")
                {
                    BreakFastNutri.update(list);
                  
                }
                else if(name == "Lunch")
                {
                    LunchNutri.update(list);
                }
                else if(name == "Dinner")
                {
                    DinnerNutri.update(list);
                }
                else
                {
                    SnackNutri.update(list);
                }

                foreach (var i in nutri.nutrition)
                {
                    i.Total = 0;
                }
                updateTotal();

            }
            else if (e.Parameter is NavigationParameters_AddFood_ToFoodDiary parameters_1)
            {
                List<Food> foodList = parameters_1.foodList;
                string mealName = parameters_1.mealName;

                //Đây là từ AddFood sang FoodDiary
                if (mealName == "BreakFast")
                {
                    BreakFastNutri.updateWithListFood(foodList);
                }
                else if(mealName == "Lunch")
                {
                    LunchNutri.updateWithListFood(foodList);
                }
                else if(mealName == "Dinner")
                {
                    DinnerNutri.updateWithListFood(foodList);
                }
                else
                {
                    SnackNutri.updateWithListFood(foodList);
                }

                foreach (var i in nutri.nutrition)
                {
                    i.Total = 0;
                }
                updateTotal();

            }
            else if (e.Parameter is NavigationParameters_SearchFood parameters_2)
            {
                Food food = parameters_2.selectedFood;
                string mealName = parameters_2.selectedMeal.mealName;

                if (mealName == "BreakFast")
                {
                    BreakFastNutri.updateWithFood(food);
                }
                else if (mealName == "Lunch")
                {
                    LunchNutri.updateWithFood(food);
                }
                else if (mealName == "Dinner")
                {
                    DinnerNutri.updateWithFood(food);
                }
                else
                {
                    SnackNutri.updateWithFood(food);
                }

                foreach (var i in nutri.nutrition)
                {
                    i.Total = 0;
                }
                updateTotal();
            }
            else if(e.Parameter is NavigationParameters_AddFood_ToFoodDiary parameters_1)
            {
                List<Food> foodList = parameters_1.foodList;
                string mealName = parameters_1.mealName;

                //?�y l� t? AddFood sang FoodDiary
            }    
            else if (e.Parameter is NavigationParameters_SearchFood parameters_2)
            {
                Food food = parameters_2.selectedFood;
                string mealName = parameters_2.selectedMeal.mealName;

                //?�y l� t? SearchFood sang FoodDiary
            }
        }

        void updateForMeal(InputNutritionViewModel src)
        {
            foreach (var i in src.NutritionData)
            {
                nutri.nutrition[0].Total += i.CaloriesInput;
                nutri.nutrition[1].Total += i.CarbsInput;
                nutri.nutrition[2].Total += i.FatInput;
                nutri.nutrition[3].Total += i.ProteinInput;
                nutri.nutrition[4].Total += i.SodiumInput;
                nutri.nutrition[5].Total += i.SugarInput;
            }
            
        }


        void updateTotal()
        {
            //Update for break
            updateForMeal(BreakFastNutri);
            updateForMeal(LunchNutri);
            updateForMeal(DinnerNutri);
            updateForMeal(SnackNutri);
            foreach (var i in nutri.nutrition)
            {
                i.Remain = i.Daily - i.Total;
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var itemToDelete = btn?.Tag as InputNutritionData;
            if (itemToDelete != null)
            {
                if (BreakFastNutri.NutritionData.Contains(itemToDelete))
                {
                    BreakFastNutri.NutritionData.Remove(itemToDelete);
                }
                else if (LunchNutri.NutritionData.Contains(itemToDelete))
                {
                    LunchNutri.NutritionData.Remove(itemToDelete);
                }
                else if (DinnerNutri.NutritionData.Contains(itemToDelete))
                {
                    DinnerNutri.NutritionData.Remove(itemToDelete);
                }
                else
                {
                    SnackNutri.NutritionData.Remove(itemToDelete);
                }
                
            }

            foreach (var i in nutri.nutrition)
            {
                i.Total = 0;
            }
            updateTotal();
        }
    }
}
