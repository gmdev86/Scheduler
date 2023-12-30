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

    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }
    }

    public class AppointmentDataAccess
    {
        private string connectionString;

        public AppointmentDataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void CreateAppointment(Appointment appointment)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
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
                        command.Parameters.AddWithValue("@CreatedBy", appointment.CreatedBy);
                        command.Parameters.AddWithValue("@LastUpdate", appointment.LastUpdate);
                        command.Parameters.AddWithValue("@LastUpdateBy", appointment.LastUpdateBy);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating appointment: {ex.Message}");
                    // Handle the exception as needed
                }
            }
        }

        public List<Appointment> GetAllAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM appointment";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
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
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving appointments: {ex.Message}");
                    // Handle the exception as needed
                }
            }

            return appointments;
        }

        public void UpdateAppointment(Appointment updatedAppointment)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
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
                        command.Parameters.AddWithValue("@CreatedBy", updatedAppointment.CreatedBy);
                        command.Parameters.AddWithValue("@LastUpdate", updatedAppointment.LastUpdate);
                        command.Parameters.AddWithValue("@LastUpdateBy", updatedAppointment.LastUpdateBy);
                        command.Parameters.AddWithValue("@AppointmentId", updatedAppointment.AppointmentId);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating appointment: {ex.Message}");
                    // Handle the exception as needed
                }
            }
        }

        public void DeleteAppointment(int appointmentId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "DELETE FROM appointment WHERE appointmentId = @AppointmentId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AppointmentId", appointmentId);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting appointment: {ex.Message}");
                    // Handle the exception as needed
                }
            }
        }
    }

}
