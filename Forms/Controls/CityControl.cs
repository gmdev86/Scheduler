using Scheduler.Core.Services;
using System;
using System.Data;
using System.Windows.Forms;
using Scheduler.Core.Localization;
using Scheduler.Core.Models;
using Scheduler.Core.Utility;

namespace Scheduler.Forms.Controls
{
    public partial class CityControl : UserControl
    {
        #region Properties

        private DataService _dataService;
        private BindingSource _cityBindingSource;
        private Form dynamicForm;

        #endregion

        public CityControl()
        {
            InitializeComponent();
        }

        private void CityControl_Load(object sender, System.EventArgs e)
        {
            _dataService = DataService.Instance;
            InitializeDataBinding();
            LoadData();
        }

        private void InitializeDataBinding()
        {
            _cityBindingSource = new BindingSource();
            _cityBindingSource.DataSource = dgvCity.DataSource;
            dgvCity.DataSource = _cityBindingSource;
            dgvCity.CellFormatting += dgvCity_CellFormatting;
        }

        private void LoadData()
        {
            DataTable usersDataTable = _dataService.GetAllCities();
            _cityBindingSource.DataSource = usersDataTable;
            _cityBindingSource.ResetBindings(false);
        }

        private void dgvCity_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
            OpenDynamicForm(new City());
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvCity.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCity.SelectedRows[0];
                DateTime.TryParse(selectedRow.Cells["createDate"].Value?.ToString(), out DateTime createDate);

                var city = new City
                {
                    CityId = (int)selectedRow.Cells["cityId"].Value,
                    CityName = (string)selectedRow.Cells["city"].Value,
                    CountryId = (int)selectedRow.Cells["countryId"].Value,
                    CreateDate = createDate,
                    CreatedBy = (string)selectedRow.Cells["createdBy"].Value,
                    LastUpdate = DateTimeConverter.DateTimeOffsetToUtc(DateTime.Now),
                    LastUpdateBy = (string)selectedRow.Cells["lastUpdateBy"].Value
                };
                OpenDynamicForm(city);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCity.SelectedRows.Count > 0)
            {
                if (Dialog.ShowDeleteConfirmation() == DialogResult.OK)
                {
                    DataGridViewRow selectedRow = dgvCity.SelectedRows[0];
                    var cityId = (int)selectedRow.Cells["cityId"].Value;
                    try
                    {
                        _dataService.DeleteCity(cityId);
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("CONSTRAINT"))
                        {
                            MessageBox.Show($"{Resources.CityConstraintMessage}", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(Resources.SelectCity, Resources.CityNotSelected, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                _cityBindingSource.RemoveFilter();
            }
            else
            {
                int.TryParse(txtSearch.Text, out int searchValue);
                string filterExpression = $"cityId = {searchValue} OR city LIKE '%{txtSearch.Text}%'";
                _cityBindingSource.Filter = filterExpression;
            }

            dgvCity.Refresh();
            if (dgvCity.RowCount == 0)
            {
                MessageBox.Show(Resources.NoCityFound, Resources.NoResults, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void OpenDynamicForm(City city)
        {
            dynamicForm = new Form();
            CityModifyControl cityModifyControl = new CityModifyControl(city);
            cityModifyControl.CancelClicked += OnDynamicClose;
            cityModifyControl.SaveClicked += OnDynamicSave;
            dynamicForm.Controls.Add(cityModifyControl);
            dynamicForm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            dynamicForm.AutoSize = true;
            dynamicForm.Text = Resources.AddCity;
            dynamicForm.StartPosition = FormStartPosition.CenterScreen;
            dynamicForm.ControlBox = false;
            if (this.ParentForm != null)
            {
                this.ParentForm.Enabled = false;
            }
            dynamicForm.ShowDialog();
        }
    }
}
