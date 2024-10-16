using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI.ViewModel
{
    public class Meals : INotifyPropertyChanged
    {
        public string mealName
        {
            get; set;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
