using System;
using System.Drawing;
using System.Windows.Forms;
using Scheduler.Core.Enums;
using Scheduler.Core.Services;

namespace Scheduler.Forms.Controls
{
    public partial class DayControl : UserControl
    {
        private int _year;
        private int _month;
        private int _day;

        public DayControl(int year, int month, int day, bool allowAddEvent = true)
        {
            InitializeComponent();
            try
            {
                Font awesomeFont = FontService.LoadFontAwesome();
                btnAddEvent.Font = awesomeFont;
                btnAddEvent.Text = char.ConvertFromUtf32((int)IconType.PlusCircle);
            }
            catch (Exception e)
            {
            }

            _year = year;
            _month = month;
            _day = day;
            if (allowAddEvent)
            {
                btnAddEvent.Visible = true;
            }
        }

        public void SetDayLabel(int day)
        {
            lblDay.Text = day.ToString();
        }

        private void btnAddEvent_Click(object sender, System.EventArgs e)
        {
            Appointments appointments = new Appointments(_year, _month, _day);
            appointments.Show();
        }

        private void btnAddEvent_MouseEnter(object sender, System.EventArgs e)
        {
            btnAddEvent.Cursor = Cursors.Hand;
        }

        private void btnAddEvent_MouseLeave(object sender, System.EventArgs e)
        {
            btnAddEvent.Cursor = Cursors.Default;
        }
    }
}
