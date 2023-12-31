using Scheduler.Core.Localization;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Scheduler.Core.Models;
using Scheduler.Core.Interfaces;
using Scheduler.Core.Services;
using System.Text;

namespace Scheduler.Forms.Controls
{
    public partial class CityModifyControl : UserControl
    {
        public event EventHandler CancelClicked;
        public event EventHandler SaveClicked;
        private Form dynamicForm;
        private BindingList<SelectListItem> _countryListItems;
        private IDataService _dataService;
        private City _city;

        public CityModifyControl(City city)
        {
            InitializeComponent();
            _dataService = new DataService();
            _countryListItems = new BindingList<SelectListItem>();
            LoadCountries();
            _city = city;
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
                var countryId = 0;
                if (cbCountry.SelectedItem != null)
                {
                    countryId = (cbCountry.SelectedItem as SelectListItem).Id;
                }
                _city.CityName = txtCity.Text;
                _city.CountryId = countryId;
                _city.CreateDate = _city.CreateDate == DateTime.MinValue ? Core.Utility.DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now) : _city.CreateDate;
                _city.CreatedBy = "System"; //todo: make sure to update to logged in user
                _city.LastUpdate = Core.Utility.DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now);
                _city.LastUpdateBy = "System"; //todo: make sure to update to logged in user

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

            if (string.IsNullOrEmpty(txtCity.Text))
            {
                sb.AppendLine(Resources.CityRequired);
                isValid = false;
            }

            if (txtCity.Text.Length > 50)
            {
                sb.AppendLine(Resources.CityMax);
                isValid = false;
            }

            if (!(cbCountry.SelectedItem is SelectListItem))
            {
                sb.AppendLine(Resources.CountryRequired);
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
