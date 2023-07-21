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
            this.grbxCredentials = new System.Windows.Forms.GroupBox();
            this.lblPasswordInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chbxRememberMe = new System.Windows.Forms.CheckBox();
            this.grbxPreferences = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxNoticePeriod = new System.Windows.Forms.TextBox();
            this.lblNoticePeriod = new System.Windows.Forms.Label();
            this.lblCommuting = new System.Windows.Forms.Label();
            this.cbxCommuting = new System.Windows.Forms.ComboBox();
            this.lblVisaSponsorship = new System.Windows.Forms.Label();
            this.cbxVisaSponsorship = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSalaryExpectation = new System.Windows.Forms.Label();
            this.tbxSalary = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxCity = new System.Windows.Forms.TextBox();
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
            this.lblRemainingDays = new System.Windows.Forms.Label();
            this.tabSelection = new System.Windows.Forms.TabControl();
            this.tabJobApplier = new System.Windows.Forms.TabPage();
            this.tabInfoExtractor = new System.Windows.Forms.TabPage();
            this.chbxPhoneNumber = new System.Windows.Forms.CheckBox();
            this.chbxEmail = new System.Windows.Forms.CheckBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbxTitle = new System.Windows.Forms.TextBox();
            this.lbxInfo = new System.Windows.Forms.ListBox();
            this.grbxCredentials.SuspendLayout();
            this.grbxPreferences.SuspendLayout();
            this.tabSelection.SuspendLayout();
            this.tabJobApplier.SuspendLayout();
            this.tabInfoExtractor.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartApplying
            // 
            this.btnStartApplying.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnStartApplying.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnStartApplying.Location = new System.Drawing.Point(35, 192);
            this.btnStartApplying.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartApplying.Name = "btnStartApplying";
            this.btnStartApplying.Size = new System.Drawing.Size(132, 79);
            this.btnStartApplying.TabIndex = 0;
            this.btnStartApplying.Text = "Start Applying";
            this.btnStartApplying.UseVisualStyleBackColor = false;
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
            this.tbxPassword.PasswordChar = '*';
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
            // grbxCredentials
            // 
            this.grbxCredentials.Controls.Add(this.lblPasswordInfo);
            this.grbxCredentials.Controls.Add(this.label2);
            this.grbxCredentials.Controls.Add(this.tbxEmail);
            this.grbxCredentials.Controls.Add(this.lblUserName);
            this.grbxCredentials.Controls.Add(this.lblPassword);
            this.grbxCredentials.Controls.Add(this.tbxPassword);
            this.grbxCredentials.ForeColor = System.Drawing.Color.DarkGreen;
            this.grbxCredentials.Location = new System.Drawing.Point(12, 12);
            this.grbxCredentials.Name = "grbxCredentials";
            this.grbxCredentials.Size = new System.Drawing.Size(336, 122);
            this.grbxCredentials.TabIndex = 6;
            this.grbxCredentials.TabStop = false;
            // 
            // lblPasswordInfo
            // 
            this.lblPasswordInfo.AutoSize = true;
            this.lblPasswordInfo.Font = new System.Drawing.Font("Century Gothic", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordInfo.Location = new System.Drawing.Point(6, 103);
            this.lblPasswordInfo.Name = "lblPasswordInfo";
            this.lblPasswordInfo.Size = new System.Drawing.Size(209, 13);
            this.lblPasswordInfo.TabIndex = 10;
            this.lblPasswordInfo.Text = "We don\'t store your password for your safety";
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
            // chbxRememberMe
            // 
            this.chbxRememberMe.AutoSize = true;
            this.chbxRememberMe.Location = new System.Drawing.Point(895, 487);
            this.chbxRememberMe.Name = "chbxRememberMe";
            this.chbxRememberMe.Size = new System.Drawing.Size(146, 20);
            this.chbxRememberMe.TabIndex = 7;
            this.chbxRememberMe.Text = "Remember my settings";
            this.chbxRememberMe.UseVisualStyleBackColor = true;
            // 
            // grbxPreferences
            // 
            this.grbxPreferences.Controls.Add(this.label8);
            this.grbxPreferences.Controls.Add(this.tbxNoticePeriod);
            this.grbxPreferences.Controls.Add(this.lblNoticePeriod);
            this.grbxPreferences.Controls.Add(this.lblCommuting);
            this.grbxPreferences.Controls.Add(this.cbxCommuting);
            this.grbxPreferences.Controls.Add(this.lblVisaSponsorship);
            this.grbxPreferences.Controls.Add(this.cbxVisaSponsorship);
            this.grbxPreferences.Controls.Add(this.label7);
            this.grbxPreferences.Controls.Add(this.label6);
            this.grbxPreferences.Controls.Add(this.lblSalaryExpectation);
            this.grbxPreferences.Controls.Add(this.tbxSalary);
            this.grbxPreferences.Controls.Add(this.label5);
            this.grbxPreferences.Controls.Add(this.tbxCity);
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
            this.grbxPreferences.Location = new System.Drawing.Point(6, 5);
            this.grbxPreferences.Name = "grbxPreferences";
            this.grbxPreferences.Size = new System.Drawing.Size(653, 430);
            this.grbxPreferences.TabIndex = 7;
            this.grbxPreferences.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Silver;
            this.label8.Location = new System.Drawing.Point(426, 262);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 16);
            this.label8.TabIndex = 25;
            this.label8.Text = "Ex: 14 days";
            // 
            // tbxNoticePeriod
            // 
            this.tbxNoticePeriod.Location = new System.Drawing.Point(429, 238);
            this.tbxNoticePeriod.Name = "tbxNoticePeriod";
            this.tbxNoticePeriod.Size = new System.Drawing.Size(174, 21);
            this.tbxNoticePeriod.TabIndex = 24;
            // 
            // lblNoticePeriod
            // 
            this.lblNoticePeriod.AutoSize = true;
            this.lblNoticePeriod.Location = new System.Drawing.Point(426, 219);
            this.lblNoticePeriod.Name = "lblNoticePeriod";
            this.lblNoticePeriod.Size = new System.Drawing.Size(120, 16);
            this.lblNoticePeriod.TabIndex = 23;
            this.lblNoticePeriod.Text = "Notice Period in days";
            // 
            // lblCommuting
            // 
            this.lblCommuting.AutoSize = true;
            this.lblCommuting.Location = new System.Drawing.Point(12, 339);
            this.lblCommuting.Name = "lblCommuting";
            this.lblCommuting.Size = new System.Drawing.Size(115, 16);
            this.lblCommuting.TabIndex = 21;
            this.lblCommuting.Text = "Ok with commuting:";
            // 
            // cbxCommuting
            // 
            this.cbxCommuting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCommuting.FormattingEnabled = true;
            this.cbxCommuting.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cbxCommuting.Location = new System.Drawing.Point(15, 358);
            this.cbxCommuting.Name = "cbxCommuting";
            this.cbxCommuting.Size = new System.Drawing.Size(143, 24);
            this.cbxCommuting.TabIndex = 20;
            // 
            // lblVisaSponsorship
            // 
            this.lblVisaSponsorship.AutoSize = true;
            this.lblVisaSponsorship.Location = new System.Drawing.Point(12, 275);
            this.lblVisaSponsorship.Name = "lblVisaSponsorship";
            this.lblVisaSponsorship.Size = new System.Drawing.Size(129, 16);
            this.lblVisaSponsorship.TabIndex = 19;
            this.lblVisaSponsorship.Text = "Need visa sponsorship:";
            // 
            // cbxVisaSponsorship
            // 
            this.cbxVisaSponsorship.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVisaSponsorship.FormattingEnabled = true;
            this.cbxVisaSponsorship.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cbxVisaSponsorship.Location = new System.Drawing.Point(15, 294);
            this.cbxVisaSponsorship.Name = "cbxVisaSponsorship";
            this.cbxVisaSponsorship.Size = new System.Drawing.Size(143, 24);
            this.cbxVisaSponsorship.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.Location = new System.Drawing.Point(231, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Ex: 65000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(231, 340);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Ex: Istanbul, Turkey";
            // 
            // lblSalaryExpectation
            // 
            this.lblSalaryExpectation.AutoSize = true;
            this.lblSalaryExpectation.Location = new System.Drawing.Point(231, 216);
            this.lblSalaryExpectation.Name = "lblSalaryExpectation";
            this.lblSalaryExpectation.Size = new System.Drawing.Size(112, 16);
            this.lblSalaryExpectation.TabIndex = 15;
            this.lblSalaryExpectation.Text = "Salary Expectation:";
            // 
            // tbxSalary
            // 
            this.tbxSalary.Location = new System.Drawing.Point(234, 238);
            this.tbxSalary.Name = "tbxSalary";
            this.tbxSalary.Size = new System.Drawing.Size(174, 21);
            this.tbxSalary.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(231, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "City you live:";
            // 
            // tbxCity
            // 
            this.tbxCity.Location = new System.Drawing.Point(234, 316);
            this.tbxCity.Name = "tbxCity";
            this.tbxCity.Size = new System.Drawing.Size(174, 21);
            this.tbxCity.TabIndex = 12;
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
            this.cbxDatePosted.Size = new System.Drawing.Size(143, 24);
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
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Job locations:";
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
            this.lblStatus.Location = new System.Drawing.Point(360, 487);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 16);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status";
            // 
            // btnStopApplying
            // 
            this.btnStopApplying.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnStopApplying.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnStopApplying.Location = new System.Drawing.Point(175, 192);
            this.btnStopApplying.Margin = new System.Windows.Forms.Padding(4);
            this.btnStopApplying.Name = "btnStopApplying";
            this.btnStopApplying.Size = new System.Drawing.Size(132, 79);
            this.btnStopApplying.TabIndex = 9;
            this.btnStopApplying.Text = "Stop Applying";
            this.btnStopApplying.UseVisualStyleBackColor = false;
            this.btnStopApplying.Click += new System.EventHandler(this.btnStopApplying_Click);
            // 
            // lblRemainingDays
            // 
            this.lblRemainingDays.AutoSize = true;
            this.lblRemainingDays.Location = new System.Drawing.Point(9, 487);
            this.lblRemainingDays.Name = "lblRemainingDays";
            this.lblRemainingDays.Size = new System.Drawing.Size(49, 16);
            this.lblRemainingDays.TabIndex = 14;
            this.lblRemainingDays.Text = "Licence";
            // 
            // tabSelection
            // 
            this.tabSelection.Controls.Add(this.tabJobApplier);
            this.tabSelection.Controls.Add(this.tabInfoExtractor);
            this.tabSelection.Location = new System.Drawing.Point(363, 17);
            this.tabSelection.Name = "tabSelection";
            this.tabSelection.SelectedIndex = 0;
            this.tabSelection.Size = new System.Drawing.Size(678, 467);
            this.tabSelection.TabIndex = 15;
            // 
            // tabJobApplier
            // 
            this.tabJobApplier.Controls.Add(this.grbxPreferences);
            this.tabJobApplier.Location = new System.Drawing.Point(4, 25);
            this.tabJobApplier.Name = "tabJobApplier";
            this.tabJobApplier.Padding = new System.Windows.Forms.Padding(3);
            this.tabJobApplier.Size = new System.Drawing.Size(670, 438);
            this.tabJobApplier.TabIndex = 0;
            this.tabJobApplier.Text = "Job Applier";
            this.tabJobApplier.UseVisualStyleBackColor = true;
            // 
            // tabInfoExtractor
            // 
            this.tabInfoExtractor.Controls.Add(this.lbxInfo);
            this.tabInfoExtractor.Controls.Add(this.chbxPhoneNumber);
            this.tabInfoExtractor.Controls.Add(this.chbxEmail);
            this.tabInfoExtractor.Controls.Add(this.lblTitle);
            this.tabInfoExtractor.Controls.Add(this.tbxTitle);
            this.tabInfoExtractor.Location = new System.Drawing.Point(4, 25);
            this.tabInfoExtractor.Name = "tabInfoExtractor";
            this.tabInfoExtractor.Padding = new System.Windows.Forms.Padding(3);
            this.tabInfoExtractor.Size = new System.Drawing.Size(670, 438);
            this.tabInfoExtractor.TabIndex = 1;
            this.tabInfoExtractor.Text = "Info Extrator";
            this.tabInfoExtractor.UseVisualStyleBackColor = true;
            // 
            // chbxPhoneNumber
            // 
            this.chbxPhoneNumber.AutoSize = true;
            this.chbxPhoneNumber.Location = new System.Drawing.Point(382, 13);
            this.chbxPhoneNumber.Name = "chbxPhoneNumber";
            this.chbxPhoneNumber.Size = new System.Drawing.Size(107, 20);
            this.chbxPhoneNumber.TabIndex = 3;
            this.chbxPhoneNumber.Text = "Phone Number";
            this.chbxPhoneNumber.UseVisualStyleBackColor = true;
            // 
            // chbxEmail
            // 
            this.chbxEmail.AutoSize = true;
            this.chbxEmail.Location = new System.Drawing.Point(322, 13);
            this.chbxEmail.Name = "chbxEmail";
            this.chbxEmail.Size = new System.Drawing.Size(54, 20);
            this.chbxEmail.TabIndex = 2;
            this.chbxEmail.Text = "Email";
            this.chbxEmail.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(6, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(30, 16);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Title:";
            // 
            // tbxTitle
            // 
            this.tbxTitle.Location = new System.Drawing.Point(42, 10);
            this.tbxTitle.Name = "tbxTitle";
            this.tbxTitle.Size = new System.Drawing.Size(258, 21);
            this.tbxTitle.TabIndex = 0;
            this.tbxTitle.Text = "Recruiter Hunter";
            // 
            // lbxInfo
            // 
            this.lbxInfo.FormattingEnabled = true;
            this.lbxInfo.ItemHeight = 16;
            this.lbxInfo.Location = new System.Drawing.Point(9, 54);
            this.lbxInfo.Name = "lbxInfo";
            this.lbxInfo.Size = new System.Drawing.Size(655, 372);
            this.lbxInfo.TabIndex = 4;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1050, 511);
            this.Controls.Add(this.tabSelection);
            this.Controls.Add(this.lblRemainingDays);
            this.Controls.Add(this.btnStopApplying);
            this.Controls.Add(this.grbxCredentials);
            this.Controls.Add(this.btnStartApplying);
            this.Controls.Add(this.chbxRememberMe);
            this.Controls.Add(this.lblStatus);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Linkedin Applier";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grbxCredentials.ResumeLayout(false);
            this.grbxCredentials.PerformLayout();
            this.grbxPreferences.ResumeLayout(false);
            this.grbxPreferences.PerformLayout();
            this.tabSelection.ResumeLayout(false);
            this.tabJobApplier.ResumeLayout(false);
            this.tabInfoExtractor.ResumeLayout(false);
            this.tabInfoExtractor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartApplying;
        private System.Windows.Forms.TextBox tbxEmail;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Label lblPassword;
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxCity;
        private System.Windows.Forms.Label lblPasswordInfo;
        private System.Windows.Forms.Label lblRemainingDays;
        private System.Windows.Forms.Label lblSalaryExpectation;
        private System.Windows.Forms.TextBox tbxSalary;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblVisaSponsorship;
        private System.Windows.Forms.ComboBox cbxVisaSponsorship;
        private System.Windows.Forms.TextBox tbxNoticePeriod;
        private System.Windows.Forms.Label lblNoticePeriod;
        private System.Windows.Forms.Label lblCommuting;
        private System.Windows.Forms.ComboBox cbxCommuting;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabControl tabSelection;
        private System.Windows.Forms.TabPage tabJobApplier;
        private System.Windows.Forms.TabPage tabInfoExtractor;
        private System.Windows.Forms.TextBox tbxTitle;
        private System.Windows.Forms.CheckBox chbxPhoneNumber;
        private System.Windows.Forms.CheckBox chbxEmail;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListBox lbxInfo;
    }
}

