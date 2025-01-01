/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.up = async function(knex) {
    await knex.raw(`
        create table CardioExercise(
	        ID INT IDENTITY(1,1) not null PRIMARY KEY,
	        Cardio_name nvarchar(255) not null,
	        TimeHowLong int,
	        CaloriesBurned int,
	        CaloriesPerMinutes float,
)
    `);
};

/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.down = async function(knex) {
    await knex.raw(`
        DROP TABLE CardioExercise;
    `);
};
