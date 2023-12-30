using System.Globalization;
using System;
using System.Windows.Forms;

namespace Scheduler.Forms.Controls
{
    public class CalendarControl : UserControl
    {
        private FlowLayoutPanel flpDayContainer;
        private Button btnPrev;
        private Button btnNext;
        private Label lblMonthYearDisplay;
        private Panel panel36;
        private Label lblSaturday;
        private Label lblFriday;
        private Label lblThursday;
        private Label lblWednesday;
        private Label lblTuesday;
        private Label lblMonday;
        private Label lblSunday;
        private int _month;
        private int _year;
        private int _day;

        public CalendarControl()
        {
            InitializeComponent();
            Load += Calendar_Load;
        }

        private void InitializeComponent()
        {
            this.flpDayContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblMonthYearDisplay = new System.Windows.Forms.Label();
            this.panel36 = new System.Windows.Forms.Panel();
            this.lblSaturday = new System.Windows.Forms.Label();
            this.lblFriday = new System.Windows.Forms.Label();
            this.lblThursday = new System.Windows.Forms.Label();
            this.lblWednesday = new System.Windows.Forms.Label();
            this.lblTuesday = new System.Windows.Forms.Label();
            this.lblMonday = new System.Windows.Forms.Label();
            this.lblSunday = new System.Windows.Forms.Label();
            this.panel36.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpDayContainer
            // 
            this.flpDayContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpDayContainer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flpDayContainer.Location = new System.Drawing.Point(20, 182);
            this.flpDayContainer.Margin = new System.Windows.Forms.Padding(0);
            this.flpDayContainer.Name = "flpDayContainer";
            this.flpDayContainer.Size = new System.Drawing.Size(1096, 938);
            this.flpDayContainer.TabIndex = 12;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(623, 15);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(235, 75);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "Previous";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(911, 15);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(197, 75);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblMonthYearDisplay
            // 
            this.lblMonthYearDisplay.AutoSize = true;
            this.lblMonthYearDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthYearDisplay.Location = new System.Drawing.Point(457, 50);
            this.lblMonthYearDisplay.Name = "lblMonthYearDisplay";
            this.lblMonthYearDisplay.Size = new System.Drawing.Size(241, 37);
            this.lblMonthYearDisplay.TabIndex = 21;
            this.lblMonthYearDisplay.Text = "MONTH YEAR";
            this.lblMonthYearDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel36
            // 
            this.panel36.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel36.Controls.Add(this.btnPrev);
            this.panel36.Controls.Add(this.btnNext);
            this.panel36.Location = new System.Drawing.Point(-1, 1134);
            this.panel36.Margin = new System.Windows.Forms.Padding(0);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(1141, 109);
            this.panel36.TabIndex = 20;
            // 
            // lblSaturday
            // 
            this.lblSaturday.AutoSize = true;
            this.lblSaturday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaturday.Location = new System.Drawing.Point(986, 131);
            this.lblSaturday.Name = "lblSaturday";
            this.lblSaturday.Size = new System.Drawing.Size(107, 29);
            this.lblSaturday.TabIndex = 19;
            this.lblSaturday.Text = "Saturday";
            // 
            // lblFriday
            // 
            this.lblFriday.AutoSize = true;
            this.lblFriday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFriday.Location = new System.Drawing.Point(838, 131);
            this.lblFriday.Name = "lblFriday";
            this.lblFriday.Size = new System.Drawing.Size(80, 29);
            this.lblFriday.TabIndex = 18;
            this.lblFriday.Text = "Friday";
            // 
            // lblThursday
            // 
            this.lblThursday.AutoSize = true;
            this.lblThursday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThursday.Location = new System.Drawing.Point(668, 131);
            this.lblThursday.Name = "lblThursday";
            this.lblThursday.Size = new System.Drawing.Size(113, 29);
            this.lblThursday.TabIndex = 17;
            this.lblThursday.Text = "Thursday";
            // 
            // lblWednesday
            // 
            this.lblWednesday.AutoSize = true;
            this.lblWednesday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWednesday.Location = new System.Drawing.Point(501, 131);
            this.lblWednesday.Name = "lblWednesday";
            this.lblWednesday.Size = new System.Drawing.Size(140, 29);
            this.lblWednesday.TabIndex = 16;
            this.lblWednesday.Text = "Wednesday";
            // 
            // lblTuesday
            // 
            this.lblTuesday.AutoSize = true;
            this.lblTuesday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuesday.Location = new System.Drawing.Point(358, 131);
            this.lblTuesday.Name = "lblTuesday";
            this.lblTuesday.Size = new System.Drawing.Size(106, 29);
            this.lblTuesday.TabIndex = 15;
            this.lblTuesday.Text = "Tuesday";
            // 
            // lblMonday
            // 
            this.lblMonday.AutoSize = true;
            this.lblMonday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonday.Location = new System.Drawing.Point(202, 131);
            this.lblMonday.Name = "lblMonday";
            this.lblMonday.Size = new System.Drawing.Size(98, 29);
            this.lblMonday.TabIndex = 14;
            this.lblMonday.Text = "Monday";
            // 
            // lblSunday
            // 
            this.lblSunday.AutoSize = true;
            this.lblSunday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSunday.Location = new System.Drawing.Point(52, 131);
            this.lblSunday.Name = "lblSunday";
            this.lblSunday.Size = new System.Drawing.Size(93, 29);
            this.lblSunday.TabIndex = 13;
            this.lblSunday.Text = "Sunday";
            // 
            // CalendarControl
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flpDayContainer);
            this.Controls.Add(this.lblMonthYearDisplay);
            this.Controls.Add(this.panel36);
            this.Controls.Add(this.lblSaturday);
            this.Controls.Add(this.lblFriday);
            this.Controls.Add(this.lblThursday);
            this.Controls.Add(this.lblWednesday);
            this.Controls.Add(this.lblTuesday);
            this.Controls.Add(this.lblMonday);
            this.Controls.Add(this.lblSunday);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CalendarControl";
            this.Size = new System.Drawing.Size(1140, 1243);
            this.panel36.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void DisplayDays()
        {
            DateTime now = DateTime.Now;
            _year = now.Year;
            _month = now.Month;
            _day = now.Day;

            SetupDayContainer();
        }

        private void Calendar_Load(object sender, EventArgs e)
        {
            DisplayDays();
        }

        private void SetupDayContainer()
        {
            flpDayContainer.Controls.Clear();
            string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(_month);
            lblMonthYearDisplay.Text = monthName + " " + _year;
            DateTime startOfMonth = new DateTime(_year, _month, 1);
            int days = DateTime.DaysInMonth(_year, _month);
            int dayOfWeek = Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d")) + 1;

            int extraBlanks = 42 - ((dayOfWeek - 1) + days) + 1;

            for (int i = 1; i < dayOfWeek; i++)
            {
                BlankDayControl blankDayControl = new BlankDayControl();
                blankDayControl.Controls["lblDay"].Text = string.Empty;
                flpDayContainer.Controls.Add(blankDayControl);
            }

            for (int i = 1; i <= days; i++)
            {
                DayControl dayControl = new DayControl(_year, _month, i, AllowAddEvent(i));
                dayControl.SetDayLabel(i);

                if (i == _day && _year == DateTime.Now.Year && _month == DateTime.Now.Month)
                {
                    CircleLabel circleLabel = new CircleLabel();
                    var originalLabel = dayControl.Controls["lblDay"];
                    circleLabel.Location = originalLabel.Location;
                    circleLabel.Name = originalLabel.Name;
                    circleLabel.Text = originalLabel.Text;
                    dayControl.Controls.Remove(originalLabel);
                    dayControl.Controls.Add(circleLabel);
                }

                flpDayContainer.Controls.Add(dayControl);
            }

            for (int i = 1; i < extraBlanks; i++)
            {
                BlankDayControl blankDayControl = new BlankDayControl();
                blankDayControl.Controls["lblDay"].Text = string.Empty;
                flpDayContainer.Controls.Add(blankDayControl);
            }
        }

        private bool AllowAddEvent(int day)
        {
            DateTime currentDay = DateTime.Now;
            DateTime check = new DateTime(_year, _month, day);

            if (check >= currentDay.AddDays(-1) && IsWeekday(check))
            {
                return true;
            }

            return false;
        }

        private bool IsWeekday(DateTime date)
        {
            return date.DayOfWeek >= DayOfWeek.Monday && date.DayOfWeek <= DayOfWeek.Friday;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_month < 12)
            {
                _month += 1;
            }
            else
            {
                _month = 1;
                _year += 1;
            }

            SetupDayContainer();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_month > 1)
            {
                _month -= 1;
            }
            else
            {
                _month = 12;
                _year -= 1;
            }

            SetupDayContainer();
        }
    }
}
