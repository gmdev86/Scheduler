using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Scheduler.Core.Localization;
using Scheduler.Core.Models;
using Scheduler.Core.Services;
using Scheduler.Forms.Controls;

namespace Scheduler.Forms
{
    public partial class CustomerAdministration : Form
    {
        private Form dynamicForm;
        private BindingList<SelectListItem> _addressListItems;
        private DataService _dataService;
        private Customer _customer;
        private UserSession _userSession;

        public CustomerAdministration(Customer customer)
        {
            InitializeComponent();
            _dataService = DataService.Instance;
            _addressListItems = new BindingList<SelectListItem>();
            LoadAddresses();
            _customer = customer;
            _userSession = UserSession.Instance;
        }

        private void btnAddAddress_Click(object sender, System.EventArgs e)
        {
            dynamicForm = new Form();
            AddressModifyControl addressModifyControl = new AddressModifyControl(new Address());
            addressModifyControl.CancelClicked += OnDynamicClose;
            addressModifyControl.SaveClicked += OnDynamicSave;
            dynamicForm.Controls.Add(addressModifyControl);
            dynamicForm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            dynamicForm.AutoSize = true;
            dynamicForm.Text = Resources.AddAdress;
            dynamicForm.StartPosition = FormStartPosition.CenterScreen;
            dynamicForm.ControlBox = false;
            Enabled = false;
            dynamicForm.ShowDialog();
        }

        private void OnDynamicClose(object sender, System.EventArgs e)
        {
            Enabled = true;
            dynamicForm?.Close();
        }

        private void OnDynamicSave(object sender, System.EventArgs e)
        {
            ReloadAddresses();
            Enabled = true;
            dynamicForm?.Close();
        }

        private void CustomerAdministration_Load(object sender, System.EventArgs e)
        {
            pnlValidationErrors.Visible = false;
            lblValidationErrors.Text = String.Empty;
            LoadAddressComboBox();
            if (_customer.CustomerId > 0)
            {
                txtCustomerName.Text = _customer.CustomerName;
                cbActive.Checked = _customer.IsActive;
                var itemToSelect = _addressListItems.FirstOrDefault(x => x.Id == _customer.AddressId);
                if (itemToSelect != null)
                {
                    cbAddress.SelectedItem = itemToSelect;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadAddresses()
        {
            _addressListItems = _dataService.LoadItems("address");
        }

        private void ReloadAddresses()
        {
            _addressListItems.Clear();
            var addresses = _dataService.LoadItems("address");
            foreach (var address in addresses)
            {
                _addressListItems.Add(address);
            }
        }

        private void LoadAddressComboBox()
        {
            cbAddress.DataSource = _addressListItems;
            cbAddress.DisplayMember = "Value";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                var addressId = 0;
                if (cbAddress.SelectedItem != null)
                {
                    addressId = (cbAddress.SelectedItem as SelectListItem).Id;
                }

                _customer.CustomerName = txtCustomerName.Text;
                _customer.AddressId = addressId;
                _customer.IsActive = cbActive.Checked;
                _customer.CreateDate = _customer.CreateDate == DateTime.MinValue ? Core.Utility.DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now) : _customer.CreateDate;
                _customer.CreatedBy = string.IsNullOrWhiteSpace(_customer.CreatedBy) ? _userSession.User.UserName : _customer.CreatedBy; 
                _customer.LastUpdate = Core.Utility.DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now);
                _customer.LastUpdateBy = _userSession.User.UserName; 

                try
                {
                    if (_customer.CustomerId == 0)
                    {
                        _dataService.CreateCustomer(_customer);
                        MessageBox.Show(Resources.CustomerAddedSuccess);
                    }
                    else
                    {
                        _dataService.UpdateCustomer(_customer);
                        MessageBox.Show(Resources.CustomerUpdatedSuccess);
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Resources.FailedToSave, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsValid()
        {
            StringBuilder sb = new StringBuilder();
            bool isValid = true;
            pnlValidationErrors.Visible = false;
            lblValidationErrors.Text = string.Empty;

            if (string.IsNullOrEmpty(txtCustomerName.Text))
            {
                sb.AppendLine(Resources.CustomerNameRequired);
                isValid = false;
            }

            if (txtCustomerName.Text.Length > 45)
            {
                sb.AppendLine(Resources.CustomerNameMax);
                isValid = false;
            }

            if (!(cbAddress.SelectedItem is SelectListItem))
            {
                sb.AppendLine(Resources.AddressRequired);
                isValid = false;
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
