using System;
using System.Text;
using System.Windows.Forms;
using Scheduler.Core.Interfaces;
using Scheduler.Core.Localization;
using Scheduler.Core.Models;
using Scheduler.Core.Services;

namespace Scheduler.Forms
{
    public partial class Login : Form
    {
        #region Properties
        
        private IDataService _dataService;
        private UserSession _userSession;

        #endregion

        public Login()
        {
            InitializeComponent();
            _dataService = new DataService();
            _userSession = UserSession.Instance;
            pnlValidationErrors.Visible = false;
            lblValidationErrors.Text = string.Empty;
            SetupText();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                try
                {
                    User user = _dataService.GetUserByUsername(txtUsername.Text);
                    if (user != null)
                    {
                        if (user.Password != txtPassword.Text)
                        {
                            pnlValidationErrors.Visible = true;
                            lblValidationErrors.Text = Resources.PasswordDatabaseMatch;
                        } else if (!user.Active)
                        {
                            pnlValidationErrors.Visible = true;
                            lblValidationErrors.Text = Resources.UserNotActive;
                        }
                        else
                        {
                            _userSession.User = user;
                            Manager manager = new Manager();
                            manager.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        if (txtUsername.Text == "test")
                        {
                            user = new User
                            {
                                UserName = txtUsername.Text,
                                Active = true,
                                Password = txtPassword.Text,
                                CreateDate = Core.Utility.DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now),
                                CreatedBy = "System",
                                LastUpdate = Core.Utility.DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now),
                                LastUpdateBy = "System"
                            };

                            _dataService.CreateUser(user);
                            user = _dataService.GetUserByUsername(txtUsername.Text);
                            _userSession.User = user;
                            Manager manager = new Manager();
                            manager.Show();
                            this.Hide();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{Resources.Error}: {ex.Message}", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private bool IsValid()
        {
            StringBuilder sb = new StringBuilder();
            bool isValid = true;

            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                sb.AppendLine(Resources.UserNameRequired);
                isValid = false;
            }

            if (txtUsername.Text.Length > 50)
            {
                sb.AppendLine(Resources.UserNameMax);
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                sb.AppendLine(Resources.PasswordRequired);
                isValid = false;
            }

            if (txtPassword.Text.Length > 50)
            {
                sb.AppendLine(Resources.PasswordMax);
                isValid = false;
            }

            if (txtUsername.Text == "test")
            {
                if (txtUsername.Text != txtPassword.Text)
                {
                    sb.AppendLine(Resources.LoginErrorMessage);
                    isValid = false;
                }
            }
            
            if (!isValid)
            {
                pnlValidationErrors.Visible = true;
                lblValidationErrors.Text = sb.ToString();
            }

            return isValid;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Language language = new Language();
            language.FormClosed += Language_FormClosed;
            language.Show();
        }

        private void Language_FormClosed(object sender, EventArgs e)
        {
            this.Enabled = true;
            SetupText();
        }

        private void SetupText()
        {
            this.Text = Resources.btnLogin;
            lblPassword.Text = Resources.lblPassword;
            lblUsername.Text = Resources.lblUsername;
            btnLogin.Text = Resources.btnLogin;
            btnSettings.Text = Resources.btnSettings;
        }
    }
}
