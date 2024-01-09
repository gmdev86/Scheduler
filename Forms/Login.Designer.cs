
namespace Scheduler.Forms
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnlValidationErrors = new System.Windows.Forms.Panel();
            this.lblValidationErrors = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlValidationErrors.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(7, 23);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(62, 13);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username*:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(7, 82);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(60, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password*:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(10, 44);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsername.MaxLength = 50;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(210, 20);
            this.txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(10, 104);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(210, 20);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.pnlBody, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlFooter, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.pnlValidationErrors, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(745, 442);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.lblUsername);
            this.pnlBody.Controls.Add(this.txtPassword);
            this.pnlBody.Controls.Add(this.txtUsername);
            this.pnlBody.Controls.Add(this.lblPassword);
            this.pnlBody.Location = new System.Drawing.Point(0, 32);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(237, 153);
            this.pnlBody.TabIndex = 0;
            // 
            // pnlFooter
            // 
            this.pnlFooter.AutoSize = true;
            this.pnlFooter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlFooter.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlFooter.Controls.Add(this.btnSettings);
            this.pnlFooter.Controls.Add(this.btnLogin);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFooter.Location = new System.Drawing.Point(0, 185);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(745, 257);
            this.pnlFooter.TabIndex = 1;
            // 
            // btnSettings
            // 
            this.btnSettings.Image = global::Scheduler.Properties.Resources.Settings_16x;
            this.btnSettings.Location = new System.Drawing.Point(10, 16);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(83, 27);
            this.btnSettings.TabIndex = 5;
            this.btnSettings.Text = "Language";
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Image = global::Scheduler.Properties.Resources.GoToReference_16x;
            this.btnLogin.Location = new System.Drawing.Point(132, 16);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 10);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(87, 27);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
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
            this.pnlValidationErrors.Size = new System.Drawing.Size(745, 32);
            this.pnlValidationErrors.TabIndex = 2;
            // 
            // lblValidationErrors
            // 
            this.lblValidationErrors.AutoSize = true;
            this.lblValidationErrors.ForeColor = System.Drawing.Color.Red;
            this.lblValidationErrors.Location = new System.Drawing.Point(12, 9);
            this.lblValidationErrors.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lblValidationErrors.Name = "lblValidationErrors";
            this.lblValidationErrors.Size = new System.Drawing.Size(34, 13);
            this.lblValidationErrors.TabIndex = 0;
            this.lblValidationErrors.Text = "Errors";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(745, 442);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlValidationErrors.ResumeLayout(false);
            this.pnlValidationErrors.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlValidationErrors;
        private System.Windows.Forms.Label lblValidationErrors;
        private System.Windows.Forms.Button btnSettings;
    }
}