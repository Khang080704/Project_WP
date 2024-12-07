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
            ID INT IDENTITY(1,1) PRIMARY KEY,
            FOOD_ID INT NOT NULL,
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
            SELECT @new_FOOD_ID = FOOD_ID FROM inserted;

            -- Check if the FOOD_ID already exists
            IF NOT EXISTS (SELECT 1 FROM RECENTFOOD WHERE FOOD_ID = @new_FOOD_ID)
            BEGIN
                -- If the table has 5 rows, delete the oldest row
                IF (SELECT COUNT(*) FROM RECENTFOOD) >= 5
                BEGIN
                    DELETE FROM RECENTFOOD
                    WHERE ID = (SELECT TOP 1 ID FROM RECENTFOOD ORDER BY ID);
                END

                -- Insert the new FOOD_ID
                INSERT INTO RECENTFOOD (FOOD_ID) VALUES (@new_FOOD_ID);
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