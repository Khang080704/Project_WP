using KeepItFit___Project_WinUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI.ViewModel
{
    public class FoodPageViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<Meals> meals { get; set; }
        public List<Nutritions> nutritions { get; set; }

        public void init()
        {
            IDao dao = new MockDAO();
            meals = dao.GetAllMeals();
            nutritions = dao.GetAllNutrtion();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
