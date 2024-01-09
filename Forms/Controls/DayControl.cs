using System;
using System.ComponentModel;
using System.Windows.Forms;
using Scheduler.Core.Localization;
using Scheduler.Core.Models;

namespace Scheduler.Forms.Controls
{
    public partial class DayControl : UserControl
    {
        private int _year;
        private int _month;
        private int _day;
        private BindingList<Appointment> _appointments;
        private Form dynamicForm;
        public event EventHandler AppointmentDeleted;
        public event EventHandler AppointmentSaved;

        public DayControl()
        {
            InitializeComponent();
            _year = DateTime.Now.Year;
            _month = DateTime.Now.Month;
            _day = DateTime.Now.Day;
            _appointments = new BindingList<Appointment>();
            toolTip1.Active = false;
            btnEdit.Visible = false;
        }

        public DayControl(int year, int month, int day, BindingList<Appointment> appointments,  bool allowAddEvent = true)
        {
            InitializeComponent();
            toolTip1.Active = false;
            _year = year;
            _month = month;
            _day = day;
            lblAppointments.Visible = false;
            lblCount.Text = string.Empty;

            if (allowAddEvent)
            {
                btnAddEvent.Visible = true;
                if (appointments.Count > 0)
                {
                    lblCount.Text = appointments.Count.ToString();
                    lblAppointments.Visible = true;
                    btnEdit.Visible = true;
                }
                else
                {
                    btnEdit.Visible = false;
                }

                toolTip1.Active = true;
                toolTip1.SetToolTip(this, "Double Click to Edit");
            }

            _appointments = appointments;
        }

        public void SetDayLabel(int day)
        {
            lblDay.Text = day.ToString();
        }

        private void btnAddEvent_Click(object sender, System.EventArgs e)
        {
            Appointments appointments = new Appointments(_year, _month, _day, _appointments);
            appointments.FormClosed += Appointments_FormClosed;
            appointments.AppointmentsSaved += Appointments_Saved;
            if (this.ParentForm != null)
            {
                this.ParentForm.Enabled = false;
            }
            appointments.Show();
        }

        private void btnAddEvent_MouseEnter(object sender, System.EventArgs e)
        {
            btnAddEvent.Cursor = Cursors.Hand;
        }

        private void btnAddEvent_MouseLeave(object sender, System.EventArgs e)
        {
            btnAddEvent.Cursor = Cursors.Default;
        }

        private void Appointments_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Enabled = true;
            }
        }

        private void Appointments_Saved(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Enabled = true;
            }
            AppointmentSaved?.Invoke(this, EventArgs.Empty);
        }

        private void DayControl_DoubleClick(object sender, EventArgs e)
        {
            OpenDynamicForm();
        }

        private void OnDynamicClose(object sender, System.EventArgs e)
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Enabled = true;
            }
            dynamicForm?.Close();
        }

        private void OnDynamicDelete(object sender, System.EventArgs e)
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Enabled = true;
            }
            dynamicForm?.Close();
            AppointmentDeleted?.Invoke(this, EventArgs.Empty);
        }

        private void OpenDynamicForm()
        {
            dynamicForm = new Form();
            AppointmentsControl appointmentsControl = new AppointmentsControl(_appointments);
            appointmentsControl.CancelClicked += OnDynamicClose;
            appointmentsControl.DeleteClicked += OnDynamicDelete;
            dynamicForm.Controls.Add(appointmentsControl);
            dynamicForm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            dynamicForm.AutoSize = true;
            dynamicForm.Text = Resources.AppointmentAdministration;
            dynamicForm.StartPosition = FormStartPosition.CenterScreen;
            dynamicForm.ControlBox = false;
            if (this.ParentForm != null)
            {
                this.ParentForm.Enabled = false;
            }
            dynamicForm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenDynamicForm();
        }

        private void btnEdit_MouseEnter(object sender, EventArgs e)
        {
            btnEdit.Cursor = Cursors.Hand;
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            btnEdit.Cursor = Cursors.Default;
        }
    }
}
