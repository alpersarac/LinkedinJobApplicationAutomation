using Helper;
using LinkedinJAASerial;
using LinkedinJAASerialGenerator;
using LinkedinJobApplier.Config;
using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
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
        private HttpClient client;
        public frmMain()
        {
            InitializeComponent();
            client = new HttpClient();
            client.BaseAddress = new Uri("https://your-api-url/");
        }

        delegate void UpdateStatusLabelDelegate(string text);
        private async void frmMain_Load(object sender, EventArgs e)
        {
            frmLicence frmLicence = new frmLicence(this);
            try
            {
                string readLicenseKey = LicenseKeyManager.ReadLicenseKey();
                bool isConnectionOK = false;
                LicenceTable parsedLicenseTable = LicenseKeyManager.ParseLicenseKey(readLicenseKey, ref isConnectionOK);
                
                if (parsedLicenseTable != null && isConnectionOK==true)
                {
                    if (parsedLicenseTable.macAddress != NetworkHelper.GetMacAddress())
                    {
                        MessageBox.Show("Oops you are trying use your licence on different device");
                        Application.Exit();
                    }
                    else if (parsedLicenseTable.expirydate < DateTime.Now)
                    {
                        this.Hide();
                        frmLicence.ShowDialog();
                    }
                    else
                    {
                        LicenseKeyManager.setOnlineStatus(parsedLicenseTable, true);
                        lblRemainingDays.Text =$"Remaining days: {Convert.ToInt32((DateTime.Now.Date - parsedLicenseTable.expirydate.Date).ToString("dd"))}";
                        SetDefaultItems();
                    }

                }
                else if (parsedLicenseTable==null && isConnectionOK == true)
                {
                    this.Hide();
                    frmLicence.ShowDialog();
                }
                else if (isConnectionOK == false)
                {

                    MessageBox.Show("Unable to connect DB");
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Fatal Error please contact the developer");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                this.Hide();
                frmLicence.ShowDialog();
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
                bool isConnectionOK = false;
                LicenceTable parsedLicenseTable = LicenseKeyManager.ParseLicenseKey(readLicenseKey,ref isConnectionOK);
                LicenseKeyManager.setOnlineStatus(parsedLicenseTable, false);


                if (chbxRememberMe.Checked)
                {
                    UserDataManager userDataManager = new UserDataManager();
                    userDataManager.Username = tbxEmail.Text;
                    userDataManager.Password = tbxPassword.Text;
                    userDataManager.Status = true;
                    userDataManager.RememberMe = chbxRememberMe.Checked;
                    userDataManager.Locations = lbxLocations.Items.Cast<string>().ToList();
                    userDataManager.cbxDatePostedIndex = cbxDatePosted.SelectedIndex;
                    userDataManager.Keywords = lbxKeywords.Items.Cast<string>().ToList();
                    userDataManager.City = tbxCity.Text;
                    userDataManager.SalaryExpectation = tbxSalary.Text;
                    userDataManager.cbxCommutingIndex = cbxCommuting.SelectedIndex;
                    userDataManager.cbxVisaSponsorIndex = cbxVisaSponsorship.SelectedIndex;
                    userDataManager.NoticePeriodInDays = tbxNoticePeriod.Text;

                    // Save the user data to a file
                    userDataManager.SaveUserData();

                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
            }
            finally
            {
                Environment.Exit(0);
            }

        }
        private async void btnStartApplying_Click(object sender, EventArgs e)
        {
            AddElementsToList();
            try
            {
                cancellationTokenSource = new CancellationTokenSource();
                var cancellationToken = cancellationTokenSource.Token;
                statusUpdateThread = new Thread(UpdateStatusLabelThread);
                statusUpdateThread.Start();

                var task = Task.Run(() =>
                {
                    Linkedin linkedin = new Linkedin();
                    linkedin.LinkJobApply(cancellationToken);

                });

            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
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
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
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
            catch (Exception ex) 
            { 
                ExceptionLogger.LogException(ex); 
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
            catch (Exception ex) { ExceptionLogger.LogException(ex); }

        }
        private void cbxDatePosted_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Config.Config.DatePosted.Clear();
                Config.Config.DatePosted.Add(cbxDatePosted.GetItemText(this.cbxDatePosted.SelectedItem));
            }
            catch (Exception ex) { ExceptionLogger.LogException(ex); }

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
            catch (Exception ex) { ExceptionLogger.LogException(ex); }
        }
        #region Helper Method
        public void AddElementsToList()
        {
            ClearAllSettings();
            Config.Config.Email = tbxEmail.Text;
            Config.Config.Password = tbxPassword.Text;
            Config.Config.ExperienceLevels.Add(cbxDatePosted.SelectedText);
            Config.Config.City = tbxCity.Text;
            Config.Config.VisaRequirement = cbxVisaSponsorship.GetItemText(this.cbxVisaSponsorship.SelectedItem);
            Config.Config.CommutePreference = cbxCommuting.GetItemText(this.cbxCommuting.SelectedItem);
            Config.Config.NoticePeriod = tbxNoticePeriod.Text;
            Config.Config.SalaryExpectation = tbxSalary.Text;
            Config.Config.DatePosted.Add(cbxDatePosted.GetItemText(this.cbxDatePosted.SelectedItem));
            foreach (var location in lbxLocations.Items.Cast<string>().ToList())
            {
                if (!string.IsNullOrEmpty(location))
                {
                    Config.Config.Location.Add(location);
                }
            }
            foreach (var keyword in lbxKeywords.Items.Cast<string>().ToList())
            {
                if (!string.IsNullOrEmpty(keyword))
                {
                    var percentEncodedText = Uri.EscapeDataString(keyword);
                    Config.Config.Keywords.Add(percentEncodedText);
                }
            }
        }
        public void ClearAllSettings()
        {
            Config.Config.Email = "";
            Config.Config.Password = "";
            Config.Config.City = "";
            Config.Config.VisaRequirement = "";
            Config.Config.CommutePreference = "";
            Config.Config.NoticePeriod = "";
            Config.Config.ExperienceLevels.Clear();
            Config.Config.Location.Clear();
            Config.Config.Keywords.Clear();
            Config.Config.DatePosted.Clear();
        }
        public void SetDefaultItems()
        {
            try
            {
                cbxDatePosted.SelectedIndex = 0;
                cbxCommuting.SelectedIndex = 0;
                cbxVisaSponsorship.SelectedIndex = 0;
                Config.Config.DatePosted.Clear();
                Config.Config.DatePosted.Add(cbxDatePosted.GetItemText(this.cbxDatePosted.SelectedItem));

                UserDataManager userDataManager = new UserDataManager();

                userDataManager.LoadUserData();
                if (userDataManager.Status)
                {
                    tbxEmail.Text = userDataManager.Username;
                    tbxPassword.Text = userDataManager.Password;
                    cbxDatePosted.SelectedIndex = userDataManager.cbxDatePostedIndex;
                    chbxRememberMe.Checked = userDataManager.RememberMe;
                    tbxCity.Text = userDataManager.City;
                    tbxSalary.Text = userDataManager.SalaryExpectation;
                    cbxCommuting.SelectedIndex= userDataManager.cbxCommutingIndex;
                    cbxVisaSponsorship.SelectedIndex = userDataManager.cbxVisaSponsorIndex;
                    tbxNoticePeriod.Text = userDataManager.NoticePeriodInDays;

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
            catch (Exception ex) { ExceptionLogger.LogException(ex); }

        }
        #endregion

    }
}
