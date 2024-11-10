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
            ID INT IDENTITY(1,1) PRIMARY KEY,
            FOOD_ID INT NOT NULL,
			NUMBER_EAT INT NOT NULL,
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
            SELECT @new_food_id = FOOD_ID FROM inserted;

            -- Check if the FOOD_ID already exists in FREQUENTFOOD
            IF EXISTS (SELECT 1 FROM FREQUENTFOOD WHERE FOOD_ID = @new_food_id)
            BEGIN
                -- If it exists, increment the NUMBER_EAT
                UPDATE FREQUENTFOOD
                SET NUMBER_EAT = NUMBER_EAT + 1
                WHERE FOOD_ID = @new_food_id;
            END
            ELSE
            BEGIN
                -- If it does not exist, insert a new row with NUMBER_EAT set to 1
                INSERT INTO FREQUENTFOOD (FOOD_ID, NUMBER_EAT)
                VALUES (@new_food_id, 1);
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
