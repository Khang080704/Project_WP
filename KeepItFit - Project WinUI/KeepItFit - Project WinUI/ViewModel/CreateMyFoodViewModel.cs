using KeepItFit___Project_WinUI.Model;
using KeepItFit___Project_WinUI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI.ViewModel
{
    public class CreateMyFoodViewModel : INotifyPropertyChanged
    {
        private string _foodName { get; set; }
        public List<Nutritions> nutritions { get; set; }


        public CreateMyFoodViewModel()
        {
            IDao dao = new MockDAO();
            nutritions = dao.GetAllNutrtion();
        }

        public string foodName
        {
            get => _foodName;
            set
            {
                _foodName = value;
                OnPropertyChanged(nameof(foodName));
            }
        }

        // Add the food user creates to database
        public void AddMyFoodToDatabase() 
        {
            IDao sqlDao = new SQLDao();
            float calories = float.Parse(nutritions[0].input);
            float carbs = float.Parse(nutritions[1].input);
            float fat = float.Parse(nutritions[2].input);
            float protein = float.Parse(nutritions[3].input);
            float sodium = float.Parse(nutritions[4].input);
            float sugar = float.Parse(nutritions[5].input);

            sqlDao.UpdateMyFood(foodName, calories, carbs, fat, protein, sodium, sugar);

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
