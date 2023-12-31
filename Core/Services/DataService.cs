using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
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
            catch (Exception)
            {
            }
        }

        #region User Methods

        public DataTable GetAllUsers()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM `user`";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }
        
        public void CreateUser(User user)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
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
        }
        
        public User GetUserByUsername(string username)
        {
            User user = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
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

            return user;
        }
        
        public void UpdateUser(User user)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
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
        }
        
        public void DeleteUser(int userId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM user WHERE userId = @UserId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    command.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region Customer Methods

        public void CreateCustomer(Customer customer)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                               "VALUES (@CustomerName, @AddressId, @IsActive, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdateBy)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                    command.Parameters.AddWithValue("@AddressId", customer.AddressId);
                    command.Parameters.AddWithValue("@IsActive", customer.IsActive);
                    command.Parameters.AddWithValue("@CreateDate", customer.CreateDate);
                    command.Parameters.AddWithValue("@CreatedBy", customer.CreatedBy);
                    command.Parameters.AddWithValue("@LastUpdate", customer.LastUpdate);
                    command.Parameters.AddWithValue("@LastUpdateBy", customer.LastUpdateBy);

                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetAllCustomers()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM customer";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }

        public void UpdateCustomer(Customer updatedCustomer)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE customer SET customerName = @CustomerName, addressId = @AddressId, " +
                               "active = @IsActive, createDate = @CreateDate, createdBy = @CreatedBy, " +
                               "lastUpdate = @LastUpdate, lastUpdateBy = @LastUpdateBy " +
                               "WHERE customerId = @CustomerId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerName", updatedCustomer.CustomerName);
                    command.Parameters.AddWithValue("@AddressId", updatedCustomer.AddressId);
                    command.Parameters.AddWithValue("@IsActive", updatedCustomer.IsActive);
                    command.Parameters.AddWithValue("@CreateDate", updatedCustomer.CreateDate);
                    command.Parameters.AddWithValue("@CreatedBy", updatedCustomer.CreatedBy);
                    command.Parameters.AddWithValue("@LastUpdate", updatedCustomer.LastUpdate);
                    command.Parameters.AddWithValue("@LastUpdateBy", updatedCustomer.LastUpdateBy);
                    command.Parameters.AddWithValue("@CustomerId", updatedCustomer.CustomerId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM customer WHERE customerId = @CustomerId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);

                    command.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region Country

        public void CreateCountry(Country country)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
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
        }

        public DataTable GetAllCountries()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM country";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }

        public void UpdateCountry(Country updatedCountry)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
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
        }

        public void DeleteCountry(int countryId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM country WHERE countryId = @CountryId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CountryId", countryId);

                    command.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region City

        public void CreateCity(City city)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
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
        }

        public DataTable GetAllCities()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM city";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }

        public void UpdateCity(City updatedCity)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
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
        }

        public void DeleteCity(int cityId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM city WHERE cityId = @CityId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CityId", cityId);

                    command.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region Address

        public void CreateAddress(Address address)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                               "VALUES (@AddressLine1, @AddressLine2, @CityId, @PostalCode, @Phone, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdateBy)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AddressLine1", address.AddressLine1);
                    command.Parameters.AddWithValue("@AddressLine2", address.AddressLine2);
                    command.Parameters.AddWithValue("@CityId", address.CityId);
                    command.Parameters.AddWithValue("@PostalCode", address.PostalCode);
                    command.Parameters.AddWithValue("@Phone", address.Phone);
                    command.Parameters.AddWithValue("@CreateDate", address.CreateDate);
                    command.Parameters.AddWithValue("@CreatedBy", address.CreatedBy);
                    command.Parameters.AddWithValue("@LastUpdate", address.LastUpdate);
                    command.Parameters.AddWithValue("@LastUpdateBy", address.LastUpdateBy);

                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetAllAddresses()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM address";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }

        public void UpdateAddress(Address updatedAddress)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE address SET address = @AddressLine1, address2 = @AddressLine2, " +
                               "cityId = @CityId, postalCode = @PostalCode, phone = @Phone, " +
                               "createDate = @CreateDate, createdBy = @CreatedBy, " +
                               "lastUpdate = @LastUpdate, lastUpdateBy = @LastUpdateBy " +
                               "WHERE addressId = @AddressId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AddressLine1", updatedAddress.AddressLine1);
                    command.Parameters.AddWithValue("@AddressLine2", updatedAddress.AddressLine2);
                    command.Parameters.AddWithValue("@CityId", updatedAddress.CityId);
                    command.Parameters.AddWithValue("@PostalCode", updatedAddress.PostalCode);
                    command.Parameters.AddWithValue("@Phone", updatedAddress.Phone);
                    command.Parameters.AddWithValue("@CreateDate", updatedAddress.CreateDate);
                    command.Parameters.AddWithValue("@CreatedBy", updatedAddress.CreatedBy);
                    command.Parameters.AddWithValue("@LastUpdate", updatedAddress.LastUpdate);
                    command.Parameters.AddWithValue("@LastUpdateBy", updatedAddress.LastUpdateBy);
                    command.Parameters.AddWithValue("@AddressId", updatedAddress.AddressId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAddress(int addressId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM address WHERE addressId = @AddressId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AddressId", addressId);

                    command.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region Load ComboBoxItems

        public BindingList<SelectListItem> LoadItems(string tableName)
        {
            BindingList<SelectListItem> selectListItems = new BindingList<SelectListItem>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM {tableName}";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SelectListItem selectListItem = new SelectListItem
                            {
                                Id = reader.GetInt32($"{tableName}Id"),
                                Value = reader.GetString($"{tableName}")
                            };

                            selectListItems.Add(selectListItem);
                        }
                    }
                }
            }

            return selectListItems;
        }

        #endregion
    }
}
