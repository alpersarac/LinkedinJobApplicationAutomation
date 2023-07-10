using LinkedinJAASerial;
using LinkedinJAASerialGenerator;
using LinkedinJobApplicationAutomation.Config;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkedinJobApplier
{
    public partial class frmMain : Form
    {
        CancellationTokenSource cts = null;
        IWebDriver driver = null;
        Linkedin linkedin=null;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmLicence frmLicence = new frmLicence();
            try
            {
                // Read the license key from the file
                string readLicenseKey = LicenseKeyManager.ReadLicenseKey();

                // Parse the license key into LicenceTable object
                LicenceTable parsedLicenseTable = LicenseKeyManager.ParseLicenseKey(readLicenseKey);

                if (parsedLicenseTable.expirydate < DateTime.Now)
                {
                    this.Hide();
                    frmLicence.ShowDialog();
                }
                LicenseKeyManager.setOnlineStatus(parsedLicenseTable, true);

                SetDefaultItems();
            }
            catch (Exception)
            {
                this.Hide();
                frmLicence.ShowDialog();
            }

        }
        public void SetDefaultItems()
        {
            try
            {
                cbxDatePosted.SelectedIndex = 0;
                Config.DatePosted.Clear();
                Config.DatePosted.Add(cbxDatePosted.GetItemText(this.cbxDatePosted.SelectedItem));
            }
            catch (Exception)
            {

            }

        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string readLicenseKey = LicenseKeyManager.ReadLicenseKey();

                // Parse the license key into LicenceTable object
                LicenceTable parsedLicenseTable = LicenseKeyManager.ParseLicenseKey(readLicenseKey);
                LicenseKeyManager.setOnlineStatus(parsedLicenseTable, false);
            }
            catch (Exception)
            {

            }

        }
        private async void btnStartApplying_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a cancellation token source
                cts = new CancellationTokenSource();

                // Run the task in a separate thread
                var task = Task.Run(() =>
                {
                    // Your task logic here
                    linkedin = new Linkedin();
                    linkedin.LinkJobApply();

                    // Check if cancellation is requested
                    if (cts.Token.IsCancellationRequested)
                    {
                        linkedin.getWebDriver().Quit();
                        throw new OperationCanceledException(cts.Token);

                    }
                }, cts.Token);
            }
            catch (Exception)
            {

            }
            
        }
        private void btnAddCountry_Click(object sender, EventArgs e)
        {
            try
            {
                lbxLocations.Items.Add(tbxLocation.Text);
                Config.Location.Add(tbxLocation.Text);
                tbxLocation.Text = "";
            }
            catch (Exception)
            {

            }

        }
        private void btnAddKeyword_Click(object sender, EventArgs e)
        {
            try
            {
                lbxKeywords.Items.Add(tbxKeywords.Text);
                Config.Keywords.Add(tbxKeywords.Text);
                tbxKeywords.Text = "";
            }
            catch (Exception)
            {

            }


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Config.Email = tbxEmail.Text;
                Config.Password = tbxPassword.Text;
            }
            catch (Exception)
            {

            }

        }
        private void cbxDatePosted_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Config.DatePosted.Clear();
                Config.DatePosted.Add(cbxDatePosted.GetItemText(this.cbxDatePosted.SelectedItem));
            }
            catch (Exception)
            {

            }

        }
        private void btnClearLocation_Click(object sender, EventArgs e)
        {
            lbxLocations.Items.Clear();
        }
        private void btnClearKeywords_Click(object sender, EventArgs e)
        {
            lbxKeywords.Items.Clear();
        }

        private async void btnStopApplying_Click(object sender, EventArgs e)
        {
            try
            {
                cts.Cancel();
            }
            catch (Exception)
            {
               
            }
           
        }
    }
}
