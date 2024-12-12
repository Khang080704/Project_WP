using KeepItFit___Project_WinUI.Model;
using KeepItFit___Project_WinUI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI.ViewModel
{
    public class NutritionsViewModel: INotifyPropertyChanged
    {
        public List<Nutritions> nutrition { get; set; }
        public ObservableCollection<Meals> mealList { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void initNutrition(UserInfo info)
        {
            IDao dao = new MockDAO();
            nutrition = dao.GetAllNutrtion(info);

        }
        public void initMeal()
        {
            IDao sqldao = new SQLDao();
            mealList = sqldao.GetAllMeals();
        }
        public Nutritions getNutritions(string name)
        {
            var result = new Nutritions();
            foreach (var i in nutrition)
            {
                if (i.name == name)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }


    }
}
