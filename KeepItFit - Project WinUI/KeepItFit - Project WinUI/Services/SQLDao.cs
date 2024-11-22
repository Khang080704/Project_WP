using KeepItFit___Project_WinUI.Model;
using KeepItFit___Project_WinUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KeepItFit___Project_WinUI.Services
{
    public class SQLDao : IDao
    {
        public string connectionString;

        // Constructor
        public SQLDao()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "localhost,1433",
                InitialCatalog = "PMTDSK",
                UserID = "sa",
                Password = "SqlServer@123",
                IntegratedSecurity = false,
                TrustServerCertificate = true
            };
            connectionString = builder.ConnectionString;

        }

        // Get all meals from database using query
        public ObservableCollection<Meals> GetAllMeals()
        {
            ObservableCollection<Meals> meals = new ObservableCollection<Meals>();
            string query = "SELECT * FROM MEAL";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Meals meal = new Meals
                        {
                            mealName = reader["MEAL_NAME"].ToString()
                        };
                        meals.Add(meal);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error fetching data: {ex.Message}");
                }
            }

            return meals;
        }

        // Get all informations of food list for the meal in the day
        List<Food> ReadFoodInfo(SqlDataReader reader)
        {
            List<Food> foods = new List<Food>();
            while (reader.Read())
            {
                Food food = new Food
                {
                    foodId = Convert.ToInt32(reader["ID"]),
                    foodName = reader["FOOD_NAME"].ToString(),
                    foodCalories = Convert.ToSingle(reader["FOOD_CALORIES"]),
                    foodCarbs = Convert.ToSingle(reader["FOOD_CARBS"]),
                    foodFat = Convert.ToSingle(reader["FOOD_FAT"]),
                    foodProtein = Convert.ToSingle(reader["FOOD_PROTEIN"]),
                    foodSodium = Convert.ToSingle(reader["FOOD_SODIUM"]),
                    foodSugar = Convert.ToSingle(reader["FOOD_SUGAR"]),
                    foodQuantity = reader["FOOD_QUANTITY"].ToString(),
                    foodUnit = JsonSerializer.Deserialize<List<string>>(reader["FOOD_UNIT"].ToString()),
                    selectedFoodUnit = reader["SELECTED_FOOD_UNIT"].ToString()
                };
                foods.Add(food);
            }

            return foods;
        }

        // Get food from database using query
        public ObservableCollection<Food> GetFoodDatabase(string keyword)
        {
            ObservableCollection<Food> foods = new ObservableCollection<Food>();
            string query = @"SELECT * FROM FOOD WHERE FOOD_NAME LIKE @keyword";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<Food> foodList = ReadFoodInfo(reader);
                    foods = new ObservableCollection<Food>(foodList);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return foods;
        }

        public ObservableCollection<Food> GetFoodFrequent()
        {
            ObservableCollection<Food> foods = new ObservableCollection<Food>();
            string query = @"
                    SELECT TOP 5 f.*
                    FROM FrequentFood ff
                    JOIN FOOD f ON ff.FOOD_ID = f.ID
                    ORDER BY ff.NUMBER_EAT DESC;"; //Select all food from FrequentTable table

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<Food> foodList = ReadFoodInfo(reader);
                    foods = new ObservableCollection<Food>(foodList);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error fetching data: {ex.Message}");
                }
            }

            return foods;
        }

        public ObservableCollection<Food> GetFoodRecent()
        {
            ObservableCollection<Food> foods = new ObservableCollection<Food>();
            string query = @"
                    SELECT f.*
                    FROM RecentFood rf
                    JOIN FOOD f ON rf.FOOD_ID = f.ID
                    ORDER BY rf.ID DESC"; //Select all food from RecentFood table

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<Food> foodList = ReadFoodInfo(reader);
                    foods = new ObservableCollection<Food>(foodList);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error fetching data: {ex.Message}");
                }
            }

            return foods;
        }

        // Update food to FrequentFood or RecentFood table
        public void UpdateRecentOrFrequentFood(Food food, string type)
        {
            string query = $@"INSERT INTO {type} (FOOD_ID) VALUES (@foodId);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Debug.WriteLine(food.foodId);
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@foodId", food.foodId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error updating RECENTFOOD: {ex.Message}");
                }
            }
        }

        // Delete food from Frequent or Recent table
        public void DeleteFrequentOrRecentFood(Food food)
        {
            string queryRecent = @"DELETE FROM RecentFood WHERE FOOD_ID = @foodId;";
            string queryFrequent = @"DELETE FROM FrequentFood WHERE FOOD_ID = @foodId;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(queryRecent, connection))
                    {
                        command.Parameters.AddWithValue("@foodId", food.foodId);
                        command.ExecuteNonQuery();
                    }

                    using (SqlCommand command = new SqlCommand(queryFrequent, connection))
                    {
                        command.Parameters.AddWithValue("@foodId", food.foodId);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error deleting food: {ex.Message}");
                }
            }
        }

        //Get all foods from the meal zone in the day
        public List<Food> GetFoodForTheDay_FoodDiary(string date, string diaryType)
        {
            List<Food> foods = new List<Food>();
            string queryFood = $@"
                SELECT T.*, F.*
                FROM {diaryType} T
                JOIN FOOD F ON T.FOOD_ID = F.ID
                WHERE T.FOOD_DATE = @FoodDate;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryFood, connection);
                command.Parameters.AddWithValue("@FoodDate", date);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    foods = ReadFoodInfo(reader);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error fetching data: {ex.Message}");
                }
            }

            return foods;
        }

        public List<Food> GeQuickAddForTheDay_FoodDiary(string date, string diaryType)
        {
            List<Food> foods = new List<Food>();
            string queryQuickAdd = $@"SELECT * FROM {diaryType} WHERE FOOD_DATE = @FoodDate;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryQuickAdd, connection);
                command.Parameters.AddWithValue("@FoodDate", date);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Food food = new Food
                        {
                            foodId = Convert.ToInt32(reader["ID"]),
                            foodName = "Quick Add", // Default name is "Quick Add"
                            foodCalories = Convert.ToSingle(reader["FOOD_CALORIES"]),
                            foodCarbs = Convert.ToSingle(reader["FOOD_CARBS"]),
                            foodFat = Convert.ToSingle(reader["FOOD_FAT"]),
                            foodProtein = Convert.ToSingle(reader["FOOD_PROTEIN"]),
                            foodSodium = Convert.ToSingle(reader["FOOD_SODIUM"]),
                            foodSugar = Convert.ToSingle(reader["FOOD_SUGAR"]),
                            foodQuantity = "1", // Default quantity is "1"
                            foodUnit = ["serving(s)"],
                            selectedFoodUnit = "serving(s)"
                        };
                        foods.Add(food);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error fetching data: {ex.Message}");
                }
            }

            return foods;
        }

        // Delete food from the meal zone in the day
        public void DeleteFoodForTheDay_FoodDiary(string date, int foodId, string diaryType)
        {
            string query = $@"DELETE FROM {diaryType} WHERE FOOD_DATE = @FoodDate AND FOOD_ID = @FoodID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FoodDate", date);
                command.Parameters.AddWithValue("@FoodID", foodId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error deleting data: {ex.Message}");
                }
            }
        }

        public void DeleteQuickAddForTheDay_FoodDiary(string date, int quickAddId, string diaryType)
        {
            string query = $@"DELETE FROM {diaryType} WHERE FOOD_DATE = @FoodDate AND ID = @QuickAddID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FoodDate", date);
                command.Parameters.AddWithValue("@QuickAddID", quickAddId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error deleting data: {ex.Message}");
                }
            }
        }

        public void UpdateFoodForTheDay_FoodDiary(string date, int foodId, string foodQuantity, string diaryType)
        {
            string queryCheckExistence = $@"
                SELECT COUNT(*) 
                FROM {diaryType} 
                WHERE FOOD_DATE = @FoodDate AND FOOD_ID = @FoodID;";

            string queryUpdate = $@"
                UPDATE {diaryType} 
                SET FOOD_QUANTITY = @FoodQuantity
                WHERE FOOD_DATE = @FoodDate AND FOOD_ID = @FoodID";

            string queryInsert = $@"
                INSERT INTO FOODDIARY (FOOD_DATE) VALUES (@FoodDate);
                INSERT INTO {diaryType} (FOOD_ID, FOOD_QUANTITY, FOOD_DATE) 
                VALUES (@FoodID, @FoodQuantity, @FoodDate);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand commandCheckExistence = new SqlCommand(queryCheckExistence, connection);
                commandCheckExistence.Parameters.AddWithValue("@FoodDate", date);
                commandCheckExistence.Parameters.AddWithValue("@FoodID", foodId);

                SqlCommand commandUpdate = new SqlCommand(queryUpdate, connection);
                commandUpdate.Parameters.AddWithValue("@FoodDate", date);
                commandUpdate.Parameters.AddWithValue("@FoodID", foodId);
                commandUpdate.Parameters.AddWithValue("@FoodQuantity", foodQuantity);

                SqlCommand commandInsert = new SqlCommand(queryInsert, connection);
                commandInsert.Parameters.AddWithValue("@FoodDate", date);
                commandInsert.Parameters.AddWithValue("@FoodID", foodId);
                commandInsert.Parameters.AddWithValue("@FoodQuantity", foodQuantity);

                try
                {
                    connection.Open();
                    int count = (int)commandCheckExistence.ExecuteScalar();

                    if (count > 0)
                    {
                        // Update the food quantity if the food already exists in the meal zone
                        commandUpdate.ExecuteNonQuery();
                    }
                    else
                    {
                        // Insert the food to the meal zone if the food does not exist
                        commandInsert.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error updating or inserting data: {ex.Message}");
                }
            }
        }

        public void UpdateQuickAddForTheDay_FoodDiary(string date, List<int> quickAddList, string diaryType)
        {
            string queryInsert = $@"
                INSERT INTO {diaryType} (FOOD_DATE, FOOD_CALORIES, FOOD_CARBS, FOOD_FAT, FOOD_PROTEIN, FOOD_SODIUM, FOOD_SUGAR) 
                VALUES (@FoodDate, @FoodCalories, @FoodCarbs, @FoodFat, @FoodProtein, @FoodSodium, @FoodSugar);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand commandInsert = new SqlCommand(queryInsert, connection);
                commandInsert.Parameters.AddWithValue("@FoodDate", date);
                commandInsert.Parameters.AddWithValue("@FoodCalories", quickAddList[0]);
                commandInsert.Parameters.AddWithValue("@FoodCarbs", quickAddList[1]);
                commandInsert.Parameters.AddWithValue("@FoodFat", quickAddList[2]);
                commandInsert.Parameters.AddWithValue("@FoodProtein", quickAddList[3]);
                commandInsert.Parameters.AddWithValue("@FoodSodium", quickAddList[4]);
                commandInsert.Parameters.AddWithValue("@FoodSugar", quickAddList[5]);

                try
                {
                    connection.Open();
                    commandInsert.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error inserting data: {ex.Message}");
                }
            }
        }

        public List<Nutritions> GetAllNutrtion()
        {
            return new List<Nutritions>();
        }

        List<CardioExercise> ReadCardioInfo(SqlDataReader reader)
        {
            List<CardioExercise> cardios = new List<CardioExercise>();
            while (reader.Read())
            {
                CardioExercise cardio = new CardioExercise
                {
                    name = reader["Cardio_name"].ToString(),
                    _time = Convert.ToInt32(reader["TimeHowLong"]),
                    CaloriesBurned = Convert.ToInt32(reader["CaloriesBurned"]),
                    caloriesPerMinute = Convert.ToSingle(reader["CaloriesPerMinutes"])

                };
                cardios.Add(cardio);
            }

            return cardios;
        }

        public ObservableCollection<CardioExercise> GetAllCardioExercise(string keyword)
        {
            ObservableCollection<CardioExercise> cardio = new ObservableCollection<CardioExercise>();
            string query = @"SELECT * FROM CardioExercise WHERE Cardio_name LIKE @keyword";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<CardioExercise> cardioList = ReadCardioInfo(reader);
                    cardio = new ObservableCollection<CardioExercise>(cardioList);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return cardio;
        }

        List<StrengthTraining> ReadTrainingInfo(SqlDataReader reader)
        {
            List<StrengthTraining> data = new List<StrengthTraining>();
            while (reader.Read())
            {
                StrengthTraining item = new StrengthTraining
                {
                    name = reader["Strength_name"].ToString(),
                    Sets = Convert.ToInt32(reader["Sets"]),
                    Reps_Set = Convert.ToInt32(reader["Reps_Set"]),
                    Weight_Sets = Convert.ToInt32(reader["Weigth_Set"])

                };
                data.Add(item);
            }

            return data;
        }

        public ObservableCollection<StrengthTraining> GetAllStrengthTraining(string keyword)
        {
            ObservableCollection<StrengthTraining> training = new ObservableCollection<StrengthTraining>();
            string query = @"SELECT * FROM StrengthTraining WHERE Strength_name LIKE @keyword";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<StrengthTraining> strengthList = ReadTrainingInfo(reader);
                    training = new ObservableCollection<StrengthTraining>(strengthList);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return training;
        }
    }
}
