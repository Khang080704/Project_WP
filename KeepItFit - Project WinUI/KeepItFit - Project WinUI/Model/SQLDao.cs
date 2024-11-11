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

namespace KeepItFit___Project_WinUI.Model
{
    public class SQLDao: IDao
    {
        private string connectionString;

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
            this.connectionString = builder.ConnectionString;
            //TestConnection();
        }
        public ObservableCollection<CardioExercise> GetAllCardioExercise()
        {
            return new ObservableCollection<CardioExercise>();
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

        // Get food from database using query
        public ObservableCollection<Food> GetFoodDatabase(string keyword)
        {
            ObservableCollection<Food> foods = new ObservableCollection<Food>();
            string query = "SELECT * FROM FOOD WHERE FOOD_NAME LIKE @keyword";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
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
                    JOIN FOOD f ON rf.FOODID = f.ID
                    ORDER BY rf.ID DESC"; //Select all food from RecentFood table

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
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
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error fetching data: {ex.Message}");
                }
            }

            return foods;
        }

        // Update Frequent table
        public void UpdateFrequentFood(Food food)
        {
            string query = @"
                INSERT INTO FREQUENTFOOD (FOOD_ID) VALUES (@foodId);";

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
                    Debug.WriteLine($"Error updating FREQUENTTABLE: {ex.Message}");
                }
            }
        }

        public void UpdateRecentFood(Food food)
        {
            string query = @"
                INSERT INTO RECENTFOOD (FOODID) VALUES (@foodId);";

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
            string queryRecent = "DELETE FROM RecentFood WHERE FOODID = @foodId;";
            string queryFrequent = "DELETE FROM FrequentFood WHERE FOOD_ID = @foodId;";
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

        public void TestConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Debug.WriteLine("Connection successful");
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Connection failed");
            }
        }

        public ObservableCollection<Meals> GetAllMeals(string keyword)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Food> GetFoodDatabase()
        {
            throw new NotImplementedException();
        }

        public List<Nutritions> GetAllNutrtion()
        {
            return new List<Nutritions>();
        }
    }
}
