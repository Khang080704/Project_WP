using KeepItFit___Project_WinUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI.ViewModel
{
    public class FoodDiaryViewModel: INotifyPropertyChanged
    {
        private DateTimeOffset _selectedDate;

        //init 4 variables, each variable responsive for a meal zone
        public InputNutritionViewModel BreakFastNutri { get; set; }
        public InputNutritionViewModel LunchNutri { get; set; }
        public InputNutritionViewModel DinnerNutri { get; set; }
        public InputNutritionViewModel SnackNutri { get; set; }

        public FoodDiaryViewModel()
        {
            // initialize the selected date to the current date
            _selectedDate = DateTimeOffset.Now;

            BreakFastNutri = new InputNutritionViewModel();
            LunchNutri = new InputNutritionViewModel();
            DinnerNutri = new InputNutritionViewModel();
            SnackNutri = new InputNutritionViewModel();

            BreakFastNutri.NutritionData = BreakFastNutri.init();
            LunchNutri.NutritionData = LunchNutri.init();
            DinnerNutri.NutritionData = DinnerNutri.init();
            SnackNutri.NutritionData = SnackNutri.init();

            UpdateDataAllMeals();
        }

        public DateTimeOffset SelectedDate
        {
            get => _selectedDate;
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    OnPropertyChanged();
                    UpdateDataAllMeals();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Logic to update data based on the selected date
        public void UpdateDataAllMeals()
        {
            IDao sqlDao = new SQLDao();
            string formattedDate = _selectedDate.ToString("yyyy-MM-dd");

            // Clear the previous nutrition data when change calendar date
            BreakFastNutri.NutritionData.Clear();
            LunchNutri.NutritionData.Clear();
            DinnerNutri.NutritionData.Clear();
            SnackNutri.NutritionData.Clear();

            // Update the nutrition data for each meal zone
            BreakFastNutri.updateWithListFood(sqlDao.GetFoodForTheDay_FoodDiary(formattedDate, "BreakfastDiary"));
            LunchNutri.updateWithListFood(sqlDao.GetFoodForTheDay_FoodDiary(formattedDate, "LunchDiary"));
            DinnerNutri.updateWithListFood(sqlDao.GetFoodForTheDay_FoodDiary(formattedDate, "DinnerDiary"));
            SnackNutri.updateWithListFood(sqlDao.GetFoodForTheDay_FoodDiary(formattedDate, "SnackDiary"));
        }

        // Delete food from the meal zone(Breakfast)
        public void Delete_FoodBreakfast(InputNutritionData itemToDelete)
        {
            BreakFastNutri.NutritionData.Remove(itemToDelete);
            IDao sqlDao = new SQLDao();
            string formattedDate = _selectedDate.ToString("yyyy-MM-dd");
            string diaryType = "BreakfastDiary";

            // Delete the food from the database
            sqlDao.DeleteFoodForTheDay_FoodDiary(formattedDate, itemToDelete.foodId, diaryType);
        }

        // Delete food from the meal zone(Lunch)
        public void Delete_FoodLunch(InputNutritionData itemToDelete)
        {
            LunchNutri.NutritionData.Remove(itemToDelete);
            IDao sqlDao = new SQLDao();
            string formattedDate = _selectedDate.ToString("yyyy-MM-dd");
            string diaryType = "LunchDiary";

            // Delete the food from the database
            sqlDao.DeleteFoodForTheDay_FoodDiary(formattedDate, itemToDelete.foodId, diaryType);
        }

        // Delete food from the meal zone(Dinner)
        public void Delete_FoodDinner(InputNutritionData itemToDelete)
        {
            DinnerNutri.NutritionData.Remove(itemToDelete);
            IDao sqlDao = new SQLDao();
            string formattedDate = _selectedDate.ToString("yyyy-MM-dd");
            string diaryType = "DinnerDiary";

            // Delete the food from the database
            sqlDao.DeleteFoodForTheDay_FoodDiary(formattedDate, itemToDelete.foodId, diaryType);
        }

        // Delete food from the meal zone(Snack)
        public void Delete_FoodSnack(InputNutritionData itemToDelete)
        {
            SnackNutri.NutritionData.Remove(itemToDelete);
            IDao sqlDao = new SQLDao();
            string formattedDate = _selectedDate.ToString("yyyy-MM-dd");
            string diaryType = "SnackDiary";

            // Delete the food from the database
            sqlDao.DeleteFoodForTheDay_FoodDiary(formattedDate, itemToDelete.foodId, diaryType);
        }

        public void Update_FoodBreakfast(List<Food> foodList)
        {
            IDao sqlDao = new SQLDao();
            string formattedDate = _selectedDate.ToString("yyyy-MM-dd");
            string diaryType = "BreakfastDiary";
            foreach (var food in foodList)
            {
                sqlDao.UpdateFoodForTheDay_FoodDiary(formattedDate, food.foodId, food.foodQuantity, diaryType);
            }
        }

        public void Update_FoodLunch(List<Food> foodList)
        {
            IDao sqlDao = new SQLDao();
            string formattedDate = _selectedDate.ToString("yyyy-MM-dd");
            string diaryType = "LunchDiary";
            foreach (var food in foodList)
            {
                sqlDao.UpdateFoodForTheDay_FoodDiary(formattedDate, food.foodId, food.foodQuantity, diaryType);
            }
        }

        public void Update_FoodDinner(List<Food> foodList)
        {
            IDao sqlDao = new SQLDao();
            string formattedDate = _selectedDate.ToString("yyyy-MM-dd");
            string diaryType = "DinnerDiary";
            foreach (var food in foodList)
            {
                sqlDao.UpdateFoodForTheDay_FoodDiary(formattedDate, food.foodId, food.foodQuantity, diaryType);
            }
        }

        public void Update_FoodSnack(List<Food> foodList)
        {
            IDao sqlDao = new SQLDao();
            string formattedDate = _selectedDate.ToString("yyyy-MM-dd");
            string diaryType = "SnackDiary";
            foreach (var food in foodList)
            {
                sqlDao.UpdateFoodForTheDay_FoodDiary(formattedDate, food.foodId, food.foodQuantity, diaryType);
            }
        }
    }
}
