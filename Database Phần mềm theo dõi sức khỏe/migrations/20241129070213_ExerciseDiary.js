/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.up = async function(knex) {
    await knex.raw(`
        CREATE TABLE ExerciseDiary(
            EXERCISE_DATE DATE PRIMARY KEY,
            NOTE TEXT
        );
    `);

    await knex.raw(`
        CREATE TABLE CardioExerciseDiary(
            Exercise_ID INT,
            EXERCISE_DATE DATE,
            TimeHowLong int,
	        CaloriesBurned int,
	        CaloriesPerMinutes float,
            FOREIGN KEY (Exercise_ID) REFERENCES CardioExercise(ID),
            FOREIGN KEY (EXERCISE_DATE) REFERENCES ExerciseDiary(EXERCISE_DATE)
        );
    `);

    await knex.raw(`
        CREATE TABLE StrengthTrainingExerciseDiary(
            Exercise_ID INT,
            EXERCISE_DATE DATE,
            Sets int,
            Reps_Set int,
            Weigth_Set int,
            FOREIGN KEY (Exercise_ID) REFERENCES StrengthTraining(ID),
            FOREIGN KEY (EXERCISE_DATE) REFERENCES ExerciseDiary(EXERCISE_DATE)
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
