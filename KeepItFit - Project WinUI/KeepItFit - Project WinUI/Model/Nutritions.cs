using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI.Model
{
    public class Nutritions : INotifyPropertyChanged
    {
        public string name { get; set; }
        public string unit { get; set; }
        public int Total { get; set; }
        public int Daily { get; set; }
        public int Remain { get; set; }
        public int input { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
