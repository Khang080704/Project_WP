/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.up = async function(knex) {
    await knex.raw(`
        create table StrengthTraining(
	        ID INT IDENTITY(1,1) not null PRIMARY KEY,
	        Strength_name nvarchar(255) not null,
	        Sets int,
	        Reps_Set int,
	        Weigth_Set int,
)
    `);
};

/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.down = async function(knex) {
    await knex.raw(`
        DROP TABLE StrengthTraining;
    `);
};
