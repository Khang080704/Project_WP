using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeepItFit___Project_WinUI.ViewModel;

namespace KeepItFit___Project_WinUI.Model
{
    public interface mealDAO
    {
        public List<Meals> GetAllMeals();
    }
}
