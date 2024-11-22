using KeepItFit___Project_WinUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeepItFit___Project_WinUI.Services;

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
            CardioExerciseDatabase = new ObservableCollection<CardioExercise>();
            CardioExerciseSearchList = new ObservableCollection<CardioExercise>();
            _selectedCardioExercise = new CardioExercise();

            strengthTrainingDatabase = new ObservableCollection<StrengthTraining>();
            strengthTrainingSearchList = new ObservableCollection<StrengthTraining>();
            _selectedStrengthTraining = new StrengthTraining();
        }

        public ObservableCollection<CardioExercise> getCardioDatabase(string keyword)
        {
            var sql = new SQLDao();
            CardioExerciseDatabase = sql.GetAllCardioExercise(keyword);
            return CardioExerciseDatabase;
        }

        public ObservableCollection<StrengthTraining> getStrengthTrainDatabase(string keyword)
        {
            var sql = new SQLDao();
            strengthTrainingDatabase = sql.GetAllStrengthTraining(keyword);
            return strengthTrainingDatabase;
        }
    }
}
