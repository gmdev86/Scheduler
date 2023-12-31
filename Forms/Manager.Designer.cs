﻿namespace Scheduler.Forms
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
            this.tpCustomers = new System.Windows.Forms.TabPage();
            this.tpAddress = new System.Windows.Forms.TabPage();
            this.tpCity = new System.Windows.Forms.TabPage();
            this.tpCountry = new System.Windows.Forms.TabPage();
            this.tpReports = new System.Windows.Forms.TabPage();
            this.calendarControl1 = new Scheduler.Forms.Controls.CalendarControl();
            this.usersControl1 = new Scheduler.Forms.Controls.UsersControl();
            this.customersControl1 = new Scheduler.Forms.Controls.CustomersControl();
            this.addressControl1 = new Scheduler.Forms.Controls.AddressControl();
            this.cityControl1 = new Scheduler.Forms.Controls.CityControl();
            this.countryControl1 = new Scheduler.Forms.Controls.CountryControl();
            this.tabControl1.SuspendLayout();
            this.tpCalendar.SuspendLayout();
            this.tpUsers.SuspendLayout();
            this.tpCustomers.SuspendLayout();
            this.tpAddress.SuspendLayout();
            this.tpCity.SuspendLayout();
            this.tpCountry.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpCalendar);
            this.tabControl1.Controls.Add(this.tpUsers);
            this.tabControl1.Controls.Add(this.tpCustomers);
            this.tabControl1.Controls.Add(this.tpAddress);
            this.tabControl1.Controls.Add(this.tpCity);
            this.tabControl1.Controls.Add(this.tpCountry);
            this.tabControl1.Controls.Add(this.tpReports);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1828, 1668);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tpCalendar
            // 
            this.tpCalendar.Controls.Add(this.calendarControl1);
            this.tpCalendar.Location = new System.Drawing.Point(4, 29);
            this.tpCalendar.Margin = new System.Windows.Forms.Padding(0);
            this.tpCalendar.Name = "tpCalendar";
            this.tpCalendar.Size = new System.Drawing.Size(1820, 1635);
            this.tpCalendar.TabIndex = 0;
            this.tpCalendar.Text = "Calendar";
            this.tpCalendar.UseVisualStyleBackColor = true;
            // 
            // tpUsers
            // 
            this.tpUsers.Controls.Add(this.usersControl1);
            this.tpUsers.Location = new System.Drawing.Point(4, 29);
            this.tpUsers.Margin = new System.Windows.Forms.Padding(0);
            this.tpUsers.Name = "tpUsers";
            this.tpUsers.Size = new System.Drawing.Size(1820, 1635);
            this.tpUsers.TabIndex = 1;
            this.tpUsers.Text = "Users";
            this.tpUsers.UseVisualStyleBackColor = true;
            // 
            // tpCustomers
            // 
            this.tpCustomers.Controls.Add(this.customersControl1);
            this.tpCustomers.Location = new System.Drawing.Point(4, 29);
            this.tpCustomers.Name = "tpCustomers";
            this.tpCustomers.Size = new System.Drawing.Size(1820, 1635);
            this.tpCustomers.TabIndex = 2;
            this.tpCustomers.Text = "Customers";
            this.tpCustomers.UseVisualStyleBackColor = true;
            // 
            // tpAddress
            // 
            this.tpAddress.Controls.Add(this.addressControl1);
            this.tpAddress.Location = new System.Drawing.Point(4, 29);
            this.tpAddress.Name = "tpAddress";
            this.tpAddress.Size = new System.Drawing.Size(1820, 1635);
            this.tpAddress.TabIndex = 3;
            this.tpAddress.Text = "Address";
            this.tpAddress.UseVisualStyleBackColor = true;
            // 
            // tpCity
            // 
            this.tpCity.Controls.Add(this.cityControl1);
            this.tpCity.Location = new System.Drawing.Point(4, 29);
            this.tpCity.Name = "tpCity";
            this.tpCity.Size = new System.Drawing.Size(1820, 1635);
            this.tpCity.TabIndex = 4;
            this.tpCity.Text = "City";
            this.tpCity.UseVisualStyleBackColor = true;
            // 
            // tpCountry
            // 
            this.tpCountry.Controls.Add(this.countryControl1);
            this.tpCountry.Location = new System.Drawing.Point(4, 29);
            this.tpCountry.Name = "tpCountry";
            this.tpCountry.Size = new System.Drawing.Size(1820, 1635);
            this.tpCountry.TabIndex = 5;
            this.tpCountry.Text = "Country";
            this.tpCountry.UseVisualStyleBackColor = true;
            // 
            // tpReports
            // 
            this.tpReports.Location = new System.Drawing.Point(4, 29);
            this.tpReports.Name = "tpReports";
            this.tpReports.Size = new System.Drawing.Size(1820, 1635);
            this.tpReports.TabIndex = 6;
            this.tpReports.Text = "Reports";
            this.tpReports.UseVisualStyleBackColor = true;
            // 
            // calendarControl1
            // 
            this.calendarControl1.AutoSize = true;
            this.calendarControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.calendarControl1.Location = new System.Drawing.Point(-4, 0);
            this.calendarControl1.Margin = new System.Windows.Forms.Padding(0);
            this.calendarControl1.Name = "calendarControl1";
            this.calendarControl1.Size = new System.Drawing.Size(1140, 1243);
            this.calendarControl1.TabIndex = 0;
            // 
            // usersControl2
            // 
            this.usersControl1.Location = new System.Drawing.Point(0, 0);
            this.usersControl1.Margin = new System.Windows.Forms.Padding(0);
            this.usersControl1.Name = "usersControl2";
            this.usersControl1.Size = new System.Drawing.Size(1626, 821);
            this.usersControl1.TabIndex = 0;
            // 
            // customersControl1
            // 
            this.customersControl1.Location = new System.Drawing.Point(0, 0);
            this.customersControl1.Margin = new System.Windows.Forms.Padding(0);
            this.customersControl1.Name = "customersControl1";
            this.customersControl1.Size = new System.Drawing.Size(1626, 793);
            this.customersControl1.TabIndex = 0;
            // 
            // addressControl1
            // 
            this.addressControl1.Location = new System.Drawing.Point(0, 0);
            this.addressControl1.Margin = new System.Windows.Forms.Padding(0);
            this.addressControl1.Name = "addressControl1";
            this.addressControl1.Size = new System.Drawing.Size(1625, 789);
            this.addressControl1.TabIndex = 0;
            // 
            // cityControl1
            // 
            this.cityControl1.Location = new System.Drawing.Point(0, 0);
            this.cityControl1.Margin = new System.Windows.Forms.Padding(0);
            this.cityControl1.Name = "cityControl1";
            this.cityControl1.Size = new System.Drawing.Size(1559, 777);
            this.cityControl1.TabIndex = 0;
            // 
            // countryControl1
            // 
            this.countryControl1.Location = new System.Drawing.Point(0, 0);
            this.countryControl1.Margin = new System.Windows.Forms.Padding(0);
            this.countryControl1.Name = "countryControl1";
            this.countryControl1.Size = new System.Drawing.Size(1626, 800);
            this.countryControl1.TabIndex = 0;
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1828, 1668);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Manager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Manager_FormClosing);
            this.Load += new System.EventHandler(this.Manager_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpCalendar.ResumeLayout(false);
            this.tpCalendar.PerformLayout();
            this.tpUsers.ResumeLayout(false);
            this.tpCustomers.ResumeLayout(false);
            this.tpAddress.ResumeLayout(false);
            this.tpCity.ResumeLayout(false);
            this.tpCountry.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpCalendar;
        private System.Windows.Forms.TabPage tpUsers;
        private Controls.CalendarControl calendarControl1;
        private System.Windows.Forms.TabPage tpCustomers;
        private System.Windows.Forms.TabPage tpAddress;
        private System.Windows.Forms.TabPage tpCity;
        private System.Windows.Forms.TabPage tpCountry;
        private System.Windows.Forms.TabPage tpReports;
        private Controls.UsersControl usersControl1;
        private Controls.CustomersControl customersControl1;
        private Controls.AddressControl addressControl1;
        private Controls.CityControl cityControl1;
        private Controls.CountryControl countryControl1;
    }
}