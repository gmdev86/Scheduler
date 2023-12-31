using Scheduler.Core.Enums;
using Scheduler.Core.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Scheduler.Forms.Controls
{

    public class ResizableAppointment : Panel
    {
        public event EventHandler EndTimeChanged;

        private const int MinAppointmentHeight = 30;
        private int _maxAppointmentHeight;
        private const int TimeSlotHeight = 30;
        private const string ControlName = "ResizableAppointment";
        private Point previousMouseLocation;
        private bool isResizing;
        private int _startTime; 
        private int _endTime;
        private Button btnDelete;
        private Action<ResizableAppointment> deleteAppointment;

        public int EndTime
        {
            get { return _endTime; }
            set
            {
                if (_endTime != value)
                {
                    _endTime = value;
                    OnEndTimeChanged();
                }
            }
        }
        
        public ResizableAppointment()
        {
            this._startTime = 9;
            this._endTime = 10;
            this._maxAppointmentHeight = 8 * 30;
            this.Margin = Padding.Empty;
            this.Name = ControlName;
            this.ForeColor = Color.White;

            InitializeComponents();
        }

        public ResizableAppointment(int startTime, int endTime, int max = 8, Action<ResizableAppointment> deleteAppointment = null)
        {
            this._startTime = startTime;
            this._endTime = endTime;
            this._maxAppointmentHeight = max * 30;
            this.Margin = Padding.Empty;
            this.Name = ControlName;

            InitializeComponents();
            this.deleteAppointment = deleteAppointment;
        }

        private void InitializeComponents()
        {
            Dock = DockStyle.Top;
            Height = CalculateHeight();
            Cursor = Cursors.SizeNS;

            MouseDown += ResizableAppointment_MouseDown;
            MouseMove += ResizableAppointment_MouseMove;
            MouseUp += ResizableAppointment_MouseUp;

            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Font = FontService.LoadFontAwesome();
            this.btnDelete.Location = new System.Drawing.Point(170, 0);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(29, 29);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = char.ConvertFromUtf32((int)IconType.TrashO);
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.ForeColor = Color.Red;
            this.btnDelete.MouseEnter += btnDelete_MouseEnter;
            this.btnDelete.MouseLeave += btnDelete_MouseLeave;
            this.Controls.Add(this.btnDelete);
            this.ResumeLayout(false);
        }

        public int CurrentStartTime()
        {
            return this._startTime;
        }

        public int CurrentEndTime()
        {
            return this.EndTime;
        }

        private int CalculateHeight()
        {
            return Math.Max(MinAppointmentHeight, Math.Min(_maxAppointmentHeight, (EndTime - _startTime) * TimeSlotHeight));
        }

        private int CalculateTimeFromPosition(int position)
        {
            return _startTime + position / TimeSlotHeight;
        }

        private void ResizableAppointment_MouseDown(object sender, MouseEventArgs e)
        {
            isResizing = true;
        }

        private void ResizableAppointment_MouseMove(object sender, MouseEventArgs e)
        {
            int deltaY = -1;

            if (previousMouseLocation != Point.Empty)
            {
                deltaY = e.Y - previousMouseLocation.Y;
            }

            if (isResizing && (EndTime <= 17 && deltaY < 0))
            {
                int newHeight = e.Y / TimeSlotHeight * TimeSlotHeight;
                Height = Math.Max(MinAppointmentHeight, Math.Min(_maxAppointmentHeight, newHeight));
                var tempEndTime = CalculateTimeFromPosition(e.Y);
                EndTime = Math.Max(_startTime + 1, Math.Min(_startTime + _maxAppointmentHeight / TimeSlotHeight, tempEndTime));

                if (EndTime > 17)
                {
                    Height -= 30;
                    EndTime = 17;
                }

                Invalidate();
            }
        }

        private void ResizableAppointment_MouseUp(object sender, MouseEventArgs e)
        {
            isResizing = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (SolidBrush brush = new SolidBrush(BackColor))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }

            using (Pen pen = new Pen(ForeColor, 2))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }

            using (Font font = new Font("Arial", 10))
            {
                TextRenderer.DrawText(e.Graphics, $"{_startTime}:00 - {EndTime}:00", font, new Point(5, 5), ForeColor);
            }
        }

        protected virtual void OnEndTimeChanged()
        {
            EndTimeChanged?.Invoke(this, EventArgs.Empty);
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.deleteAppointment?.Invoke(this);
        }

        private void btnDelete_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.Cursor = Cursors.Hand;
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.Cursor = Cursors.Default;
        }

    }

}
