using System.Collections.Generic;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

namespace Scheduler.Forms.Controls
{
    public class TimeSlotsControl : UserControl
    {
        #region Properties

        private int _startTime;
        private int _endTime;
        private Action<ResizableAppointment> DeleteAppointment;
        private Dictionary<int, string> _availableSlots = new Dictionary<int, string>
        {
            { 910, "btn910" },
            { 1011, "btn1011" },
            { 1112, "btn1112" },
            { 1213, "btn1213" },
            { 1314, "btn1314" },
            { 1415, "btn1415" },
            { 1516, "btn1516" },
            { 1617, "btn1617" },
        };
        private Dictionary<int, string> _takenSlots = new Dictionary<int, string>();
        private FlowLayoutPanel flpAppointments;
        private Button btn910;
        private Button btn1617;
        private Button btn1011;
        private Button btn1516;
        private Button btn1112;
        private Button btn1415;
        private Button btn1213;
        private Button btn1314;

        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        #endregion

        #region Constructor

        public TimeSlotsControl()
        {
            InitializeComponent();
            flpAppointments.Controls.Clear();
            DeleteAppointment = DeleteAppointment_Click;
            DateTime currentDateTime = DateTime.Now;
            Year = currentDateTime.Year;
            Month = currentDateTime.Month;
            Day = currentDateTime.Day;
        }

        public TimeSlotsControl(int year, int month, int day)
        {
            InitializeComponent();
            flpAppointments.Controls.Clear();
            DeleteAppointment = DeleteAppointment_Click;
            Year = year;
            Month = month;
            Day = day;
        }

        #endregion

        #region Event Handlers

        private void DeleteAppointment_Click(ResizableAppointment resizableAppointment)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this appointment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                flpAppointments.Controls.Remove(resizableAppointment);
                ResetTimeSlot();
                CalculateAvailableTimeSlots();
            }
        }

        private void ResizableAppointment_EndTimeChanged(object sender, EventArgs e)
        {
            ResetTimeSlot();
            CalculateAvailableTimeSlots();
        }

        private void btn910_Click(object sender, System.EventArgs e)
        {
            SetTimeSlot(9, 10);
        }

        private void btn1011_Click(object sender, System.EventArgs e)
        {
            SetTimeSlot(10, 11);
        }

        private void btn1112_Click(object sender, EventArgs e)
        {
            SetTimeSlot(11, 12);
        }

        private void btn1213_Click(object sender, EventArgs e)
        {
            SetTimeSlot(12, 13);
        }

        private void btn1314_Click(object sender, EventArgs e)
        {
            SetTimeSlot(13, 14);
        }

        private void btn1415_Click(object sender, EventArgs e)
        {
            SetTimeSlot(14, 15);
        }

        private void btn1516_Click(object sender, EventArgs e)
        {
            SetTimeSlot(15, 16);
        }

        private void btn1617_Click(object sender, EventArgs e)
        {
            SetTimeSlot(16, 17);
        }

        #endregion

        #region Private Methods

        private void InitializeComponent()
        {
            this.flpAppointments = new System.Windows.Forms.FlowLayoutPanel();
            this.btn910 = new System.Windows.Forms.Button();
            this.btn1617 = new System.Windows.Forms.Button();
            this.btn1011 = new System.Windows.Forms.Button();
            this.btn1516 = new System.Windows.Forms.Button();
            this.btn1112 = new System.Windows.Forms.Button();
            this.btn1415 = new System.Windows.Forms.Button();
            this.btn1213 = new System.Windows.Forms.Button();
            this.btn1314 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flpAppointments
            // 
            this.flpAppointments.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flpAppointments.Location = new System.Drawing.Point(86, 3);
            this.flpAppointments.Name = "flpAppointments";
            this.flpAppointments.Size = new System.Drawing.Size(303, 371);
            this.flpAppointments.TabIndex = 11;
            // 
            // btn910
            // 
            this.btn910.Location = new System.Drawing.Point(5, 6);
            this.btn910.Margin = new System.Windows.Forms.Padding(0);
            this.btn910.Name = "btn910";
            this.btn910.Size = new System.Drawing.Size(75, 45);
            this.btn910.TabIndex = 12;
            this.btn910.Text = "9 -10";
            this.btn910.UseVisualStyleBackColor = true;
            this.btn910.Click += btn910_Click;
            // 
            // btn1617
            // 
            this.btn1617.Location = new System.Drawing.Point(5, 321);
            this.btn1617.Margin = new System.Windows.Forms.Padding(0);
            this.btn1617.Name = "btn1617";
            this.btn1617.Size = new System.Drawing.Size(75, 45);
            this.btn1617.TabIndex = 19;
            this.btn1617.Text = "16 - 17";
            this.btn1617.UseVisualStyleBackColor = true;
            this.btn1617.Click += btn1617_Click;
            // 
            // btn1011
            // 
            this.btn1011.Location = new System.Drawing.Point(5, 51);
            this.btn1011.Margin = new System.Windows.Forms.Padding(0);
            this.btn1011.Name = "btn1011";
            this.btn1011.Size = new System.Drawing.Size(75, 45);
            this.btn1011.TabIndex = 13;
            this.btn1011.Text = "10 - 11";
            this.btn1011.UseVisualStyleBackColor = true;
            this.btn1011.Click += btn1011_Click;
            // 
            // btn1516
            // 
            this.btn1516.Location = new System.Drawing.Point(5, 276);
            this.btn1516.Margin = new System.Windows.Forms.Padding(0);
            this.btn1516.Name = "btn1516";
            this.btn1516.Size = new System.Drawing.Size(75, 45);
            this.btn1516.TabIndex = 18;
            this.btn1516.Text = "15 - 16";
            this.btn1516.UseVisualStyleBackColor = true;
            this.btn1516.Click += btn1516_Click;
            // 
            // btn1112
            // 
            this.btn1112.Location = new System.Drawing.Point(5, 96);
            this.btn1112.Margin = new System.Windows.Forms.Padding(0);
            this.btn1112.Name = "btn1112";
            this.btn1112.Size = new System.Drawing.Size(75, 45);
            this.btn1112.TabIndex = 14;
            this.btn1112.Text = "11 - 12";
            this.btn1112.UseVisualStyleBackColor = true;
            this.btn1112.Click += btn1112_Click;
            // 
            // btn1415
            // 
            this.btn1415.Location = new System.Drawing.Point(5, 231);
            this.btn1415.Margin = new System.Windows.Forms.Padding(0);
            this.btn1415.Name = "btn1415";
            this.btn1415.Size = new System.Drawing.Size(75, 45);
            this.btn1415.TabIndex = 17;
            this.btn1415.Text = "14 - 15";
            this.btn1415.UseVisualStyleBackColor = true;
            this.btn1415.Click += btn1415_Click;
            // 
            // btn1213
            // 
            this.btn1213.Location = new System.Drawing.Point(5, 141);
            this.btn1213.Margin = new System.Windows.Forms.Padding(0);
            this.btn1213.Name = "btn1213";
            this.btn1213.Size = new System.Drawing.Size(75, 45);
            this.btn1213.TabIndex = 15;
            this.btn1213.Text = "12 - 13";
            this.btn1213.UseVisualStyleBackColor = true;
            this.btn1213.Click += btn1213_Click;
            // 
            // btn1314
            // 
            this.btn1314.Location = new System.Drawing.Point(5, 186);
            this.btn1314.Margin = new System.Windows.Forms.Padding(0);
            this.btn1314.Name = "btn1314";
            this.btn1314.Size = new System.Drawing.Size(75, 45);
            this.btn1314.TabIndex = 16;
            this.btn1314.Text = "13 - 14";
            this.btn1314.UseVisualStyleBackColor = true;
            this.btn1314.Click += btn1314_Click;
            // 
            // TimeSlotsControl
            // 
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.flpAppointments);
            this.Controls.Add(this.btn910);
            this.Controls.Add(this.btn1617);
            this.Controls.Add(this.btn1011);
            this.Controls.Add(this.btn1516);
            this.Controls.Add(this.btn1112);
            this.Controls.Add(this.btn1415);
            this.Controls.Add(this.btn1213);
            this.Controls.Add(this.btn1314);
            this.Name = "TimeSlotsControl";
            this.Size = new System.Drawing.Size(395, 377);
            this.ResumeLayout(false);
        }

        private void CalculateAvailableTimeSlots()
        {
            var resizableAppointments = FindControlsByName(flpAppointments, "ResizableAppointment");
            foreach (var control in resizableAppointments)
            {
                if (control is ResizableAppointment)
                {
                    int startTime = ((ResizableAppointment)control).CurrentStartTime();
                    int endTime = ((ResizableAppointment)control).CurrentEndTime();

                    RemoveTimeSlot(startTime, endTime);
                }
            }
        }

        private T FindControlByName<T>(string name) where T : Control
        {
            return Controls.OfType<T>().FirstOrDefault(c => c.Name == name);
        }

        private List<Control> FindControlsByName(Control container, string name)
        {
            return container.Controls
                .OfType<Control>()
                .Where(c => c.Name == name)
                .Concat(container.Controls.OfType<Control>().SelectMany(c => FindControlsByName(c, name)))
                .ToList();
        }

        private void RemoveTimeSlot(int currentStartTime, int endTime)
        {
            if (currentStartTime < endTime)
            {
                int timeSlot = Convert.ToInt32(currentStartTime.ToString() + (currentStartTime + 1).ToString());
                var item = _availableSlots.FirstOrDefault(c => c.Key == timeSlot);
                if (item.Value != null)
                {
                    Button buttonToDisable = FindControlByName<Button>(item.Value);
                    buttonToDisable.Enabled = false;
                    _takenSlots.Add(item.Key, item.Value);
                }

                _availableSlots.Remove(timeSlot);
                RemoveTimeSlot(currentStartTime + 1, endTime);
            }
        }

        private void ResetTimeSlot()
        {
            if (_takenSlots.Count > 0)
            {
                var resizableAppointments = FindControlsByName(flpAppointments, "ResizableAppointment");
                bool timeAvailable = true;
                Dictionary<int, string> itemsToAdd = new Dictionary<int, string>();
                foreach (KeyValuePair<int, string> timeSlot in _takenSlots)
                {
                    int startTime = 0;
                    int endTime = 0;
                    switch (timeSlot.Key)
                    {
                        case 910:
                            startTime = 9;
                            endTime = 9;
                            break;
                        case 1011:
                            startTime = 10;
                            endTime = 11;
                            break;
                        case 1112:
                            startTime = 11;
                            endTime = 12;
                            break;
                        case 1213:
                            startTime = 12;
                            endTime = 13;
                            break;
                        case 1314:
                            startTime = 13;
                            endTime = 14;
                            break;
                        case 1415:
                            startTime = 14;
                            endTime = 15;
                            break;
                        case 1516:
                            startTime = 15;
                            endTime = 16;
                            break;
                        case 1617:
                            startTime = 16;
                            endTime = 17;
                            break;
                    }
                    foreach (var control in resizableAppointments)
                    {
                        if (control is ResizableAppointment)
                        {
                            int usedStartTime = ((ResizableAppointment)control).CurrentStartTime();
                            int usedEndTime = ((ResizableAppointment)control).CurrentEndTime();

                            if (usedStartTime == startTime && usedEndTime == endTime)
                            {
                                timeAvailable = false;
                            }
                        }

                        if (timeAvailable == false)
                        {
                            break;
                        }
                    }

                    if (timeAvailable)
                    {
                        if (timeSlot.Key != 0)
                        {
                            itemsToAdd.Add(timeSlot.Key, timeSlot.Value);
                        }
                    }
                }
                foreach (KeyValuePair<int, string> keyValuePair in itemsToAdd)
                {
                    _takenSlots.Remove(keyValuePair.Key);
                    _availableSlots.Add(keyValuePair.Key, keyValuePair.Value);
                    Button buttonToDisable = FindControlByName<Button>(keyValuePair.Value);
                    buttonToDisable.Enabled = true;
                }
            }
        }

        private void SetTimeSlot(int startTime, int endTime)
        {
            CalculateAvailableTimeSlots();

            if (_availableSlots.Any(x => x.Key == Convert.ToInt32(startTime.ToString() + endTime.ToString())))
            {
                _startTime = startTime;
                _endTime = endTime;
                ResizableAppointment appointmentControl = new ResizableAppointment(startTime: _startTime, endTime: _endTime, 8, DeleteAppointment);

                appointmentControl.Location = new System.Drawing.Point(10, 10);
                appointmentControl.Width = 200;
                appointmentControl.EndTimeChanged += ResizableAppointment_EndTimeChanged;
                appointmentControl.BackColor = Color.White;

                flpAppointments.Controls.Add(appointmentControl);
                _startTime = _endTime;
                _endTime += 1;
            }
            else
            {
                MessageBox.Show("Time not available", "Appointment Taken", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            CalculateAvailableTimeSlots();
        }

        #endregion

    }
}
