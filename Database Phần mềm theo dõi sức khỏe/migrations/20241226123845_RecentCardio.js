/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.up = async function(knex) {
    await knex.raw(`
        CREATE TABLE RECENTCARDIO(  
            Cardio_ID int,
            Cardio_name varchar(255),
            TimeHowLong int,
            CaloriesPerMinutes float,
            CaloriesBurned int,
            USER_EMAIL NVARCHAR(50),
            PRIMARY KEY (Cardio_ID, USER_EMAIL),
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
        DROP TABLE RECENTCARDIO;
    `);
};
