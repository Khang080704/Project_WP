using KeepItFit___Project_WinUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI.ViewModel
{
    public class SearchExerciseViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CardioExercise> CardioExerciseDatabase { get; set; }
        public ObservableCollection<CardioExercise> CardioExerciseSearchList { get; set; }
        public CardioExercise _selectedCardioExercise {  get; set; }
        public bool isCardioExerciseSelected { get; set; }

        public ObservableCollection<StrengthTraining> strengthTrainingDatabase { get; set; }
        public ObservableCollection<StrengthTraining> strengthTrainingSearchList { get; set; }
        public StrengthTraining _selectedStrengthTraining { get; set; }
        public bool isStrengthExerciseSelected { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public void init()
        {
            IDao dao = new MockDAO();
            CardioExerciseDatabase = dao.GetAllCardioExercise();
            CardioExerciseSearchList = new ObservableCollection<CardioExercise>();
            _selectedCardioExercise = new CardioExercise();

            strengthTrainingDatabase = dao.GetAllStrengthTraining();
            strengthTrainingSearchList = new ObservableCollection<StrengthTraining>();
            _selectedStrengthTraining = new StrengthTraining();
        }
    }
}
