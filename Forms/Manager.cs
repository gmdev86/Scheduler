using System.Windows.Forms;
using Scheduler.Core.Enums;
using Scheduler.Core.Models;
using Scheduler.Core.Services;
using Scheduler.Core.Utility;

namespace Scheduler.Forms
{
    public partial class Manager : Form
    {
        private DataService _dataService;
        private UserSession _userSession;

        public Manager()
        {
            InitializeComponent();
        }

        private void Manager_Load(object sender, System.EventArgs e)
        {
            _dataService = DataService.Instance;
            _userSession = UserSession.Instance;
            tabControl1.AutoSize = true;
            tabControl1.Width = calendarControl1.Width;
            tabControl1.Height = calendarControl1.Height + 20;
            Appointment appointment = _dataService.AppointmentAlert(_userSession.User.UserId);

            if (appointment != null)
            {
                MessageBox.Show(
                    $"You have an upcoming appointment: {appointment.Type} @ {DateTimeConverter.UtcToLocalDateTime(appointment.Start)}",
                    "Appointment Alert", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var selectedTab = tabControl1.SelectedIndex;

            switch (selectedTab)
            {
                case (int)Tabs.Calendar:
                    tabControl1.Width = calendarControl1.Width;
                    tabControl1.Height = calendarControl1.Height + 20;
                    break;
                case (int)Tabs.Users:
                    tabControl1.Width = usersControl1.Width;
                    tabControl1.Height = usersControl1.Height + 20;
                    break;
                case (int)Tabs.Customers:
                    tabControl1.Width = customersControl1.Width;
                    tabControl1.Height = customersControl1.Height + 20;
                    break;
                case (int)Tabs.Address:
                    tabControl1.Width = addressControl1.Width;
                    tabControl1.Height = addressControl1.Height + 20;
                    break;
                case (int)Tabs.City:
                    tabControl1.Width = cityControl1.Width;
                    tabControl1.Height = cityControl1.Height + 20;
                    break;
                case (int)Tabs.Country:
                    tabControl1.Width = countryControl1.Width;
                    tabControl1.Height = countryControl1.Height + 20;
                    break;
                case (int)Tabs.Reports:
                    tabControl1.Width = reportsControl1.Width;
                    tabControl1.Height = reportsControl1.Height + 20;
                    break;
            }
            
        }

        private void Manager_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
