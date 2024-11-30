using KeepItFit___Project_WinUI.Model;
using KeepItFit___Project_WinUI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KeepItFit___Project_WinUI.ViewModel
{
    public class ExercisePageViewModel : INotifyPropertyChanged
    {
        private DateTimeOffset _selectedDate;
        public InputExerciseViewModel ExerciseInput { get; set; }
        public string Notes { get; set; }

        public ExercisePageViewModel()
        {
            _selectedDate = DateTimeOffset.Now;

            ExerciseInput = new InputExerciseViewModel();
            ExerciseInput.init();

            UpdateDataExercises();
            GetNotesForTheDay();
        }

        public DateTimeOffset SelectedDate
        {
            get => _selectedDate;
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    OnPropertyChanged();
                    UpdateDataExercises();
                    GetNotesForTheDay();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Logic to update data based on the selected date
        public void UpdateDataExercises()
        {
            IDao sqlDao = new SQLDao();
            string formattedDate = _selectedDate.ToString("yyyy-MM-dd");

            // Clear the previous exercise data when change calendar date
            ExerciseInput.CardioExerciseData.Clear();
            ExerciseInput.StrengthTrainingData.Clear();

            // Get the exercise data from the database
            ExerciseInput.updateWithList_Cardio(sqlDao.GetCardioExerciseForTheDay_ExerciseDiary(formattedDate));
            ExerciseInput.updateWithList_Strength(sqlDao.GetStrengthExerciseForTheDay_ExerciseDiary(formattedDate));
        }

        // Logic to add a new Cardio exercise
        public void UpdateCardioExercise(CardioExercise cardioExercise)
        {
            IDao sqlDao = new SQLDao();
            string formattedDate = _selectedDate.ToString("yyyy-MM-dd");

            sqlDao.UpdateCardioExercise_ExerciseDiary(formattedDate, cardioExercise.exerciseId, cardioExercise._time, cardioExercise.caloriesPerMinute, cardioExercise.CaloriesBurned);
        }

        // Logic to add a new Strength exercise
        public void UpdateStrengthExercise(StrengthTraining strengthTraining)
        {
            IDao sqlDao = new SQLDao();
            string formattedDate = _selectedDate.ToString("yyyy-MM-dd");

            sqlDao.UpdateStrengthExercise_ExerciseDiary(formattedDate, strengthTraining.exerciseId, strengthTraining.Sets, strengthTraining.Reps_Set, strengthTraining.Weight_Sets);
        }

        // Logic to delete an exercise (Cardio or Strength)
        public void DeleteExercise(object exercise)
        {
            IDao sqlDao = new SQLDao();
            string formattedDate = _selectedDate.ToString("yyyy-MM-dd");
            
            if (exercise is CardioExercise cardio)
            {
                sqlDao.DeleteExerciseForTheDay_ExerciseDiary(formattedDate, cardio.exerciseId, "CardioExerciseDiary");
                ExerciseInput.CardioExerciseData.Remove(cardio);
            }
            else if (exercise is StrengthTraining strength)
            {
                sqlDao.DeleteExerciseForTheDay_ExerciseDiary(formattedDate, strength.exerciseId, "StrengthTrainingExerciseDiary");
                ExerciseInput.StrengthTrainingData.Remove(strength);
            }
        }

        // Get "Notes" for the selected date
        public void GetNotesForTheDay()
        {
            IDao sqlDao = new SQLDao();
            string formattedDate = _selectedDate.ToString("yyyy-MM-dd");

            Notes = sqlDao.GetNotesForTheDay_ExerciseDiary(formattedDate);
        }

        // Update "Notes" for the selected date
        public void UpdateNotesForTheDay()
        {
            IDao sqlDao = new SQLDao();
            string formattedDate = _selectedDate.ToString("yyyy-MM-dd");

            sqlDao.UpdateNotesForTheDay_ExerciseDiary(formattedDate, Notes);
        }
    }
}
