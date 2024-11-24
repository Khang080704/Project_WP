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
            BreakFastNutri.updateWithListFood(sqlDao.GetFoodForTheDay_FoodDiary(formattedDate, "BreakfastDiary", "FOOD"));
            LunchNutri.updateWithListFood(sqlDao.GetFoodForTheDay_FoodDiary(formattedDate, "LunchDiary", "FOOD"));
            DinnerNutri.updateWithListFood(sqlDao.GetFoodForTheDay_FoodDiary(formattedDate, "DinnerDiary", "FOOD"));
            SnackNutri.updateWithListFood(sqlDao.GetFoodForTheDay_FoodDiary(formattedDate, "SnackDiary", "FOOD"));

            // Update the quick add data for each meal zone
            BreakFastNutri.updateWithListFood(sqlDao.GeQuickAddForTheDay_FoodDiary(formattedDate, "QuickAdd_Breakfast"));
            LunchNutri.updateWithListFood(sqlDao.GeQuickAddForTheDay_FoodDiary(formattedDate, "QuickAdd_Lunch"));
            DinnerNutri.updateWithListFood(sqlDao.GeQuickAddForTheDay_FoodDiary(formattedDate, "QuickAdd_Dinner"));
            SnackNutri.updateWithListFood(sqlDao.GeQuickAddForTheDay_FoodDiary(formattedDate, "QuickAdd_Snack"));

            // Update MyFood data for each meal zone
            BreakFastNutri.updateWithListFood(sqlDao.GetFoodForTheDay_FoodDiary(formattedDate, "MyFood_Breakfast", "MyFood"));
            LunchNutri.updateWithListFood(sqlDao.GetFoodForTheDay_FoodDiary(formattedDate, "MyFood_Lunch", "MyFood"));
            DinnerNutri.updateWithListFood(sqlDao.GetFoodForTheDay_FoodDiary(formattedDate, "MyFood_Dinner", "MyFood"));
            SnackNutri.updateWithListFood(sqlDao.GetFoodForTheDay_FoodDiary(formattedDate, "MyFood_Snack", "MyFood"));
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
            else if (itemToDelete.name.Contains("My Food"))
            {
                diaryType = "MyFood_Breakfast";
                sqlDao.DeleteFoodForTheDay_FoodDiary(formattedDate, itemToDelete.foodId, diaryType);
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
            else if (itemToDelete.name.Contains("My Food"))
            {
                diaryType = "MyFood_Lunch";
                Debug.WriteLine(itemToDelete.foodId);
                sqlDao.DeleteFoodForTheDay_FoodDiary(formattedDate, itemToDelete.foodId, diaryType);
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
            else if (itemToDelete.name.Contains("My Food"))
            {
                diaryType = "MyFood_Dinner";
                sqlDao.DeleteFoodForTheDay_FoodDiary(formattedDate, itemToDelete.foodId, diaryType);
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
            else if (itemToDelete.name.Contains("My Food"))
            {
                diaryType = "MyFood_Snack";
                sqlDao.DeleteFoodForTheDay_FoodDiary(formattedDate, itemToDelete.foodId, diaryType);
                return;
            }

            diaryType = "SnackDiary";

            // Delete the food from the database
            sqlDao.DeleteFoodForTheDay_FoodDiary(formattedDate, itemToDelete.foodId, diaryType);
        }

        public void Update_Food(List<Food> foodList, string diaryType)
        {
            IDao sqlDao = new SQLDao();
            string formattedDate = _selectedDate.ToString("yyyy-MM-dd");
            foreach (var food in foodList)
            {
                sqlDao.UpdateFoodForTheDay_FoodDiary(formattedDate, food.foodId, food.foodQuantity, diaryType);
            }
        }

        public void Update_QuickAdd(List<int> src, string diaryType)
        {
            IDao sqlDao = new SQLDao();
            string formattedDate = _selectedDate.ToString("yyyy-MM-dd");
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
