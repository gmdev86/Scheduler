using Scheduler.Core.Enums;
using Scheduler.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Scheduler.Core.Localization;
using Scheduler.Core.Models;
using System.Globalization;
using DateTimeConverter = Scheduler.Core.Utility.DateTimeConverter;

namespace Scheduler.Forms.Controls
{
    public partial class ReportsControl : UserControl
    {
        private DataService _dataService;
        private BindingSource _reportBindingSource;
        private DataTable _users;
        private DataTable _customers;
        private BindingList<Appointment> _appointments;

        public ReportsControl()
        {
            InitializeComponent();
        }

        private void ReportsControl_Load(object sender, EventArgs e)
        {
            _dataService = DataService.Instance;
            LoadData();
            InitializeDataBinding();

            cbSelectReport.Items.Add(string.Empty);
            foreach (ReportType reportType in System.Enum.GetValues(typeof(ReportType)))
            {
                cbSelectReport.Items.Add(reportType.ToString());
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cbSelectReport.SelectedItem as string))
            {
                ReportPrinter reportPrinter = new ReportPrinter(dgvReport);
                reportPrinter.Print();
            }
            else
            {
                MessageBox.Show(Resources.SelectReport, Resources.ReportNotSelected, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cbSelectReport.SelectedItem as string))
            {
                GenerateReport(cbSelectReport.SelectedItem as string);
            }
            else
            {
                MessageBox.Show(Resources.SelectReport, Resources.ReportNotSelected, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GenerateReport(string reportType)
        {
            switch (reportType)
            {
                case nameof(ReportType.AppointmentTypeByMonth):
                    Build_AppointmentTypeByMonth();
                    break;
                case nameof(ReportType.UserSchedule):
                    Build_UserSchedule();
                    break;
                case nameof(ReportType.TotalAppointmentsByType):
                    Build_TotalAppointmentsByType();
                    break;
            }
        }

        private void Build_AppointmentTypeByMonth()
        {
            DataTable dt = new DataTable();
            dt.TableName = "Appointment Type by Month";
            dt.Columns.Add(new DataColumn
            {
                Caption = "Month",
                DataType = typeof(string),
                ColumnName = "Month",
            });
            dt.Columns.Add(new DataColumn
            {
                Caption = "Type",
                DataType = typeof(string),
                ColumnName = "Appointment Type",
            });
            dt.Columns.Add(new DataColumn
            {
                Caption = "Total",
                DataType = typeof(int),
                ColumnName = "Total",
            });

            var appointments = _appointments.GroupBy(x => x.Start.Month).OrderBy(x =>x.Key);
            foreach (var monthGroup in appointments)
            {
                var typeGroup = monthGroup.GroupBy(x => x.Type);

                foreach (var app in typeGroup)
                {
                    var row = dt.NewRow();
                    row["Month"] = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthGroup.Key);
                    row["Appointment Type"] = app.Key;
                    row["Total"] = app.ToList().Count;
                    dt.Rows.Add(row);
                }
            }

            _reportBindingSource.DataSource = dt;
            _reportBindingSource.ResetBindings(true);
        }

        private void Build_UserSchedule()
        {
            DataTable dt = new DataTable();
            dt.TableName = "User Schedule";
            dt.Columns.Add(new DataColumn
            {
                DataType = typeof(string),
                ColumnName = "User",
            });
            dt.Columns.Add(new DataColumn
            {
                DataType = typeof(string),
                ColumnName = "Appointment Type",
            });
            dt.Columns.Add(new DataColumn
            {
                DataType = typeof(DateTime),
                ColumnName = "Start",
            });
            dt.Columns.Add(new DataColumn
            {
                DataType = typeof(DateTime),
                ColumnName = "End",
            });


            List<User> userList =
                (from DataRow row in _users.Rows
                    select new User
                    {
                        UserId = int.Parse(row["userId"].ToString()),
                        UserName = row["userName"].ToString()
                    }).ToList();

            foreach (var user in userList)
            {
                var appointments = _appointments
                    .Where(x => x.UserId == user.UserId && x.Start.Date >= DateTime.UtcNow.Date)
                    .OrderBy(x => x.Start.Date);
                foreach (Appointment appointment in appointments)
                {
                    var row = dt.NewRow();
                    row["User"] = user.UserName;
                    row["Appointment Type"] = appointment.Type;
                    row["Start"] = DateTimeConverter.UtcToLocalDateTime(appointment.Start);
                    row["End"] = DateTimeConverter.UtcToLocalDateTime(appointment.End);
                    dt.Rows.Add(row);
                }
            }

            _reportBindingSource.DataSource = dt;
            _reportBindingSource.ResetBindings(true);
        }

        private void Build_TotalAppointmentsByType()
        {
            DataTable dt = new DataTable();
            dt.TableName = "Appointment Totals by Type";
            dt.Columns.Add(new DataColumn
            {
                Caption = "Type",
                DataType = typeof(string),
                ColumnName = "Appointment Type",
            });
            dt.Columns.Add(new DataColumn
            {
                Caption = "Total",
                DataType = typeof(int),
                ColumnName = "Total",
            });

            var appointments = _appointments.GroupBy(x => x.Type);
            foreach (var appointment in appointments)
            {
                var row = dt.NewRow();
                row["Appointment Type"] = appointment.Key;
                row["Total"] = appointment.ToList().Count;
                dt.Rows.Add(row);
            }

            _reportBindingSource.DataSource = dt;
            _reportBindingSource.ResetBindings(true);
        }

        private void InitializeDataBinding()
        {
            _reportBindingSource = new BindingSource();
            _reportBindingSource.DataSource = dgvReport.DataSource;
            dgvReport.DataSource = _reportBindingSource;
        }

        private void LoadData()
        {
            _users = _dataService.GetAllUsers();
            _customers = _dataService.GetAllCustomers();
            _appointments = _dataService.GetAllAppointments();
        }
        
    }
}
