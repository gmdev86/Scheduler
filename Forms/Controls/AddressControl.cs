using Scheduler.Core.Services;
using System;
using System.Data;
using System.Windows.Forms;
using Scheduler.Core.Localization;
using Scheduler.Core.Utility;
using Scheduler.Core.Models;

namespace Scheduler.Forms.Controls
{
    public partial class AddressControl : UserControl
    {
        #region Properties

        private DataService _dataService;
        private BindingSource _addressBindingSource;
        private Form dynamicForm;

        #endregion

        public AddressControl()
        {
            InitializeComponent();
        }

        private void AddressControl_Load(object sender, System.EventArgs e)
        {
            _dataService = DataService.Instance;
            InitializeDataBinding();
            LoadData();
        }

        private void InitializeDataBinding()
        {
            _addressBindingSource = new BindingSource();
            _addressBindingSource.DataSource = dgvAddress.DataSource;
            dgvAddress.DataSource = _addressBindingSource;
            dgvAddress.CellFormatting += dgvAddress_CellFormatting;
        }

        private void LoadData()
        {
            DataTable addressDataTable = _dataService.GetAllAddresses();
            _addressBindingSource.DataSource = addressDataTable;
            _addressBindingSource.ResetBindings(false);
        }

        private void dgvAddress_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DateTime)
            {
                DateTime originalDateTime = (DateTime)e.Value;
                DateTime convertedDateTime = DateTimeConverter.UtcToLocalDateTime(originalDateTime);
                e.Value = convertedDateTime;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenDynamicForm(new Address());
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvAddress.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvAddress.SelectedRows[0];
                DateTime.TryParse(selectedRow.Cells["createDate"].Value?.ToString(), out DateTime createDate);

                var address = new Address
                {
                    AddressId = (int)selectedRow.Cells["addressId"].Value,
                    AddressLine1 = (string)selectedRow.Cells["address"].Value,
                    AddressLine2 = (string)selectedRow.Cells["address2"].Value,
                    CityId = (int)selectedRow.Cells["cityId"].Value,
                    Phone = (string)selectedRow.Cells["phone"].Value,
                    PostalCode = (string)selectedRow.Cells["postalCode"].Value,
                    CreateDate = createDate,
                    CreatedBy = (string)selectedRow.Cells["createdBy"].Value,
                    LastUpdate = DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now),
                    LastUpdateBy = (string)selectedRow.Cells["lastUpdateBy"].Value
                };
                OpenDynamicForm(address);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAddress.SelectedRows.Count > 0)
            {
                if (Dialog.ShowDeleteConfirmation() == DialogResult.OK)
                {
                    DataGridViewRow selectedRow = dgvAddress.SelectedRows[0];
                    var addressId = (int)selectedRow.Cells["addressId"].Value;
                    try
                    {
                        _dataService.DeleteAddress(addressId);
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("CONSTRAINT"))
                        {
                            MessageBox.Show($"{Resources.AddressConstraintMessage}", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(Resources.SelectAddress, Resources.AddressNotSelected, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                _addressBindingSource.RemoveFilter();
            }
            else
            {
                int.TryParse(txtSearch.Text, out int searchValue);
                string filterExpression = $"addressId = {searchValue} OR address LIKE '%{txtSearch.Text}%'";
                _addressBindingSource.Filter = filterExpression;
            }

            dgvAddress.Refresh();
            if (dgvAddress.RowCount == 0)
            {
                MessageBox.Show(Resources.NoAddressesFound, Resources.NoResults, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OnDynamicClose(object sender, System.EventArgs e)
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Enabled = true;
            }
            dynamicForm?.Close();
        }

        private void OnDynamicSave(object sender, System.EventArgs e)
        {
            LoadData();
            if (this.ParentForm != null)
            {
                this.ParentForm.Enabled = true;
            }
            dynamicForm?.Close();
        }

        private void OpenDynamicForm(Address address)
        {
            dynamicForm = new Form();
            AddressModifyControl addressModifyControl = new AddressModifyControl(address);
            addressModifyControl.CancelClicked += OnDynamicClose;
            addressModifyControl.SaveClicked += OnDynamicSave;
            dynamicForm.Controls.Add(addressModifyControl);
            dynamicForm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            dynamicForm.AutoSize = true;
            dynamicForm.Text = Resources.AddAdress;
            dynamicForm.StartPosition = FormStartPosition.CenterScreen;
            dynamicForm.ControlBox = false;
            if (this.ParentForm != null)
            {
                this.ParentForm.Enabled = false;
            }
            dynamicForm.ShowDialog();
        }
    }
}
