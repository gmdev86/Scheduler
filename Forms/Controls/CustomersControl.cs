using System;
using System.Data;
using System.Windows.Forms;
using Scheduler.Core.Interfaces;
using Scheduler.Core.Models;
using Scheduler.Core.Services;
using Scheduler.Core.Utility;

namespace Scheduler.Forms.Controls
{
    public partial class CustomersControl : UserControl
    {
        #region Properties

        private IDataService _dataService;
        private BindingSource _customersBindingSource;

        #endregion

        public CustomersControl()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            DataTable customerDataTable = _dataService.GetAllCustomers();
            _customersBindingSource.DataSource = customerDataTable;
            _customersBindingSource.ResetBindings(false);
        }

        private void InitializeDataBinding()
        {
            _customersBindingSource = new BindingSource();
            _customersBindingSource.DataSource = dgvCustomers.DataSource;
            dgvCustomers.DataSource = _customersBindingSource;
            dgvCustomers.CellFormatting += dgvCustomers_CellFormatting;
        }

        private void CustomersControl_Load(object sender, EventArgs e)
        {
            _dataService = new DataService();
            InitializeDataBinding();
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CustomerAdministration customerAdministration = new CustomerAdministration(new Customer());
            customerAdministration.ControlBox = false;
            if (this.ParentForm != null)
            {
                this.ParentForm.Enabled = false;
            }
            customerAdministration.FormClosing += CustomerAdministration_Closing;
            customerAdministration.Show();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void CustomerAdministration_Closing(object sender, EventArgs e)
        {
            LoadData();
            if (this.ParentForm != null)
            {
                this.ParentForm.Enabled = true;
            }
        }

        private void dgvCustomers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
