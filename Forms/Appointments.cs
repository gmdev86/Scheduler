using System;
using Scheduler.Core.Interfaces;
using Scheduler.Core.Models;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using Scheduler.Core.Services;
using System.Collections.Generic;
using System.Text;
using Scheduler.Core.Localization;

namespace Scheduler.Forms
{
    public partial class Appointments : Form
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        private BindingList<SelectListItem> _userListItems;
        private BindingList<SelectListItem> _customerListItems;
        private IDataService _dataService;
        private BindingList<Appointment> _appointments;

        public Appointments()
        {
            InitializeComponent();
            _dataService = new DataService();
            _userListItems = new BindingList<SelectListItem>();
            _customerListItems = new BindingList<SelectListItem>();
            _userListItems = _dataService.LoadItems("user");
            _customerListItems = _dataService.LoadItems("customer");
        }

        public Appointments(int year, int month, int day, BindingList<Appointment> appointments)
        {
            InitializeComponent();
            _appointments = appointments;
            Year = year;
            Month = month;
            Day = day;
            lblHeader.Text = $"{DateTimeFormatInfo.CurrentInfo.GetMonthName(Month)}, {Day} {Year}";
            timeSlotsControl.Year = Year;
            timeSlotsControl.Month = Month;
            timeSlotsControl.Day = Day;
            _dataService = new DataService();
            _userListItems = new BindingList<SelectListItem>();
            _customerListItems = new BindingList<SelectListItem>();
            _userListItems = _dataService.LoadItems("user", true);
            _userListItems.Insert(0, new SelectListItem());
            _customerListItems = _dataService.LoadItems("customer", true);
            _customerListItems.Insert(0, new SelectListItem());

            foreach (Appointment appointment in _appointments)
            {
                var startTime = Core.Utility.DateTimeConverter.UtcToLocalDateTime(appointment.Start).Hour;
                var endTime = Core.Utility.DateTimeConverter.UtcToLocalDateTime(appointment.End).Hour;
                timeSlotsControl.SetTimeSlot(startTime, endTime, false);
            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (IsValid())
            {
                var appointmentTimes = timeSlotsControl.AppointmentTimes;
                if (appointmentTimes.Count == 0)
                {
                    MessageBox.Show("Please select appointment times");
                }
                else
                {
                    try
                    {
                        var selectedIndex = cbUser.SelectedIndex;
                        int? userId = null;
                        int? customerId = null;
                        if (selectedIndex > 0)
                        {
                            userId = (cbUser.Items[selectedIndex] as SelectListItem).Id;
                        }
                        selectedIndex = cbCustomer.SelectedIndex;
                        if (selectedIndex > 0)
                        {
                            customerId = (cbCustomer.Items[selectedIndex] as SelectListItem).Id;
                        }

                        foreach (AppointmentTime appointmentTime in appointmentTimes)
                        {
                            DateTime startTime = DateTime.Now.Date.Add(new TimeSpan(appointmentTime.StartTime, 0, 0));
                            DateTime endTime = DateTime.Now.Date.Add(new TimeSpan(appointmentTime.EndTime, 0, 0));
                            Appointment appointment = new Appointment
                            {
                                UserId = userId ?? 0,
                                CustomerId = customerId ?? 0,
                                Contact = txtContact.Text,
                                Description = txtDescription.Text,
                                Location = txtLocation.Text,
                                Title = txtTitle.Text,
                                Type = txtType.Text,
                                Url = txtUrl.Text,
                                Start = Core.Utility.DateTimeConverter.DateTimeOffsetToUtc(startTime),
                                End = Core.Utility.DateTimeConverter.DateTimeOffsetToUtc(endTime),
                                CreateDate = Core.Utility.DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now),
                                CreatedBy = "System", //todo: make sure to update to logged in user
                                LastUpdate = Core.Utility.DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now),
                                LastUpdateBy = "System" //todo: make sure to update to logged in user
                            };
                            _dataService.CreateAppointment(appointment);
                        }
                        MessageBox.Show(Resources.AppointmentsAddedSuccess);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Resources.FailedToSave, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Appointments_Load(object sender, System.EventArgs e)
        {
            pnlValidationErrors.Visible = false;
            lblValidationErrors.Text = string.Empty;
            cbUser.DataSource = _userListItems;
            cbUser.DisplayMember = "Value";
            cbCustomer.DataSource = _customerListItems;
            cbCustomer.DisplayMember = "Value";
        }

        private bool IsValid()
        {
            StringBuilder sb = new StringBuilder();
            bool isValid = true;
            pnlValidationErrors.Visible = false;
            lblValidationErrors.Text = string.Empty;

            if ((cbCustomer.Items[cbCustomer.SelectedIndex] as SelectListItem).Id == 0)
            {
                isValid = false;
                sb.AppendLine(Resources.CustomerRequired);
            }

            if ((cbUser.Items[cbUser.SelectedIndex] as SelectListItem).Id == 0)
            {
                isValid = false;
                sb.AppendLine(Resources.UserRequired);
            }

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                isValid = false;
                sb.AppendLine(Resources.TitleRequired);
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                isValid = false;
                sb.AppendLine(Resources.DescriptionRequired);
            }

            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                isValid = false;
                sb.AppendLine(Resources.LocationRequired);
            }

            if (string.IsNullOrWhiteSpace(txtContact.Text))
            {
                isValid = false;
                sb.AppendLine(Resources.ContactRequired);
            }

            if (string.IsNullOrWhiteSpace(txtType.Text))
            {
                isValid = false;
                sb.AppendLine(Resources.TypeRequired);
            }

            if (string.IsNullOrWhiteSpace(txtUrl.Text))
            {
                isValid = false;
                sb.AppendLine(Resources.UrlRequired);
            }

            if (!isValid)
            {
                pnlValidationErrors.Visible = true;
                lblValidationErrors.Text = sb.ToString();
            }

            return isValid;
        }
    }
}
