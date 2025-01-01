/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.up = async function(knex) {
    await knex.raw(`
        CREATE TABLE UserStrength(  
            ID INT not null PRIMARY KEY,
            Email NVARCHAR(50),
            StrengthName NVARCHAR(255),
            Sets int,
	        Reps_Set int,
	        Weight_Set int,
        );
    `);
};

/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.down = async function(knex) {
    await knex.raw(`
        DROP TABLE UserStrength;
    `);
};
