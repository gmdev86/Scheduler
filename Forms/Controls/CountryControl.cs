using Scheduler.Core.Interfaces;
using System;
using System.Data;
using System.Windows.Forms;
using Scheduler.Core.Localization;
using Scheduler.Core.Utility;
using Scheduler.Core.Services;
using Scheduler.Core.Models;

namespace Scheduler.Forms.Controls
{
    public partial class CountryControl : UserControl
    {
        #region Properties

        private IDataService _dataService;
        private BindingSource _countryBindingSource;
        private Form dynamicForm;

        #endregion

        public CountryControl()
        {
            InitializeComponent();
        }

        private void CountryControl_Load(object sender, System.EventArgs e)
        {
            _dataService = new DataService();
            InitializeDataBinding();
            LoadData();
        }

        private void InitializeDataBinding()
        {
            _countryBindingSource = new BindingSource();
            _countryBindingSource.DataSource = dgvCountry.DataSource;
            dgvCountry.DataSource = _countryBindingSource;
            dgvCountry.CellFormatting += dgvCountry_CellFormatting;
        }

        private void LoadData()
        {
            DataTable usersDataTable = _dataService.GetAllCountries();
            _countryBindingSource.DataSource = usersDataTable;
            _countryBindingSource.ResetBindings(false);
        }

        private void dgvCountry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DateTime)
            {
                DateTime originalDateTime = (DateTime)e.Value;
                DateTime convertedDateTime = DateTimeConverter.UtcToLocalDateTime(originalDateTime);
                e.Value = convertedDateTime;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenDynamicForm(new Country());
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvCountry.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCountry.SelectedRows[0];
                DateTime.TryParse(selectedRow.Cells["createDate"].Value?.ToString(), out DateTime createDate);

                var country = new Country
                {
                    CountryId = (int)selectedRow.Cells["countryId"].Value,
                    CountryName = (string)selectedRow.Cells["country"].Value,
                    CreateDate = createDate,
                    CreatedBy = (string)selectedRow.Cells["createdBy"].Value,
                    LastUpdate = DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now),
                    LastUpdateBy = (string)selectedRow.Cells["lastUpdateBy"].Value
                };
                OpenDynamicForm(country);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCountry.SelectedRows.Count > 0)
            {
                if (Dialog.ShowDeleteConfirmation() == DialogResult.OK)
                {
                    DataGridViewRow selectedRow = dgvCountry.SelectedRows[0];
                    var countryId = (int)selectedRow.Cells["countryId"].Value;
                    try
                    {
                        _dataService.DeleteCountry(countryId);
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("CONSTRAINT"))
                        {
                            MessageBox.Show($"{Resources.CountryConstraintMessage}", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show($"{Resources.Error}: {ex.Message}", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(Resources.SelectCountry, Resources.CountryNotSelected, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                _countryBindingSource.RemoveFilter();
            }
            else
            {
                int.TryParse(txtSearch.Text, out int searchValue);
                string filterExpression = $"countryId = {searchValue} OR country LIKE '%{txtSearch.Text}%'";
                _countryBindingSource.Filter = filterExpression;
            }

            dgvCountry.Refresh();
            if (dgvCountry.RowCount == 0)
            {
                MessageBox.Show(Resources.NoCountryFound, Resources.NoResults, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OnDynamicClose(object sender, System.EventArgs e)
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Enabled = true;
            }
            dynamicForm?.Close();
        }

        private void OnDynamicSave(object sender, System.EventArgs e)
        {
            LoadData();
            if (this.ParentForm != null)
            {
                this.ParentForm.Enabled = true;
            }
            dynamicForm?.Close();
        }

        private void OpenDynamicForm(Country country)
        {
            dynamicForm = new Form();
            CountryModifyControl countryModifyControl = new CountryModifyControl(country);
            countryModifyControl.CancelClicked += OnDynamicClose;
            countryModifyControl.SaveClicked += OnDynamicSave;
            dynamicForm.Controls.Add(countryModifyControl);
            dynamicForm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            dynamicForm.AutoSize = true;
            dynamicForm.Text = Resources.AddCountry;
            dynamicForm.StartPosition = FormStartPosition.CenterScreen;
            dynamicForm.ControlBox = false;
            if (this.ParentForm != null)
            {
                this.ParentForm.Enabled = true;
            }
            dynamicForm.ShowDialog();
        }
    }
}
