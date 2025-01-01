/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.up = async function(knex) {
    await knex.raw(`
        IF OBJECT_ID('FREQUENTFOOD', 'U') IS NOT NULL
        BEGIN
            DROP TABLE FREQUENTFOOD;
        END
    `);
    await knex.raw(`
         CREATE TABLE FREQUENTFOOD(  
            ID INT IDENTITY(1,1),
            FOOD_ID INT NOT NULL,
            NUMBER_EAT INT NOT NULL,
            USER_EMAIL NVARCHAR(50),
            PRIMARY KEY (ID, USER_EMAIL),
            FOREIGN KEY (USER_EMAIL) REFERENCES [User](Email),
            FOREIGN KEY (FOOD_ID) REFERENCES FOOD(ID)
        );
    `);

    await knex.raw(`
        CREATE TRIGGER TRG_UPDATE_FREQUENTFOOD
        ON FREQUENTFOOD
        INSTEAD OF INSERT
        AS
        BEGIN
            DECLARE @new_food_id INT;
            DECLARE @new_user_email NVARCHAR(50);
            SELECT @new_food_id = FOOD_ID, @new_user_email = USER_EMAIL FROM inserted;

            -- Check if the FOOD_ID and USER_EMAIL combination already exists in FREQUENTFOOD
            IF EXISTS (SELECT 1 FROM FREQUENTFOOD WHERE FOOD_ID = @new_food_id AND USER_EMAIL = @new_user_email)
            BEGIN
                -- If it exists, increment the NUMBER_EAT
                UPDATE FREQUENTFOOD
                SET NUMBER_EAT = NUMBER_EAT + 1
                WHERE FOOD_ID = @new_food_id AND USER_EMAIL = @new_user_email;
            END
            ELSE
            BEGIN
                -- If it does not exist, insert a new row with NUMBER_EAT set to 1
                INSERT INTO FREQUENTFOOD (FOOD_ID, NUMBER_EAT, USER_EMAIL)
                VALUES (@new_food_id, 1, @new_user_email);
            END
        END;`)
};

/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.down = async function(knex) {
    await knex.raw(`
        DROP TRIGGER IF EXISTS TRG_LIMIT_RECENTFOOD;
        DROP TABLE FREQUENTFOOD;
    `);
};
