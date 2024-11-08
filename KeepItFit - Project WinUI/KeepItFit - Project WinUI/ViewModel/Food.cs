using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI.ViewModel
{
    public class Food : INotifyPropertyChanged
    {
        private int _foodId;
        private string _foodName;
        private float _foodCalories;
        private float _foodCarbs;
        private float _foodFat;
        private float _foodProtein;
        private float _foodSodium;
        private float _foodSugar;
        private string _foodQuantity;
        private List<string> _foodUnit;
        private string _selectedFoodUnit;

        public int foodId
        {
            get => _foodId;
            set
            {
                _foodId = value;
                OnPropertyChanged(nameof(foodId));
            }
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

        public float foodCalories
        {
            get => _foodCalories;
            set
            {
                _foodCalories = value;
                OnPropertyChanged(nameof(foodCalories));
            }
        }

        public float foodCarbs
        {
            get => _foodCarbs;
            set
            {
                _foodCarbs = value;
                OnPropertyChanged(nameof(foodCarbs));
            }
        }

        public float foodFat
        {
            get => _foodFat;
            set
            {
                _foodFat = value;
                OnPropertyChanged(nameof(foodFat));
            }
        }

        public float foodProtein
        {
            get => _foodProtein;
            set
            {
                _foodProtein = value;
                OnPropertyChanged(nameof(foodProtein));
            }
        }

        public float foodSodium
        {
            get => _foodSodium;
            set
            {
                _foodSodium = value;
                OnPropertyChanged(nameof(foodSodium));
            }
        }

        public float foodSugar
        {
            get => _foodSugar;
            set
            {
                _foodSugar = value;
                OnPropertyChanged(nameof(foodSugar));
            }
        }

        public string foodQuantity
        {
            get => _foodQuantity;
            set
            {
                _foodQuantity = value;
                OnPropertyChanged(nameof(foodQuantity));
            }
        }

        public List<string> foodUnit
        {
            get => _foodUnit;
            set
            {
                _foodUnit = value;
                OnPropertyChanged(nameof(foodUnit));
            }
        }

        //Selected unit from User when changing the Unit
        public string selectedFoodUnit
        {
            get => _selectedFoodUnit;
            set
            {
                _selectedFoodUnit = value;
                OnPropertyChanged(nameof(selectedFoodUnit));
            }
        }

        private Visibility _foodQuantityErrorVisibility = Visibility.Collapsed;
        private Visibility _foodUnitErrorVisibility = Visibility.Collapsed;

        public Visibility foodQuantityErrorVisibility
        {
            get => _foodQuantityErrorVisibility;
            set
            {
                if (_foodQuantityErrorVisibility != value)
                {
                    _foodQuantityErrorVisibility = value;
                    OnPropertyChanged(nameof(foodQuantityErrorVisibility));
                }
            }
        }

        public Visibility foodUnitErrorVisibility
        {
            get => _foodUnitErrorVisibility;
            set
            {
                if (_foodUnitErrorVisibility != value)
                {
                    _foodUnitErrorVisibility = value;
                    OnPropertyChanged(nameof(foodUnitErrorVisibility));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
