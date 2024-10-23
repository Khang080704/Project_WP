using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeepItFit___Project_WinUI.ViewModel;

namespace KeepItFit___Project_WinUI.Model
{
    public class MockDAO : IDao
    {
        public ObservableCollection<Meals> GetAllMeals()
        {
            var result = new ObservableCollection<Meals>()
            {
                new Meals() {
                    mealName = "BreakFast"
                },
                new Meals() {
                    mealName = "Lunch"
                },
                new Meals() {
                    mealName = "Dinner"
                },
                new Meals()
                {
                    mealName = "Snacks"
                }
            };
            return result;
        }

        public ObservableCollection<Food> GetFoodRecent()
        {
            var result = new ObservableCollection<Food>()
            {
                new Food() {
                    foodName = "Chicken Breast",
                    foodCalories = 165,
                    foodCarbs = 0,
                    foodFat = 3.6f,
                    foodProtein = 31,
                    foodSodium = 74,
                    foodSugar = 0,
                    foodQuantity = 1,
                    foodUnit = new List<string>{"grams", "oz", "lb", "kilograms"}
                },
                new Food() {
                    foodName = "Noodles",
                    foodCalories = 138,           
                    foodCarbs = 25,               
                    foodFat = 1.1f,             
                    foodProtein = 4.5f,      
                    foodSodium = 6,           
                    foodSugar = 0.9f,
                    foodQuantity = 1,
                    foodUnit = new List<string>{"grams", "oz", "lb", "kilograms" }
                },
                new Food() {
                    foodName = "Potato Salad",
                    foodCalories = 143,            
                    foodCarbs = 17,                
                    foodFat = 7.5f,                
                    foodProtein = 2.1f,           
                    foodSodium = 450,              
                    foodSugar = 2.5f,              
                    foodQuantity = 1,              
                    foodUnit = new List<string>{"grams", "cup"}
                },
                new Food() {
                    foodName = "Egg",
                    foodCalories = 78,
                    foodCarbs = 0.6f,
                    foodFat = 5.3f,
                    foodProtein = 6.3f,
                    foodSodium = 62,
                    foodSugar = 0.6f,
                    foodQuantity = 1,
                    foodUnit = new List<string>{ "piece", "grams", "dozen" }
                },
            };
            return result;
        }

        public ObservableCollection<Food> GetFoodFrequent()
        {
            var result = new ObservableCollection<Food>()
            {
                new Food() {
                    foodName = "Potato Salad",
                    foodCalories = 143,
                    foodCarbs = 17,
                    foodFat = 7.5f,
                    foodProtein = 2.1f,
                    foodSodium = 450,
                    foodSugar = 2.5f,
                    foodQuantity = 1,
                    foodUnit = new List<string>{"grams", "cup"}
                },
                new Food() {
                    foodName = "Orange",
                    foodCalories = 47,            
                    foodCarbs = 12,               
                    foodFat = 0.1f,               
                    foodProtein = 0.9f,           
                    foodSodium = 0,               
                    foodSugar = 9,                
                    foodQuantity = 100,          
                    foodUnit = new List<string>{"piece", "grams"}
                },
                new Food() {
                    foodName = "Egg",
                    foodCalories = 78,
                    foodCarbs = 0.6f,
                    foodFat = 5.3f,
                    foodProtein = 6.3f,
                    foodSodium = 62,
                    foodSugar = 0.6f,
                    foodQuantity = 1,
                    foodUnit = new List<string>{ "piece", "grams", "dozen" }
                },
                new Food() {
                    foodName = "Broccoli",
                    foodCalories = 55,
                    foodCarbs = 11,
                    foodFat = 0.6f,
                    foodProtein = 3.7f,
                    foodSodium = 33,
                    foodSugar = 2.2f,
                    foodQuantity = 100,
                    foodUnit = new List<string>{"grams", "oz", "lb", "kilograms" }
                },      
            };

            return result;
        }

        public List<Nutritions> GetAllNutrtion()
        {
            var result = new List<Nutritions>()
            {

                new Nutritions()
                {
                    name = "Calories",
                    Total = 0,
                    Daily = 0,
                    Remain = 0,
                    unit = "kcal",
                },
                new Nutritions()
                {
                    name = "Carbs",
                    Total = 0,
                    Daily = 0,
                    Remain = 0,
                    unit = "g"
                },
                new Nutritions()
                {
                    name = "Fat",
                    Total = 0,
                    Daily = 0,
                    Remain = 0,
                    unit = "g",
                },
                new Nutritions()
                {
                    name = "Protein",
                    Total = 0,
                    Daily = 0,
                    Remain = 0,
                    unit = "g",
                },
                new Nutritions()
                {
                    name = "Sodium",
                    Total = 0,
                    Daily = 0,
                    Remain = 0,
                    unit = "mg"
                },
                new Nutritions()
                {
                    name = "Sugar",
                    Total = 0,
                    Daily = 0,
                    Remain = 0,
                    unit = "g"
                },
            };
            return result;
        }
    }



}
