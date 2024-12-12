using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI.Model
{
    public class UserInfo
    {
        // Thông tin cá nhân
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }

        // Thông tin thể chất
        public double Height { get; set; } // cm
        public double Weight { get; set; } // kg
        public string ActivityLevel { get; set; }

        // Thông tin dinh dưỡng và thói quen ăn uống
        public int MealsPerDay { get; set; }
        public bool NightEating { get; set; }

        // Thông tin y tế
        public bool HasChronicDiseases { get; set; }
        public List<string> ChronicDiseases { get; set; }
        public bool HasFoodAllergies { get; set; }
        public List<string> FoodAllergies { get; set; }

        // Thông tin bổ sung
        public string NutritionGoal { get; set; }
        public int Calo { get; set; }
        public int Protein { get; set; }
        public int Sodium { get; set; } = 2300;
        public int Fat { get; set; }
        public int Sugar { get; set; }
        public int Carb { get; set; }

        // Phương thức khởi tạo (constructor)
        public UserInfo()
        {
            ChronicDiseases = new List<string>();
            FoodAllergies = new List<string>();
        }

        // Phương thức để tính toán TDEE dựa trên thông tin người dùng
        public int CalculateTDEE()
        {
            // Tính BMR (Basal Metabolic Rate - Tỷ lệ trao đổi chất cơ bản)
            double BMR = (Gender.ToLower() == "male") ?
                88.362 + (13.397 * Weight) + (4.799 * Height)
                - (5.677 * (DateTime.Now.Year - Birthdate.Year)) : 447.593
                + (9.247 * Weight) + (3.098 * Height)
                - (4.330 * (DateTime.Now.Year - Birthdate.Year));

            // Tính TDEE dựa trên mức độ hoạt động
            double activityFactor = ActivityLevel switch
            {
                "Very sedentary" => 1.2,
                "Lightly active" => 1.375,
                "Moderately active" => 1.55,
                "Highly active" => 1.725,
                "Very highly active" => 1.9,
                _ => 1.2,
            };

            Calo = Convert.ToInt32(BMR * activityFactor);
            return Convert.ToInt32(BMR * activityFactor);
        }


        public void calculateNutritionNeed()
        {
            double tdee = CalculateTDEE();

            double proteinPercentage = 0.15;
            double fatPercentage = 0.30;
            double carbohydratePercentage = 0.55;
            double sugarPercentage = 0.1;

            Protein = Convert.ToInt32(tdee * proteinPercentage);
            Fat = Convert.ToInt32(tdee * fatPercentage);
            Carb = Convert.ToInt32(tdee * carbohydratePercentage);
            Sugar = Convert.ToInt32((tdee * sugarPercentage) / 4);
        }

    }
}
