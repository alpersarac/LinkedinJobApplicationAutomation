namespace LinkedinJobApplier
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnStartApplying = new System.Windows.Forms.Button();
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.grbxCredentials = new System.Windows.Forms.GroupBox();
            this.chbxRememberMe = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grbxPreferences = new System.Windows.Forms.GroupBox();
            this.btnClearKeywords = new System.Windows.Forms.Button();
            this.btnClearLocation = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxDatePosted = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxKeywords = new System.Windows.Forms.TextBox();
            this.btnAddKeyword = new System.Windows.Forms.Button();
            this.lbxKeywords = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxLocation = new System.Windows.Forms.TextBox();
            this.btnAddCountry = new System.Windows.Forms.Button();
            this.lbxLocations = new System.Windows.Forms.ListBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnStopApplying = new System.Windows.Forms.Button();
            this.grbxCredentials.SuspendLayout();
            this.grbxPreferences.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartApplying
            // 
            this.btnStartApplying.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnStartApplying.Location = new System.Drawing.Point(35, 192);
            this.btnStartApplying.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartApplying.Name = "btnStartApplying";
            this.btnStartApplying.Size = new System.Drawing.Size(132, 79);
            this.btnStartApplying.TabIndex = 0;
            this.btnStartApplying.Text = "Start Applying";
            this.btnStartApplying.UseVisualStyleBackColor = true;
            this.btnStartApplying.Click += new System.EventHandler(this.btnStartApplying_Click);
            // 
            // tbxEmail
            // 
            this.tbxEmail.ForeColor = System.Drawing.Color.DarkGreen;
            this.tbxEmail.Location = new System.Drawing.Point(79, 40);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.Size = new System.Drawing.Size(233, 21);
            this.tbxEmail.TabIndex = 1;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblUserName.Location = new System.Drawing.Point(10, 43);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(64, 16);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "Username:";
            // 
            // tbxPassword
            // 
            this.tbxPassword.ForeColor = System.Drawing.Color.DarkGreen;
            this.tbxPassword.Location = new System.Drawing.Point(79, 67);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(233, 21);
            this.tbxPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblPassword.Location = new System.Drawing.Point(10, 72);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 16);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password:";
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnSave.Location = new System.Drawing.Point(79, 94);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(233, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Sign In";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grbxCredentials
            // 
            this.grbxCredentials.Controls.Add(this.label2);
            this.grbxCredentials.Controls.Add(this.tbxEmail);
            this.grbxCredentials.Controls.Add(this.btnSave);
            this.grbxCredentials.Controls.Add(this.lblUserName);
            this.grbxCredentials.Controls.Add(this.lblPassword);
            this.grbxCredentials.Controls.Add(this.tbxPassword);
            this.grbxCredentials.ForeColor = System.Drawing.Color.DarkGreen;
            this.grbxCredentials.Location = new System.Drawing.Point(12, 12);
            this.grbxCredentials.Name = "grbxCredentials";
            this.grbxCredentials.Size = new System.Drawing.Size(336, 130);
            this.grbxCredentials.TabIndex = 6;
            this.grbxCredentials.TabStop = false;
            // 
            // chbxRememberMe
            // 
            this.chbxRememberMe.AutoSize = true;
            this.chbxRememberMe.Location = new System.Drawing.Point(541, 447);
            this.chbxRememberMe.Name = "chbxRememberMe";
            this.chbxRememberMe.Size = new System.Drawing.Size(146, 20);
            this.chbxRememberMe.TabIndex = 7;
            this.chbxRememberMe.Text = "Remember my settings";
            this.chbxRememberMe.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(10, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "LinkedIn Username and Password";
            // 
            // grbxPreferences
            // 
            this.grbxPreferences.Controls.Add(this.chbxRememberMe);
            this.grbxPreferences.Controls.Add(this.btnClearKeywords);
            this.grbxPreferences.Controls.Add(this.btnClearLocation);
            this.grbxPreferences.Controls.Add(this.label4);
            this.grbxPreferences.Controls.Add(this.cbxDatePosted);
            this.grbxPreferences.Controls.Add(this.label3);
            this.grbxPreferences.Controls.Add(this.tbxKeywords);
            this.grbxPreferences.Controls.Add(this.btnAddKeyword);
            this.grbxPreferences.Controls.Add(this.lbxKeywords);
            this.grbxPreferences.Controls.Add(this.label1);
            this.grbxPreferences.Controls.Add(this.tbxLocation);
            this.grbxPreferences.Controls.Add(this.btnAddCountry);
            this.grbxPreferences.Controls.Add(this.lbxLocations);
            this.grbxPreferences.ForeColor = System.Drawing.Color.DarkGreen;
            this.grbxPreferences.Location = new System.Drawing.Point(354, 12);
            this.grbxPreferences.Name = "grbxPreferences";
            this.grbxPreferences.Size = new System.Drawing.Size(698, 473);
            this.grbxPreferences.TabIndex = 7;
            this.grbxPreferences.TabStop = false;
            // 
            // btnClearKeywords
            // 
            this.btnClearKeywords.Location = new System.Drawing.Point(541, 175);
            this.btnClearKeywords.Name = "btnClearKeywords";
            this.btnClearKeywords.Size = new System.Drawing.Size(75, 28);
            this.btnClearKeywords.TabIndex = 11;
            this.btnClearKeywords.Text = "Clear";
            this.btnClearKeywords.UseVisualStyleBackColor = true;
            this.btnClearKeywords.Click += new System.EventHandler(this.btnClearKeywords_Click);
            // 
            // btnClearLocation
            // 
            this.btnClearLocation.Location = new System.Drawing.Point(219, 174);
            this.btnClearLocation.Name = "btnClearLocation";
            this.btnClearLocation.Size = new System.Drawing.Size(75, 28);
            this.btnClearLocation.TabIndex = 10;
            this.btnClearLocation.Text = "Clear";
            this.btnClearLocation.UseVisualStyleBackColor = true;
            this.btnClearLocation.Click += new System.EventHandler(this.btnClearLocation_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Date Posted:";
            // 
            // cbxDatePosted
            // 
            this.cbxDatePosted.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDatePosted.FormattingEnabled = true;
            this.cbxDatePosted.Items.AddRange(new object[] {
            "Any Time",
            "Past Month",
            "Past Week",
            "Past 24 Hours"});
            this.cbxDatePosted.Location = new System.Drawing.Point(15, 235);
            this.cbxDatePosted.Name = "cbxDatePosted";
            this.cbxDatePosted.Size = new System.Drawing.Size(121, 24);
            this.cbxDatePosted.TabIndex = 8;
            this.cbxDatePosted.SelectedIndexChanged += new System.EventHandler(this.cbxDatePosted_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkGreen;
            this.label3.Location = new System.Drawing.Point(334, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Keywords:";
            // 
            // tbxKeywords
            // 
            this.tbxKeywords.ForeColor = System.Drawing.Color.DarkGreen;
            this.tbxKeywords.Location = new System.Drawing.Point(337, 40);
            this.tbxKeywords.Name = "tbxKeywords";
            this.tbxKeywords.Size = new System.Drawing.Size(196, 21);
            this.tbxKeywords.TabIndex = 7;
            // 
            // btnAddKeyword
            // 
            this.btnAddKeyword.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnAddKeyword.Location = new System.Drawing.Point(541, 38);
            this.btnAddKeyword.Name = "btnAddKeyword";
            this.btnAddKeyword.Size = new System.Drawing.Size(75, 26);
            this.btnAddKeyword.TabIndex = 6;
            this.btnAddKeyword.Text = "Add";
            this.btnAddKeyword.UseVisualStyleBackColor = true;
            this.btnAddKeyword.Click += new System.EventHandler(this.btnAddKeyword_Click);
            // 
            // lbxKeywords
            // 
            this.lbxKeywords.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbxKeywords.FormattingEnabled = true;
            this.lbxKeywords.ItemHeight = 16;
            this.lbxKeywords.Location = new System.Drawing.Point(337, 68);
            this.lbxKeywords.Name = "lbxKeywords";
            this.lbxKeywords.Size = new System.Drawing.Size(279, 100);
            this.lbxKeywords.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Locations:";
            // 
            // tbxLocation
            // 
            this.tbxLocation.ForeColor = System.Drawing.Color.DarkGreen;
            this.tbxLocation.Location = new System.Drawing.Point(15, 40);
            this.tbxLocation.Name = "tbxLocation";
            this.tbxLocation.Size = new System.Drawing.Size(196, 21);
            this.tbxLocation.TabIndex = 3;
            // 
            // btnAddCountry
            // 
            this.btnAddCountry.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnAddCountry.Location = new System.Drawing.Point(219, 38);
            this.btnAddCountry.Name = "btnAddCountry";
            this.btnAddCountry.Size = new System.Drawing.Size(75, 26);
            this.btnAddCountry.TabIndex = 2;
            this.btnAddCountry.Text = "Add";
            this.btnAddCountry.UseVisualStyleBackColor = true;
            this.btnAddCountry.Click += new System.EventHandler(this.btnAddCountry_Click);
            // 
            // lbxLocations
            // 
            this.lbxLocations.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbxLocations.FormattingEnabled = true;
            this.lbxLocations.ItemHeight = 16;
            this.lbxLocations.Location = new System.Drawing.Point(15, 68);
            this.lbxLocations.Name = "lbxLocations";
            this.lbxLocations.Size = new System.Drawing.Size(279, 100);
            this.lbxLocations.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(9, 469);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 16);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "status";
            // 
            // btnStopApplying
            // 
            this.btnStopApplying.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnStopApplying.Location = new System.Drawing.Point(175, 192);
            this.btnStopApplying.Margin = new System.Windows.Forms.Padding(4);
            this.btnStopApplying.Name = "btnStopApplying";
            this.btnStopApplying.Size = new System.Drawing.Size(132, 79);
            this.btnStopApplying.TabIndex = 9;
            this.btnStopApplying.Text = "Stop Applying";
            this.btnStopApplying.UseVisualStyleBackColor = true;
            this.btnStopApplying.Click += new System.EventHandler(this.btnStopApplying_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1064, 495);
            this.Controls.Add(this.btnStopApplying);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.grbxPreferences);
            this.Controls.Add(this.grbxCredentials);
            this.Controls.Add(this.btnStartApplying);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grbxCredentials.ResumeLayout(false);
            this.grbxCredentials.PerformLayout();
            this.grbxPreferences.ResumeLayout(false);
            this.grbxPreferences.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartApplying;
        private System.Windows.Forms.TextBox tbxEmail;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grbxCredentials;
        private System.Windows.Forms.GroupBox grbxPreferences;
        private System.Windows.Forms.Button btnAddCountry;
        private System.Windows.Forms.ListBox lbxLocations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxKeywords;
        private System.Windows.Forms.Button btnAddKeyword;
        private System.Windows.Forms.ListBox lbxKeywords;
        private System.Windows.Forms.CheckBox chbxRememberMe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxDatePosted;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnClearKeywords;
        private System.Windows.Forms.Button btnClearLocation;
        private System.Windows.Forms.Button btnStopApplying;
    }
}

