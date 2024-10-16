using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI.ViewModel
{
    public class Food : INotifyPropertyChanged
    {
        public string foodName { get; set;}
        public float foodCalories { get; set; } 
        public float foodCarbs { get; set; } 
        public float foodFat { get; set; } 
        public float foodProtein { get; set; }
        public float foodSodium { get; set; }
        public float foodSugar { get; set; }
        public float foodQuantity { get; set; }
        public string foodUnit { get; set;}


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
