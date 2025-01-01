/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.up = async function(knex) {
    await knex.raw(`
        CREATE TABLE RECENTSTRENGTH(  
            Strength_ID int,
            Strength_name varchar(255),
            Sets int,
            Reps_Set int,
            Weight_Set int,
            USER_EMAIL NVARCHAR(50),
            PRIMARY KEY (Strength_ID, USER_EMAIL),
            FOREIGN KEY (USER_EMAIL) REFERENCES [User](Email)
        );
    `);
};

/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.down = async function(knex) {
    await knex.raw(`
        DROP TABLE RECENTSTRENGTH;
    `);
};
