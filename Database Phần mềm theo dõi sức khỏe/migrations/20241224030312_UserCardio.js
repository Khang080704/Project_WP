/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.up = async function(knex) {
    await knex.raw(`
        CREATE TABLE UserCardio(  
            ID INT not null PRIMARY KEY,
            Email NVARCHAR(50),
            CardioName NVARCHAR(255),
            TimeHowLong int,
	        CaloriesBurned int,
	        CaloriesPerMinutes float,
        );
    `);
};

/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.down = async function(knex) {
    await knex.raw(`
        DROP TABLE UserCardio;
    `);
};
