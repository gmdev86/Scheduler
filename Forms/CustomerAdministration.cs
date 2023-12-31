using System;
using System.ComponentModel;
using System.Windows.Forms;
using Scheduler.Core.Interfaces;
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
        private IDataService _dataService;

        public CustomerAdministration()
        {
            InitializeComponent();
            _dataService = new DataService();
            _addressListItems = new BindingList<SelectListItem>();
            LoadAddresses();
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

        }
    }
}
