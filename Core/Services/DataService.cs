using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using Scheduler.Core.Interfaces;
using Scheduler.Core.Models;

namespace Scheduler.Core.Services
{
    public class DataService : IDataService
    {
        private string connectionString = "Server=localhost;Port=3306;Database=schedule;Uid=test;Pwd=test;";

        public DataService()
        {
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["ScheduleConnectionString"].ConnectionString;
            }
            catch (Exception e)
            {
            }
        }

        #region User Methods

        public DataTable GetAllUsers()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM `user`";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }
        
        public void CreateUser(User user)
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
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating user: {ex.Message}");
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
                                user = new User()
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
        
        public void UpdateUser(User user)
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
                        command.Parameters.AddWithValue("@UserName", user.UserName);
                        command.Parameters.AddWithValue("@Password", user.Password);
                        command.Parameters.AddWithValue("@Active", user.Active);
                        command.Parameters.AddWithValue("@CreateDate", user.CreateDate);
                        command.Parameters.AddWithValue("@CreatedBy", user.CreatedBy);
                        command.Parameters.AddWithValue("@LastUpdate", user.LastUpdate);
                        command.Parameters.AddWithValue("@LastUpdateBy", user.LastUpdateBy);
                        command.Parameters.AddWithValue("@UserId", user.UserId);

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
        
        public void DeleteUser(int userId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "DELETE FROM user WHERE userId = @UserId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        #endregion
        
    }
}
