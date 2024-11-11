using KeepItFit___Project_WinUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI.ViewModel
{
    public class InputExerciseViewModel
    {
        public ObservableCollection<CardioExercise> CardioExerciseData { get; set; }
        public ObservableCollection<StrengthTraining> StrengthTrainingData { get; set; }
        public void init()
        {
            CardioExerciseData = new ObservableCollection<CardioExercise>();
            StrengthTrainingData = new ObservableCollection<StrengthTraining>();
        }
        public void updateWithCardio(CardioExercise cardioExercise)
        {
            CardioExerciseData.Add(cardioExercise);
        }
        public void updateWithStrength(StrengthTraining strengthTraining)
        {
            StrengthTrainingData.Add(strengthTraining);
        }
    }
}
