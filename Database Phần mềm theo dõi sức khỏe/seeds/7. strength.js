/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> } 
 */
exports.seed = async function(knex) {
  // Deletes ALL existing entries
  await knex('StrengthTrainingExerciseDiary').del();
  await knex('CardioExerciseDiary').del();
  await knex('EXERCISEDIARY').del();
  await knex('StrengthTraining').del();
  await knex.raw('DBCC CHECKIDENT (\'StrengthTraining\', RESEED, 0)');
  await knex('StrengthTraining').insert([
    { Strength_name: 'Abdominal Leg Raise', Sets: 0, Reps_Set: 0, Weight_Set: 0},
    { Strength_name: 'Abdominal Twist, Seated, Machine', Sets: 0, Reps_Set: 0, Weight_Set: 0},
    { Strength_name: 'Back Extension', Sets: 0, Reps_Set: 0, Weight_Set: 0},
    { Strength_name: 'Bar Dip, Palms In, Neutral Grip', Sets: 0, Reps_Set: 0, Weight_Set: 0},
    { Strength_name: 'Barbell Military Press', Sets: 0, Reps_Set: 0, Weight_Set: 0},
    { Strength_name: 'Barbell Row, Bent-over', Sets: 0, Reps_Set: 0, Weight_Set: 0},
    { Strength_name: 'Bench Press, Barbell', Sets: 0, Reps_Set: 0, Weight_Set: 0},
    { Strength_name: 'Cable Crossover, High Pulley', Sets: 0, Reps_Set: 0, Weight_Set: 0},
    { Strength_name: 'Deadlift, Straight Leg', Sets: 0, Reps_Set: 0, Weight_Set: 0},
    { Strength_name: 'Dumbbell Row, Two-Arm, Bent-Over', Sets: 0, Reps_Set: 0, Weight_Set: 0},
    { Strength_name: 'Flat Dumbbell Fly', Sets: 0, Reps_Set: 0, Weight_Set: 0},
    { Strength_name: 'Front Barbell Raise, Standing, Medium-Grip', Sets: 0, Reps_Set: 0, Weight_Set: 0},
    { Strength_name: 'Hack Squat', Sets: 0, Reps_Set: 0, Weight_Set: 0},
    { Strength_name: 'Heel Raise', Sets: 0, Reps_Set: 0, Weight_Set: 0},
    { Strength_name: 'Hip Abduction, Machine, Seated', Sets: 0, Reps_Set: 0, Weight_Set: 0},
    { Strength_name: 'Lat Pulldown', Sets: 0, Reps_Set: 0, Weight_Set: 0},
    { Strength_name: 'Lateral Arm Raise, Machine', Sets: 0, Reps_Set: 0, Weight_Set: 0},
    { Strength_name: 'Lateral Raise, Dumbbell, Side', Sets: 0, Reps_Set: 0, Weight_Set: 0},
    { Strength_name: 'Machine Fly', Sets: 0, Reps_Set: 0, Weight_Set: 0},
    { Strength_name: 'Machine Squat', Sets: 0, Reps_Set: 0, Weight_Set: 0},
    { Strength_name: 'Overhead Press, Barbell', Sets: 0, Reps_Set: 0, Weight_Set: 0},
    { Strength_name: 'Preacher Bench Medium-Grip Barbell Curl', Sets: 0, Reps_Set: 0, Weight_Set: 0},
    { Strength_name: 'Seated Calf Raise', Sets: 0, Reps_Set: 0, Weight_Set: 0},
    { Strength_name: 'Side Bends, Barbell', Sets: 0, Reps_Set: 0, Weight_Set: 0},
    { Strength_name: 'Squat', Sets: 0, Reps_Set: 0, Weight_Set: 0},

  ]);
};
