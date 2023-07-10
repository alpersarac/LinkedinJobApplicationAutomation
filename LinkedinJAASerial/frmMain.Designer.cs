namespace LinkedinJAASerial
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
            this.btnStats = new System.Windows.Forms.Button();
            this.listbStats = new System.Windows.Forms.ListBox();
            this.lblActiveCount = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
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
            this.tabControl1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(568, 387);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rtbxLicence);
            this.tabPage1.Controls.Add(this.lblEmail);
            this.tabPage1.Controls.Add(this.tbxEmail);
            this.tabPage1.Controls.Add(this.btnGenerateLicence);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(560, 358);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Generation";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rtbxLicence
            // 
            this.rtbxLicence.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbxLicence.Location = new System.Drawing.Point(111, 65);
            this.rtbxLicence.Name = "rtbxLicence";
            this.rtbxLicence.Size = new System.Drawing.Size(290, 123);
            this.rtbxLicence.TabIndex = 17;
            this.rtbxLicence.Text = "";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(67, 9);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 16);
            this.lblEmail.TabIndex = 16;
            this.lblEmail.Text = "Email:";
            // 
            // tbxEmail
            // 
            this.tbxEmail.Location = new System.Drawing.Point(111, 9);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.Size = new System.Drawing.Size(290, 21);
            this.tbxEmail.TabIndex = 15;
            // 
            // btnGenerateLicence
            // 
            this.btnGenerateLicence.Location = new System.Drawing.Point(111, 36);
            this.btnGenerateLicence.Name = "btnGenerateLicence";
            this.btnGenerateLicence.Size = new System.Drawing.Size(290, 23);
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
            this.tabPage2.Size = new System.Drawing.Size(560, 358);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Search";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblLicenceKey
            // 
            this.lblLicenceKey.AutoSize = true;
            this.lblLicenceKey.Location = new System.Drawing.Point(33, 35);
            this.lblLicenceKey.Name = "lblLicenceKey";
            this.lblLicenceKey.Size = new System.Drawing.Size(72, 16);
            this.lblLicenceKey.TabIndex = 26;
            this.lblLicenceKey.Text = "LicenceKey:";
            // 
            // lblEmailSearch
            // 
            this.lblEmailSearch.AutoSize = true;
            this.lblEmailSearch.Location = new System.Drawing.Point(67, 9);
            this.lblEmailSearch.Name = "lblEmailSearch";
            this.lblEmailSearch.Size = new System.Drawing.Size(38, 16);
            this.lblEmailSearch.TabIndex = 25;
            this.lblEmailSearch.Text = "Email:";
            // 
            // tbxEmailVerification
            // 
            this.tbxEmailVerification.Location = new System.Drawing.Point(111, 9);
            this.tbxEmailVerification.Name = "tbxEmailVerification";
            this.tbxEmailVerification.Size = new System.Drawing.Size(290, 21);
            this.tbxEmailVerification.TabIndex = 24;
            // 
            // rtbxResult
            // 
            this.rtbxResult.Location = new System.Drawing.Point(111, 90);
            this.rtbxResult.Name = "rtbxResult";
            this.rtbxResult.Size = new System.Drawing.Size(290, 96);
            this.rtbxResult.TabIndex = 23;
            this.rtbxResult.Text = "";
            // 
            // tbxLicence
            // 
            this.tbxLicence.Location = new System.Drawing.Point(111, 35);
            this.tbxLicence.Name = "tbxLicence";
            this.tbxLicence.Size = new System.Drawing.Size(290, 21);
            this.tbxLicence.TabIndex = 22;
            // 
            // btnSearchLicence
            // 
            this.btnSearchLicence.Location = new System.Drawing.Point(111, 61);
            this.btnSearchLicence.Name = "btnSearchLicence";
            this.btnSearchLicence.Size = new System.Drawing.Size(290, 23);
            this.btnSearchLicence.TabIndex = 21;
            this.btnSearchLicence.Text = "Search";
            this.btnSearchLicence.UseVisualStyleBackColor = true;
            this.btnSearchLicence.Click += new System.EventHandler(this.btnSearchLicence_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblActiveCount);
            this.tabPage3.Controls.Add(this.listbStats);
            this.tabPage3.Controls.Add(this.btnStats);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(560, 358);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Stats";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            // listbStats
            // 
            this.listbStats.FormattingEnabled = true;
            this.listbStats.ItemHeight = 16;
            this.listbStats.Location = new System.Drawing.Point(6, 35);
            this.listbStats.Name = "listbStats";
            this.listbStats.Size = new System.Drawing.Size(547, 308);
            this.listbStats.TabIndex = 1;
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 402);
            this.Controls.Add(this.tabControl1);
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
        private System.Windows.Forms.ListBox listbStats;
        private System.Windows.Forms.Label lblActiveCount;
    }
}

