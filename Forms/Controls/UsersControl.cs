using System.Data;
using Scheduler.Core.Interfaces;
using System.Windows.Forms;
using Scheduler.Core.Models;
using Scheduler.Core.Services;
using System;
using Scheduler.Core.Localization;
using Scheduler.Core.Utility;

namespace Scheduler.Forms.Controls
{
    public partial class UsersControl : UserControl
    {
        #region Properties

        private IDataService _dataService;
        private BindingSource _usersBindingSource;

        #endregion

        public UsersControl()
        {
            InitializeComponent();
        }

        private void UsersControl_Load(object sender, System.EventArgs e)
        {
            _dataService = new DataService();
            InitializeDataBinding();
            LoadData();
        }

        private void InitializeDataBinding()
        {
            _usersBindingSource = new BindingSource();
            _usersBindingSource.DataSource = dgvUsers.DataSource;
            dgvUsers.DataSource = _usersBindingSource;
            dgvUsers.CellFormatting += dgvUsers_CellFormatting;
        }

        private void LoadData()
        {
            DataTable usersDataTable = _dataService.GetAllUsers();
            _usersBindingSource.DataSource = usersDataTable;
            _usersBindingSource.ResetBindings(false);
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            UserAdministration userAdministration = new UserAdministration(new User(), _dataService);
            userAdministration.FormClosed += UserAdministration_FormClosed;
            userAdministration.Show();
        }

        private void UserAdministration_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadData();
        }

        private void dgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DateTime)
            {
                DateTime originalDateTime = (DateTime)e.Value;
                DateTime convertedDateTime = DateTimeConverter.UtcToLocalDateTime(originalDateTime);
                e.Value = convertedDateTime;
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvUsers.SelectedRows[0];
                DateTime.TryParse(selectedRow.Cells["createDate"].Value?.ToString(), out DateTime createDate);
                var isActive = (SByte)selectedRow.Cells["active"].Value;

                var user = new User
                {
                    UserId = (int)selectedRow.Cells["userId"].Value,
                    UserName = (string)selectedRow.Cells["userName"].Value,
                    Password = (string)selectedRow.Cells["password"].Value,
                    Active = (isActive == 1),
                    CreateDate = createDate,
                    CreatedBy = (string)selectedRow.Cells["createdBy"].Value,
                    LastUpdate = DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now),
                    LastUpdateBy = (string)selectedRow.Cells["lastUpdateBy"].Value
                };
                UserAdministration userAdministration = new UserAdministration(user, _dataService);
                userAdministration.FormClosed += UserAdministration_FormClosed;
                userAdministration.Show();
            }
            else
            {
                MessageBox.Show(Resources.SelectUser, Resources.UserNotSelected, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                if (Dialog.ShowDeleteConfirmation() == DialogResult.OK)
                {
                    DataGridViewRow selectedRow = dgvUsers.SelectedRows[0];
                    var userId = (int)selectedRow.Cells["userId"].Value;
                    try
                    {
                        _dataService.DeleteUser(userId);
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"{Resources.Error}: {ex.Message}", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(Resources.SelectUser, Resources.UserNotSelected, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                _usersBindingSource.RemoveFilter();
            }
            else
            {
                int.TryParse(txtSearch.Text, out int searchValue);
                string filterExpression = $"userId = {searchValue} OR userName LIKE '%{txtSearch.Text}%'";
                _usersBindingSource.Filter = filterExpression;
            }

            dgvUsers.Refresh();
            if (dgvUsers.RowCount == 0)
            {
                MessageBox.Show(Resources.NoUsersFound, Resources.NoResults, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
