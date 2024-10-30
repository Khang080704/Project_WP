using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI.ViewModel
{
    public class InputNutritionViewModel
    {
        public ObservableCollection<InputNutritionData> NutritionData { get; set; }
        public ObservableCollection<InputNutritionData> init()
        {
            var result = new ObservableCollection<InputNutritionData>();
            return result;
        }
        public void update(List<int> src)
        {
            var result = new InputNutritionData()
            {
                CaloriesInput = src[0],
                CarbsInput = src[1],
                FatInput = src[2],
                ProteinInput = src[3],
                SodiumInput = src[4],
                SugarInput = src[5],
            };
           
            NutritionData.Add(result);
        }
        public void updateWithFood(Food src)
        {
            var result = new InputNutritionData()
            {
                name = $"{src.foodName}, {src.foodQuantity} {src.selectedFoodUnit}",
                CaloriesInput = Convert.ToInt32(src.foodCalories) * Convert.ToInt32(src.foodQuantity),
                CarbsInput = Convert.ToInt32(src.foodCarbs) * Convert.ToInt32(src.foodQuantity),
                FatInput = Convert.ToInt32(src.foodFat) * Convert.ToInt32(src.foodQuantity),
                ProteinInput = Convert.ToInt32(src.foodProtein) * Convert.ToInt32(src.foodQuantity),
                SodiumInput= Convert.ToInt32(src.foodSodium) * Convert.ToInt32(src.foodQuantity),
                SugarInput = Convert.ToInt32(src.foodSugar) * Convert.ToInt32(src.foodQuantity),
            };
            NutritionData.Add(result);
        }
        public void updateWithListFood(List<Food> src)
        {
            foreach(var i in src)
            {
                updateWithFood(i);
            }
        }
    }
}
