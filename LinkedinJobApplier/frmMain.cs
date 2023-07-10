using LinkedinJAASerial;
using LinkedinJAASerialGenerator;
using LinkedinJobApplier.Config;
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
        CancellationTokenSource cancellationTokenSource = null;
        Thread statusUpdateThread = null;
        public frmMain()
        {
            InitializeComponent();
        }

        delegate void UpdateStatusLabelDelegate(string text);
        private void frmMain_Load(object sender, EventArgs e)
        {
            frmLicence frmLicence = new frmLicence();
            try
            {
                // Read the license key from the file
                string readLicenseKey = LicenseKeyManager.ReadLicenseKey();

                // Parse the license key into LicenceTable object
                LicenceTable parsedLicenseTable = LicenseKeyManager.ParseLicenseKey(readLicenseKey);
                if (parsedLicenseTable!=null)
                {
                    if (parsedLicenseTable.expirydate < DateTime.Now)
                    {
                        this.Hide();
                        frmLicence.ShowDialog();
                    }
                    LicenseKeyManager.setOnlineStatus(parsedLicenseTable, true);

                    SetDefaultItems();
                }
                else
                {
                    MessageBox.Show("Unable to connect DB");
                }
                
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
                Config.Config.DatePosted.Clear();
                Config.Config.DatePosted.Add(cbxDatePosted.GetItemText(this.cbxDatePosted.SelectedItem));

                UserDataManager userDataManager = new UserDataManager();

                userDataManager.LoadUserData();
                if (userDataManager.Status)
                {
                    // Access the user data
                    tbxEmail.Text = userDataManager.Username;
                    Config.Config.Email = tbxEmail.Text;
                    tbxPassword.Text = userDataManager.Password;
                    Config.Config.Password = tbxPassword.Text;
                    cbxDatePosted.SelectedIndex= userDataManager.ComboBoxSelectedIndex;
                    chbxRememberMe.Checked = userDataManager.RememberMe;
                    foreach (var location in userDataManager.Locations)
                    {
                        if (!string.IsNullOrEmpty(location))
                        {
                            lbxLocations.Items.Add(location);
                            Config.Config.Location.Add(tbxLocation.Text);
                        }
                    }
                    foreach (var keyword in userDataManager.Keywords)
                    {
                        if (!string.IsNullOrEmpty(keyword))
                        {
                            Config.Config.Keywords.Add(tbxLocation.Text);
                            lbxKeywords.Items.Add(keyword);
                        }
                    }
                    
                }

                
            }
            catch (Exception)
            {

            }

        }
        private void UpdateStatusLabel(string text)
        {
            if (lblStatus.InvokeRequired)
            {
                lblStatus.Invoke(new UpdateStatusLabelDelegate(UpdateStatusLabel), text);
            }
            else
            {
                lblStatus.Text = text;
            }
        }

        // Method to update the label in a separate thread
        private void UpdateStatusLabelThread()
        {
            while (true)
            {
                // Get the successful job application count from Config
                int count = Config.Config.successfulJobApplicationCounter;

                // Update the label with the count
                string labelText = $"Applied: {count} jobs";
                UpdateStatusLabel(labelText);

                // Delay for a specific duration before updating again
                Thread.Sleep(1000);
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


                if (chbxRememberMe.Checked)
                {
                    UserDataManager userDataManager = new UserDataManager();
                    userDataManager.Username = tbxEmail.Text;
                    userDataManager.Password = tbxPassword.Text;
                    userDataManager.Status = true;
                    userDataManager.RememberMe = chbxRememberMe.Checked;
                    userDataManager.Locations = lbxLocations.Items.Cast<string>().ToList();
                    userDataManager.ComboBoxSelectedIndex = cbxDatePosted.SelectedIndex;
                    userDataManager.Keywords= lbxKeywords.Items.Cast<string>().ToList();

                    // Save the user data to a file
                    userDataManager.SaveUserData();

                }
            }
            catch (Exception)
            {

            }

        }
        private async void btnStartApplying_Click(object sender, EventArgs e)
        {
            Config.Config.Email = tbxEmail.Text;
            Config.Config.Password = tbxPassword.Text;
            Console.WriteLine(Config.Config.Keywords);
            Console.WriteLine(Config.Config.Location);

            foreach (var location in lbxLocations.Items.Cast<string>().ToList())
            {
                if (!string.IsNullOrEmpty(location))
                { 
                    Config.Config.Location.Add(tbxLocation.Text);
                }
            }
            foreach (var keyword in lbxKeywords.Items.Cast<string>().ToList())
            {
                if (!string.IsNullOrEmpty(keyword))
                {
                    Config.Config.Keywords.Add(tbxLocation.Text);
                }
            }
            try
            {
                cancellationTokenSource = new CancellationTokenSource();
                var cancellationToken = cancellationTokenSource.Token;
                statusUpdateThread = new Thread(UpdateStatusLabelThread);
                statusUpdateThread.Start();
                // Start the Task with the cancellation token
                var task = Task.Run(() =>
                {
                    Linkedin linkedin = new Linkedin();
                    linkedin.LinkJobApply(cancellationToken);
                    
                });


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
                Config.Config.Location.Add(tbxLocation.Text);
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
                Config.Config.Keywords.Add(tbxKeywords.Text);
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
                Config.Config.Email = tbxEmail.Text;
                Config.Config.Password = tbxPassword.Text;
                Console.WriteLine(Config.Config.Location);
            }
            catch (Exception)
            {

            }

        }
        private void cbxDatePosted_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Config.Config.DatePosted.Clear();
                Config.Config.DatePosted.Add(cbxDatePosted.GetItemText(this.cbxDatePosted.SelectedItem));
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
                statusUpdateThread?.Abort();
                // Request cancellation of the task
                cancellationTokenSource.Cancel();
            }
            catch (Exception)
            {
                // Handle any exceptions if needed
            }
        }
    }
}
