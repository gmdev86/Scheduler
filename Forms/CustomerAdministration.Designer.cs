namespace Scheduler.Forms
{
    partial class CustomerAdministration
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlValidationErrors = new System.Windows.Forms.Panel();
            this.lblValidationErrors = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.btnAddAddress = new System.Windows.Forms.Button();
            this.cbAddress = new System.Windows.Forms.ComboBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(720, 377);
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
            this.pnlValidationErrors.Size = new System.Drawing.Size(720, 39);
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
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFooter.Location = new System.Drawing.Point(0, 308);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(720, 70);
            this.pnlFooter.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(219, 15);
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
            this.btnCancel.Location = new System.Drawing.Point(348, 15);
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
            this.pnlBody.Controls.Add(this.btnAddAddress);
            this.pnlBody.Controls.Add(this.cbAddress);
            this.pnlBody.Controls.Add(this.txtCustomerName);
            this.pnlBody.Controls.Add(this.cbActive);
            this.pnlBody.Controls.Add(this.lblAddress);
            this.pnlBody.Controls.Add(this.lblCustomerName);
            this.pnlBody.Location = new System.Drawing.Point(0, 39);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(468, 269);
            this.pnlBody.TabIndex = 4;
            // 
            // btnAddAddress
            // 
            this.btnAddAddress.Location = new System.Drawing.Point(324, 161);
            this.btnAddAddress.Name = "btnAddAddress";
            this.btnAddAddress.Size = new System.Drawing.Size(121, 44);
            this.btnAddAddress.TabIndex = 5;
            this.btnAddAddress.Text = "Add Address";
            this.btnAddAddress.UseVisualStyleBackColor = true;
            this.btnAddAddress.Click += new System.EventHandler(this.btnAddAddress_Click);
            // 
            // cbAddress
            // 
            this.cbAddress.FormattingEnabled = true;
            this.cbAddress.Location = new System.Drawing.Point(16, 170);
            this.cbAddress.Name = "cbAddress";
            this.cbAddress.Size = new System.Drawing.Size(274, 28);
            this.cbAddress.TabIndex = 4;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(16, 66);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(274, 26);
            this.txtCustomerName.TabIndex = 3;
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(20, 225);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(71, 24);
            this.cbActive.TabIndex = 2;
            this.cbActive.Text = "Active";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(16, 135);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(78, 20);
            this.lblAddress.TabIndex = 1;
            this.lblAddress.Text = "Address*:";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(12, 31);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(134, 20);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "Customer Name*:";
            // 
            // CustomerAdministration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(720, 377);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerAdministration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Administration";
            this.Load += new System.EventHandler(this.CustomerAdministration_Load);
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
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.ComboBox cbAddress;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.Button btnAddAddress;
    }
}