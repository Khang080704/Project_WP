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
        //Database of food
        public ObservableCollection<Food> GetFoodDatabase()
        {
            var result = new ObservableCollection<Food>()
            {
                new Food {
                    foodName = "Chicken Breast",
                    foodCalories = 165,
                    foodCarbs = 0,
                    foodFat = 3.6f,
                    foodProtein = 31,
                    foodSodium = 74,
                    foodSugar = 0,
                    foodQuantity = "1",
                    foodUnit = new List<string> { "grams", "oz", "kilograms" } // Thịt gà thường đo bằng gram, ounce, kilogram
                },
                new Food {
                    foodName = "Salmon",
                    foodCalories = 208,
                    foodCarbs = 0,
                    foodFat = 13f,
                    foodProtein = 20,
                    foodSodium = 59,
                    foodSugar = 0,
                    foodQuantity = "1",
                    foodUnit = new List<string> { "grams", "oz", "fillet", "kilograms" } // Cá hồi có thể tính theo gram, ounce, miếng fillet, kilogram
                },
                new Food {
                    foodName = "Broccoli",
                    foodCalories = 55,
                    foodCarbs = 11.2f,
                    foodFat = 0.6f,
                    foodProtein = 3.7f,
                    foodSodium = 49,
                    foodSugar = 2.2f,
                    foodQuantity = "1",
                    foodUnit = new List<string> { "grams", "cup", "stalk", "kilograms" } // Súp lơ thường đo bằng gram, cốc, hoặc cây (stalk)
                },
                new Food {
                    foodName = "Avocado",
                    foodCalories = 160,
                    foodCarbs = 8.5f,
                    foodFat = 14.7f,
                    foodProtein = 2,
                    foodSodium = 7,
                    foodSugar = 0.7f,
                    foodQuantity = "1",
                    foodUnit = new List<string> { "grams", "half", "whole", "kilograms" } // Bơ có thể đo bằng gram, nửa quả, hoặc cả quả
                },
                new Food {
                    foodName = "Almonds",
                    foodCalories = 579,
                    foodCarbs = 21.6f,
                    foodFat = 49.9f,
                    foodProtein = 21.2f,
                    foodSodium = 1,
                    foodSugar = 4.4f,
                    foodQuantity = "1",
                    foodUnit = new List<string> { "grams", "oz", "handful", "kilograms" } // Hạnh nhân có thể đo bằng gram, ounce, hoặc bằng tay nắm (handful)
                },
                new Food {
                    foodName = "Brown Rice",
                    foodCalories = 123,
                    foodCarbs = 25.6f,
                    foodFat = 1.0f,
                    foodProtein = 2.7f,
                    foodSodium = 4,
                    foodSugar = 0.4f,
                    foodQuantity = "1",
                    foodUnit = new List<string> { "grams", "cup", "kilograms" } // Gạo lứt đo bằng gram, cốc (cup), hoặc kilogram
                },
                new Food {
                    foodName = "Eggs",
                    foodCalories = 155,
                    foodCarbs = 1.1f,
                    foodFat = 10.6f,
                    foodProtein = 13,
                    foodSodium = 124,
                    foodSugar = 1.1f,
                    foodQuantity = "1",
                    foodUnit = new List<string> { "unit", "dozen" } // Trứng thường đo bằng đơn vị quả (unit) hoặc tá (dozen)
                },
                new Food {
                    foodName = "Banana",
                    foodCalories = 89,
                    foodCarbs = 22.8f,
                    foodFat = 0.3f,
                    foodProtein = 1.1f,
                    foodSodium = 1,
                    foodSugar = 12.2f,
                    foodQuantity = "1",
                    foodUnit = new List<string> { "unit", "grams", "bunch" } // Chuối đo bằng quả, gram, hoặc chùm (bunch)
                },
                new Food {
                    foodName = "Greek Yogurt",
                    foodCalories = 59,
                    foodCarbs = 3.6f,
                    foodFat = 0.4f,
                    foodProtein = 10,
                    foodSodium = 36,
                    foodSugar = 3.2f,
                    foodQuantity = "1",
                    foodUnit = new List<string> { "grams", "oz", "cup" } // Sữa chua Hy Lạp đo bằng gram, ounce, hoặc cốc
                },
                new Food {
                    foodName = "Sweet Potato",
                    foodCalories = 86,
                    foodCarbs = 20.1f,
                    foodFat = 0.1f,
                    foodProtein = 1.6f,
                    foodSodium = 55,
                    foodSugar = 4.2f,
                    foodQuantity = "1",
                    foodUnit = new List<string> { "grams", "unit", "kilograms" } // Khoai lang có thể đo bằng gram, quả, hoặc kilogram
                }
            };

            return result;
        }

        public ObservableCollection<Meals> GetAllMeals()
        {
            var result = new ObservableCollection<Meals>()
            {
                new Meals() {
                    mealName = "BreakFast",
                    nutriList = GetAllNutrtion()
                },
                new Meals() {
                    mealName = "Lunch",
                    nutriList = GetAllNutrtion()
                },
                new Meals() {
                    mealName = "Dinner",
                    nutriList = GetAllNutrtion()
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
                    foodQuantity = "1",
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
                    foodQuantity = "1",
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
                    foodQuantity = "1",              
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
                    foodQuantity = "1",
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
                    foodQuantity = "1",
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
                    foodQuantity = "1",          
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
                    foodQuantity = "1",
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
                    foodQuantity = "1",
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
                    Daily = 2300,
                    Remain = 0,
                    unit = "kcal",
                },
                new Nutritions()
                {
                    name = "Carbs",
                    Total = 0,
                    Daily = 300,
                    Remain = 0,
                    unit = "g"
                },
                new Nutritions()
                {
                    name = "Fat",
                    Total = 0,
                    Daily = 60,
                    Remain = 0,
                    unit = "g",
                },
                new Nutritions()
                {
                    name = "Protein",
                    Total = 0,
                    Daily = 60,
                    Remain = 0,
                    unit = "g",
                },
                new Nutritions()
                {
                    name = "Sodium",
                    Total = 0,
                    Daily = 2300,
                    Remain = 0,
                    unit = "mg"
                },
                new Nutritions()
                {
                    name = "Sugar",
                    Total = 0,
                    Daily = 30,
                    Remain = 0,
                    unit = "g"
                },
            };
            return result;
        }
    }



}
