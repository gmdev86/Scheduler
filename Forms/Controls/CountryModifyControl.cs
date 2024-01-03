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
        private DataService _dataService;
        private Country _country;
        private UserSession _userSession;

        public CountryModifyControl(Country country)
        {
            InitializeComponent();
            _country = country;
            _userSession = UserSession.Instance;
            _dataService = DataService.Instance;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                _country.CountryName = txtCountry.Text;
                _country.CreateDate = _country.CreateDate == DateTime.MinValue ? DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now) : _country.CreateDate;
                _country.CreatedBy = string.IsNullOrWhiteSpace(_country.CreatedBy) ? _userSession.User.UserName : _country.CreatedBy; 
                _country.LastUpdate = DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now);
                _country.LastUpdateBy = _userSession.User.UserName; 

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
            pnlValidationErrors.Visible = false;
            lblValidationErrors.Text = string.Empty;
            if (_country.CountryId > 0)
            {
                txtCountry.Text = _country.CountryName;
            }
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
