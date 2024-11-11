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

        public ObservableCollection<Food> GetFoodDatabase(string keyword)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Food> GetFoodRecent()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Food> GetFoodFrequent()
        {
            throw new NotImplementedException();
        }

        public void UpdateFrequentTable(Food food)
        {
            throw new NotImplementedException();
        }

        public void UpdateFrequentFood(Food food)
        {
            throw new NotImplementedException();
        }

        public void UpdateRecentFood(Food food)
        {
            throw new NotImplementedException();
        }

        public void DeleteFrequentOrRecentFood(Food food)
        {
            throw new NotImplementedException();
        }

        public List<Food> GetBreakfastFoodForTheDay(string date)
        {
            throw new NotImplementedException();
        }

        public List<Food> GetLunchFoodForTheDay(string date)
        {
            throw new NotImplementedException();
        }

        public List<Food> GetDinnerFoodForTheDay(string date)
        {
            throw new NotImplementedException();
        }

        public List<Food> GetSnackFoodForTheDay(string date)
        {
            throw new NotImplementedException();
        }

        public void DeleteFoodForTheDay_FoodDiary(string date, int foodId, string diaryType)
        {
            throw new NotImplementedException();
        }

        public List<Food> GetFoodForTheDay_FoodDiary(string date, string diaryType)
        {
            throw new NotImplementedException();
        }

        public void UpdateRecentOrFrequentFood(Food food, string type)
        {
            throw new NotImplementedException();
        }

        public void UpdateFoodForTheDay_FoodDiary(string date, int foodId, string foodQuantity, string diaryType)
        {
            throw new NotImplementedException();
        }
    }



}
