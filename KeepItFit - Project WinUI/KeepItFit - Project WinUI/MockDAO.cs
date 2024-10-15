using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI
{
    public class MockDAO : mealDAO
    {
        public List<Meals> GetAllMeals()
        {
            var result = new List<Meals>()
            {
                new Meals() {
                    mealName = "BreakFast"
                },
                new Meals() {
                    mealName = "Lunch"
                },
                new Meals() {
                    mealName = "Dinner"
                },
                new Meals()
                {
                    mealName = "Snacks"
                }
            };
            return result;
        }

    }

}
