using Scheduler.Core.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Scheduler.Core.Localization;
using Scheduler.Core.Utility;
using DateTimeConverter = Scheduler.Core.Utility.DateTimeConverter;
using Scheduler.Core.Services;

namespace Scheduler.Forms.Controls
{
    public partial class AppointmentsControl : UserControl
    {
        public event EventHandler CancelClicked;
        public event EventHandler DeleteClicked;
        public event EventHandler AppointmentUpdated;
        private BindingList<Appointment> _appointments;
        private BindingList<Appointment> _originalAppointments;
        private BindingSource _appointmentsBindingSource;
        private DataService _dataService;
        private Form dynamicForm;

        public AppointmentsControl()
        {
            InitializeComponent();
            _appointments = new BindingList<Appointment>();
            _originalAppointments = new BindingList<Appointment>();
            _dataService = DataService.Instance;
        }

        public AppointmentsControl(BindingList<Appointment> appointments)
        {
            InitializeComponent();
            _dataService = DataService.Instance;
            if (appointments == null)
            {
                appointments = new BindingList<Appointment>();
            }
            _appointments = appointments;
            _originalAppointments = new BindingList<Appointment>(_appointments);
        }

        private void AppointmentsControl_Load(object sender, EventArgs e)
        {
            InitializeDataBinding();
            LoadData();
        }

        private void InitializeDataBinding()
        {
            _appointmentsBindingSource = new BindingSource();
            _appointmentsBindingSource.DataSource = dgvAppointments.DataSource;
            dgvAppointments.DataSource = _appointmentsBindingSource;
            dgvAppointments.CellFormatting += dgvAppointments_CellFormatting;
        }

        private void LoadData()
        {
            _appointmentsBindingSource.DataSource = _appointments;
            _appointmentsBindingSource.ResetBindings(false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                _appointments = new BindingList<Appointment>(_originalAppointments);
            }
            else
            {
                int.TryParse(txtSearch.Text, out int searchValue);
                var filter = _appointments
                    .Where(x => x.AppointmentId == searchValue || x.Title.Contains(txtSearch.Text)).ToList();
                _appointments = new BindingList<Appointment>(filter);
            }

            LoadData();
            dgvAppointments.Refresh();
            if (dgvAppointments.RowCount == 0)
            {
                MessageBox.Show(Resources.NoResults, Resources.NoResults, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count > 0)
            {
                if (Dialog.ShowDeleteConfirmation() == DialogResult.OK)
                {
                    DataGridViewRow selectedRow = dgvAppointments.SelectedRows[0];
                    var appointmentId = (int)selectedRow.Cells["AppointmentId"].Value;
                    try
                    {
                        _dataService.DeleteAppointment(appointmentId);
                        DeleteClicked?.Invoke(this, EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{Resources.Error}: {ex.Message}", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(Resources.SelectAppointment, Resources.AppointmentNotSelected, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }

        private void dgvAppointments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DateTime)
            {
                DateTime originalDateTime = (DateTime)e.Value;
                DateTime convertedDateTime = DateTimeConverter.UtcToLocalDateTime(originalDateTime);
                e.Value = convertedDateTime;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvAppointments.SelectedRows[0];

                try
                {
                    Appointment appointment = new Appointment
                    {
                        AppointmentId = (int)selectedRow.Cells["AppointmentId"].Value,
                        CustomerId = (int)selectedRow.Cells["CustomerId"].Value,
                        UserId = (int)selectedRow.Cells["UserId"].Value,
                        Title = (string)selectedRow.Cells["Title"].Value,
                        Description = (string)selectedRow.Cells["Description"].Value,
                        Contact = (string)selectedRow.Cells["Contact"].Value,
                        Location = (string)selectedRow.Cells["Location"].Value,
                        Type = (string)selectedRow.Cells["Type"].Value,
                        Url = (string)selectedRow.Cells["Url"].Value,
                        Start = (DateTime)selectedRow.Cells["Start"].Value,
                        End = (DateTime)selectedRow.Cells["End"].Value,
                        CreatedBy = (string)selectedRow.Cells["CreatedBy"].Value,
                        CreateDate = (DateTime)selectedRow.Cells["CreateDate"].Value,
                        LastUpdateBy = (string)selectedRow.Cells["LastUpdateBy"].Value,
                        LastUpdate = (DateTime)selectedRow.Cells["LastUpdate"].Value
                    };
                    dynamicForm = new Form();
                    AppointmentModifyControl appointmentModifyControl =
                        new AppointmentModifyControl(appointment, _appointments);
                    appointmentModifyControl.CancelClicked += Dynamic_FormCanceled;
                    appointmentModifyControl.SaveClicked += Dynamic_FormSaved;
                    dynamicForm.Controls.Add(appointmentModifyControl);
                    dynamicForm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    dynamicForm.AutoSize = true;
                    dynamicForm.Text = Resources.AppointmentAdministration;
                    dynamicForm.StartPosition = FormStartPosition.CenterScreen;
                    dynamicForm.ControlBox = false;
                    if (this.ParentForm != null)
                    {
                        this.ParentForm.Enabled = false;
                    }
                    dynamicForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{Resources.Error}: {ex.Message}", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(Resources.SelectAppointment, Resources.AppointmentNotSelected, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Dynamic_FormCanceled(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Enabled = true;
            }
            dynamicForm?.Close();
        }

        private void Dynamic_FormSaved(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Enabled = true;
            }
            dynamicForm?.Close();
            DateTime day = _appointments[0].Start.Date;
            _appointments = _dataService.GetAllAppointments();
            var updatedList = _appointments.Where(x => x.Start.Date == day.Date).ToList();
            _appointments = new BindingList<Appointment>(updatedList);
            LoadData();
            AppointmentUpdated?.Invoke(sender, e);
        }
    }
}
