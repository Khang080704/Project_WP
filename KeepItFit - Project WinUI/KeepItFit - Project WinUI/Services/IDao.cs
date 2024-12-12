using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeepItFit___Project_WinUI.Model;

namespace KeepItFit___Project_WinUI.Services
{
    public interface IDao
    {

        public List<Nutritions> GetAllNutrtion();
        public List<Nutritions> GetAllNutrtion(UserInfo info);
        //Exercise part
        public ObservableCollection<CardioExercise> GetAllCardioExercise(string keyword);
        public ObservableCollection<StrengthTraining> GetAllStrengthTraining(string keyword);
        public List<CardioExercise> GetCardioExerciseForTheDay_ExerciseDiary(string date);
        public List<StrengthTraining> GetStrengthExerciseForTheDay_ExerciseDiary(string date);
        public void UpdateCardioExercise_ExerciseDiary(string date, int exerciseId, int howLong, float caloriesPerMinute, int caloriesBurned);
        public void UpdateStrengthExercise_ExerciseDiary(string date, int exerciseId, int sets, int reps_set, int weight_set);
        public void DeleteExerciseForTheDay_ExerciseDiary(string date, int exerciseId, string diaryType);
        public string GetNotesForTheDay_ExerciseDiary(string date);
        public void UpdateNotesForTheDay_ExerciseDiary(string date, string notes);


        // SQLDao
        public ObservableCollection<Meals> GetAllMeals();
        public ObservableCollection<Food> GetFoodRecent();
        public ObservableCollection<Food> GetFoodFrequent();
        public ObservableCollection<Food> GetFoodDatabase(string keyword);
        public void UpdateRecentOrFrequentFood(Food food, string type);
        public void DeleteFrequentOrRecentFood(Food food);
        public List<Food> GetFoodForTheDay_FoodDiary(string date, string diaryType, string table);
        public List<Food> GeQuickAddForTheDay_FoodDiary(string date, string diaryType);
        public void DeleteFoodForTheDay_FoodDiary(string date, int foodId, string diaryType);
        public void DeleteQuickAddForTheDay_FoodDiary(string date, int quickAddId, string diaryType);
        public void UpdateFoodForTheDay_FoodDiary(string date, int foodId, string foodQuantity, string diaryType);
        public void UpdateQuickAddForTheDay_FoodDiary(string date, List<int> quickAddList, string diaryType);
        public void UpdateMyFood(string foodName, float foodCalories, float foodCarbs, float foodFat, float foodProtein, float foodSodium, float foodSugar);
        public ObservableCollection<Food> GetFoodMyFood();
        public void DeleteMyFood(Food food);

    }

}
