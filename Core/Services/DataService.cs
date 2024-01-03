using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using Scheduler.Core.Models;
using Scheduler.Core.Utility;

namespace Scheduler.Core.Services
{
    public class DataService
    {
        private string _connectionString = "Server=localhost;Port=3306;Database=schedule;Uid=test;Pwd=test;";
        private static DataService _instance;

        public DataService()
        {
            try
            {
                _connectionString = ConfigurationManager.ConnectionStrings["ScheduleConnectionString"].ConnectionString;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Missing or invalid connention string in App.config", "Invalid Connectionstring", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static DataService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataService();
                }
                return _instance;
            }
        }

        #region User Methods

        public DataTable GetAllUsers()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
                    command.Parameters.AddWithValue("@CreatedBy", user.CreatedBy.Truncate(40));
                    command.Parameters.AddWithValue("@LastUpdate", user.LastUpdate);
                    command.Parameters.AddWithValue("@LastUpdateBy", user.LastUpdateBy.Truncate(40));

                    command.ExecuteNonQuery();
                }
            }
        }
        
        public User GetUserByUsername(string username)
        {
            User user = null;

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
                    command.Parameters.AddWithValue("@CreatedBy", user.CreatedBy.Truncate(40));
                    command.Parameters.AddWithValue("@LastUpdate", user.LastUpdate);
                    command.Parameters.AddWithValue("@LastUpdateBy", user.LastUpdateBy.Truncate(40));
                    command.Parameters.AddWithValue("@UserId", user.UserId);

                    command.ExecuteNonQuery();
                }
            }
        }
        
        public void DeleteUser(int userId)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
                    command.Parameters.AddWithValue("@CreatedBy", customer.CreatedBy.Truncate(40));
                    command.Parameters.AddWithValue("@LastUpdate", customer.LastUpdate);
                    command.Parameters.AddWithValue("@LastUpdateBy", customer.LastUpdateBy.Truncate(40));

                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetAllCustomers()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
                    command.Parameters.AddWithValue("@CreatedBy", updatedCustomer.CreatedBy.Truncate(40));
                    command.Parameters.AddWithValue("@LastUpdate", updatedCustomer.LastUpdate);
                    command.Parameters.AddWithValue("@LastUpdateBy", updatedCustomer.LastUpdateBy.Truncate(40));
                    command.Parameters.AddWithValue("@CustomerId", updatedCustomer.CustomerId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                               "VALUES (@CountryName, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdateBy)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CountryName", country.CountryName);
                    command.Parameters.AddWithValue("@CreateDate", country.CreateDate);
                    command.Parameters.AddWithValue("@CreatedBy", country.CreatedBy.Truncate(40));
                    command.Parameters.AddWithValue("@LastUpdate", country.LastUpdate);
                    command.Parameters.AddWithValue("@LastUpdateBy", country.LastUpdateBy.Truncate(40));

                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetAllCountries()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
                    command.Parameters.AddWithValue("@CreatedBy", updatedCountry.CreatedBy.Truncate(40));
                    command.Parameters.AddWithValue("@LastUpdate", updatedCountry.LastUpdate);
                    command.Parameters.AddWithValue("@LastUpdateBy", updatedCountry.LastUpdateBy.Truncate(40));
                    command.Parameters.AddWithValue("@CountryId", updatedCountry.CountryId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCountry(int countryId)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                               "VALUES (@CityName, @CountryId, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdateBy)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CityName", city.CityName);
                    command.Parameters.AddWithValue("@CountryId", city.CountryId);
                    command.Parameters.AddWithValue("@CreateDate", city.CreateDate);
                    command.Parameters.AddWithValue("@CreatedBy", city.CreatedBy.Truncate(40));
                    command.Parameters.AddWithValue("@LastUpdate", city.LastUpdate);
                    command.Parameters.AddWithValue("@LastUpdateBy", city.LastUpdateBy.Truncate(40));

                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetAllCities()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
                    command.Parameters.AddWithValue("@CreatedBy", updatedCity.CreatedBy.Truncate(40));
                    command.Parameters.AddWithValue("@LastUpdate", updatedCity.LastUpdate);
                    command.Parameters.AddWithValue("@LastUpdateBy", updatedCity.LastUpdateBy.Truncate(40));
                    command.Parameters.AddWithValue("@CityId", updatedCity.CityId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCity(int cityId)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
                    command.Parameters.AddWithValue("@CreatedBy", address.CreatedBy.Truncate(40));
                    command.Parameters.AddWithValue("@LastUpdate", address.LastUpdate);
                    command.Parameters.AddWithValue("@LastUpdateBy", address.LastUpdateBy.Truncate(40));

                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetAllAddresses()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
                    command.Parameters.AddWithValue("@CreatedBy", updatedAddress.CreatedBy.Truncate(40));
                    command.Parameters.AddWithValue("@LastUpdate", updatedAddress.LastUpdate);
                    command.Parameters.AddWithValue("@LastUpdateBy", updatedAddress.LastUpdateBy.Truncate(40));
                    command.Parameters.AddWithValue("@AddressId", updatedAddress.AddressId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAddress(int addressId)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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

        #region Appointment

        public void CreateAppointment(Appointment appointment)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO appointment (customerId, userId, title, description, location, contact, " +
                               "type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                               "VALUES (@CustomerId, @UserId, @Title, @Description, @Location, @Contact, " +
                               "@Type, @Url, @Start, @End, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdateBy)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", appointment.CustomerId);
                    command.Parameters.AddWithValue("@UserId", appointment.UserId);
                    command.Parameters.AddWithValue("@Title", appointment.Title);
                    command.Parameters.AddWithValue("@Description", appointment.Description);
                    command.Parameters.AddWithValue("@Location", appointment.Location);
                    command.Parameters.AddWithValue("@Contact", appointment.Contact);
                    command.Parameters.AddWithValue("@Type", appointment.Type);
                    command.Parameters.AddWithValue("@Url", appointment.Url);
                    command.Parameters.AddWithValue("@Start", appointment.Start);
                    command.Parameters.AddWithValue("@End", appointment.End);
                    command.Parameters.AddWithValue("@CreateDate", appointment.CreateDate);
                    command.Parameters.AddWithValue("@CreatedBy", appointment.CreatedBy.Truncate(40));
                    command.Parameters.AddWithValue("@LastUpdate", appointment.LastUpdate);
                    command.Parameters.AddWithValue("@LastUpdateBy", appointment.LastUpdateBy.Truncate(40));

                    command.ExecuteNonQuery();
                }
            }
        }

        public BindingList<Appointment> GetAllAppointments(DateTime? createDateTime = null)
        {
            BindingList<Appointment> appointments = new BindingList<Appointment>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT * " +
                               "FROM appointment " +
                               "WHERE @createDate is null || " +
                               "createDate = @createDate";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@createDate", createDateTime);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Appointment appointment = new Appointment
                            {
                                AppointmentId = reader.GetInt32("appointmentId"),
                                CustomerId = reader.GetInt32("customerId"),
                                UserId = reader.GetInt32("userId"),
                                Title = reader.GetString("title"),
                                Description = reader.GetString("description"),
                                Location = reader.GetString("location"),
                                Contact = reader.GetString("contact"),
                                Type = reader.GetString("type"),
                                Url = reader.GetString("url"),
                                Start = reader.GetDateTime("start"),
                                End = reader.GetDateTime("end"),
                                CreateDate = reader.GetDateTime("createDate"),
                                CreatedBy = reader.GetString("createdBy"),
                                LastUpdate = reader.GetDateTime("lastUpdate"),
                                LastUpdateBy = reader.GetString("lastUpdateBy")
                            };

                            appointments.Add(appointment);
                        }
                    }
                }
            }

            return appointments;
        }

        public Appointment AppointmentAlert(int userId)
        {
            Appointment appointment = new Appointment();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                DateTime currentDateAndTime = DateTime.UtcNow;
                DateTime fifteenMinutesFromNow = currentDateAndTime.AddMinutes(15);

                string query = "SELECT * " +
                               "FROM appointment " +
                               "WHERE @start >= @currentTime " +
                               "AND @start <= @fifteenMinutesFromNow " +
                               "AND userId = @userId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@currentTime", currentDateAndTime);
                    command.Parameters.AddWithValue("@fifteenMinutesFromNow", fifteenMinutesFromNow);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            appointment = new Appointment
                            {
                                AppointmentId = reader.GetInt32("appointmentId"),
                                CustomerId = reader.GetInt32("customerId"),
                                UserId = reader.GetInt32("userId"),
                                Title = reader.GetString("title"),
                                Description = reader.GetString("description"),
                                Location = reader.GetString("location"),
                                Contact = reader.GetString("contact"),
                                Type = reader.GetString("type"),
                                Url = reader.GetString("url"),
                                Start = reader.GetDateTime("start"),
                                End = reader.GetDateTime("end"),
                                CreateDate = reader.GetDateTime("createDate"),
                                CreatedBy = reader.GetString("createdBy"),
                                LastUpdate = reader.GetDateTime("lastUpdate"),
                                LastUpdateBy = reader.GetString("lastUpdateBy")
                            };
                        }
                    }
                }
            }

            return appointment;
        }

        public void UpdateAppointment(Appointment updatedAppointment)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "UPDATE appointment SET customerId = @CustomerId, userId = @UserId, " +
                               "title = @Title, description = @Description, location = @Location, " +
                               "contact = @Contact, type = @Type, url = @Url, start = @Start, " +
                               "end = @End, createDate = @CreateDate, createdBy = @CreatedBy, " +
                               "lastUpdate = @LastUpdate, lastUpdateBy = @LastUpdateBy " +
                               "WHERE appointmentId = @AppointmentId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", updatedAppointment.CustomerId);
                    command.Parameters.AddWithValue("@UserId", updatedAppointment.UserId);
                    command.Parameters.AddWithValue("@Title", updatedAppointment.Title);
                    command.Parameters.AddWithValue("@Description", updatedAppointment.Description);
                    command.Parameters.AddWithValue("@Location", updatedAppointment.Location);
                    command.Parameters.AddWithValue("@Contact", updatedAppointment.Contact);
                    command.Parameters.AddWithValue("@Type", updatedAppointment.Type);
                    command.Parameters.AddWithValue("@Url", updatedAppointment.Url);
                    command.Parameters.AddWithValue("@Start", updatedAppointment.Start);
                    command.Parameters.AddWithValue("@End", updatedAppointment.End);
                    command.Parameters.AddWithValue("@CreateDate", updatedAppointment.CreateDate);
                    command.Parameters.AddWithValue("@CreatedBy", updatedAppointment.CreatedBy.Truncate(40));
                    command.Parameters.AddWithValue("@LastUpdate", updatedAppointment.LastUpdate);
                    command.Parameters.AddWithValue("@LastUpdateBy", updatedAppointment.LastUpdateBy.Truncate(40));
                    command.Parameters.AddWithValue("@AppointmentId", updatedAppointment.AppointmentId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAppointment(int appointmentId)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = "DELETE FROM appointment WHERE appointmentId = @AppointmentId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AppointmentId", appointmentId);

                    command.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region Load ComboBoxItems

        public BindingList<SelectListItem> LoadItems(string tableName, bool includeNamePostfix = false)
        {
            BindingList<SelectListItem> selectListItems = new BindingList<SelectListItem>();
            string valueText = tableName;
            if (includeNamePostfix)
            {
                valueText = valueText + "Name";
            }

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
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
                                Value = reader.GetString($"{valueText}")
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
