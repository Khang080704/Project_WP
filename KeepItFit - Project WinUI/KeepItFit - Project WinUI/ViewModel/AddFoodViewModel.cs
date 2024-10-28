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
    public class AddFoodViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Food> foodRecent { get; set; }
        public ObservableCollection<Food> foodFrequent { get; set; }
        public ObservableCollection<Food> foodMyFood { get; set; } //Update later -> don't understand what its function


        public event PropertyChangedEventHandler PropertyChanged;

        public void init()
        {
            IDao dao = new MockDAO();
            foodRecent = dao.GetFoodRecent();
            foodFrequent = dao.GetFoodFrequent();
        }
        
    }
}
