using Scheduler.Core.Localization;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Scheduler.Core.Models;
using Scheduler.Core.Services;
using System.Text;
using Scheduler.Core.Utility;

namespace Scheduler.Forms.Controls
{
    public partial class CityModifyControl : UserControl
    {
        public event EventHandler CancelClicked;
        public event EventHandler SaveClicked;
        private Form dynamicForm;
        private BindingList<SelectListItem> _countryListItems;
        private DataService _dataService;
        private City _city;
        private UserSession _userSession;

        public CityModifyControl(City city)
        {
            InitializeComponent();
            _dataService = DataService.Instance;
            _countryListItems = new BindingList<SelectListItem>();
            LoadCountries();
            _city = city;
            _userSession = UserSession.Instance;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }

        private void CityModifyControl_Load(object sender, EventArgs e)
        {
            pnlValidationErrors.Visible = false;
            lblValidationErrors.Text = string.Empty;
            LoadCountryComboBox();
            if (_city.CityId > 0)
            {
                txtCity.Text = _city.CityName;
                var itemToSelect = _countryListItems.FirstOrDefault(x => x.Id == _city.CountryId);
                if (itemToSelect != null)
                {
                    cbCountry.SelectedItem = itemToSelect;
                }
            }
        }

        private void LoadCountries()
        {
            _countryListItems = _dataService.LoadItems("country");
        }

        private void ReloadCounties()
        {
            _countryListItems.Clear();
            var counties = _dataService.LoadItems("country");
            foreach (var country in counties)
            {
                _countryListItems.Add(country);
            }
        }

        private void LoadCountryComboBox()
        {
            cbCountry.DataSource = _countryListItems;
            cbCountry.DisplayMember = "Value";
        }

        private void btnAddCountry_Click(object sender, EventArgs e)
        {
            dynamicForm = new Form();
            CountryModifyControl countryModifyControl = new CountryModifyControl(new Country());
            countryModifyControl.CancelClicked += OnDynamicClose;
            countryModifyControl.SaveClicked += OnDynamicSave;
            dynamicForm.Controls.Add(countryModifyControl);
            dynamicForm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            dynamicForm.AutoSize = true;
            dynamicForm.Text = Resources.AddCountry;
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
            ReloadCounties();
            Enabled = true;
            dynamicForm?.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                _city.CreateDate = _city.CreateDate == DateTime.MinValue ? Core.Utility.DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now) : _city.CreateDate;
                _city.CreatedBy = string.IsNullOrWhiteSpace(_city.CreatedBy) ? _userSession.User.UserName : _city.CreatedBy;
                _city.LastUpdate = Core.Utility.DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now);
                _city.LastUpdateBy = _userSession.User.UserName;

                try
                {
                    if (_city.CityId == 0)
                    {
                        _dataService.CreateCity(_city);
                        MessageBox.Show(Resources.CityAddedSuccess);
                    }
                    else
                    {
                        _dataService.UpdateCity(_city);
                        MessageBox.Show(Resources.CityUpdatedSuccess);
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

            var countryId = 0;
            if (cbCountry.SelectedItem != null)
            {
                countryId = (cbCountry.SelectedItem as SelectListItem).Id;
            }
            _city.CityName = txtCity.Trim();
            _city.CountryId = countryId;

            var validationErrors = new Validator<City>(_city)
                .Required(x => x.CityName, Resources.CityRequired)
                .MustBeTrue(x => x.CityName.Length <= 50, Resources.CityMax)
                .MustBeTrue(x => x.CountryId > 0, Resources.CountryRequired)
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
