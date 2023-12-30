
namespace Scheduler.Forms.Controls
{
    partial class DayControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDay = new System.Windows.Forms.Label();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Location = new System.Drawing.Point(16, 17);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(27, 20);
            this.lblDay.TabIndex = 0;
            this.lblDay.Text = "00";
            this.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEvent.Font = new System.Drawing.Font("FontAwesome", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEvent.ForeColor = System.Drawing.Color.Green;
            this.btnAddEvent.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddEvent.Location = new System.Drawing.Point(108, 6);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(36, 38);
            this.btnAddEvent.TabIndex = 1;
            this.btnAddEvent.Text = "00";
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Visible = false;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            this.btnAddEvent.MouseEnter += new System.EventHandler(this.btnAddEvent_MouseEnter);
            this.btnAddEvent.MouseLeave += new System.EventHandler(this.btnAddEvent_MouseLeave);
            // 
            // DayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAddEvent);
            this.Controls.Add(this.lblDay);
            this.Name = "DayControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Button btnAddEvent;
    }
}
