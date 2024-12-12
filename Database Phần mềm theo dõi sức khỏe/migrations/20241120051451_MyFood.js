/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.up = async function(knex) {
    await knex.raw(`
        CREATE TABLE MyFood(  
            ID INT IDENTITY(1,1),
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
            USER_EMAIL NVARCHAR(50),
            PRIMARY KEY (ID, USER_EMAIL),
            FOREIGN KEY (USER_EMAIL) REFERENCES [User](Email)
        );
    `);

    await knex.raw(`
        CREATE TABLE MyFood_Lunch(
            FOOD_ID INT,
            FOOD_QUANTITY NVARCHAR(50) NOT NULL,
            FOOD_DATE DATE,
            USER_EMAIL NVARCHAR(50),
            FOREIGN KEY (FOOD_ID, USER_EMAIL) REFERENCES MyFood(ID, USER_EMAIL),
            FOREIGN KEY (FOOD_DATE, USER_EMAIL) REFERENCES FOODDIARY(FOOD_DATE, USER_EMAIL)
        );
    `);

    await knex.raw(`
        CREATE TABLE MyFood_Dinner(
            FOOD_ID INT,
            FOOD_QUANTITY NVARCHAR(50) NOT NULL,
            FOOD_DATE DATE,
            USER_EMAIL NVARCHAR(50),
            FOREIGN KEY (FOOD_ID, USER_EMAIL) REFERENCES MyFood(ID, USER_EMAIL),
            FOREIGN KEY (FOOD_DATE, USER_EMAIL) REFERENCES FOODDIARY(FOOD_DATE, USER_EMAIL)
        );
    `);


    await knex.raw(`
        CREATE TABLE MyFood_Snack(
            FOOD_ID INT,
            FOOD_QUANTITY NVARCHAR(50) NOT NULL,
            FOOD_DATE DATE,
            USER_EMAIL NVARCHAR(50),
            FOREIGN KEY (FOOD_ID, USER_EMAIL) REFERENCES MyFood(ID, USER_EMAIL),
            FOREIGN KEY (FOOD_DATE, USER_EMAIL) REFERENCES FOODDIARY(FOOD_DATE, USER_EMAIL)
        );
    `);

    await knex.raw(`
        CREATE TABLE MyFood_Breakfast(
            FOOD_ID INT,
            FOOD_QUANTITY NVARCHAR(50) NOT NULL,
            FOOD_DATE DATE,
            USER_EMAIL NVARCHAR(50),
            FOREIGN KEY (FOOD_ID, USER_EMAIL) REFERENCES MyFood(ID, USER_EMAIL),
            FOREIGN KEY (FOOD_DATE, USER_EMAIL) REFERENCES FOODDIARY(FOOD_DATE, USER_EMAIL)
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
