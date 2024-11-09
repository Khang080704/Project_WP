exports.seed = async function(knex) {
  await knex('LUNCHDIARY').del(); 
  await knex('DINNERDIARY').del(); 
  await knex('SNACKDIARY').del(); 
  await knex('BREAKFASTDIARY').del(); 
  await knex('FOODDIARY').del(); 

  // Insert data into FOODDIARY
  await knex('FOODDIARY').insert([
      { FOOD_DATE: '2023-10-01' },
      { FOOD_DATE: '2023-10-02' }
  ]);

  // Insert data into LUNCHDIARY
  await knex('LUNCHDIARY').insert([
      { FOOD_ID: 1, FOOD_QUANTITY: '2', FOOD_DATE: '2023-10-01' },
      { FOOD_ID: 2, FOOD_QUANTITY: '1', FOOD_DATE: '2023-10-02' }
  ]);

  // Insert data into DINNERDIARY
  await knex('DINNERDIARY').insert([
      { FOOD_ID: 3, FOOD_QUANTITY: '3', FOOD_DATE: '2023-10-01' },
      { FOOD_ID: 4, FOOD_QUANTITY: '2', FOOD_DATE: '2023-10-02' }
  ]);

  // Insert data into SNACKDIARY
  await knex('SNACKDIARY').insert([
      { FOOD_ID: 5, FOOD_QUANTITY: '1', FOOD_DATE: '2023-10-01' },
      { FOOD_ID: 6, FOOD_QUANTITY: '2', FOOD_DATE: '2023-10-02' }
  ]);

  // Insert data into BREAKFASTDIARY
  await knex('BREAKFASTDIARY').insert([
      { FOOD_ID: 7, FOOD_QUANTITY: '1', FOOD_DATE: '2023-10-01' },
      { FOOD_ID: 8, FOOD_QUANTITY: '2', FOOD_DATE: '2023-10-02' }
  ]);
};