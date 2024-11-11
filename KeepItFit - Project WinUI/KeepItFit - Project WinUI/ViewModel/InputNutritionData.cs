using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI.ViewModel
{
    //This class is used to receive nutrition list that is send from another
    //page
    public class InputNutritionData : INotifyPropertyChanged
    {
        //Default name is "Quicl Add, 1 serving" for QuickAdd Calories page (FoodPage)
        //if page == AddFood, rename it according to the name of dish + nutrition amount
        //. 1 InputNutritionData is 1 line display in FoodDiary

        public int foodId { get; set; }
        public string foodQuantity { get; set; }
        public string name { get; set; } = "Quick Add, 1 serving";        
        public int CaloriesInput { get; set; }
        public int SodiumInput { get; set; }
        public int FatInput { get; set; }
        public int SugarInput { get; set; }
        public int ProteinInput { get; set; }
        public int CarbsInput { get; set; } 

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
