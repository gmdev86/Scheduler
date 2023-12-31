namespace Scheduler.Forms
{
    partial class UserAdministration
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
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlValidationErrors = new System.Windows.Forms.Panel();
            this.lblValidationErrors = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtPasswordConfirm = new System.Windows.Forms.TextBox();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlValidationErrors.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.pnlFooter, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.pnlValidationErrors, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlBody, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(505, 475);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlFooter
            // 
            this.pnlFooter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlFooter.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 413);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(505, 62);
            this.pnlFooter.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(264, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 45);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(393, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 45);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.pnlValidationErrors.Size = new System.Drawing.Size(505, 39);
            this.pnlValidationErrors.TabIndex = 2;
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
            // pnlBody
            // 
            this.pnlBody.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlBody.Controls.Add(this.lblConfirm);
            this.pnlBody.Controls.Add(this.txtPasswordConfirm);
            this.pnlBody.Controls.Add(this.cbActive);
            this.pnlBody.Controls.Add(this.lblPassword);
            this.pnlBody.Controls.Add(this.lblUsername);
            this.pnlBody.Controls.Add(this.txtPassword);
            this.pnlBody.Controls.Add(this.txtUsername);
            this.pnlBody.Location = new System.Drawing.Point(0, 39);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(504, 287);
            this.pnlBody.TabIndex = 0;
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Location = new System.Drawing.Point(280, 132);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(147, 20);
            this.lblConfirm.TabIndex = 4;
            this.lblConfirm.Text = "Confirm Password*:";
            // 
            // txtPasswordConfirm
            // 
            this.txtPasswordConfirm.Location = new System.Drawing.Point(274, 165);
            this.txtPasswordConfirm.Name = "txtPasswordConfirm";
            this.txtPasswordConfirm.Size = new System.Drawing.Size(204, 26);
            this.txtPasswordConfirm.TabIndex = 5;
            this.txtPasswordConfirm.UseSystemPasswordChar = true;
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Checked = true;
            this.cbActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbActive.Location = new System.Drawing.Point(33, 236);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(78, 24);
            this.cbActive.TabIndex = 6;
            this.cbActive.Text = "Active";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(29, 130);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(88, 20);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password*:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(29, 30);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(93, 20);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username*:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(33, 165);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(204, 26);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(33, 69);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(204, 26);
            this.txtUsername.TabIndex = 1;
            // 
            // UserAdministration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(505, 475);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserAdministration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Administration";
            this.Load += new System.EventHandler(this.UserAdministration_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlValidationErrors.ResumeLayout(false);
            this.pnlValidationErrors.PerformLayout();
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
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.TextBox txtPasswordConfirm;
        private System.Windows.Forms.Label lblConfirm;
    }
}