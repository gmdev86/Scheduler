namespace Scheduler.Forms
{
    partial class Manager
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpCalendar = new System.Windows.Forms.TabPage();
            this.tpUsers = new System.Windows.Forms.TabPage();
            this.tpCustomer = new System.Windows.Forms.TabPage();
            this.tpAddress = new System.Windows.Forms.TabPage();
            this.tpCity = new System.Windows.Forms.TabPage();
            this.tpCountry = new System.Windows.Forms.TabPage();
            this.tpReports = new System.Windows.Forms.TabPage();
            this.calendarControl1 = new Scheduler.Forms.Controls.CalendarControl();
            this.tabControl1.SuspendLayout();
            this.tpCalendar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpCalendar);
            this.tabControl1.Controls.Add(this.tpUsers);
            this.tabControl1.Controls.Add(this.tpCustomer);
            this.tabControl1.Controls.Add(this.tpAddress);
            this.tabControl1.Controls.Add(this.tpCity);
            this.tabControl1.Controls.Add(this.tpCountry);
            this.tabControl1.Controls.Add(this.tpReports);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1152, 1270);
            this.tabControl1.TabIndex = 1;
            // 
            // tpCalendar
            // 
            this.tpCalendar.Controls.Add(this.calendarControl1);
            this.tpCalendar.Location = new System.Drawing.Point(4, 29);
            this.tpCalendar.Margin = new System.Windows.Forms.Padding(0);
            this.tpCalendar.Name = "tpCalendar";
            this.tpCalendar.Size = new System.Drawing.Size(1144, 1237);
            this.tpCalendar.TabIndex = 2;
            this.tpCalendar.Text = "Calendar";
            this.tpCalendar.UseVisualStyleBackColor = true;
            // 
            // tpUsers
            // 
            this.tpUsers.Location = new System.Drawing.Point(4, 29);
            this.tpUsers.Margin = new System.Windows.Forms.Padding(0);
            this.tpUsers.Name = "tpUsers";
            this.tpUsers.Size = new System.Drawing.Size(1126, 1240);
            this.tpUsers.TabIndex = 0;
            this.tpUsers.Text = "Users";
            this.tpUsers.UseVisualStyleBackColor = true;
            // 
            // tpCustomer
            // 
            this.tpCustomer.Location = new System.Drawing.Point(4, 29);
            this.tpCustomer.Margin = new System.Windows.Forms.Padding(0);
            this.tpCustomer.Name = "tpCustomer";
            this.tpCustomer.Size = new System.Drawing.Size(1126, 1240);
            this.tpCustomer.TabIndex = 1;
            this.tpCustomer.Text = "Customers";
            this.tpCustomer.UseVisualStyleBackColor = true;
            // 
            // tpAddress
            // 
            this.tpAddress.Location = new System.Drawing.Point(4, 29);
            this.tpAddress.Margin = new System.Windows.Forms.Padding(0);
            this.tpAddress.Name = "tpAddress";
            this.tpAddress.Size = new System.Drawing.Size(1126, 1240);
            this.tpAddress.TabIndex = 3;
            this.tpAddress.Text = "Address";
            this.tpAddress.UseVisualStyleBackColor = true;
            // 
            // tpCity
            // 
            this.tpCity.Location = new System.Drawing.Point(4, 29);
            this.tpCity.Margin = new System.Windows.Forms.Padding(0);
            this.tpCity.Name = "tpCity";
            this.tpCity.Size = new System.Drawing.Size(1126, 1240);
            this.tpCity.TabIndex = 4;
            this.tpCity.Text = "City";
            this.tpCity.UseVisualStyleBackColor = true;
            // 
            // tpCountry
            // 
            this.tpCountry.Location = new System.Drawing.Point(4, 29);
            this.tpCountry.Margin = new System.Windows.Forms.Padding(0);
            this.tpCountry.Name = "tpCountry";
            this.tpCountry.Size = new System.Drawing.Size(1126, 1240);
            this.tpCountry.TabIndex = 5;
            this.tpCountry.Text = "Country";
            this.tpCountry.UseVisualStyleBackColor = true;
            // 
            // tpReports
            // 
            this.tpReports.Location = new System.Drawing.Point(4, 29);
            this.tpReports.Margin = new System.Windows.Forms.Padding(0);
            this.tpReports.Name = "tpReports";
            this.tpReports.Size = new System.Drawing.Size(1126, 1240);
            this.tpReports.TabIndex = 6;
            this.tpReports.Text = "Reports";
            this.tpReports.UseVisualStyleBackColor = true;
            // 
            // calendarControl1
            // 
            this.calendarControl1.AutoSize = true;
            this.calendarControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.calendarControl1.Location = new System.Drawing.Point(0, 0);
            this.calendarControl1.Margin = new System.Windows.Forms.Padding(0);
            this.calendarControl1.Name = "calendarControl1";
            this.calendarControl1.Size = new System.Drawing.Size(1140, 1243);
            this.calendarControl1.TabIndex = 0;
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1152, 1270);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Manager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manager";
            this.tabControl1.ResumeLayout(false);
            this.tpCalendar.ResumeLayout(false);
            this.tpCalendar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpCalendar;
        private Controls.CalendarControl calendarControl1;
        private System.Windows.Forms.TabPage tpUsers;
        private System.Windows.Forms.TabPage tpCustomer;
        private System.Windows.Forms.TabPage tpAddress;
        private System.Windows.Forms.TabPage tpCity;
        private System.Windows.Forms.TabPage tpCountry;
        private System.Windows.Forms.TabPage tpReports;
    }
}