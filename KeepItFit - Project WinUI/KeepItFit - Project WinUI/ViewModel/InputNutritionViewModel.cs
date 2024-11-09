using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeepItFit___Project_WinUI.Model;

namespace KeepItFit___Project_WinUI.ViewModel
{
    //This class is used to display a list of nutrition that send from
    //another page
    public class InputNutritionViewModel
    {
        //List of Nutrition
        public ObservableCollection<InputNutritionData> NutritionData { get; set; }
        public ObservableCollection<InputNutritionData> init()
        {
            var result = new ObservableCollection<InputNutritionData>();
            return result;
        }
        //Received a list from QuickAdd, update it (add) to NutritionData
        public void update(List<int> src)
        {
            var result = new InputNutritionData()
            {
                CaloriesInput = src[0], //Calories
                CarbsInput = src[1], //Carbs
                FatInput = src[2], //Fat
                ProteinInput = src[3], //Protein
                SodiumInput = src[4], //Sodium
                SugarInput = src[5], //Sugar
            };
            //src[0], src[1],... are default order of nutrition list
            NutritionData.Add(result);
        }
        //Received From page SearchFood
        public void updateWithFood(Food src)
        {
            //Convert to number
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

        //Received a food list from AddFood page
        public void updateWithListFood(List<Food> src)
        {
            foreach(var i in src)
            {
                updateWithFood(i);
            }
        }
    }
}
