/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.up = async function(knex) {
    await knex.raw(`
        CREATE TABLE QUICKADD_BREAKFAST(
            ID INT,
            FOOD_DATE DATE,
            FOOD_CALORIES FLOAT NOT NULL,
            FOOD_CARBS FLOAT NOT NULL,
            FOOD_FAT FLOAT NOT NULL,
            FOOD_PROTEIN FLOAT NOT NULL,
            FOOD_SODIUM FLOAT NOT NULL,
            FOOD_SUGAR FLOAT NOT NULL,
            USER_EMAIL NVARCHAR(50),
            PRIMARY KEY(ID, FOOD_DATE, USER_EMAIL),
            FOREIGN KEY (USER_EMAIL) REFERENCES [User](Email)
        );
    `);

    await knex.raw(`
    CREATE TRIGGER trg_QUICKADD_BREAKFAST_Insert
    ON QUICKADD_BREAKFAST
    INSTEAD OF INSERT
    AS
    BEGIN
        DECLARE @maxID INT;

        -- Calculate the max ID for each FOOD_DATE and USER_EMAIL
        INSERT INTO QUICKADD_BREAKFAST (ID, FOOD_DATE, FOOD_CALORIES, FOOD_CARBS, FOOD_FAT, FOOD_PROTEIN, FOOD_SODIUM, FOOD_SUGAR, USER_EMAIL)
        SELECT 
            ISNULL((SELECT MAX(ID) FROM QUICKADD_BREAKFAST WHERE FOOD_DATE = i.FOOD_DATE AND USER_EMAIL = i.USER_EMAIL), 0) + 1,
            i.FOOD_DATE,
            i.FOOD_CALORIES,
            i.FOOD_CARBS,
            i.FOOD_FAT,
            i.FOOD_PROTEIN,
            i.FOOD_SODIUM,
            i.FOOD_SUGAR,
            i.USER_EMAIL
        FROM inserted i;
    END;
    `)

    await knex.raw(`
        CREATE TABLE QUICKADD_LUNCH(
            ID INT,
            FOOD_DATE DATE,
            FOOD_CALORIES FLOAT NOT NULL,
            FOOD_CARBS FLOAT NOT NULL,
            FOOD_FAT FLOAT NOT NULL,
            FOOD_PROTEIN FLOAT NOT NULL,
            FOOD_SODIUM FLOAT NOT NULL,
            FOOD_SUGAR FLOAT NOT NULL,
            USER_EMAIL NVARCHAR(50),
            PRIMARY KEY(ID, FOOD_DATE, USER_EMAIL),
            FOREIGN KEY (USER_EMAIL) REFERENCES [User](Email)
        );
    `);

    await knex.raw(`
        CREATE TRIGGER trg_QUICKADD_LUNCH_Insert
        ON QUICKADD_LUNCH
        INSTEAD OF INSERT
        AS
        BEGIN
            INSERT INTO QUICKADD_LUNCH (ID, FOOD_DATE, FOOD_CALORIES, FOOD_CARBS, FOOD_FAT, FOOD_PROTEIN, FOOD_SODIUM, FOOD_SUGAR, USER_EMAIL)
            SELECT 
                ISNULL((SELECT MAX(ID) FROM QUICKADD_LUNCH WHERE FOOD_DATE = i.FOOD_DATE AND USER_EMAIL = i.USER_EMAIL), 0) + 1,
                i.FOOD_DATE,
                i.FOOD_CALORIES,
                i.FOOD_CARBS,
                i.FOOD_FAT,
                i.FOOD_PROTEIN,
                i.FOOD_SODIUM,
                i.FOOD_SUGAR,
                i.USER_EMAIL
            FROM inserted i;
        END;
    `)

    await knex.raw(`    
        CREATE TABLE QUICKADD_DINNER(
            ID INT,
            FOOD_DATE DATE,
            FOOD_CALORIES FLOAT NOT NULL,
            FOOD_CARBS FLOAT NOT NULL,
            FOOD_FAT FLOAT NOT NULL,
            FOOD_PROTEIN FLOAT NOT NULL,
            FOOD_SODIUM FLOAT NOT NULL,
            FOOD_SUGAR FLOAT NOT NULL,
            USER_EMAIL NVARCHAR(50),
            PRIMARY KEY(ID, FOOD_DATE, USER_EMAIL),
            FOREIGN KEY (USER_EMAIL) REFERENCES [User](Email)
        );
    `)

    await knex.raw(`
        CREATE TRIGGER trg_QUICKADD_DINNER_Insert
        ON QUICKADD_DINNER
        INSTEAD OF INSERT
        AS
        BEGIN
            INSERT INTO QUICKADD_DINNER (ID, FOOD_DATE, FOOD_CALORIES, FOOD_CARBS, FOOD_FAT, FOOD_PROTEIN, FOOD_SODIUM, FOOD_SUGAR, USER_EMAIL)
            SELECT 
                ISNULL((SELECT MAX(ID) FROM QUICKADD_DINNER WHERE FOOD_DATE = i.FOOD_DATE AND USER_EMAIL = i.USER_EMAIL), 0) + 1,
                i.FOOD_DATE,
                i.FOOD_CALORIES,
                i.FOOD_CARBS,
                i.FOOD_FAT,
                i.FOOD_PROTEIN,
                i.FOOD_SODIUM,
                i.FOOD_SUGAR,
                i.USER_EMAIL
            FROM inserted i;
        END;
    `)

    await knex.raw(`
        CREATE TABLE QUICKADD_SNACK(
            ID INT,
            FOOD_DATE DATE,
            FOOD_CALORIES FLOAT NOT NULL,
            FOOD_CARBS FLOAT NOT NULL,
            FOOD_FAT FLOAT NOT NULL,
            FOOD_PROTEIN FLOAT NOT NULL,
            FOOD_SODIUM FLOAT NOT NULL,
            FOOD_SUGAR FLOAT NOT NULL,
            USER_EMAIL NVARCHAR(50),
            PRIMARY KEY(ID, FOOD_DATE, USER_EMAIL),
            FOREIGN KEY (USER_EMAIL) REFERENCES [User](Email)
        );
    `)

    await knex.raw(`
        CREATE TRIGGER trg_QUICKADD_SNACK_Insert
        ON QUICKADD_SNACK
        INSTEAD OF INSERT
        AS
        BEGIN
            INSERT INTO QUICKADD_SNACK (ID, FOOD_DATE, FOOD_CALORIES, FOOD_CARBS, FOOD_FAT, FOOD_PROTEIN, FOOD_SODIUM, FOOD_SUGAR, USER_EMAIL)
            SELECT 
                ISNULL((SELECT MAX(ID) FROM QUICKADD_SNACK WHERE FOOD_DATE = i.FOOD_DATE AND USER_EMAIL = i.USER_EMAIL), 0) + 1,
                i.FOOD_DATE,
                i.FOOD_CALORIES,
                i.FOOD_CARBS,
                i.FOOD_FAT,
                i.FOOD_PROTEIN,
                i.FOOD_SODIUM,
                i.FOOD_SUGAR,
                i.USER_EMAIL
            FROM inserted i;
        END;
    `)
};

/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.down = async function(knex) {
  
};
