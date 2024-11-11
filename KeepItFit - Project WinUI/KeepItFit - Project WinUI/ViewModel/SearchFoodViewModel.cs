using KeepItFit___Project_WinUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI.ViewModel
{
    public class SearchFoodViewModel : INotifyPropertyChanged
    {   
        public ObservableCollection<Food> foodSearchList;
        public ObservableCollection<Meals> meals { get; set; }

        //private IDao sqlDao;

        private Food _selectedFood;
        private Meals _selectedMeal;

        public Meals SelectedMeal
        {
            get => _selectedMeal;
            set
            {
                _selectedMeal = value;
                OnPropertyChanged(nameof(SelectedMeal));
            }
        }

        public Food SelectedFood
        {
            get => _selectedFood;
            set
            {
                _selectedFood = value;
                OnPropertyChanged(nameof(SelectedFood));
            }
        }

        private bool _isFoodSelected;
        public bool IsFoodSelected
        {
            get => _isFoodSelected;
            set
            {
                _isFoodSelected = value;
                OnPropertyChanged(nameof(IsFoodSelected));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void init()
        {
            var sqlDao = new SQLDao();
            meals = sqlDao.GetAllMeals();
            foodSearchList = new ObservableCollection<Food>();
            SelectedFood = new Food();
            SelectedMeal = new Meals();
        }

        public ObservableCollection<Food> GetFoodDatabase(string keyword)
        {
            var sqlDao = new SQLDao();
            return sqlDao.GetFoodDatabase(keyword);
        }

        public void UpdateFrequentFood(Food food)
        {
            var sqlDao = new SQLDao();
            sqlDao.UpdateFrequentFood(food);
        }
        
        public void UpdateRecentFood(Food food)
        {
            var sqlDao = new SQLDao();
            sqlDao.UpdateRecentFood(food);
        }
    }
}
