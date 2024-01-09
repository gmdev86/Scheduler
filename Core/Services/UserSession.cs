using Scheduler.Core.Models;
using System;
using System.Globalization;

namespace Scheduler.Core.Services
{
    public class UserSession
    {
        private static UserSession _instance;

        private User _user;

        public User User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                LogLoginHistory();
            }
        }

        public CultureInfo CurrentCultureInfo { get; set; } = CultureInfo.InvariantCulture;

        private UserSession()
        {
        }

        public static UserSession Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserSession();
                }
                return _instance;
            }
        }

        private void LogLoginHistory()
        {
            string logMessage = $"{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")} - User '{_user.UserName}' logged in.";
            string filePath = "Login_History.txt";
            System.IO.File.AppendAllText(filePath, logMessage + Environment.NewLine);
        }

        public void LogLoginAttempted(string errorMessage = "")
        {
            string logMessage = $"{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")} - Log in attempted {errorMessage}";
            string filePath = "Login_History.txt";
            System.IO.File.AppendAllText(filePath, logMessage + Environment.NewLine);
        }

    }

}
