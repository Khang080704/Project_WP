using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI.Model
{
    public class CardioExercise : INotifyPropertyChanged
    {
        public string name {  get; set; }
        private int time;
        public int _time {
            get => time;
            set
            {
                if(time != value)
                {
                    time = value;
                    calculateTotalCalories();
                }
            } 
        }
        public int CaloriesBurned { get; set; }
        public float caloriesPerMinute { get; set; }
        void calculateTotalCalories()
        {
            CaloriesBurned = (int)(time * caloriesPerMinute);
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
