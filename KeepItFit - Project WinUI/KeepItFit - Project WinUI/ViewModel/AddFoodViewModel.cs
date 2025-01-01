using KeepItFit___Project_WinUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeepItFit___Project_WinUI.Services;

namespace KeepItFit___Project_WinUI.ViewModel
{
    public class AddFoodViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Food> foodRecent { get; set; }
        public ObservableCollection<Food> foodFrequent { get; set; }
        public ObservableCollection<Food> foodMyFood { get; set; } //Update later -> don't understand what its function

        //private IDao sqlDao;

        public void init()
        {
            //sqlDao = new SQLDao();
            foodRecent = new ObservableCollection<Food>();
            foodFrequent = new ObservableCollection<Food>();
            LoadRecentFood();
            LoadFrequentFood();
            LoadMyFood();
        }

        public void LoadRecentFood()
        {
            var sqlDao = new SQLDao();
            foodRecent = sqlDao.GetFoodRecent();
        }

        public void LoadFrequentFood()
        {
            var sqlDao = new SQLDao();
            foodFrequent = sqlDao.GetFoodFrequent();
        }

        public void LoadMyFood()
        {
            var sqlDao = new SQLDao();
            foodMyFood = sqlDao.GetFoodMyFood();
        }

        public void DeleteMyFood(Food food)
        {
            var dao = new SQLDao();
            dao.DeleteMyFood(food);
            LoadMyFood();
        }

        public void DeleteFrequentOrRecentFood(Food food)
        {
            var dao = new SQLDao();
            dao.DeleteFrequentOrRecentFood(food);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
