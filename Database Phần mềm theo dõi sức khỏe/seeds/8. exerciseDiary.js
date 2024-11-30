exports.seed = async function(knex) {
    await knex('StrengthTrainingExerciseDiary').del();
    await knex('CardioExerciseDiary').del();
    await knex('EXERCISEDIARY').del();

    // Insert data into EXERCISEDIARY
    await knex('EXERCISEDIARY').insert([
        { EXERCISE_DATE: '2024-10-28', NOTE: 'Cardio' },
        { EXERCISE_DATE: '2024-11-29', NOTE: 'Strength Training' }
    ]);

    // Insert data into CardioExerciseDiary
    await knex('CardioExerciseDiary').insert({ Exercise_ID: 1, EXERCISE_DATE: '2024-10-28', TimeHowLong: 30, CaloriesBurned: 200, CaloriesPerMinutes: 6.67 });
    await knex('CardioExerciseDiary').insert({ Exercise_ID: 2, EXERCISE_DATE: '2024-11-29', TimeHowLong: 45, CaloriesBurned: 300, CaloriesPerMinutes: 6.67 });

    // Insert data into StrengthTrainingExerciseDiary
    await knex('StrengthTrainingExerciseDiary').insert({ Exercise_ID: 1, EXERCISE_DATE: '2024-10-28', Sets: 3, Reps_Set: 10, Weigth_Set: 50 });
    await knex('StrengthTrainingExerciseDiary').insert({ Exercise_ID: 2, EXERCISE_DATE: '2024-11-29', Sets: 4, Reps_Set: 12, Weigth_Set: 60 });
    await knex('StrengthTrainingExerciseDiary').insert({ Exercise_ID: 3, EXERCISE_DATE: '2024-11-29', Sets: 5, Reps_Set: 15, Weigth_Set: 70 });

};