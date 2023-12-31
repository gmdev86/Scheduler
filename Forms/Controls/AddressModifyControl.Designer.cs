namespace Scheduler.Forms.Controls
{
    partial class AddressModifyControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlValidationErrors = new System.Windows.Forms.Panel();
            this.lblValidationErrors = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.txtPhoneNumber = new Scheduler.Forms.Controls.PhoneNumberTextBox();
            this.btnAddCity = new System.Windows.Forms.Button();
            this.lblCity = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.cbCity = new System.Windows.Forms.ComboBox();
            this.txtPostalCode = new System.Windows.Forms.TextBox();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlValidationErrors.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.pnlValidationErrors, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlFooter, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.pnlBody, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(484, 438);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlValidationErrors
            // 
            this.pnlValidationErrors.AutoSize = true;
            this.pnlValidationErrors.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlValidationErrors.BackColor = System.Drawing.Color.White;
            this.pnlValidationErrors.Controls.Add(this.lblValidationErrors);
            this.pnlValidationErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlValidationErrors.Location = new System.Drawing.Point(0, 0);
            this.pnlValidationErrors.Margin = new System.Windows.Forms.Padding(0);
            this.pnlValidationErrors.Name = "pnlValidationErrors";
            this.pnlValidationErrors.Size = new System.Drawing.Size(484, 39);
            this.pnlValidationErrors.TabIndex = 3;
            // 
            // lblValidationErrors
            // 
            this.lblValidationErrors.AutoSize = true;
            this.lblValidationErrors.BackColor = System.Drawing.Color.White;
            this.lblValidationErrors.ForeColor = System.Drawing.Color.Red;
            this.lblValidationErrors.Location = new System.Drawing.Point(12, 9);
            this.lblValidationErrors.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.lblValidationErrors.Name = "lblValidationErrors";
            this.lblValidationErrors.Size = new System.Drawing.Size(126, 20);
            this.lblValidationErrors.TabIndex = 0;
            this.lblValidationErrors.Text = "Validation Errors";
            // 
            // pnlFooter
            // 
            this.pnlFooter.AutoSize = true;
            this.pnlFooter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlFooter.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 370);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(484, 68);
            this.pnlFooter.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(245, 13);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 45);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(374, 13);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 45);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBody.Controls.Add(this.txtPhoneNumber);
            this.pnlBody.Controls.Add(this.btnAddCity);
            this.pnlBody.Controls.Add(this.lblCity);
            this.pnlBody.Controls.Add(this.label4);
            this.pnlBody.Controls.Add(this.label3);
            this.pnlBody.Controls.Add(this.lblAddress2);
            this.pnlBody.Controls.Add(this.lblAddress);
            this.pnlBody.Controls.Add(this.cbCity);
            this.pnlBody.Controls.Add(this.txtPostalCode);
            this.pnlBody.Controls.Add(this.txtAddress2);
            this.pnlBody.Controls.Add(this.txtAddress);
            this.pnlBody.Location = new System.Drawing.Point(0, 39);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(484, 331);
            this.pnlBody.TabIndex = 4;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(29, 279);
            this.txtPhoneNumber.MaxLength = 8;
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(194, 26);
            this.txtPhoneNumber.TabIndex = 11;
            this.txtPhoneNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAddCity
            // 
            this.btnAddCity.Location = new System.Drawing.Point(269, 110);
            this.btnAddCity.Name = "btnAddCity";
            this.btnAddCity.Size = new System.Drawing.Size(99, 46);
            this.btnAddCity.TabIndex = 10;
            this.btnAddCity.Text = "Add City";
            this.btnAddCity.UseVisualStyleBackColor = true;
            this.btnAddCity.Click += new System.EventHandler(this.btnAddCity_Click);
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Location = new System.Drawing.Point(25, 96);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(45, 20);
            this.lblCity.TabIndex = 9;
            this.lblCity.Text = "City*:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Phone*:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Postal Code*:";
            // 
            // lblAddress2
            // 
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.Location = new System.Drawing.Point(265, 19);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(85, 20);
            this.lblAddress2.TabIndex = 6;
            this.lblAddress2.Text = "Address 2:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(25, 19);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(78, 20);
            this.lblAddress.TabIndex = 5;
            this.lblAddress.Text = "Address*:";
            // 
            // cbCity
            // 
            this.cbCity.FormattingEnabled = true;
            this.cbCity.Location = new System.Drawing.Point(29, 119);
            this.cbCity.Name = "cbCity";
            this.cbCity.Size = new System.Drawing.Size(194, 28);
            this.cbCity.TabIndex = 4;
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.Location = new System.Drawing.Point(29, 203);
            this.txtPostalCode.MaxLength = 10;
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(194, 26);
            this.txtPostalCode.TabIndex = 2;
            // 
            // txtAddress2
            // 
            this.txtAddress2.Location = new System.Drawing.Point(269, 42);
            this.txtAddress2.MaxLength = 50;
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(179, 26);
            this.txtAddress2.TabIndex = 1;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(29, 42);
            this.txtAddress.MaxLength = 50;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(194, 26);
            this.txtAddress.TabIndex = 0;
            // 
            // AddressModifyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AddressModifyControl";
            this.Size = new System.Drawing.Size(484, 438);
            this.Load += new System.EventHandler(this.AddressModifyControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlValidationErrors.ResumeLayout(false);
            this.pnlValidationErrors.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlValidationErrors;
        private System.Windows.Forms.Label lblValidationErrors;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Button btnAddCity;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAddress2;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.ComboBox cbCity;
        private System.Windows.Forms.TextBox txtPostalCode;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.TextBox txtAddress;
        private PhoneNumberTextBox txtPhoneNumber;
    }
}
