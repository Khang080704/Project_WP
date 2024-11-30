/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> } 
 */
exports.seed = async function(knex) {
  await knex('FREQUENTFOOD').del(); // Deletes ALL existing entries
  await knex.raw("DBCC CHECKIDENT ('FREQUENTFOOD', RESEED, 0)"); // Reserts the ID back to 1
  await knex('FREQUENTFOOD').insert([{ FOOD_ID: 1 },]);
  await knex('FREQUENTFOOD').insert([{ FOOD_ID: 7 },]);
  await knex('FREQUENTFOOD').insert([{ FOOD_ID: 5 },]);
  await knex('FREQUENTFOOD').insert([{ FOOD_ID: 1 },]);
  await knex('FREQUENTFOOD').insert([{ FOOD_ID: 7 },]);
  await knex('FREQUENTFOOD').insert([{ FOOD_ID: 3 },]);
  await knex('FREQUENTFOOD').insert([{ FOOD_ID: 14 },]);
  await knex('FREQUENTFOOD').insert([{ FOOD_ID: 5 },]);
  await knex('FREQUENTFOOD').insert([{ FOOD_ID: 11 },]);
  await knex('FREQUENTFOOD').insert([{ FOOD_ID: 19 },]);
  await knex('FREQUENTFOOD').insert([{ FOOD_ID: 19 },]);
  await knex('FREQUENTFOOD').insert([{ FOOD_ID: 20 },]);
};
