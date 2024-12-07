/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> } 
 */
exports.seed = async function(knex) {
  await knex('MEAL').del(); // Deletes ALL existing entries
  await knex.raw("DBCC CHECKIDENT ('MEAL', RESEED, 0)"); // Reserts the ID back to 1
  await knex('MEAL').insert([
    { MEAL_NAME: "BreakFast" },
    { MEAL_NAME: "Lunch" },
    { MEAL_NAME: "Dinner" },
    { MEAL_NAME: "Snack" },
  ]);
};
