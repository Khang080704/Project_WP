/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> } 
 */
exports.seed = async function(knex) {
  await knex('RECENTFOOD').del(); // Deletes ALL existing 
  await knex.raw("DBCC CHECKIDENT ('RECENTFOOD', RESEED, 0)");
  await knex('RECENTFOOD').insert([{ FOOD_ID: 1, USER_EMAIL: '123@example.com' }]);
  await knex('RECENTFOOD').insert([{ FOOD_ID: 14, USER_EMAIL: '123@example.com' }]);
  await knex('RECENTFOOD').insert([{ FOOD_ID: 8, USER_EMAIL: '123@example.com' }]);
  await knex('RECENTFOOD').insert([{ FOOD_ID: 9, USER_EMAIL: '123@example.com' }]);
  await knex('RECENTFOOD').insert([{ FOOD_ID: 10, USER_EMAIL: '123@example.com' }]);
  await knex('RECENTFOOD').insert([{ FOOD_ID: 11, USER_EMAIL: '123@example.com' }]);
  await knex('RECENTFOOD').insert([{ FOOD_ID: 4, USER_EMAIL: '456@example.com' }]);
  await knex('RECENTFOOD').insert([{ FOOD_ID: 7, USER_EMAIL: '456@example.com' }]);
  await knex('RECENTFOOD').insert([{ FOOD_ID: 3, USER_EMAIL: '789@example.com' }]);
};