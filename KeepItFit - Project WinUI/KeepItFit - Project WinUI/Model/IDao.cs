using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI.Model
{
    public interface IDao
    {
        
        public List<Nutritions> GetAllNutrtion();
        public ObservableCollection<CardioExercise> GetAllCardioExercise();
        public ObservableCollection<StrengthTraining> GetAllStrengthTraining();


        // SQLDao
        public ObservableCollection<Meals> GetAllMeals();
        public ObservableCollection<Food> GetFoodRecent();
        public ObservableCollection<Food> GetFoodFrequent();
        public ObservableCollection<Food> GetFoodDatabase(string keyword);
        public void UpdateRecentOrFrequentFood(Food food, string type);
        public void DeleteFrequentOrRecentFood(Food food);
        public List<Food> GetFoodForTheDay_FoodDiary(string date, string diaryType);
        public List<Food> GeQuickAddForTheDay_FoodDiary(string date, string diaryType);
        public void DeleteFoodForTheDay_FoodDiary(string date, int foodId, string diaryType);
        public void DeleteQuickAddForTheDay_FoodDiary(string date, int quickAddId, string diaryType);
        public void UpdateFoodForTheDay_FoodDiary(string date, int foodId, string foodQuantity, string diaryType);
        public void UpdateQuickAddForTheDay_FoodDiary(string date, List<int> quickAddList, string diaryType);
        public ObservableCollection<Food> GetFoodDatabase();

       
    }

}
