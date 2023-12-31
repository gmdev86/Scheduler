using Scheduler.Core.Interfaces;
using System;
using System.Text;
using System.Windows.Forms;
using Scheduler.Core.Localization;
using Scheduler.Core.Models;
using Scheduler.Core.Services;
using Scheduler.Core.Utility;

namespace Scheduler.Forms.Controls
{
    public partial class CountryModifyControl : UserControl
    {
        public event EventHandler CancelClicked;
        public event EventHandler SaveClicked;
        private IDataService _dataService;
        private Country _country;

        public CountryModifyControl(Country country)
        {
            InitializeComponent();
            _country = country;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                _country.CountryName = txtCountry.Text;
                _country.CreateDate = _country.CreateDate == DateTime.MinValue ? DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now) : _country.CreateDate;
                _country.CreatedBy = "System"; //todo: make sure to update to logged in user
                _country.LastUpdate = DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now);
                _country.LastUpdateBy = "System"; //todo: make sure to update to logged in user

                try
                {
                    if (_country.CountryId == 0)
                    {
                        _dataService.CreateCountry(_country);
                        MessageBox.Show(Resources.CountryAddedSuccess);
                    }
                    else
                    {
                        _dataService.UpdateCountry(_country);
                        MessageBox.Show(Resources.CountryUpdatedSuccess);
                    }
                    SaveClicked?.Invoke(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Resources.FailedToSave, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }

        private void CountryModifyControl_Load(object sender, EventArgs e)
        {
            _dataService = new DataService();
            pnlValidationErrors.Visible = false;
            lblValidationErrors.Text = string.Empty;
        }

        private bool IsValid()
        {
            StringBuilder sb = new StringBuilder();
            bool isValid = true;
            pnlValidationErrors.Visible = false;
            lblValidationErrors.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(txtCountry.Text))
            {
                sb.AppendLine(Resources.CountryRequired);
                isValid = false;
            }

            if (txtCountry.Text.Length > 50)
            {
                sb.AppendLine(Resources.CountryMax);
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
