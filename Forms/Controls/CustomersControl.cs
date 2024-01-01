using System;
using System.Data;
using System.Windows.Forms;
using Scheduler.Core.Interfaces;
using Scheduler.Core.Localization;
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
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                _customersBindingSource.RemoveFilter();
            }
            else
            {
                int.TryParse(txtSearch.Text, out int searchValue);
                string filterExpression = $"customerId = {searchValue} OR customerName LIKE '%{txtSearch.Text}%'";
                _customersBindingSource.Filter = filterExpression;
            }

            dgvCustomers.Refresh();
            if (dgvCustomers.RowCount == 0)
            {
                MessageBox.Show(Resources.NoCustomerFound, Resources.NoResults, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CustomerAdministration customerAdministration = new CustomerAdministration(new Customer());
            customerAdministration.ControlBox = false;
            customerAdministration.FormClosing += CustomerAdministration_Closing;
            if (this.ParentForm != null)
            {
                this.ParentForm.Enabled = false;
            }
            customerAdministration.Show();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCustomers.SelectedRows[0];
                DateTime.TryParse(selectedRow.Cells["createDate"].Value?.ToString(), out DateTime createDate);
                var isActive = (bool)selectedRow.Cells["active"].Value;

                var customer = new Customer
                {
                    CustomerId = (int)selectedRow.Cells["customerId"].Value,
                    CustomerName = (string)selectedRow.Cells["customerName"].Value,
                    AddressId = (int)selectedRow.Cells["addressId"].Value,
                    IsActive = isActive,
                    CreateDate = createDate,
                    CreatedBy = (string)selectedRow.Cells["createdBy"].Value,
                    LastUpdate = DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now),
                    LastUpdateBy = (string)selectedRow.Cells["lastUpdateBy"].Value
                };

                CustomerAdministration customerAdministration = new CustomerAdministration(customer);
                customerAdministration.ControlBox = false;
                customerAdministration.FormClosing += CustomerAdministration_Closing;
                if (this.ParentForm != null)
                {
                    this.ParentForm.Enabled = false;
                }
                customerAdministration.Show();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                if (Dialog.ShowDeleteConfirmation() == DialogResult.OK)
                {
                    DataGridViewRow selectedRow = dgvCustomers.SelectedRows[0];
                    var customerId = (int)selectedRow.Cells["customerId"].Value;
                    try
                    {
                        _dataService.DeleteCustomer(customerId);
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("CONSTRAINT"))
                        {
                            MessageBox.Show($"{Resources.CustomerConstraintMessage}", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show($"{Resources.Error}: {ex.Message}", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(Resources.SelectCustomer, Resources.CustomerNotSelected, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
