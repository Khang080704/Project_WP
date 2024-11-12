exports.seed = async function(knex) {
  await knex('LUNCHDIARY').del(); 
  await knex('DINNERDIARY').del(); 
  await knex('SNACKDIARY').del(); 
  await knex('BREAKFASTDIARY').del(); 
  await knex('QUICKADD_BREAKFAST').del();
  await knex('QUICKADD_LUNCH').del();
  await knex('QUICKADD_DINNER').del();
  await knex('QUICKADD_SNACK').del();
  await knex('FOODDIARY').del(); 

  // Insert data into FOODDIARY
  await knex('FOODDIARY').insert([
      { FOOD_DATE: '2024-10-01' },
      { FOOD_DATE: '2024-11-11' }
  ]);

  // Insert data into LUNCHDIARY
  await knex('LUNCHDIARY').insert({ FOOD_ID: 1, FOOD_QUANTITY: '2', FOOD_DATE: '2024-10-01' });
  await knex('LUNCHDIARY').insert({ FOOD_ID: 2, FOOD_QUANTITY: '1', FOOD_DATE: '2024-11-11' });
  await knex('LUNCHDIARY').insert({ FOOD_ID: 4, FOOD_QUANTITY: '1', FOOD_DATE: '2024-11-11' });
  
  // Insert data into DINNERDIARY
  await knex('DINNERDIARY').insert({ FOOD_ID: 3, FOOD_QUANTITY: '3', FOOD_DATE: '2024-10-01' });
  await knex('DINNERDIARY').insert({ FOOD_ID: 4, FOOD_QUANTITY: '2', FOOD_DATE: '2024-11-11' });

  // Insert data into SNACKDIARY
  await knex('SNACKDIARY').insert({ FOOD_ID: 5, FOOD_QUANTITY: '1', FOOD_DATE: '2024-10-01' });
  await knex('SNACKDIARY').insert({ FOOD_ID: 6, FOOD_QUANTITY: '2', FOOD_DATE: '2024-11-11' });

  // Insert data into BREAKFASTDIARY
  await knex('BREAKFASTDIARY').insert({ FOOD_ID: 7, FOOD_QUANTITY: '1', FOOD_DATE: '2024-10-01' });
  await knex('BREAKFASTDIARY').insert({ FOOD_ID: 8, FOOD_QUANTITY: '2', FOOD_DATE: '2024-11-11' });


    // Insert data into QUICKADD_BREAKFAST
    await knex('QUICKADD_BREAKFAST').insert([
    { FOOD_DATE: '2024-10-01', FOOD_CALORIES: 200, FOOD_CARBS: 30, FOOD_FAT: 10, FOOD_PROTEIN: 15, FOOD_SODIUM: 5, FOOD_SUGAR: 20 }
    ]);
    await knex('QUICKADD_BREAKFAST').insert([
    { FOOD_DATE: '2024-11-11', FOOD_CALORIES: 250, FOOD_CARBS: 40, FOOD_FAT: 15, FOOD_PROTEIN: 20, FOOD_SODIUM: 10, FOOD_SUGAR: 25 }
    ]);
    await knex('QUICKADD_BREAKFAST').insert([
    { FOOD_DATE: '2024-11-11', FOOD_CALORIES: 300, FOOD_CARBS: 50, FOOD_FAT: 20, FOOD_PROTEIN: 25, FOOD_SODIUM: 15, FOOD_SUGAR: 30 }
    ]);

    // Insert data into QUICKADD_LUNCH
    await knex('QUICKADD_LUNCH').insert(
    { FOOD_DATE: '2024-10-01', FOOD_CALORIES: 400, FOOD_CARBS: 60, FOOD_FAT: 20, FOOD_PROTEIN: 30, FOOD_SODIUM: 10, FOOD_SUGAR: 40 }
    );
    await knex('QUICKADD_LUNCH').insert(
    { FOOD_DATE: '2024-11-11', FOOD_CALORIES: 450, FOOD_CARBS: 70, FOOD_FAT: 25, FOOD_PROTEIN: 35, FOOD_SODIUM: 20, FOOD_SUGAR: 45 }
    );
    await knex('QUICKADD_LUNCH').insert(
    { FOOD_DATE: '2024-11-11', FOOD_CALORIES: 500, FOOD_CARBS: 80, FOOD_FAT: 30, FOOD_PROTEIN: 40, FOOD_SODIUM: 25, FOOD_SUGAR: 50 }
    );

    // Insert data into QUICKADD_DINNER
    await knex('QUICKADD_DINNER').insert(
    { FOOD_DATE: '2024-10-01', FOOD_CALORIES: 600, FOOD_CARBS: 90, FOOD_FAT: 40, FOOD_PROTEIN: 50, FOOD_SODIUM: 30, FOOD_SUGAR: 60 }
    );
    await knex('QUICKADD_DINNER').insert(
    { FOOD_DATE: '2024-11-11', FOOD_CALORIES: 650, FOOD_CARBS: 100, FOOD_FAT: 45, FOOD_PROTEIN: 55, FOOD_SODIUM: 35, FOOD_SUGAR: 65 }
    );
    await knex('QUICKADD_DINNER').insert(
    { FOOD_DATE: '2024-11-11', FOOD_CALORIES: 700, FOOD_CARBS: 110, FOOD_FAT: 50, FOOD_PROTEIN: 60, FOOD_SODIUM: 40, FOOD_SUGAR: 70 }
    );

    // Insert data into QUICKADD_SNACK
    await knex('QUICKADD_SNACK').insert(
    { FOOD_DATE: '2024-10-01', FOOD_CALORIES: 100, FOOD_CARBS: 15, FOOD_FAT: 5, FOOD_PROTEIN: 10, FOOD_SODIUM: 2, FOOD_SUGAR: 12 }
    );
    await knex('QUICKADD_SNACK').insert(
    { FOOD_DATE: '2024-11-11', FOOD_CALORIES: 150, FOOD_CARBS: 25, FOOD_FAT: 10, FOOD_PROTEIN: 15, FOOD_SODIUM: 5, FOOD_SUGAR: 18 }
    );
    await knex('QUICKADD_SNACK').insert(
    { FOOD_DATE: '2024-11-11', FOOD_CALORIES: 200, FOOD_CARBS: 35, FOOD_FAT: 15, FOOD_PROTEIN: 20, FOOD_SODIUM: 8, FOOD_SUGAR: 24 }
    );
};