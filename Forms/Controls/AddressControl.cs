using Scheduler.Core.Interfaces;
using Scheduler.Core.Services;
using System;
using System.Data;
using System.Windows.Forms;
using Scheduler.Core.Utility;

namespace Scheduler.Forms.Controls
{
    public partial class AddressControl : UserControl
    {
        #region Properties

        private IDataService _dataService;
        private BindingSource _addressBindingSource;

        #endregion

        public AddressControl()
        {
            InitializeComponent();
        }

        private void AddressControl_Load(object sender, System.EventArgs e)
        {
            _dataService = new DataService();
            InitializeDataBinding();
            LoadData();
        }

        private void InitializeDataBinding()
        {
            _addressBindingSource = new BindingSource();
            _addressBindingSource.DataSource = dgvAddress.DataSource;
            dgvAddress.DataSource = _addressBindingSource;
            dgvAddress.CellFormatting += dgvAddress_CellFormatting;
        }

        private void LoadData()
        {
            DataTable addressDataTable = _dataService.GetAllAddresses();
            _addressBindingSource.DataSource = addressDataTable;
            _addressBindingSource.ResetBindings(false);
        }

        private void dgvAddress_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DateTime)
            {
                DateTime originalDateTime = (DateTime)e.Value;
                DateTime convertedDateTime = DateTimeConverter.UtcToLocalDateTime(originalDateTime);
                e.Value = convertedDateTime;
            }
        }
    }
}
