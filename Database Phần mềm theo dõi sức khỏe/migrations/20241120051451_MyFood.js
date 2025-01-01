/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.up = async function(knex) {
    await knex.raw(`
        CREATE TABLE MyFood(  
            ID INT IDENTITY(1,1) PRIMARY KEY,
            FOOD_NAME NVARCHAR(255) NOT NULL,
            FOOD_CALORIES FLOAT NOT NULL,
            FOOD_CARBS FLOAT NOT NULL,
            FOOD_FAT FLOAT NOT NULL,
            FOOD_PROTEIN FLOAT NOT NULL,
            FOOD_SODIUM FLOAT NOT NULL,
            FOOD_SUGAR FLOAT NOT NULL,
            FOOD_QUANTITY NVARCHAR(50) NOT NULL,
            FOOD_UNIT NVARCHAR(MAX) NOT NULL, -- Save the unit of the food
            SELECTED_FOOD_UNIT NVARCHAR(50) NOT NULL,
        );
    `);

    await knex.raw(`
        CREATE TABLE MyFood_Lunch(
            FOOD_ID INT,
            FOOD_QUANTITY NVARCHAR(50) NOT NULL,
            FOOD_DATE DATE,
            FOREIGN KEY (FOOD_ID) REFERENCES MyFood(ID),
            FOREIGN KEY (FOOD_DATE) REFERENCES FOODDIARY(FOOD_DATE)
        );
    `);

    await knex.raw(`
        CREATE TABLE MyFood_Dinner(
            FOOD_ID INT,
            FOOD_QUANTITY NVARCHAR(50) NOT NULL,
            FOOD_DATE DATE,
            FOREIGN KEY (FOOD_ID) REFERENCES MyFood(ID),
            FOREIGN KEY (FOOD_DATE) REFERENCES FOODDIARY(FOOD_DATE)
        );
    `);


    await knex.raw(`
        CREATE TABLE MyFood_Snack(
            FOOD_ID INT,
            FOOD_QUANTITY NVARCHAR(50) NOT NULL,
            FOOD_DATE DATE,
            FOREIGN KEY (FOOD_ID) REFERENCES MyFood(ID),
            FOREIGN KEY (FOOD_DATE) REFERENCES FOODDIARY(FOOD_DATE)
        );
    `);

    await knex.raw(`
        CREATE TABLE MyFood_Breakfast(
            FOOD_ID INT,
            FOOD_QUANTITY NVARCHAR(50) NOT NULL,
            FOOD_DATE DATE,
            FOREIGN KEY (FOOD_ID) REFERENCES MyFood(ID),
            FOREIGN KEY (FOOD_DATE) REFERENCES FOODDIARY(FOOD_DATE)
        );
    `);
};

/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.down = async function(knex) {
    await knex.raw(`
        DROP TABLE MyFood;
    `);
};
