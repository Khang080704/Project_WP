/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.up = async function(knex) {
    await knex.raw(`
        CREATE TABLE FOODDIARY(
            FOOD_DATE DATE,
            TOTALCALO INT,
            USER_EMAIL NVARCHAR(50),
            PRIMARY KEY (FOOD_DATE, USER_EMAIL),
            FOREIGN KEY (USER_EMAIL) REFERENCES [User](Email)
        );
    `);

    await knex.raw(`
        CREATE TABLE LUNCHDIARY(
            FOOD_ID INT,
            FOOD_QUANTITY NVARCHAR(50) NOT NULL,
            FOOD_DATE DATE,
            USER_EMAIL NVARCHAR(50),
            FOREIGN KEY (FOOD_ID) REFERENCES FOOD(ID),
            FOREIGN KEY (FOOD_DATE, USER_EMAIL) REFERENCES FOODDIARY(FOOD_DATE, USER_EMAIL)
        );
    `);
    
    await knex.raw(`
        CREATE TABLE DINNERDIARY(
            FOOD_ID INT,
            FOOD_QUANTITY NVARCHAR(50) NOT NULL,
            FOOD_DATE DATE,
            USER_EMAIL NVARCHAR(50),
            FOREIGN KEY (FOOD_ID) REFERENCES FOOD(ID),
            FOREIGN KEY (FOOD_DATE, USER_EMAIL) REFERENCES FOODDIARY(FOOD_DATE, USER_EMAIL)
        );
    `);
    
    await knex.raw(`
        CREATE TABLE SNACKDIARY(
            FOOD_ID INT,
            FOOD_QUANTITY NVARCHAR(50) NOT NULL,
            FOOD_DATE DATE,
            USER_EMAIL NVARCHAR(50),
            FOREIGN KEY (FOOD_ID) REFERENCES FOOD(ID),
            FOREIGN KEY (FOOD_DATE, USER_EMAIL) REFERENCES FOODDIARY(FOOD_DATE, USER_EMAIL)
        );
    `);
    
    await knex.raw(`
        CREATE TABLE BREAKFASTDIARY(
            FOOD_ID INT,
            FOOD_QUANTITY NVARCHAR(50) NOT NULL,
            FOOD_DATE DATE,
            USER_EMAIL NVARCHAR(50),
            FOREIGN KEY (FOOD_ID) REFERENCES FOOD(ID),
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
        DROP TABLE BREAKFASTDIARY;
        DROP TABLE SNACKDIARY;
        DROP TABLE DINNERDIARY;
        DROP TABLE LUNCHDIARY;
        DROP TABLE FOODDIARY;
    `);
};