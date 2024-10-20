using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeepItFit___Project_WinUI.ViewModel;

namespace KeepItFit___Project_WinUI.Model
{
    public interface IDao
    {
        public List<Meals> GetAllMeals();
        public List<Food> GetFoodRecent();
        public List<Food> GetFoodFrequent();
        public List<Nutritions> GetAllNutrtion();
    }

}
