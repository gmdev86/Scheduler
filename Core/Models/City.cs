using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Scheduler.Core.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }

        private string connectionString;

        public City()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ScheduleConnectionString"].ConnectionString;
        }

        public void CreateCity(City city)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                                   "VALUES (@CityName, @CountryId, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdateBy)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CityName", city.CityName);
                        command.Parameters.AddWithValue("@CountryId", city.CountryId);
                        command.Parameters.AddWithValue("@CreateDate", city.CreateDate);
                        command.Parameters.AddWithValue("@CreatedBy", city.CreatedBy);
                        command.Parameters.AddWithValue("@LastUpdate", city.LastUpdate);
                        command.Parameters.AddWithValue("@LastUpdateBy", city.LastUpdateBy);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating city: {ex.Message}");
                    // Handle the exception as needed
                }
            }
        }

        public List<City> GetAllCities()
        {
            List<City> cities = new List<City>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM city";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                City city = new City
                                {
                                    CityId = reader.GetInt32("cityId"),
                                    CityName = reader.GetString("city"),
                                    CountryId = reader.GetInt32("countryId"),
                                    CreateDate = reader.GetDateTime("createDate"),
                                    CreatedBy = reader.GetString("createdBy"),
                                    LastUpdate = reader.GetDateTime("lastUpdate"),
                                    LastUpdateBy = reader.GetString("lastUpdateBy")
                                };

                                cities.Add(city);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving cities: {ex.Message}");
                    // Handle the exception as needed
                }
            }

            return cities;
        }

        public void UpdateCity(City updatedCity)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE city SET city = @CityName, countryId = @CountryId, " +
                                   "createDate = @CreateDate, createdBy = @CreatedBy, " +
                                   "lastUpdate = @LastUpdate, lastUpdateBy = @LastUpdateBy " +
                                   "WHERE cityId = @CityId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CityName", updatedCity.CityName);
                        command.Parameters.AddWithValue("@CountryId", updatedCity.CountryId);
                        command.Parameters.AddWithValue("@CreateDate", updatedCity.CreateDate);
                        command.Parameters.AddWithValue("@CreatedBy", updatedCity.CreatedBy);
                        command.Parameters.AddWithValue("@LastUpdate", updatedCity.LastUpdate);
                        command.Parameters.AddWithValue("@LastUpdateBy", updatedCity.LastUpdateBy);
                        command.Parameters.AddWithValue("@CityId", updatedCity.CityId);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating city: {ex.Message}");
                    // Handle the exception as needed
                }
            }
        }

        public void DeleteCity(int cityId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "DELETE FROM city WHERE cityId = @CityId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CityId", cityId);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting city: {ex.Message}");
                    // Handle the exception as needed
                }
            }
        }
    }
}
