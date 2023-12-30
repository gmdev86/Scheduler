using System.Globalization;
using System.Windows.Forms;

namespace Scheduler.Forms
{
    public partial class Appointments : Form
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public Appointments()
        {
            InitializeComponent();
        }

        public Appointments(int year, int month, int day)
        {
            InitializeComponent();
            Year = year;
            Month = month;
            Day = day;

            lblHeader.Text = $"{DateTimeFormatInfo.CurrentInfo.GetMonthName(Month)}, {Day} {Year}";
            timeSlotsControl.Year = Year;
            timeSlotsControl.Month = Month;
            timeSlotsControl.Day = Day;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
