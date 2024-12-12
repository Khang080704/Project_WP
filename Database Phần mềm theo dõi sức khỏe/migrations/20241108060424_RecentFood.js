/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.up = async function(knex) {
    await knex.raw(`
        IF OBJECT_ID('RECENTFOOD', 'U') IS NOT NULL
        BEGIN
            DROP TABLE RECENTFOOD;
        END
    `);
    await knex.raw(`
        CREATE TABLE RECENTFOOD(  
            ID INT IDENTITY(1,1),
            FOOD_ID INT NOT NULL,
            USER_EMAIL NVARCHAR(50),
            PRIMARY KEY (ID, USER_EMAIL),
            FOREIGN KEY (USER_EMAIL) REFERENCES [User](Email),
            FOREIGN KEY (FOOD_ID) REFERENCES FOOD(ID)
        );
    `);

    await knex.raw(`
        CREATE TRIGGER TRG_LIMIT_RECENTFOOD
        ON RECENTFOOD
        INSTEAD OF INSERT
        AS
        BEGIN
            DECLARE @new_FOOD_ID INT;
            DECLARE @new_USER_EMAIL NVARCHAR(50);
            SELECT @new_FOOD_ID = FOOD_ID, @new_USER_EMAIL = USER_EMAIL FROM inserted;

            -- Check if the FOOD_ID and USER_EMAIL combination already exists
            IF NOT EXISTS (SELECT 1 FROM RECENTFOOD WHERE FOOD_ID = @new_FOOD_ID AND USER_EMAIL = @new_USER_EMAIL)
            BEGIN
                -- If the table has 5 rows for the same USER_EMAIL, delete the oldest row
                IF (SELECT COUNT(*) FROM RECENTFOOD WHERE USER_EMAIL = @new_USER_EMAIL) >= 5
                BEGIN
                    DELETE FROM RECENTFOOD
                    WHERE ID = (SELECT TOP 1 ID FROM RECENTFOOD WHERE USER_EMAIL = @new_USER_EMAIL ORDER BY ID);
                END

                -- Insert the new FOOD_ID and USER_EMAIL
                INSERT INTO RECENTFOOD (FOOD_ID, USER_EMAIL) VALUES (@new_FOOD_ID, @new_USER_EMAIL);
            END
        END;
    `);
};

/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> }
 */
exports.down = async function(knex) {
    await knex.raw(`
        DROP TRIGGER IF EXISTS TRG_LIMIT_RECENTFOOD;
        DROP TABLE RECENTFOOD;
    `);
};