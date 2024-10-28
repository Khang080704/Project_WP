using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeepItFit___Project_WinUI.ViewModel;

namespace KeepItFit___Project_WinUI.Model
{
    public interface IDao
    {
        public ObservableCollection<Meals> GetAllMeals();
        public ObservableCollection<Food> GetFoodRecent();
        public ObservableCollection<Food> GetFoodFrequent();
        public List<Nutritions> GetAllNutrtion();

        public ObservableCollection<Food> GetFoodDatabase();
    }

}
