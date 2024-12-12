exports.seed = async function(knex) {
    await knex('StrengthTrainingExerciseDiary').del();
    await knex('CardioExerciseDiary').del();
    await knex('EXERCISEDIARY').del();

    // Insert data into EXERCISEDIARY
    await knex('EXERCISEDIARY').insert([
        { EXERCISE_DATE: '2024-10-28', NOTE: 'Cardio', USER_EMAIL: '123@example.com' },
        { EXERCISE_DATE: '2024-11-29', NOTE: 'Strength Training', USER_EMAIL: '456@example.com' }
    ]);
    
    // Insert data into CardioExerciseDiary
    await knex('CardioExerciseDiary').insert({ Exercise_ID: 1, EXERCISE_DATE: '2024-10-28', USER_EMAIL: '123@example.com', TimeHowLong: 30, CaloriesBurned: 200, CaloriesPerMinutes: 6.67 });
    await knex('CardioExerciseDiary').insert({ Exercise_ID: 2, EXERCISE_DATE: '2024-11-29', USER_EMAIL: '456@example.com', TimeHowLong: 45, CaloriesBurned: 300, CaloriesPerMinutes: 6.67 });
    
    // Insert data into StrengthTrainingExerciseDiary
    await knex('StrengthTrainingExerciseDiary').insert({ Exercise_ID: 1, EXERCISE_DATE: '2024-10-28', USER_EMAIL: '123@example.com', Sets: 3, Reps_Set: 10, Weight_Set: 50 });
    await knex('StrengthTrainingExerciseDiary').insert({ Exercise_ID: 2, EXERCISE_DATE: '2024-11-29', USER_EMAIL: '456@example.com', Sets: 4, Reps_Set: 12, Weight_Set: 60 });
    await knex('StrengthTrainingExerciseDiary').insert({ Exercise_ID: 3, EXERCISE_DATE: '2024-11-29', USER_EMAIL: '456@example.com', Sets: 5, Reps_Set: 15, Weight_Set: 70 });
};