/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.up = async function(knex) {
    await knex.raw(`
        CREATE TABLE UserInfor(
            id int identity(1,1) primary key,
            Calo int,
            Carbs int,
            Fat int,
            Sodium int,
            Sugar int,
            Protein int,
        )
    `);
};

/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.down = async function(knex) {
    await knex.raw(`
        DROP TABLE USER
    `);
};
