using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI.ViewModel
{
    public class TypeExercise: INotifyPropertyChanged
    {
        public string typeName
        {
            get; set;
        }
       // public List<Nutritions> nutriList { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
