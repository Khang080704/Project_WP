/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> } 
 */
exports.seed = async function(knex) {
  await knex('BREAKFASTDIARY').del();
  await knex('SNACKDIARY').del();
  await knex('DINNERDIARY').del();
  await knex('LUNCHDIARY').del();
  await knex('RECENTFOOD').del();
  await knex('FREQUENTFOOD').del();
  await knex('FOOD').del(); // Deletes ALL existing entries
  await knex.raw('DBCC CHECKIDENT (\'FOOD\', RESEED, 0)'); // Resets the ID back to 1
  await knex('FOOD').insert([
    { FOOD_NAME: "Chicken Breast", FOOD_CALORIES: 165, FOOD_CARBS: 0, FOOD_FAT: 3.6, FOOD_PROTEIN: 31, FOOD_SODIUM: 74, FOOD_SUGAR: 0, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["grams", "oz", "kilograms"]), SELECTED_FOOD_UNIT: "grams" },
    { FOOD_NAME: "Salmon", FOOD_CALORIES: 208, FOOD_CARBS: 0, FOOD_FAT: 13, FOOD_PROTEIN: 20, FOOD_SODIUM: 59, FOOD_SUGAR: 0, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["grams", "oz", "fillet", "kilograms"]), SELECTED_FOOD_UNIT: "grams" },
    { FOOD_NAME: "Broccoli", FOOD_CALORIES: 55, FOOD_CARBS: 11.2, FOOD_FAT: 0.6, FOOD_PROTEIN: 3.7, FOOD_SODIUM: 49, FOOD_SUGAR: 2.2, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["grams", "cup", "stalk", "kilograms"]), SELECTED_FOOD_UNIT: "grams" },
    { FOOD_NAME: "Avocado", FOOD_CALORIES: 160, FOOD_CARBS: 8.5, FOOD_FAT: 14.7, FOOD_PROTEIN: 2, FOOD_SODIUM: 7, FOOD_SUGAR: 0.7, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["grams", "half", "whole", "kilograms"]), SELECTED_FOOD_UNIT: "grams" },
    { FOOD_NAME: "Almonds", FOOD_CALORIES: 579, FOOD_CARBS: 21.6, FOOD_FAT: 49.9, FOOD_PROTEIN: 21.2, FOOD_SODIUM: 1, FOOD_SUGAR: 4.4, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["grams", "oz", "handful", "kilograms"]), SELECTED_FOOD_UNIT: "grams" },
    { FOOD_NAME: "Brown Rice", FOOD_CALORIES: 123, FOOD_CARBS: 25.6, FOOD_FAT: 1.0, FOOD_PROTEIN: 2.7, FOOD_SODIUM: 4, FOOD_SUGAR: 0.4, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["grams", "cup", "kilograms"]), SELECTED_FOOD_UNIT: "grams" },
    { FOOD_NAME: "Eggs", FOOD_CALORIES: 155, FOOD_CARBS: 1.1, FOOD_FAT: 10.6, FOOD_PROTEIN: 13, FOOD_SODIUM: 124, FOOD_SUGAR: 1.1, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["unit", "dozen"]), SELECTED_FOOD_UNIT: "unit" },
    { FOOD_NAME: "Banana", FOOD_CALORIES: 89, FOOD_CARBS: 22.8, FOOD_FAT: 0.3, FOOD_PROTEIN: 1.1, FOOD_SODIUM: 1, FOOD_SUGAR: 12.2, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["unit", "grams", "bunch"]), SELECTED_FOOD_UNIT: "unit" },
    { FOOD_NAME: "Greek Yogurt", FOOD_CALORIES: 59, FOOD_CARBS: 3.6, FOOD_FAT: 0.4, FOOD_PROTEIN: 10, FOOD_SODIUM: 36, FOOD_SUGAR: 3.2, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["grams", "oz", "cup"]), SELECTED_FOOD_UNIT: "grams" },
    { FOOD_NAME: "Sweet Potato", FOOD_CALORIES: 86, FOOD_CARBS: 20.1, FOOD_FAT: 0.1, FOOD_PROTEIN: 1.6, FOOD_SODIUM: 55, FOOD_SUGAR: 4.2, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["grams", "unit", "kilograms"]), SELECTED_FOOD_UNIT: "grams" },
    { FOOD_NAME: "Apple", FOOD_CALORIES: 52, FOOD_CARBS: 14, FOOD_FAT: 0.2, FOOD_PROTEIN: 0.3, FOOD_SODIUM: 1, FOOD_SUGAR: 10.4, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["unit", "grams", "slice"]), SELECTED_FOOD_UNIT: "unit" },
    { FOOD_NAME: "Carrot", FOOD_CALORIES: 41, FOOD_CARBS: 9.6, FOOD_FAT: 0.2, FOOD_PROTEIN: 0.9, FOOD_SODIUM: 69, FOOD_SUGAR: 4.7, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["grams", "unit", "kilograms"]), SELECTED_FOOD_UNIT: "grams" },
    { FOOD_NAME: "Spinach", FOOD_CALORIES: 23, FOOD_CARBS: 3.6, FOOD_FAT: 0.4, FOOD_PROTEIN: 2.9, FOOD_SODIUM: 79, FOOD_SUGAR: 0.4, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["grams", "cup", "bunch"]), SELECTED_FOOD_UNIT: "grams" },
    { FOOD_NAME: "Tomato", FOOD_CALORIES: 18, FOOD_CARBS: 3.9, FOOD_FAT: 0.2, FOOD_PROTEIN: 0.9, FOOD_SODIUM: 5, FOOD_SUGAR: 2.6, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["unit", "grams", "slice"]), SELECTED_FOOD_UNIT: "unit" },
    { FOOD_NAME: "Mango", FOOD_CALORIES: 60, FOOD_CARBS: 15, FOOD_FAT: 0.4, FOOD_PROTEIN: 0.8, FOOD_SODIUM: 1, FOOD_SUGAR: 13.7, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["unit", "grams", "slice"]), SELECTED_FOOD_UNIT: "unit" },
    { FOOD_NAME: "Blueberries", FOOD_CALORIES: 57, FOOD_CARBS: 14.5, FOOD_FAT: 0.3, FOOD_PROTEIN: 0.7, FOOD_SODIUM: 1, FOOD_SUGAR: 9.7, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["grams", "cup", "handful"]), SELECTED_FOOD_UNIT: "grams" },
    { FOOD_NAME: "Beef", FOOD_CALORIES: 250, FOOD_CARBS: 0, FOOD_FAT: 15, FOOD_PROTEIN: 26, FOOD_SODIUM: 72, FOOD_SUGAR: 0, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["grams", "oz", "kilograms"]), SELECTED_FOOD_UNIT: "grams" },
    { FOOD_NAME: "Tofu", FOOD_CALORIES: 76, FOOD_CARBS: 1.9, FOOD_FAT: 4.8, FOOD_PROTEIN: 8, FOOD_SODIUM: 7, FOOD_SUGAR: 0.3, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["grams", "oz", "block"]), SELECTED_FOOD_UNIT: "grams" },
    { FOOD_NAME: "Lentils", FOOD_CALORIES: 116, FOOD_CARBS: 20, FOOD_FAT: 0.4, FOOD_PROTEIN: 9, FOOD_SODIUM: 2, FOOD_SUGAR: 1.8, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["grams", "cup", "kilograms"]), SELECTED_FOOD_UNIT: "grams" },
    { FOOD_NAME: "Chia Seeds", FOOD_CALORIES: 486, FOOD_CARBS: 42.1, FOOD_FAT: 30.7, FOOD_PROTEIN: 16.5, FOOD_SODIUM: 16, FOOD_SUGAR: 0, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["grams", "oz", "tablespoon"]), SELECTED_FOOD_UNIT: "grams" },
    { FOOD_NAME: "Pasta", FOOD_CALORIES: 131, FOOD_CARBS: 25, FOOD_FAT: 1.1, FOOD_PROTEIN: 5, FOOD_SODIUM: 1, FOOD_SUGAR: 0.8, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["grams", "cup", "kilograms"]), SELECTED_FOOD_UNIT: "grams" },
    { FOOD_NAME: "Milk", FOOD_CALORIES: 42, FOOD_CARBS: 4.8, FOOD_FAT: 1, FOOD_PROTEIN: 3.4, FOOD_SODIUM: 44, FOOD_SUGAR: 4.8, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["ml", "cup", "liters"]), SELECTED_FOOD_UNIT: "ml" },
    { FOOD_NAME: "Oranges", FOOD_CALORIES: 47, FOOD_CARBS: 11.7, FOOD_FAT: 0.1, FOOD_PROTEIN: 0.9, FOOD_SODIUM: 0, FOOD_SUGAR: 9.4, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["unit", "grams", "slice"]), SELECTED_FOOD_UNIT: "unit" },
    { FOOD_NAME: "Oatmeal", FOOD_CALORIES: 68, FOOD_CARBS: 12, FOOD_FAT: 1.4, FOOD_PROTEIN: 2.4, FOOD_SODIUM: 49, FOOD_SUGAR: 0.5, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["grams", "cup", "bowl"]), SELECTED_FOOD_UNIT: "grams" },
    { FOOD_NAME: "Cheddar Cheese", FOOD_CALORIES: 402, FOOD_CARBS: 1.3, FOOD_FAT: 33.1, FOOD_PROTEIN: 24.9, FOOD_SODIUM: 621, FOOD_SUGAR: 0.5, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["grams", "slice", "oz"]), SELECTED_FOOD_UNIT: "grams" },
    { FOOD_NAME: "Peanut Butter", FOOD_CALORIES: 588, FOOD_CARBS: 20, FOOD_FAT: 50, FOOD_PROTEIN: 25, FOOD_SODIUM: 17, FOOD_SUGAR: 9, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["grams", "tablespoon", "cup"]), SELECTED_FOOD_UNIT: "grams" },
    { FOOD_NAME: "Potato", FOOD_CALORIES: 77, FOOD_CARBS: 17, FOOD_FAT: 0.1, FOOD_PROTEIN: 2, FOOD_SODIUM: 6, FOOD_SUGAR: 0.8, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["unit", "grams", "kilograms"]), SELECTED_FOOD_UNIT: "grams" },
    { FOOD_NAME: "Strawberries", FOOD_CALORIES: 32, FOOD_CARBS: 7.7, FOOD_FAT: 0.3, FOOD_PROTEIN: 0.7, FOOD_SODIUM: 1, FOOD_SUGAR: 4.9, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["grams", "cup", "handful"]), SELECTED_FOOD_UNIT: "grams" },
    { FOOD_NAME: "Cucumber", FOOD_CALORIES: 16, FOOD_CARBS: 3.6, FOOD_FAT: 0.1, FOOD_PROTEIN: 0.7, FOOD_SODIUM: 2, FOOD_SUGAR: 1.7, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["unit", "grams", "slice"]), SELECTED_FOOD_UNIT: "unit" },
    { FOOD_NAME: "Bell Pepper", FOOD_CALORIES: 31, FOOD_CARBS: 6, FOOD_FAT: 0.3, FOOD_PROTEIN: 1, FOOD_SODIUM: 2, FOOD_SUGAR: 4.2, FOOD_QUANTITY: "1", FOOD_UNIT: JSON.stringify(["unit", "grams", "slice"]), SELECTED_FOOD_UNIT: "unit" },
  ]);
};

