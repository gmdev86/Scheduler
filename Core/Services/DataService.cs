using MySql.Data.MySqlClient;
using Scheduler.Core.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler.Core.Services
{
    public class DataService
    {
        private string connectionString;

        public DataService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ScheduleConnectionString"].ConnectionString;
        }
        public void test()
        {
            // Connection string
            string connectionString = "Server=localhost;Port=3306;Database=schedule;Uid=test;Pwd=test;";

            // Create MySqlConnection
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Connection successful
                    Console.WriteLine("Connected to MySQL Database!");

                    // Example query
                    string query = "SELECT * FROM user";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Process the retrieved data
                                Console.WriteLine($"Column1: {reader["Column1"]}, Column2: {reader["Column2"]}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occurred during the connection attempt or query execution
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public void InsertUser(User user)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO user (userName, password, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                                   "VALUES (@UserName, @Password, @Active, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdateBy)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", user.UserName);
                        command.Parameters.AddWithValue("@Password", user.Password);
                        command.Parameters.AddWithValue("@Active", user.Active);
                        command.Parameters.AddWithValue("@CreateDate", user.CreateDate);
                        command.Parameters.AddWithValue("@CreatedBy", user.CreatedBy);
                        command.Parameters.AddWithValue("@LastUpdate", user.LastUpdate);
                        command.Parameters.AddWithValue("@LastUpdateBy", user.LastUpdateBy);

                        command.ExecuteNonQuery();
                        MessageBox.Show("User added.", "Adding User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting user: {ex.Message}");
                    // Handle the exception as needed
                }
            }
        }

        public User GetUserByUsername(string username)
        {
            User user = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM user WHERE userName = @Username";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new User
                                {
                                    UserId = reader.GetInt32("userId"),
                                    UserName = reader.GetString("userName"),
                                    Password = reader.GetString("password"),
                                    Active = reader.GetBoolean("active"),
                                    CreateDate = reader.GetDateTime("createDate"),
                                    CreatedBy = reader.GetString("createdBy"),
                                    LastUpdate = reader.GetDateTime("lastUpdate"),
                                    LastUpdateBy = reader.GetString("lastUpdateBy")
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving user: {ex.Message}");
                    // Handle the exception as needed
                }
            }

            return user;
        }

        public void UpdateUser(User updatedUser)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE user SET userName = @UserName, password = @Password, " +
                                   "active = @Active, createDate = @CreateDate, createdBy = @CreatedBy, " +
                                   "lastUpdate = @LastUpdate, lastUpdateBy = @LastUpdateBy " +
                                   "WHERE userId = @UserId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", updatedUser.UserName);
                        command.Parameters.AddWithValue("@Password", updatedUser.Password);
                        command.Parameters.AddWithValue("@Active", updatedUser.Active);
                        command.Parameters.AddWithValue("@CreateDate", updatedUser.CreateDate);
                        command.Parameters.AddWithValue("@CreatedBy", updatedUser.CreatedBy);
                        command.Parameters.AddWithValue("@LastUpdate", updatedUser.LastUpdate);
                        command.Parameters.AddWithValue("@LastUpdateBy", updatedUser.LastUpdateBy);
                        command.Parameters.AddWithValue("@UserId", updatedUser.UserId);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating user: {ex.Message}");
                    // Handle the exception as needed
                }
            }
        }
    }
}
