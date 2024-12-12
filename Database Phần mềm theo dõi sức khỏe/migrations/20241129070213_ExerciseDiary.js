/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.up = async function(knex) {
    await knex.raw(`
        CREATE TABLE ExerciseDiary(
            EXERCISE_DATE DATE,
            NOTE TEXT,
            USER_EMAIL NVARCHAR(50),
            PRIMARY KEY (EXERCISE_DATE, USER_EMAIL),
            FOREIGN KEY (USER_EMAIL) REFERENCES [User](Email)
        );
    `);

    await knex.raw(`
        CREATE TABLE CardioExerciseDiary(
            Exercise_ID INT,
            EXERCISE_DATE DATE,
            USER_EMAIL NVARCHAR(50),
            TimeHowLong INT,
            CaloriesBurned INT,
            CaloriesPerMinutes FLOAT,
            FOREIGN KEY (Exercise_ID) REFERENCES CardioExercise(ID),
            FOREIGN KEY (EXERCISE_DATE, USER_EMAIL) REFERENCES ExerciseDiary(EXERCISE_DATE, USER_EMAIL)
        );
    `);

    await knex.raw(`
        CREATE TABLE StrengthTrainingExerciseDiary(
            Exercise_ID INT,
            EXERCISE_DATE DATE,
            USER_EMAIL NVARCHAR(50),
            Sets INT,
            Reps_Set INT,
            Weight_Set INT,
            FOREIGN KEY (Exercise_ID) REFERENCES StrengthTraining(ID),
            FOREIGN KEY (EXERCISE_DATE, USER_EMAIL) REFERENCES ExerciseDiary(EXERCISE_DATE, USER_EMAIL)
        ); 
    `);
};

/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.down = async function(knex) {
    await knex.raw(`
        DROP TABLE ExerciseDiary;
        DROP TABLE CardioExerciseDiary;
        DROP TABLE StrengthTrainingExerciseDiary;
    `);
};
