using System;
using System.Text;
using System.Windows.Forms;
using Scheduler.Core.Interfaces;
using Scheduler.Core.Models;
using Scheduler.Core.Utility;
using Resources = Scheduler.Core.Localization.Resources;

namespace Scheduler.Forms
{
    public partial class UserAdministration : Form
    {
        #region Properties

        private User _user;
        private IDataService _dataService;

        #endregion

        #region Constructors

        public UserAdministration(User user, IDataService dataService)
        {
            InitializeComponent();
            lblValidationErrors.Text = string.Empty;
            lblValidationErrors.Visible = false;
            _user = user;
            _dataService = dataService;

            if (_user.UserId > 0)
            {
                txtUsername.Text = _user.UserName;
                txtPassword.Text = _user.Password;
                cbActive.Checked = _user.Active;
            }
        }

        #endregion

        #region Events

        private void UserAdministration_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (IsValid())
            {
                _user.UserName = txtUsername.Text;
                _user.Password = txtPassword.Text;
                _user.Active = cbActive.Checked;
                _user.CreateDate = _user.CreateDate == DateTime.MinValue ? DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now) : _user.CreateDate;
                _user.CreatedBy = "System"; //todo: make sure to update to logged in user
                _user.LastUpdate = DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now);
                _user.LastUpdateBy = "System"; //todo: make sure to update to logged in user

                try
                {
                    if (_user.UserId == 0)
                    {
                        _dataService.CreateUser(_user);
                        MessageBox.Show(Resources.UserAddedSuccess);
                    }
                    else
                    {
                        _dataService.UpdateUser(_user);
                        MessageBox.Show(Resources.UserUpdatedSuccess);
                    }

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Resources.FailedToSave, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        #endregion


        #region Private Methods

        private bool IsValid()
        {
            bool isValid = true;
            StringBuilder sb = new StringBuilder();
            lblValidationErrors.Text = string.Empty;
            lblValidationErrors.Visible = false;

            if (txtUsername.Text.Length > 50)
            {
                isValid = false;
                sb.AppendLine(Resources.UserNameMax);
            }

            if (txtUsername.Text.Length == 0)
            {
                isValid = false;
                sb.AppendLine(Resources.UserNameRequired);
            }

            if (txtPassword.Text.Length > 50)
            {
                isValid = false;
                sb.AppendLine(Resources.PasswordMax);
            }

            if (txtPassword.Text.Length == 0)
            {
                isValid = false;
                sb.AppendLine(Resources.PasswordRequired);
            }

            if (txtPassword.Text != txtPasswordConfirm.Text)
            {
                isValid = false;
                sb.AppendLine(Resources.PasswordRequired);
            }

            if (isValid == false)
            {
                lblValidationErrors.Text = sb.ToString();
                lblValidationErrors.Visible = true;
            }

            return isValid;
        }

        #endregion

    }
}
