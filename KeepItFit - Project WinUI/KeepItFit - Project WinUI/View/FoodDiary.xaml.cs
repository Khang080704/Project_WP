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

namespace KeepItFit___Project_WinUI
{

    public sealed partial class FoodDiary : Page
    {
        public FoodDiaryViewModel viewModel { get; set; }

        public NutritionsViewModel nutri { get; set; }
        

        public FoodDiary()
        {
            this.InitializeComponent();
            viewModel = new FoodDiaryViewModel();

            nutri = new NutritionsViewModel();
            nutri.initNutrition();
            nutri.initMeal();

            updateTotal();
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
                    //Add new list into viewModel
                    viewModel.BreakFastNutri.update(list);
                  
                }
                else if(name == "Lunch")
                {
                    viewModel.LunchNutri.update(list);
                }
                else if(name == "Dinner")
                {
                    viewModel.DinnerNutri.update(list);
                }
                else
                {
                    viewModel.SnackNutri.update(list);
                }

                //In the table, set all total's value = 0, calcaulate again
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
                    viewModel.Update_FoodBreakfast(foodList);
                }
                else if(mealName == "Lunch")
                {
                    viewModel.Update_FoodLunch(foodList);
                }
                else if(mealName == "Dinner")
                {
                    viewModel.Update_FoodDinner(foodList);
                }
                else
                {
                    viewModel.Update_FoodSnack(foodList);
                }

                viewModel.UpdateDataAllMeals();

                foreach (var i in nutri.nutrition)
                {
                    i.Total = 0;
                }
                updateTotal();

            }
            else if (e.Parameter is NavigationParameters_SearchFood parameters_2)
            {
                //Search Food to FoodDiary
                Food food = parameters_2.selectedFood;
                string mealName = parameters_2.selectedMeal.mealName;
                List<Food> foodList = new List<Food>();
                foodList.Add(food);

                if (mealName == "BreakFast")
                {
                    viewModel.Update_FoodBreakfast(foodList);
                }
                else if (mealName == "Lunch")
                {
                    viewModel.Update_FoodLunch(foodList);
                }
                else if (mealName == "Dinner")
                {
                    viewModel.Update_FoodDinner(foodList);
                }
                else
                {
                    viewModel.Update_FoodSnack(foodList);
                }

                viewModel.UpdateDataAllMeals();

                foreach (var i in nutri.nutrition)
                {
                    i.Total = 0;
                }
                updateTotal();
            }
            
        }

        //nutri.nutrition contains list of nutritions in order
        //[0] : calories
        //[1]: Carbs
        //...
        //When add a new InputNutritionViewModel to list,
        //update total's value of nutrion by calculate sum 
        //of all elements in src
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
            //Calculate the total's value of all meal
            updateForMeal(viewModel.BreakFastNutri);
            updateForMeal(viewModel.LunchNutri);
            updateForMeal(viewModel.DinnerNutri);
            updateForMeal(viewModel.SnackNutri);
            //Cal the remain
            foreach (var i in nutri.nutrition)
            {
                i.Remain = i.Daily - i.Total;
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

            //Set value to 0 and calculate from begin
            foreach (var i in nutri.nutrition)
            {
                i.Total = 0;
            }
            updateTotal();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int result = nutri.nutrition[0].Remain;
            var screen = new NutritionResult(result);
            screen.Activate();
        }
    }
}
