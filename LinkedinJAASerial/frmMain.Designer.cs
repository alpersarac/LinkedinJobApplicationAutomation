﻿namespace LinkedinJAASerial
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chbxInfoExtrator = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxDays = new System.Windows.Forms.ComboBox();
            this.rtbxLicence = new System.Windows.Forms.RichTextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.btnGenerateLicence = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblLicenceKey = new System.Windows.Forms.Label();
            this.lblEmailSearch = new System.Windows.Forms.Label();
            this.tbxEmailVerification = new System.Windows.Forms.TextBox();
            this.rtbxResult = new System.Windows.Forms.RichTextBox();
            this.tbxLicence = new System.Windows.Forms.TextBox();
            this.btnSearchLicence = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lwStats = new System.Windows.Forms.ListView();
            this.lblActiveCount = new System.Windows.Forms.Label();
            this.btnStats = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnGenerateConnectionStringFile = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.rhtbxEncrypted = new System.Windows.Forms.RichTextBox();
            this.tbxEncryptLicence = new System.Windows.Forms.TextBox();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.ftpTab = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.tbxFtpPasswordEncrypted = new System.Windows.Forms.TextBox();
            this.tbxFtpPassword = new System.Windows.Forms.TextBox();
            this.tbxFtpUserNameEncrypted = new System.Windows.Forms.TextBox();
            this.tbxFtpUserName = new System.Windows.Forms.TextBox();
            this.tbxIpEncrypted = new System.Windows.Forms.TextBox();
            this.tbxIpClear = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.ftpTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.ftpTab);
            this.tabControl1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1111, 421);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chbxInfoExtrator);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cbxDays);
            this.tabPage1.Controls.Add(this.rtbxLicence);
            this.tabPage1.Controls.Add(this.lblEmail);
            this.tabPage1.Controls.Add(this.tbxEmail);
            this.tabPage1.Controls.Add(this.btnGenerateLicence);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1103, 392);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Generation";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chbxInfoExtrator
            // 
            this.chbxInfoExtrator.AutoSize = true;
            this.chbxInfoExtrator.Location = new System.Drawing.Point(453, 6);
            this.chbxInfoExtrator.Name = "chbxInfoExtrator";
            this.chbxInfoExtrator.Size = new System.Drawing.Size(90, 20);
            this.chbxInfoExtrator.TabIndex = 20;
            this.chbxInfoExtrator.Text = "Info Extrator";
            this.chbxInfoExtrator.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Days:";
            // 
            // cbxDays
            // 
            this.cbxDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDays.FormattingEnabled = true;
            this.cbxDays.Items.AddRange(new object[] {
            "3",
            "7",
            "14",
            "21",
            "30"});
            this.cbxDays.Location = new System.Drawing.Point(50, 30);
            this.cbxDays.Name = "cbxDays";
            this.cbxDays.Size = new System.Drawing.Size(70, 24);
            this.cbxDays.TabIndex = 18;
            // 
            // rtbxLicence
            // 
            this.rtbxLicence.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbxLicence.Location = new System.Drawing.Point(6, 65);
            this.rtbxLicence.Name = "rtbxLicence";
            this.rtbxLicence.Size = new System.Drawing.Size(785, 321);
            this.rtbxLicence.TabIndex = 17;
            this.rtbxLicence.Text = "";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(6, 3);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 16);
            this.lblEmail.TabIndex = 16;
            this.lblEmail.Text = "Email:";
            // 
            // tbxEmail
            // 
            this.tbxEmail.Location = new System.Drawing.Point(50, 3);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.Size = new System.Drawing.Size(290, 21);
            this.tbxEmail.TabIndex = 15;
            // 
            // btnGenerateLicence
            // 
            this.btnGenerateLicence.Location = new System.Drawing.Point(357, 3);
            this.btnGenerateLicence.Name = "btnGenerateLicence";
            this.btnGenerateLicence.Size = new System.Drawing.Size(77, 23);
            this.btnGenerateLicence.TabIndex = 11;
            this.btnGenerateLicence.Text = "Generate Licence";
            this.btnGenerateLicence.UseVisualStyleBackColor = true;
            this.btnGenerateLicence.Click += new System.EventHandler(this.btnGenerateLicence_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblLicenceKey);
            this.tabPage2.Controls.Add(this.lblEmailSearch);
            this.tabPage2.Controls.Add(this.tbxEmailVerification);
            this.tabPage2.Controls.Add(this.rtbxResult);
            this.tabPage2.Controls.Add(this.tbxLicence);
            this.tabPage2.Controls.Add(this.btnSearchLicence);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1103, 392);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Search";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblLicenceKey
            // 
            this.lblLicenceKey.AutoSize = true;
            this.lblLicenceKey.Location = new System.Drawing.Point(13, 32);
            this.lblLicenceKey.Name = "lblLicenceKey";
            this.lblLicenceKey.Size = new System.Drawing.Size(72, 16);
            this.lblLicenceKey.TabIndex = 26;
            this.lblLicenceKey.Text = "LicenceKey:";
            // 
            // lblEmailSearch
            // 
            this.lblEmailSearch.AutoSize = true;
            this.lblEmailSearch.Location = new System.Drawing.Point(47, 6);
            this.lblEmailSearch.Name = "lblEmailSearch";
            this.lblEmailSearch.Size = new System.Drawing.Size(38, 16);
            this.lblEmailSearch.TabIndex = 25;
            this.lblEmailSearch.Text = "Email:";
            // 
            // tbxEmailVerification
            // 
            this.tbxEmailVerification.Location = new System.Drawing.Point(91, 6);
            this.tbxEmailVerification.Name = "tbxEmailVerification";
            this.tbxEmailVerification.Size = new System.Drawing.Size(290, 21);
            this.tbxEmailVerification.TabIndex = 24;
            // 
            // rtbxResult
            // 
            this.rtbxResult.Location = new System.Drawing.Point(16, 59);
            this.rtbxResult.Name = "rtbxResult";
            this.rtbxResult.Size = new System.Drawing.Size(775, 327);
            this.rtbxResult.TabIndex = 23;
            this.rtbxResult.Text = "";
            // 
            // tbxLicence
            // 
            this.tbxLicence.Location = new System.Drawing.Point(91, 32);
            this.tbxLicence.Name = "tbxLicence";
            this.tbxLicence.Size = new System.Drawing.Size(290, 21);
            this.tbxLicence.TabIndex = 22;
            // 
            // btnSearchLicence
            // 
            this.btnSearchLicence.Location = new System.Drawing.Point(408, 6);
            this.btnSearchLicence.Name = "btnSearchLicence";
            this.btnSearchLicence.Size = new System.Drawing.Size(80, 46);
            this.btnSearchLicence.TabIndex = 21;
            this.btnSearchLicence.Text = "Search";
            this.btnSearchLicence.UseVisualStyleBackColor = true;
            this.btnSearchLicence.Click += new System.EventHandler(this.btnSearchLicence_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lwStats);
            this.tabPage3.Controls.Add(this.lblActiveCount);
            this.tabPage3.Controls.Add(this.btnStats);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1103, 392);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Stats";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lwStats
            // 
            this.lwStats.FullRowSelect = true;
            this.lwStats.HideSelection = false;
            this.lwStats.Location = new System.Drawing.Point(6, 35);
            this.lwStats.Name = "lwStats";
            this.lwStats.Size = new System.Drawing.Size(1091, 351);
            this.lwStats.TabIndex = 3;
            this.lwStats.UseCompatibleStateImageBehavior = false;
            // 
            // lblActiveCount
            // 
            this.lblActiveCount.AutoSize = true;
            this.lblActiveCount.Location = new System.Drawing.Point(87, 9);
            this.lblActiveCount.Name = "lblActiveCount";
            this.lblActiveCount.Size = new System.Drawing.Size(25, 16);
            this.lblActiveCount.TabIndex = 2;
            this.lblActiveCount.Text = "      ";
            // 
            // btnStats
            // 
            this.btnStats.Location = new System.Drawing.Point(6, 6);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(75, 23);
            this.btnStats.TabIndex = 0;
            this.btnStats.Text = "Show Stats";
            this.btnStats.UseVisualStyleBackColor = true;
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.richTextBox1);
            this.tabPage4.Controls.Add(this.btnGenerateConnectionStringFile);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1103, 392);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Connection String";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 35);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(547, 281);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // btnGenerateConnectionStringFile
            // 
            this.btnGenerateConnectionStringFile.Location = new System.Drawing.Point(169, 6);
            this.btnGenerateConnectionStringFile.Name = "btnGenerateConnectionStringFile";
            this.btnGenerateConnectionStringFile.Size = new System.Drawing.Size(224, 23);
            this.btnGenerateConnectionStringFile.TabIndex = 0;
            this.btnGenerateConnectionStringFile.Text = "Generate Connection String";
            this.btnGenerateConnectionStringFile.UseVisualStyleBackColor = true;
            this.btnGenerateConnectionStringFile.Click += new System.EventHandler(this.btnGenerateConnectionStringFile_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.rhtbxEncrypted);
            this.tabPage5.Controls.Add(this.tbxEncryptLicence);
            this.tabPage5.Controls.Add(this.btnDecrypt);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1103, 392);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Decryption";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // rhtbxEncrypted
            // 
            this.rhtbxEncrypted.Location = new System.Drawing.Point(6, 62);
            this.rhtbxEncrypted.Name = "rhtbxEncrypted";
            this.rhtbxEncrypted.Size = new System.Drawing.Size(547, 128);
            this.rhtbxEncrypted.TabIndex = 2;
            this.rhtbxEncrypted.Text = "";
            // 
            // tbxEncryptLicence
            // 
            this.tbxEncryptLicence.Location = new System.Drawing.Point(6, 6);
            this.tbxEncryptLicence.Name = "tbxEncryptLicence";
            this.tbxEncryptLicence.Size = new System.Drawing.Size(547, 21);
            this.tbxEncryptLicence.TabIndex = 1;
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(6, 33);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(547, 23);
            this.btnDecrypt.TabIndex = 0;
            this.btnDecrypt.Text = "Encrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnEncrpt_Click_1);
            // 
            // ftpTab
            // 
            this.ftpTab.Controls.Add(this.button1);
            this.ftpTab.Controls.Add(this.textBox1);
            this.ftpTab.Controls.Add(this.textBox2);
            this.ftpTab.Controls.Add(this.textBox3);
            this.ftpTab.Controls.Add(this.textBox4);
            this.ftpTab.Controls.Add(this.textBox5);
            this.ftpTab.Controls.Add(this.textBox6);
            this.ftpTab.Controls.Add(this.btnEncrypt);
            this.ftpTab.Controls.Add(this.tbxFtpPasswordEncrypted);
            this.ftpTab.Controls.Add(this.tbxFtpPassword);
            this.ftpTab.Controls.Add(this.tbxFtpUserNameEncrypted);
            this.ftpTab.Controls.Add(this.tbxFtpUserName);
            this.ftpTab.Controls.Add(this.tbxIpEncrypted);
            this.ftpTab.Controls.Add(this.tbxIpClear);
            this.ftpTab.Location = new System.Drawing.Point(4, 25);
            this.ftpTab.Name = "ftpTab";
            this.ftpTab.Padding = new System.Windows.Forms.Padding(3);
            this.ftpTab.Size = new System.Drawing.Size(1103, 392);
            this.ftpTab.TabIndex = 5;
            this.ftpTab.Text = "FTP";
            this.ftpTab.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(520, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(410, 33);
            this.button1.TabIndex = 13;
            this.button1.Text = "Decrypt";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(735, 107);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(195, 21);
            this.textBox1.TabIndex = 12;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(520, 107);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(195, 21);
            this.textBox2.TabIndex = 11;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(735, 70);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(195, 21);
            this.textBox3.TabIndex = 10;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(520, 70);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(195, 21);
            this.textBox4.TabIndex = 9;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(735, 30);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(195, 21);
            this.textBox5.TabIndex = 8;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(520, 30);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(195, 21);
            this.textBox6.TabIndex = 7;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(28, 144);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(410, 33);
            this.btnEncrypt.TabIndex = 6;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // tbxFtpPasswordEncrypted
            // 
            this.tbxFtpPasswordEncrypted.Location = new System.Drawing.Point(243, 107);
            this.tbxFtpPasswordEncrypted.Name = "tbxFtpPasswordEncrypted";
            this.tbxFtpPasswordEncrypted.Size = new System.Drawing.Size(195, 21);
            this.tbxFtpPasswordEncrypted.TabIndex = 5;
            // 
            // tbxFtpPassword
            // 
            this.tbxFtpPassword.Location = new System.Drawing.Point(28, 107);
            this.tbxFtpPassword.Name = "tbxFtpPassword";
            this.tbxFtpPassword.Size = new System.Drawing.Size(195, 21);
            this.tbxFtpPassword.TabIndex = 4;
            // 
            // tbxFtpUserNameEncrypted
            // 
            this.tbxFtpUserNameEncrypted.Location = new System.Drawing.Point(243, 70);
            this.tbxFtpUserNameEncrypted.Name = "tbxFtpUserNameEncrypted";
            this.tbxFtpUserNameEncrypted.Size = new System.Drawing.Size(195, 21);
            this.tbxFtpUserNameEncrypted.TabIndex = 3;
            // 
            // tbxFtpUserName
            // 
            this.tbxFtpUserName.Location = new System.Drawing.Point(28, 70);
            this.tbxFtpUserName.Name = "tbxFtpUserName";
            this.tbxFtpUserName.Size = new System.Drawing.Size(195, 21);
            this.tbxFtpUserName.TabIndex = 2;
            // 
            // tbxIpEncrypted
            // 
            this.tbxIpEncrypted.Location = new System.Drawing.Point(243, 30);
            this.tbxIpEncrypted.Name = "tbxIpEncrypted";
            this.tbxIpEncrypted.Size = new System.Drawing.Size(195, 21);
            this.tbxIpEncrypted.TabIndex = 1;
            // 
            // tbxIpClear
            // 
            this.tbxIpClear.Location = new System.Drawing.Point(28, 30);
            this.tbxIpClear.Name = "tbxIpClear";
            this.tbxIpClear.Size = new System.Drawing.Size(195, 21);
            this.tbxIpClear.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 438);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serial";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ftpTab.ResumeLayout(false);
            this.ftpTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox rtbxLicence;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox tbxEmail;
        private System.Windows.Forms.Button btnGenerateLicence;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblLicenceKey;
        private System.Windows.Forms.Label lblEmailSearch;
        private System.Windows.Forms.TextBox tbxEmailVerification;
        private System.Windows.Forms.RichTextBox rtbxResult;
        private System.Windows.Forms.TextBox tbxLicence;
        private System.Windows.Forms.Button btnSearchLicence;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnStats;
        private System.Windows.Forms.Label lblActiveCount;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnGenerateConnectionStringFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxDays;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.RichTextBox rhtbxEncrypted;
        private System.Windows.Forms.TextBox tbxEncryptLicence;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.ListView lwStats;
        private System.Windows.Forms.CheckBox chbxInfoExtrator;
        private System.Windows.Forms.TabPage ftpTab;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.TextBox tbxFtpPasswordEncrypted;
        private System.Windows.Forms.TextBox tbxFtpPassword;
        private System.Windows.Forms.TextBox tbxFtpUserNameEncrypted;
        private System.Windows.Forms.TextBox tbxFtpUserName;
        private System.Windows.Forms.TextBox tbxIpEncrypted;
        private System.Windows.Forms.TextBox tbxIpClear;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
    }
}

