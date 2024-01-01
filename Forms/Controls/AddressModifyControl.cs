﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Scheduler.Core.Interfaces;
using Scheduler.Core.Localization;
using Scheduler.Core.Models;
using Scheduler.Core.Services;

namespace Scheduler.Forms.Controls
{
    public partial class AddressModifyControl : UserControl
    {
        public event EventHandler CancelClicked;
        public event EventHandler SaveClicked;
        private Form dynamicForm;
        private BindingList<SelectListItem> _cityListItems;
        private IDataService _dataService;
        private Address _address;

        public AddressModifyControl(Address address)
        {
            InitializeComponent();
            _dataService = new DataService();
            _cityListItems = new BindingList<SelectListItem>();
            LoadCities();
            _address = address;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnAddCity_Click(object sender, EventArgs e)
        {
            dynamicForm = new Form();
            CityModifyControl cityModifyControl = new CityModifyControl(new City());
            cityModifyControl.CancelClicked += OnDynamicClose;
            cityModifyControl.SaveClicked += OnDynamicSave;
            dynamicForm.Controls.Add(cityModifyControl);
            dynamicForm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            dynamicForm.AutoSize = true;
            dynamicForm.Text = Resources.AddCity;
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
            ReloadCities();
            Enabled = true;
            dynamicForm?.Close();
        }

        private void AddressModifyControl_Load(object sender, EventArgs e)
        {
            pnlValidationErrors.Visible = false;
            lblValidationErrors.Text = string.Empty;
            LoadCityComboBox();
            if (_address.AddressId > 0)
            {
                txtAddress.Text = _address.AddressLine1;
                txtAddress2.Text = _address.AddressLine2;
                var itemToSelect = _cityListItems.FirstOrDefault(x => x.Id == _address.CityId);
                if (itemToSelect != null)
                {
                    cbCity.SelectedItem = itemToSelect;
                }
                txtPostalCode.Text = _address.PostalCode;
                txtPhoneNumber.Text = _address.Phone;
            }
        }

        private void LoadCities()
        {
            _cityListItems = _dataService.LoadItems("city");
        }

        private void ReloadCities()
        {
            _cityListItems.Clear();
            var cities = _dataService.LoadItems("city");
            foreach (var city in cities)
            {
                _cityListItems.Add(city);
            }
        }

        private void LoadCityComboBox()
        {
            cbCity.DataSource = _cityListItems;
            cbCity.DisplayMember = "Value";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                var cityId = 0;
                if (cbCity.SelectedItem != null)
                {
                    cityId = (cbCity.SelectedItem as SelectListItem).Id;
                }

                _address.AddressLine1 = txtAddress.Text;
                _address.AddressLine2 = txtAddress2.Text.Length == 0 ? string.Empty : txtAddress2.Text;
                _address.CityId = cityId;
                _address.PostalCode = txtPostalCode.Text;
                _address.Phone = txtPhoneNumber.Text;
                _address.CreateDate = _address.CreateDate == DateTime.MinValue ? Core.Utility.DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now) : _address.CreateDate;
                _address.CreatedBy = "System"; //todo: make sure to update to logged in user
                _address.LastUpdate = Core.Utility.DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now);
                _address.LastUpdateBy = "System"; //todo: make sure to update to logged in user

                try
                {
                    if (_address.AddressId == 0)
                    {
                        _dataService.CreateAddress(_address);
                        MessageBox.Show(Resources.AddressAddedSuccess);
                    }
                    else
                    {
                        _dataService.UpdateAddress(_address);
                        MessageBox.Show(Resources.AddressUpdatedSuccess);
                    }
                    SaveClicked?.Invoke(this, EventArgs.Empty);
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

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                sb.AppendLine(Resources.AddressRequired);
                isValid = false;
            }

            if (txtAddress.Text.Length > 50)
            {
                sb.AppendLine(Resources.AddressMax);
                isValid = false;
            }

            if (txtAddress2.Text.Length > 50)
            {
                sb.AppendLine(Resources.Address2Max);
                isValid = false;
            }

            if (!(cbCity.SelectedItem is SelectListItem))
            {
                sb.AppendLine(Resources.CityRequired);
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtPostalCode.Text))
            {
                sb.AppendLine(Resources.PostalCodeRequired);
                isValid = false;
            }

            if (txtPostalCode.Text.Length > 10)
            {
                sb.AppendLine(Resources.PostalCodeMax);
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                sb.AppendLine(Resources.PhoneRequired);
                isValid = false;
            }

            if (txtPhoneNumber.Text.Length > 20)
            {
                sb.AppendLine(Resources.PhoneMax);
                isValid = false;
            }

            if (!txtPhoneNumber.IsTextValid)
            {
                sb.AppendLine(Resources.PhoneInvalidFormat);
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
