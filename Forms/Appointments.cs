using System;
using Scheduler.Core.Models;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using Scheduler.Core.Services;
using System.Text;
using Scheduler.Core.Enums;
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
        private DataService _dataService;
        private BindingList<Appointment> _appointments;
        public event EventHandler AppointmentsSaved;
        private UserSession _userSession;

        public Appointments()
        {
            InitializeComponent();
            _dataService = DataService.Instance;
            _userListItems = new BindingList<SelectListItem>();
            _customerListItems = new BindingList<SelectListItem>();
            _userListItems = _dataService.LoadItems("user");
            _customerListItems = _dataService.LoadItems("customer");
            _userSession = UserSession.Instance;
        }

        public Appointments(int year, int month, int day, BindingList<Appointment> appointments)
        {
            InitializeComponent();
            _userSession = UserSession.Instance;
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
                            DateTime startTime = new DateTime(Year, Month, Day, appointmentTime.StartTime, 0, 0);
                            DateTime endTime = new DateTime(Year, Month, Day, appointmentTime.EndTime, 0, 0);
                            Appointment appointment = new Appointment
                            {
                                UserId = userId ?? 0,
                                CustomerId = customerId ?? 0,
                                Contact = txtContact.Text,
                                Description = txtDescription.Text,
                                Location = txtLocation.Text,
                                Title = txtTitle.Text,
                                Type = cbType.SelectedItem as string,
                                Url = txtUrl.Text,
                                Start = Core.Utility.DateTimeConverter.DateTimeOffsetToUtc(startTime),
                                End = Core.Utility.DateTimeConverter.DateTimeOffsetToUtc(endTime),
                                CreateDate = Core.Utility.DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now),
                                CreatedBy = _userSession.User.UserName,
                                LastUpdate = Core.Utility.DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now),
                                LastUpdateBy = _userSession.User.UserName
                            };
                            _dataService.CreateAppointment(appointment);
                        }
                        MessageBox.Show(Resources.AppointmentsAddedSuccess);
                        AppointmentsSaved?.Invoke(this, EventArgs.Empty);
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

            cbType.Items.Add(string.Empty);
            foreach (AppointmentType appointmentType in Enum.GetValues(typeof(AppointmentType)))
            {
                cbType.Items.Add(appointmentType.ToString());
            }
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

            if (string.IsNullOrWhiteSpace(cbType.SelectedItem as string))
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
