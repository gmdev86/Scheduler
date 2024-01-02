using Scheduler.Core.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Scheduler.Core.Localization;
using Scheduler.Core.Utility;
using DateTimeConverter = Scheduler.Core.Utility.DateTimeConverter;
using Scheduler.Core.Interfaces;
using Scheduler.Core.Services;

namespace Scheduler.Forms.Controls
{
    public partial class AppointmentsControl : UserControl
    {
        public event EventHandler CancelClicked;
        public event EventHandler DeleteClicked;
        private BindingList<Appointment> _appointments;
        private BindingList<Appointment> _originalAppointments;
        private BindingSource _appointmentsBindingSource;
        private IDataService _dataService;

        public AppointmentsControl()
        {
            InitializeComponent();
            _appointments = new BindingList<Appointment>();
            _originalAppointments = new BindingList<Appointment>();
            _dataService = new DataService();
        }

        public AppointmentsControl(BindingList<Appointment> appointments)
        {
            InitializeComponent();
            _dataService = new DataService();
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
    }
}
