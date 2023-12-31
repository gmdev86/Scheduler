using System;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Scheduler.Core.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }

        private string connectionString;

        public User()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ScheduleConnectionString"].ConnectionString;
        }


    }

}
