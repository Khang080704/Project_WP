using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Remain = 2300,
                    unit = "kcal",
                },
                new Nutritions()
                {
                    name = "Carbs",
                    Total = 0,
                    Daily = 300,
                    Remain = 300,
                    unit = "g"
                },
                new Nutritions()
                {
                    name = "Fat",
                    Total = 0,
                    Daily = 60,
                    Remain = 60,
                    unit = "g",
                },
                new Nutritions()
                {
                    name = "Protein",
                    Total = 0,
                    Daily = 60,
                    Remain = 60,
                    unit = "g",
                },
                new Nutritions()
                {
                    name = "Sodium",
                    Total = 0,
                    Daily = 2300,
                    Remain = 2300,
                    unit = "mg"
                },
                new Nutritions()
                {
                    name = "Sugar",
                    Total = 0,
                    Daily = 30,
                    Remain = 30,
                    unit = "g"
                },
            };
            return result;
        }

        public ObservableCollection<CardioExercise> GetAllCardioExercise()
        {
            var result = new ObservableCollection<CardioExercise>()
            {
                new CardioExercise()
                {
                    name = "Aerobic, general",
                    _time = 0,
                    caloriesPerMinute = 7.7f,
                    CaloriesBurned = 0,
                },
                new CardioExercise()
                {
                    name = "Badminton, competitive",
                    _time = 0,
                    caloriesPerMinute = 8.3f,
                    CaloriesBurned = 0,
                },
                new CardioExercise()
                {
                    name = "Billiards",
                    _time = 0,
                    caloriesPerMinute = 3,
                    CaloriesBurned = 0,
                },
                new CardioExercise()
                {
                    name = "Canoeing, on camping trip",
                    _time = 0,
                    caloriesPerMinute = 4.7f,
                    CaloriesBurned = 0,
                },
                new CardioExercise()
                {
                    name = "Dancing, general",
                    _time = 0,
                    caloriesPerMinute = 5.3f,
                    CaloriesBurned = 0,
                },
                new CardioExercise()
                {
                    name = "Fishing from boat, sitting",
                    _time = 0,
                    caloriesPerMinute = 3,
                    CaloriesBurned = 0,
                },
                new CardioExercise()
                {
                    name = "Golf, carrying clubs",
                    _time = 0,
                    caloriesPerMinute = 5.3f,
                    CaloriesBurned = 0
                },
                new CardioExercise()
                {
                    name = "Horseback riding, general",
                    _time = 0,
                    caloriesPerMinute = 4.7f,
                    CaloriesBurned = 0,
                },
                new CardioExercise()
                {
                    name = "Judo, karate, kick boxing, tae kwan do",
                    _time = 0,
                    caloriesPerMinute = 11.8f,
                    CaloriesBurned = 0,
                },
                new CardioExercise()
                {
                    name = "Music playing, drums",
                    _time = 0,
                    caloriesPerMinute = 4.7f,
                    CaloriesBurned = 0,
                }
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

        public ObservableCollection<StrengthTraining> GetAllStrengthTraining()
        {
            var result = new ObservableCollection<StrengthTraining>()
            {
                new StrengthTraining()
                {
                    name = "Abdominal Leg Raise",
                    Sets = 0,
                    Reps_Set = 0,
                    Weight_Sets = 0,
                },
                new StrengthTraining()
                {
                    name = "Back Extension",
                    Sets = 0,
                    Reps_Set = 0,
                    Weight_Sets = 0,
                },
                new StrengthTraining()
                {
                    name = "Cable Crossover, High Pulley",
                    Sets = 0,
                    Reps_Set = 0,
                    Weight_Sets = 0,
                },
                new StrengthTraining()
                {
                    name = "Deadlift, Straight Leg",
                    Sets = 0,
                    Reps_Set = 0,
                    Weight_Sets = 0,
                },
                new StrengthTraining()
                {
                    name = "Flat Dumbbell Fly",
                    Sets = 0,
                    Reps_Set = 0,
                    Weight_Sets = 0,
                },
                new StrengthTraining()
                {
                    name = "Hack Squat",
                    Sets = 0,
                    Reps_Set = 0,
                    Weight_Sets = 0,
                },
                new StrengthTraining()
                {
                    name = "Kickbacks, Bent, 1-Arm, Dumbbell",
                    Sets = 0,
                    Reps_Set = 0,
                    Weight_Sets = 0,
                },
                new StrengthTraining()
                {
                    name = "Incline Lateral, Dumbbells",
                    Sets = 0,
                    Reps_Set = 0,
                    Weight_Sets = 0,
                },
                new StrengthTraining()
                {
                    name = "Lat Pulldown",
                    Sets = 0,
                    Reps_Set = 0,
                    Weight_Sets = 0,
                },
                new StrengthTraining()
                {
                    name = "Machine Squat",
                    Sets = 0,
                    Reps_Set = 0,
                    Weight_Sets = 0,
                },
            };
            return result;
        }
    }

}
