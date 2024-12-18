/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.up = async function(knex) {
    await knex.raw(`
        CREATE TABLE [User](
            Email NVARCHAR(50) PRIMARY KEY,
            Password TEXT NOT NULL,
            FirstName NVARCHAR(50) NOT NULL,
            LastName NVARCHAR(50) NOT NULL,
            DateOfBirth DATE NOT NULL,
            DailyCaloriesGoal INT NOT NULL,
            Calo int default 0,
            Carbs int default 0,
            Fat int default 0,
            Sodium int default 0,
            Sugar int default 0,
            Protein int default 0,
            Avatar VARBINARY(MAX),
        );
    `);
};

/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.down = async function(knex) {
    await knex.raw(`
        DROP TABLE [User];
    `);
};
