/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> } 
 */
exports.seed = async function(knex) {
  await knex('FREQUENTFOOD').del(); // Deletes ALL existing entries
  await knex.raw("DBCC CHECKIDENT ('FREQUENTFOOD', RESEED, 0)"); // Reserts the ID back to 1
  await knex('FREQUENTFOOD').insert({ FOOD_ID: 1, USER_EMAIL: '123@example.com' });
  await knex('FREQUENTFOOD').insert({ FOOD_ID: 7, USER_EMAIL: '123@example.com' });
  await knex('FREQUENTFOOD').insert({ FOOD_ID: 5, USER_EMAIL: '123@example.com' });
  await knex('FREQUENTFOOD').insert({ FOOD_ID: 1, USER_EMAIL: '456@example.com' });
  await knex('FREQUENTFOOD').insert({ FOOD_ID: 7, USER_EMAIL: '456@example.com' });
  await knex('FREQUENTFOOD').insert({ FOOD_ID: 3, USER_EMAIL: '456@example.com' });
  await knex('FREQUENTFOOD').insert({ FOOD_ID: 14, USER_EMAIL: '456@example.com' });
  await knex('FREQUENTFOOD').insert({ FOOD_ID: 5, USER_EMAIL: '789@example.com' });
  await knex('FREQUENTFOOD').insert({ FOOD_ID: 11, USER_EMAIL: '789@example.com' });
  await knex('FREQUENTFOOD').insert({ FOOD_ID: 19, USER_EMAIL: '789@example.com' });
  await knex('FREQUENTFOOD').insert({ FOOD_ID: 19, USER_EMAIL: 'dsds@dsd.com' });
  await knex('FREQUENTFOOD').insert({ FOOD_ID: 20, USER_EMAIL: 'dsds@dsd.com' });
};
