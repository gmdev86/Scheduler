using Scheduler.Core.Models;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Scheduler.Core.Localization;
using System.Data;

namespace Scheduler.Forms.Controls
{
    public partial class AppointmentsControl : UserControl
    {
        public event EventHandler CancelClicked;
        public event EventHandler DeleteClicked;
        private BindingList<Appointment> _appointments;
        private BindingSource _appointmentsBindingSource;

        public AppointmentsControl()
        {
            InitializeComponent();
            _appointments = new BindingList<Appointment>();
        }

        public AppointmentsControl(BindingList<Appointment> appointments)
        {
            InitializeComponent();
            if (appointments == null)
            {
                appointments = new BindingList<Appointment>();
            }
            _appointments = appointments;
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
            dgvAppointments.DataSource = dgvAppointments;
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
                _appointmentsBindingSource.RemoveFilter();
            }
            else
            {
                int.TryParse(txtSearch.Text, out int searchValue);
                string filterExpression = $"appointmentId = {searchValue} OR title LIKE '%{txtSearch.Text}%'";
                _appointmentsBindingSource.Filter = filterExpression;
            }

            dgvAppointments.Refresh();
            if (dgvAppointments.RowCount == 0)
            {
                MessageBox.Show(Resources.NoResults, Resources.NoResults, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteClicked?.Invoke(this, EventArgs.Empty);
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
