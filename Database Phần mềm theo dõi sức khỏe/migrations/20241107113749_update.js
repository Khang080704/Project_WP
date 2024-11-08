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
            FOODID INT NOT NULL,
        );
    `);

    await knex.raw(`
        CREATE TRIGGER TRG_LIMIT_RECENTFOOD
        ON RECENTFOOD
        INSTEAD OF INSERT
        AS
        BEGIN
            DECLARE @new_foodid INT;
            SELECT @new_foodid = FOODID FROM inserted;

            -- Check if the FOODID already exists
            IF NOT EXISTS (SELECT 1 FROM RECENTFOOD WHERE FOODID = @new_foodid)
            BEGIN
                -- If the table has 5 rows, delete the oldest row
                IF (SELECT COUNT(*) FROM RECENTFOOD) >= 5
                BEGIN
                    DELETE FROM RECENTFOOD
                    WHERE ID = (SELECT TOP 1 ID FROM RECENTFOOD ORDER BY ID);
                END

                -- Insert the new FOODID
                INSERT INTO RECENTFOOD (FOODID) VALUES (@new_foodid);
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