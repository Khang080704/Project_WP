/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.up = async function(knex) {
    await knex.raw(`
        CREATE TABLE FOOD(  
            ID INT IDENTITY(1,1) PRIMARY KEY,
            FOOD_NAME NVARCHAR(255) NOT NULL,
            FOOD_CALORIES FLOAT NOT NULL,
            FOOD_CARBS FLOAT NOT NULL,
            FOOD_FAT FLOAT NOT NULL,
            FOOD_PROTEIN FLOAT NOT NULL,
            FOOD_SODIUM FLOAT NOT NULL,
            FOOD_SUGAR FLOAT NOT NULL,
            FOOD_QUANTITY NVARCHAR(50) NOT NULL,
            FOOD_UNIT NVARCHAR(MAX) NOT NULL, -- Save the unit of the food using JSON format
            SELECTED_FOOD_UNIT NVARCHAR(50) NOT NULL,
	    Primary key(ID, FOOD_NAME)
        );
    `);
};

/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.down = async function(knex) {
    await knex.raw(`
        DROP TABLE FOOD;
    `);
};