using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Scheduler.Core.Localization;
using Scheduler.Core.Models;
using Scheduler.Core.Services;
using Scheduler.Core.Utility;

namespace Scheduler.Forms.Controls
{
    public partial class AddressModifyControl : UserControl
    {
        public event EventHandler CancelClicked;
        public event EventHandler SaveClicked;
        private Form dynamicForm;
        private BindingList<SelectListItem> _cityListItems;
        private DataService _dataService;
        private Address _address;
        private UserSession _userSession;

        public AddressModifyControl(Address address)
        {
            InitializeComponent();
            _dataService = DataService.Instance;
            _cityListItems = new BindingList<SelectListItem>();
            LoadCities();
            _address = address;
            _userSession = UserSession.Instance;
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
                _address.CreateDate = _address.CreateDate == DateTime.MinValue ? Core.Utility.DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now) : _address.CreateDate;
                _address.CreatedBy = string.IsNullOrWhiteSpace(_address.CreatedBy) ? _userSession.User.UserName : _address.CreatedBy;
                _address.LastUpdate = Core.Utility.DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now);
                _address.LastUpdateBy = _userSession.User.UserName;

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

            var cityId = 0;
            if (cbCity.SelectedItem != null)
            {
                cityId = (cbCity.SelectedItem as SelectListItem).Id;
            }

            _address.AddressLine1 = txtAddress.Trim();
            _address.AddressLine2 = txtAddress2.Trim().Length == 0 ? string.Empty : txtAddress2.Trim();
            _address.CityId = cityId;
            _address.PostalCode = txtPostalCode.Trim();
            _address.Phone = txtPhoneNumber.Trim();

            var validationErrors = new Validator<Address>(_address)
                .Required(x => x.AddressLine1, Resources.AddressRequired)
                .Required(x => x.PostalCode, Resources.PostalCodeRequired)
                .Required(x => x.Phone, Resources.PhoneRequired)
                .MustBeTrue(x => x.AddressLine1.Length <= 50, Resources.AddressMax)
                .MustBeTrue(x => x.AddressLine2.Length <= 50, Resources.Address2Max)
                .MustBeTrue(x => x.PostalCode.Length <= 10, Resources.PostalCodeMax)
                .MustBeTrue(x => x.Phone.Length <= 20, Resources.PhoneMax)
                .MustBeTrue(x => txtPhoneNumber.IsTextValid, Resources.PhoneInvalidFormat)
                .MustBeTrue(x => x.CityId > 0, Resources.CityRequired)
                .Validate();


            if (validationErrors.Count > 0)
            {
                foreach (ValidationError validationError in validationErrors)
                {
                    sb.AppendLine(validationError.ErrorMessage);
                }
                pnlValidationErrors.Visible = true;
                lblValidationErrors.Text = sb.ToString();
                isValid = false;
            }

            return isValid;
        }
    }
}
