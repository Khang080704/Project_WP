using KeepItFit___Project_WinUI.Model;
using KeepItFit___Project_WinUI.Services;
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

        public NutritionsViewModel nutri { get; set; }

        public FoodDiaryViewModel()
        {
            // initialize the selected date to the current date
            _selectedDate = DateTimeOffset.Now;

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

            UpdateDataAllMeals();
            updateTotal();
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
                    updateTotal();
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

            // Update the food data for each meal zone
            BreakFastNutri.updateWithListFood(sqlDao.GetFoodForTheDay_FoodDiary(formattedDate, "BreakfastDiary"));
            LunchNutri.updateWithListFood(sqlDao.GetFoodForTheDay_FoodDiary(formattedDate, "LunchDiary"));
            DinnerNutri.updateWithListFood(sqlDao.GetFoodForTheDay_FoodDiary(formattedDate, "DinnerDiary"));
            SnackNutri.updateWithListFood(sqlDao.GetFoodForTheDay_FoodDiary(formattedDate, "SnackDiary"));

            // Update the quick add data for each meal zone
            BreakFastNutri.updateWithListFood(sqlDao.GeQuickAddForTheDay_FoodDiary(formattedDate, "QuickAdd_Breakfast"));
            LunchNutri.updateWithListFood(sqlDao.GeQuickAddForTheDay_FoodDiary(formattedDate, "QuickAdd_Lunch"));
            DinnerNutri.updateWithListFood(sqlDao.GeQuickAddForTheDay_FoodDiary(formattedDate, "QuickAdd_Dinner"));
            SnackNutri.updateWithListFood(sqlDao.GeQuickAddForTheDay_FoodDiary(formattedDate, "QuickAdd_Snack"));
        }

        // Delete food from the meal zone(Breakfast)
        public void Delete_FoodBreakfast(InputNutritionData itemToDelete)
        {
            BreakFastNutri.NutritionData.Remove(itemToDelete);
            IDao sqlDao = new SQLDao();
            string formattedDate = _selectedDate.ToString("yyyy-MM-dd");
            string diaryType;
            if (itemToDelete.name.Contains("Quick Add"))
            {
                diaryType = "QuickAdd_Breakfast";
                Debug.WriteLine(itemToDelete.foodId);
                sqlDao.DeleteQuickAddForTheDay_FoodDiary(formattedDate, itemToDelete.foodId, diaryType);
                return;
            }

            diaryType = "BreakfastDiary";

            // Delete the food from the database
            sqlDao.DeleteFoodForTheDay_FoodDiary(formattedDate, itemToDelete.foodId, diaryType);
        }

        // Delete food from the meal zone(Lunch)
        public void Delete_FoodLunch(InputNutritionData itemToDelete)
        {
            LunchNutri.NutritionData.Remove(itemToDelete);
            IDao sqlDao = new SQLDao();
            string formattedDate = _selectedDate.ToString("yyyy-MM-dd");
            string diaryType;
            if (itemToDelete.name.Contains("Quick Add"))
            {
                diaryType = "QuickAdd_Lunch";
                Debug.WriteLine(itemToDelete.foodId);
                sqlDao.DeleteQuickAddForTheDay_FoodDiary(formattedDate, itemToDelete.foodId, diaryType);
                return;
            }

            diaryType = "LunchDiary";

            // Delete the food from the database
            sqlDao.DeleteFoodForTheDay_FoodDiary(formattedDate, itemToDelete.foodId, diaryType);
        }

        // Delete food from the meal zone(Dinner)
        public void Delete_FoodDinner(InputNutritionData itemToDelete)
        {
            DinnerNutri.NutritionData.Remove(itemToDelete);
            IDao sqlDao = new SQLDao();
            string formattedDate = _selectedDate.ToString("yyyy-MM-dd");
            string diaryType;
            if (itemToDelete.name.Contains("Quick Add"))
            {
                diaryType = "QuickAdd_Dinner";

                sqlDao.DeleteQuickAddForTheDay_FoodDiary(formattedDate, itemToDelete.foodId, diaryType);
                return;
            }

            diaryType = "DinnerDiary";

            // Delete the food from the database
            sqlDao.DeleteFoodForTheDay_FoodDiary(formattedDate, itemToDelete.foodId, diaryType);
        }

        // Delete food from the meal zone(Snack)
        public void Delete_FoodSnack(InputNutritionData itemToDelete)
        {
            SnackNutri.NutritionData.Remove(itemToDelete);
            IDao sqlDao = new SQLDao();
            string formattedDate = _selectedDate.ToString("yyyy-MM-dd");
            string diaryType;
            if (itemToDelete.name.Contains("Quick Add"))
            {
                diaryType = "QuickAdd_Snack";

                sqlDao.DeleteQuickAddForTheDay_FoodDiary(formattedDate, itemToDelete.foodId, diaryType);
                return;
            }

            diaryType = "SnackDiary";

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

        public void Update_QuickAddBreakFast(List<int> src)
        {
            IDao sqlDao = new SQLDao();
            string formattedDate = _selectedDate.ToString("yyyy-MM-dd");
            string diaryType = "QuickAdd_Breakfast";
            sqlDao.UpdateQuickAddForTheDay_FoodDiary(formattedDate, src, diaryType);
        }

        public void Update_QuickAddLunch(List<int> src)
        {
            IDao sqlDao = new SQLDao();
            string formattedDate = _selectedDate.ToString("yyyy-MM-dd");
            string diaryType = "QuickAdd_Lunch";
            sqlDao.UpdateQuickAddForTheDay_FoodDiary(formattedDate, src, diaryType);
        }

        public void Update_QuickAddDinner(List<int> src)
        {
            IDao sqlDao = new SQLDao();
            string formattedDate = _selectedDate.ToString("yyyy-MM-dd");
            string diaryType = "QuickAdd_Dinner";
            sqlDao.UpdateQuickAddForTheDay_FoodDiary(formattedDate, src, diaryType);
        }

        public void Update_QuickAddSnack(List<int> src)
        {
            IDao sqlDao = new SQLDao();
            string formattedDate = _selectedDate.ToString("yyyy-MM-dd");
            string diaryType = "QuickAdd_Snack";
            sqlDao.UpdateQuickAddForTheDay_FoodDiary(formattedDate, src, diaryType);
        }

        //nutri.nutrition contains list of nutritions in order
        //[0] : calories
        //[1]: Carbs
        //...
        //When add a new InputNutritionViewModel to list,
        //update total's value of nutrion by calculate sum 
        //of all elements in src
        public void updateForMeal(InputNutritionViewModel src)
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
        public void updateTotal()
        {
            foreach (var i in nutri.nutrition)
            {
                i.Total = 0;
            }

            //Calculate the total's value of all meal
            updateForMeal(BreakFastNutri);
            updateForMeal(LunchNutri);
            updateForMeal(DinnerNutri);
            updateForMeal(SnackNutri);
            //Cal the remain
            foreach (var i in nutri.nutrition)
            {
                i.Remain = i.Daily - i.Total;
            }
        }
    }
}
