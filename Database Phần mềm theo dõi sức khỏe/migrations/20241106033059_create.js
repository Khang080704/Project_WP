/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.up = async function(knex) {
    await knex.raw(`
        CREATE TABLE FREQUENTFOOD(  
            ID INT IDENTITY(1,1) PRIMARY KEY,
            FOODID INT NOT NULL,
            FOREIGN KEY (FOODID) REFERENCES FOOD(ID)
        );
    `);
};

/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.down = async function(knex) {
    await knex.raw(`
        DROP TABLE FREQUENTFOOD;
    `);
};
