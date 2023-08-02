namespace LinkedinJobApplier
{
    partial class frmSplash
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
            this.progressBarSplash = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblProgress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBarSplash
            // 
            this.progressBarSplash.Location = new System.Drawing.Point(141, 127);
            this.progressBarSplash.MarqueeAnimationSpeed = 25;
            this.progressBarSplash.Name = "progressBarSplash";
            this.progressBarSplash.Size = new System.Drawing.Size(272, 23);
            this.progressBarSplash.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarSplash.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LinkedinJobApplier.Properties.Resources.linkedinApplierIcon;
            this.pictureBox1.Location = new System.Drawing.Point(219, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(238, 153);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(70, 13);
            this.lblProgress.TabIndex = 2;
            this.lblProgress.Text = "Please Wait..";
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 173);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.progressBarSplash);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSplash";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarSplash;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblProgress;
    }
}