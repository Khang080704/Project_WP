using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeepItFit___Project_WinUI.ViewModel;

namespace KeepItFit___Project_WinUI.Model
{
    public class MockDAO : IDao
    {
        public List<Meals> GetAllMeals()
        {
            var result = new List<Meals>()
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

        public List<Food> GetFoodRecent()
        {
            var result = new List<Food>()
            {
                new Food() {
                    foodName = "Apple",
                    foodCalories = 52,
                    foodCarbs = 14,
                    foodFat = 0.2f,
                    foodProtein = 0.3f,
                    foodSodium = 1,
                    foodSugar = 10,
                    foodQuantity = 1,
                    foodUnit = "medium"
                },
                new Food() {
                    foodName = "Banana",
                    foodCalories = 89,
                    foodCarbs = 23,
                    foodFat = 0.3f,
                    foodProtein = 1.1f,
                    foodSodium = 1,
                    foodSugar = 12,
                    foodQuantity = 1,
                    foodUnit = "large"
                },
                new Food() {
                    foodName = "Orange",
                    foodCalories = 62,
                    foodCarbs = 15,
                    foodFat = 0.2f,
                    foodProtein = 1.2f,
                    foodSodium = 1,
                    foodSugar = 12,
                    foodQuantity = 1,
                    foodUnit = "slice"
                },
            };
            return result;
        }

        public List<Food> GetFoodFrequent()
        {
            var result = new List<Food>()
            {
                new Food() {
                    foodName = "Chicken Breast",
                    foodCalories = 165,
                    foodCarbs = 0,
                    foodFat = 3.6f,
                    foodProtein = 31f,
                    foodSodium = 74,
                    foodSugar = 0,
                    foodQuantity = 100,
                    foodUnit = "grams"
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
                    foodUnit = "large"
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
                    foodUnit = "grams"
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
            Remain = 0
        },
        new Nutritions()
        {
            name = "Carbs",
            Total = 0,
            Daily = 0,
            Remain = 0
        },
        new Nutritions()
        {
            name = "Fat",
            Total = 0,
            Daily = 0,
            Remain = 0
        },
        new Nutritions()
        {
            name = "Protein",
            Total = 0,
            Daily = 0,
            Remain = 0
        },
        new Nutritions()
        {
            name = "Sodium",
            Total = 0,
            Daily = 0,
            Remain = 0
        },
        new Nutritions()
        {
            name = "Sugar",
            Total = 0,
            Daily = 0,
            Remain = 0
        }
    };
            return result;
        }
    }



}
