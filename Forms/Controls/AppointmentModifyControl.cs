using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Scheduler.Core.Enums;
using Scheduler.Core.Localization;
using Scheduler.Core.Models;
using Scheduler.Core.Services;

namespace Scheduler.Forms.Controls
{
    public partial class AppointmentModifyControl : UserControl
    {
        public event EventHandler SaveClicked;
        public event EventHandler CancelClicked;
        private DataService _dataService;
        private UserSession _userSession;
        private BindingList<SelectListItem> _userListItems;
        private BindingList<SelectListItem> _customerListItems;
        private BindingList<SelectListItem> _timeListItems;
        private Appointment _appointment;
        private List<SelectListItem> _allTimes = new List<SelectListItem>
        {
            new SelectListItem{Id = 910, Value = "9 - 10"},
            new SelectListItem{Id = 1011, Value = "10 - 11"},
            new SelectListItem{Id = 1112, Value = "11 - 12"},
            new SelectListItem{Id = 1213, Value = "12 - 13"},
            new SelectListItem{Id = 1314, Value = "13 - 14"},
            new SelectListItem{Id = 1415, Value = "14 - 15"},
            new SelectListItem{Id = 1516, Value = "15 - 16"},
            new SelectListItem{Id = 1617, Value = "16 - 17"},
        };

        public AppointmentModifyControl(Appointment appointment, BindingList<Appointment> appointments)
        {
            InitializeComponent();
            _dataService = DataService.Instance;
            _userSession = UserSession.Instance;
            _userListItems = new BindingList<SelectListItem>();
            _customerListItems = new BindingList<SelectListItem>();
            _userListItems = _dataService.LoadItems("user", true);
            _userListItems.Insert(0, new SelectListItem());
            _customerListItems = _dataService.LoadItems("customer", true);
            _customerListItems.Insert(0, new SelectListItem());
            _appointment = appointment;

            foreach (Appointment appointment1 in appointments)
            {
                if (appointment1.AppointmentId != appointment.AppointmentId)
                {
                    var start = Core.Utility.DateTimeConverter.UtcToLocalDateTime(appointment1.Start);
                    var end = Core.Utility.DateTimeConverter.UtcToLocalDateTime(appointment1.End);
                    int timeSlot = Convert.ToInt32(start.Hour.ToString() + end.Hour.ToString());
                    _allTimes.Remove(_allTimes.FirstOrDefault(x => x.Id == timeSlot));
                }
            }

            _timeListItems = new BindingList<SelectListItem>(_allTimes);
            cbTime.DataSource = _timeListItems;
            cbTime.DisplayMember = "Value";
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

            int typeIndex = cbType.FindString(appointment.Type);
            cbType.SelectedIndex = typeIndex;

            for (int i = 0; i < cbUser.Items.Count; i++)
            {
                if (cbUser.Items[i] is SelectListItem item)
                {
                    if (item.Id == appointment.UserId)
                    {
                        cbUser.SelectedIndex = i;
                    }
                }
            }

            for (int i = 0; i < cbCustomer.Items.Count; i++)
            {
                if (cbCustomer.Items[i] is SelectListItem item)
                {
                    if (item.Id == appointment.CustomerId)
                    {
                        cbCustomer.SelectedIndex = i;
                    }
                }
            }

            for (int i = 0; i < cbTime.Items.Count; i++)
            {
                if (cbTime.Items[i] is SelectListItem item)
                {
                    var currentStart = Core.Utility.DateTimeConverter.UtcToLocalDateTime(appointment.Start);
                    var currentEnd = Core.Utility.DateTimeConverter.UtcToLocalDateTime(appointment.End);
                    if (item.Id == Convert.ToInt32(currentStart.Hour.ToString() + currentEnd.Hour.ToString()))
                    {
                        cbTime.SelectedIndex = i;
                    }
                }
            }

            txtTitle.Text = appointment.Title;
            txtDescription.Text = appointment.Description;
            txtLocation.Text = appointment.Location;
            txtContact.Text = appointment.Contact;
            txtUrl.Text = appointment.Url;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                var selectedIndex = cbUser.SelectedIndex;
                int? userId = null;
                int? customerId = null;
                int? time = null;
                if (selectedIndex > 0)
                {
                    userId = (cbUser.Items[selectedIndex] as SelectListItem).Id;
                }
                selectedIndex = cbCustomer.SelectedIndex;
                if (selectedIndex > 0)
                {
                    customerId = (cbCustomer.Items[selectedIndex] as SelectListItem).Id;
                }

                selectedIndex = cbTime.SelectedIndex;
                int _startTime = 0;
                int _endTime = 0;
                if (selectedIndex > 0)
                {
                    time = (cbTime.Items[selectedIndex] as SelectListItem).Id;
                    
                    switch (time)
                    {
                        case 910:
                            _startTime = 9;
                            _endTime = 10;
                            break;
                        case 1011:
                            _startTime = 10;
                            _endTime = 11;
                            break;
                        case 1112:
                            _startTime = 11;
                            _endTime = 12;
                            break;
                        case 1213:
                            _startTime = 12;
                            _endTime = 13;
                            break;
                        case 1314:
                            _startTime = 13;
                            _endTime = 14;
                            break;
                        case 1415:
                            _startTime = 14;
                            _endTime = 15;
                            break;
                        case 1516:
                            _startTime = 15;
                            _endTime = 16;
                            break;
                        case 1617:
                            _startTime = 16;
                            _endTime = 17;
                            break;
                    }
                }

                DateTime startTime = new DateTime(_appointment.Start.Year, _appointment.Start.Month, _appointment.Start.Day, _startTime, 0, 0);
                DateTime endTime = new DateTime(_appointment.Start.Year, _appointment.Start.Month, _appointment.Start.Day, _endTime, 0, 0);
                Appointment appointment = new Appointment
                {
                    AppointmentId = _appointment.AppointmentId,
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
                _dataService.UpdateAppointment(appointment);
                MessageBox.Show(Resources.AppointmentUpdated);
                SaveClicked?.Invoke(sender, e);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(sender, e);
        }

        private bool IsValid()
        {
            StringBuilder sb = new StringBuilder();
            bool isValid = true;
            pnlValidationErrors.Visible = false;
            lblValidationErrors.Text = string.Empty;

            if (cbCustomer.SelectedIndex == -1 || (cbCustomer.Items[cbCustomer.SelectedIndex] as SelectListItem).Id == 0)
            {
                isValid = false;
                sb.AppendLine(Resources.CustomerRequired);
            }

            if (cbUser.SelectedIndex == -1 || (cbUser.Items[cbUser.SelectedIndex] as SelectListItem).Id == 0)
            {
                isValid = false;
                sb.AppendLine(Resources.UserRequired);
            }

            if (cbTime.SelectedIndex == -1 || (cbTime.Items[cbTime.SelectedIndex] as SelectListItem).Id == 0)
            {
                isValid = false;
                sb.AppendLine(Resources.TimeRequired);
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
