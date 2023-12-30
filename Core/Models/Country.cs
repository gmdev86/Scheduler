using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Scheduler.Core.Models
{

    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }

        private string connectionString;

        public Country()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ScheduleConnectionString"].ConnectionString;
        }

        public void CreateCountry(Country country)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                                   "VALUES (@CountryName, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdateBy)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CountryName", country.CountryName);
                        command.Parameters.AddWithValue("@CreateDate", country.CreateDate);
                        command.Parameters.AddWithValue("@CreatedBy", country.CreatedBy);
                        command.Parameters.AddWithValue("@LastUpdate", country.LastUpdate);
                        command.Parameters.AddWithValue("@LastUpdateBy", country.LastUpdateBy);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating country: {ex.Message}");
                    // Handle the exception as needed
                }
            }
        }

        public List<Country> GetAllCountries()
        {
            List<Country> countries = new List<Country>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM country";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Country country = new Country
                                {
                                    CountryId = reader.GetInt32("countryId"),
                                    CountryName = reader.GetString("country"),
                                    CreateDate = reader.GetDateTime("createDate"),
                                    CreatedBy = reader.GetString("createdBy"),
                                    LastUpdate = reader.GetDateTime("lastUpdate"),
                                    LastUpdateBy = reader.GetString("lastUpdateBy")
                                };

                                countries.Add(country);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving countries: {ex.Message}");
                    // Handle the exception as needed
                }
            }

            return countries;
        }

        public void UpdateCountry(Country updatedCountry)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE country SET country = @CountryName, " +
                                   "createDate = @CreateDate, createdBy = @CreatedBy, " +
                                   "lastUpdate = @LastUpdate, lastUpdateBy = @LastUpdateBy " +
                                   "WHERE countryId = @CountryId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CountryName", updatedCountry.CountryName);
                        command.Parameters.AddWithValue("@CreateDate", updatedCountry.CreateDate);
                        command.Parameters.AddWithValue("@CreatedBy", updatedCountry.CreatedBy);
                        command.Parameters.AddWithValue("@LastUpdate", updatedCountry.LastUpdate);
                        command.Parameters.AddWithValue("@LastUpdateBy", updatedCountry.LastUpdateBy);
                        command.Parameters.AddWithValue("@CountryId", updatedCountry.CountryId);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating country: {ex.Message}");
                    // Handle the exception as needed
                }
            }
        }

        public void DeleteCountry(int countryId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "DELETE FROM country WHERE countryId = @CountryId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CountryId", countryId);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting country: {ex.Message}");
                    // Handle the exception as needed
                }
            }
        }
    }

}
