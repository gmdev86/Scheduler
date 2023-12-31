using System.Windows.Forms;
using Scheduler.Core.Enums;

namespace Scheduler.Forms
{
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
        }

        private void Manager_Load(object sender, System.EventArgs e)
        {
            tabControl1.AutoSize = true;
            tabControl1.Width = calendarControl1.Width;
            tabControl1.Height = calendarControl1.Height + 20;
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
                    break;
            }
            
        }

        private void Manager_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
