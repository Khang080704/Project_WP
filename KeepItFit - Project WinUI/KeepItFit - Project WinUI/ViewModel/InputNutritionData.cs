using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI.ViewModel
{
    public class InputNutritionData : INotifyPropertyChanged
    {
        public string name { get; set; } = "Quick Add, 1 serving";
        public int CaloriesInput { get; set; }
        public int SodiumInput { get; set; }
        public int FatInput { get; set; }
        public int SugarInput { get; set; }
        public int ProteinInput { get; set; }
        public int CarbsInput { get; set; }

        public void updateData(int calo, int carbs, int fat,
            int protein, int sodium, int sugar)
        {
            CaloriesInput = calo;
            CarbsInput = carbs;
            FatInput = fat;
            ProteinInput = protein;
            SodiumInput = sodium;
            SugarInput = sugar;
        }    

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
