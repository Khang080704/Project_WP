/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.up = async function(knex) {
    await knex.raw(`
        CREATE TABLE FOODDIARY(
            FOOD_DATE DATE PRIMARY KEY,
            TOTALCALO INT
        );
    `);

    await knex.raw(`
        CREATE TABLE LUNCHDIARY(
            FOOD_ID INT,
            FOOD_QUANTITY NVARCHAR(50) NOT NULL,
            FOOD_DATE DATE,
            FOREIGN KEY (FOOD_ID) REFERENCES FOOD(ID),
            FOREIGN KEY (FOOD_DATE) REFERENCES FOODDIARY(FOOD_DATE)
        );
    `);

    await knex.raw(`
        CREATE TABLE DINNERDIARY(
            FOOD_ID INT,
            FOOD_QUANTITY NVARCHAR(50) NOT NULL,
            FOOD_DATE DATE,
            FOREIGN KEY (FOOD_ID) REFERENCES FOOD(ID),
            FOREIGN KEY (FOOD_DATE) REFERENCES FOODDIARY(FOOD_DATE)
        );
    `);


    await knex.raw(`
        CREATE TABLE SNACKDIARY(
            FOOD_ID INT,
            FOOD_QUANTITY NVARCHAR(50) NOT NULL,
            FOOD_DATE DATE,
            FOREIGN KEY (FOOD_ID) REFERENCES FOOD(ID),
            FOREIGN KEY (FOOD_DATE) REFERENCES FOODDIARY(FOOD_DATE)
        );
    `);

    await knex.raw(`
        CREATE TABLE BREAKFASTDIARY(
            FOOD_ID INT,
            FOOD_QUANTITY NVARCHAR(50) NOT NULL,
            FOOD_DATE DATE,
            FOREIGN KEY (FOOD_ID) REFERENCES FOOD(ID),
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
        DROP TABLE BREAKFASTDIARY;
        DROP TABLE SNACKDIARY;
        DROP TABLE DINNERDIARY;
        DROP TABLE LUNCHDIARY;
        DROP TABLE FOODDIARY;
    `);
};