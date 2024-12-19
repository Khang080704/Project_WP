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
    await knex.raw(`
      INSERT INTO [User] (Email, Password, FirstName, LastName, DateOfBirth, DailyCaloriesGoal, Avatar)
      VALUES 
      ('123@example.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'harry', 'Potter', '2024-12-10', 1800, CONVERT(VARBINARY(MAX), NULL)),
      ('456@example.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'john', 'wick', '2024-12-10', 2000, CONVERT(VARBINARY(MAX), NULL)),
      ('789@example.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'Tom', 'Jerry', '2024-12-17', 2000, CONVERT(VARBINARY(MAX), NULL)),
      ('dsds@dsd.com', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 'hello', 'dds', '2024-12-10', 1500, CONVERT(VARBINARY(MAX), NULL))
  `);
};