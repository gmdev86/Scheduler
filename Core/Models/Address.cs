using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Scheduler.Core.Models
{

    public class Address
    {
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int CityId { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }
    }

    public class AddressDataAccess
    {
        private string connectionString;

        public AddressDataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void CreateAddress(Address address)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
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
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating address: {ex.Message}");
                    // Handle the exception as needed
                }
            }
        }

        public List<Address> GetAllAddresses()
        {
            List<Address> addresses = new List<Address>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM address";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Address address = new Address
                                {
                                    AddressId = reader.GetInt32("addressId"),
                                    AddressLine1 = reader.GetString("address"),
                                    AddressLine2 = reader.GetString("address2"),
                                    CityId = reader.GetInt32("cityId"),
                                    PostalCode = reader.GetString("postalCode"),
                                    Phone = reader.GetString("phone"),
                                    CreateDate = reader.GetDateTime("createDate"),
                                    CreatedBy = reader.GetString("createdBy"),
                                    LastUpdate = reader.GetDateTime("lastUpdate"),
                                    LastUpdateBy = reader.GetString("lastUpdateBy")
                                };

                                addresses.Add(address);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving addresses: {ex.Message}");
                    // Handle the exception as needed
                }
            }

            return addresses;
        }

        public void UpdateAddress(Address updatedAddress)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
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
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating address: {ex.Message}");
                    // Handle the exception as needed
                }
            }
        }

        public void DeleteAddress(int addressId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "DELETE FROM address WHERE addressId = @AddressId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AddressId", addressId);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting address: {ex.Message}");
                    // Handle the exception as needed
                }
            }
        }
    }

}
