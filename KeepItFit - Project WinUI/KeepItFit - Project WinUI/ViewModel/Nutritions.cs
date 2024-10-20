using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI.ViewModel
{
    public class Nutritions : INotifyPropertyChanged
    {
        public string name {  get; set; }
        public string unit { get; set; }
        public int Total { get; set; }
        public int Daily { get; set; }
        public int Remain { get; set; }
        void updateRemaining()
        {
            Remain = Daily - Total;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
