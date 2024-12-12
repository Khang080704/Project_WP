/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> } 
 */
exports.seed = async function(knex) {
    // Deletes ALL existing entries
    await knex('StrengthTrainingExerciseDiary').del();
    await knex('CardioExerciseDiary').del();
    await knex('EXERCISEDIARY').del();
    await knex('BREAKFASTDIARY').del();
    await knex('SNACKDIARY').del();
    await knex('DINNERDIARY').del();
    await knex('LUNCHDIARY').del();
    await knex('RECENTFOOD').del();
    await knex('FREQUENTFOOD').del();
    await knex('FOODDIARY').del();
    await knex('QUICKADD_BREAKFAST').del();
    await knex('QUICKADD_LUNCH').del();
    await knex('QUICKADD_DINNER').del();
    await knex('QUICKADD_SNACK').del();

    await knex('User').del();
    
    // Insert data into User table
    await knex('User').insert([
      { Email: '123@example.com', Password: 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', FirstName: 'harry', LastName: 'Potter', DateOfBirth: '2024-12-10', DailyCaloriesGoal: 1800 },
      { Email: '456@example.com', Password: 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', FirstName: 'john', LastName: 'wick', DateOfBirth: '2024-12-10', DailyCaloriesGoal: 2000 },
      { Email: '789@example.com', Password: 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', FirstName: 'Tom', LastName: 'Jerry', DateOfBirth: '2024-12-17', DailyCaloriesGoal: 2000 },
      { Email: 'dsds@dsd.com', Password: '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', FirstName: 'hello', LastName: 'dds', DateOfBirth: '2024-12-10', DailyCaloriesGoal: 1500 }
    ]);
};