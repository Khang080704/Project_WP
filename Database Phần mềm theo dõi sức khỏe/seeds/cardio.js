/**
 * @param { import("knex").Knex } knex
 * @returns { Promise<void> } 
 */
exports.seed = async function(knex) {
  // Deletes ALL existing entries
  await knex('CardioExercise').del();
  await knex.raw('DBCC CHECKIDENT (\'CardioExercise\', RESEED, 0)');
  await knex('CardioExercise').insert([
    {Cardio_name: "Aerobic, general", TimeHowLong: 0, CaloriesBurned: 0, CaloriesPerMinutes: 7.7},
    {Cardio_name: "Badminton, competitive", TimeHowLong: 0, CaloriesBurned: 0, CaloriesPerMinutes: 8.3},
    {Cardio_name: "Billiards", TimeHowLong: 0, CaloriesBurned: 0, CaloriesPerMinutes: 3},
    {Cardio_name: "Canoeing, on camping trip", TimeHowLong: 0, CaloriesBurned: 0, CaloriesPerMinutes: 4.7},
    {Cardio_name: "Dancing, general", TimeHowLong: 0, CaloriesBurned: 0, CaloriesPerMinutes: 5.3},
    {Cardio_name: "Fishing from boat, sitting", TimeHowLong: 0, CaloriesBurned: 0, CaloriesPerMinutes: 3},
    {Cardio_name: "Golf, carrying clubs", TimeHowLong: 0, CaloriesBurned: 0, CaloriesPerMinutes: 5.3},
    {Cardio_name: "Horseback riding, general", TimeHowLong: 0, CaloriesBurned: 0, CaloriesPerMinutes: 4.7},
    {Cardio_name: "Judo, karate, kick boxing, tae kwan do", TimeHowLong: 0, CaloriesBurned: 0, CaloriesPerMinutes: 11.8},
    {Cardio_name: "Music playing, drums", TimeHowLong: 0, CaloriesBurned: 0, CaloriesPerMinutes: 4.7},
  ]);
};
