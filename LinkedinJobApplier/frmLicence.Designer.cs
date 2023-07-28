namespace LinkedinJobApplier
{
    partial class frmLicence
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLicence));
            this.tbxLicence = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblRegStatus = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblSerialKey = new System.Windows.Forms.Label();
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.logoPctrbx = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoPctrbx)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxLicence
            // 
            this.tbxLicence.Location = new System.Drawing.Point(107, 164);
            this.tbxLicence.Margin = new System.Windows.Forms.Padding(4);
            this.tbxLicence.Name = "tbxLicence";
            this.tbxLicence.Size = new System.Drawing.Size(362, 21);
            this.tbxLicence.TabIndex = 0;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegister.Location = new System.Drawing.Point(106, 238);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(88, 28);
            this.btnRegister.TabIndex = 1;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(253, 302);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(70, 16);
            this.lblResult.TabIndex = 2;
            this.lblResult.Text = "                     ";
            // 
            // lblRegStatus
            // 
            this.lblRegStatus.AutoSize = true;
            this.lblRegStatus.BackColor = System.Drawing.Color.White;
            this.lblRegStatus.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblRegStatus.Location = new System.Drawing.Point(222, 331);
            this.lblRegStatus.Name = "lblRegStatus";
            this.lblRegStatus.Size = new System.Drawing.Size(128, 16);
            this.lblRegStatus.TabIndex = 3;
            this.lblRegStatus.Text = "You are not registered.";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.RosyBrown;
            this.btnExit.Location = new System.Drawing.Point(381, 237);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(88, 28);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblSerialKey
            // 
            this.lblSerialKey.AutoSize = true;
            this.lblSerialKey.Location = new System.Drawing.Point(105, 142);
            this.lblSerialKey.Name = "lblSerialKey";
            this.lblSerialKey.Size = new System.Drawing.Size(61, 16);
            this.lblSerialKey.TabIndex = 5;
            this.lblSerialKey.Text = "Serial Key:";
            // 
            // tbxEmail
            // 
            this.tbxEmail.Location = new System.Drawing.Point(108, 209);
            this.tbxEmail.Margin = new System.Windows.Forms.Padding(4);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.Size = new System.Drawing.Size(362, 21);
            this.tbxEmail.TabIndex = 6;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(105, 189);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 16);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(216, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Linkedin Applier";
            // 
            // logoPctrbx
            // 
            this.logoPctrbx.Image = global::LinkedinJobApplier.Properties.Resources.linkedinApplierIcon;
            this.logoPctrbx.Location = new System.Drawing.Point(243, 12);
            this.logoPctrbx.Name = "logoPctrbx";
            this.logoPctrbx.Size = new System.Drawing.Size(80, 80);
            this.logoPctrbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPctrbx.TabIndex = 8;
            this.logoPctrbx.TabStop = false;
            // 
            // frmLicence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(558, 359);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logoPctrbx);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.tbxEmail);
            this.Controls.Add(this.lblSerialKey);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblRegStatus);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.tbxLicence);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLicence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Licence";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLicence_FormClosing);
            this.Load += new System.EventHandler(this.frmLicence_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logoPctrbx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxLicence;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblRegStatus;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblSerialKey;
        private System.Windows.Forms.TextBox tbxEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.PictureBox logoPctrbx;
        private System.Windows.Forms.Label label1;
    }
}