using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Core.Models
{
    using System;
    using System.Collections.Generic;
    using MySql.Data.MySqlClient;

    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int AddressId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }
    }

    public class CustomerDataAccess
    {
        private string connectionString;

        public CustomerDataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void CreateCustomer(Customer customer)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
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
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating customer: {ex.Message}");
                    // Handle the exception as needed
                }
            }
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM customer";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer
                                {
                                    CustomerId = reader.GetInt32("customerId"),
                                    CustomerName = reader.GetString("customerName"),
                                    AddressId = reader.GetInt32("addressId"),
                                    IsActive = reader.GetBoolean("active"),
                                    CreateDate = reader.GetDateTime("createDate"),
                                    CreatedBy = reader.GetString("createdBy"),
                                    LastUpdate = reader.GetDateTime("lastUpdate"),
                                    LastUpdateBy = reader.GetString("lastUpdateBy")
                                };

                                customers.Add(customer);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving customers: {ex.Message}");
                    // Handle the exception as needed
                }
            }

            return customers;
        }

        public void UpdateCustomer(Customer updatedCustomer)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
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
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating customer: {ex.Message}");
                    // Handle the exception as needed
                }
            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "DELETE FROM customer WHERE customerId = @CustomerId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", customerId);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting customer: {ex.Message}");
                    // Handle the exception as needed
                }
            }
        }
    }

}
