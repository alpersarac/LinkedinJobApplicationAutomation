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
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LinkedinJobApplier
{
    public partial class frmMain : Form
    {
        #region Variables
        CancellationTokenSource cancellationTokenSource = null;
        Thread statusUpdateThread = null;
        Thread phoneEmailThread = null;
        Thread operationThread = null;
        private HttpClient client;
        bool isinfoextratorRunTime = false;

        #endregion

        public frmMain()
        {
            InitializeComponent();          
            //client = new HttpClient();
            //client.BaseAddress = new Uri("https://your-api-url/");
        }

        delegate void UpdateStatusLabelDelegate(string text);
        delegate void UpdateInfoListboxDelegate(string PhoneEmail);
        private void frmMain_Load(object sender, EventArgs e)
        {
            frmLicence frmLicence = new frmLicence(this);
            if (UpdateHelper.CheckForUpdates())
            {
                System.Diagnostics.Process.Start(Application.ExecutablePath);
                Application.Exit();
            }
            try
            {
                DateTime? currentDateTime = WordTimerManager.GetCurrentDateTime();
                try
                {
                    if (currentDateTime == null)
                    {
                        MessageBox.Show("Unable connect to internet, please check your internet connection", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                    else
                    {
                        string readLicenseKey = LicenseKeyManager.ReadLicenseKey();
                        bool isConnectionOK = false;
                        radioChrome.Checked = true;
                        LicenceTable parsedLicenseTable = LicenseKeyManager.ParseLicenseKey(readLicenseKey, ref isConnectionOK);

                        if (parsedLicenseTable != null && isConnectionOK == true)
                        {

                            if (parsedLicenseTable.expirydate < currentDateTime /*DateTime.Now*/)
                            {
                                this.Hide();
                                frmLicence.ShowDialog();
                            }
                            else if (string.IsNullOrEmpty(parsedLicenseTable.macAddress))
                            {
                                MessageBox.Show("Make sure that you have internet connection", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else if (!NetworkHelper.GetMacAddresses().Contains(parsedLicenseTable.macAddress))
                            {
                                MessageBox.Show("Oops you are trying use your licence on different device", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                LicenseKeyManager.SetMacAddressAttempt(parsedLicenseTable.id, NetworkHelper.GetActiveMacAddress());
                                Application.Exit();
                            }
                            else
                            {
                                LicenseKeyManager.setOnlineStatus(parsedLicenseTable, true);
                                isinfoextratorRunTime = parsedLicenseTable.isinfoextrator;
                                lblRemainingDays.Text = $"Remaining days: {Convert.ToInt32((DateTime.Now.Date - parsedLicenseTable.expirydate.Date).ToString("dd"))}";
                                SetDefaultItems();
                                SetTabsPages(parsedLicenseTable.isinfoextrator);
                            }

                        }
                        else if (parsedLicenseTable == null && isConnectionOK == true)
                        {
                            this.Hide();
                            frmLicence.ShowDialog();
                        }
                        else if (isConnectionOK == false)
                        {

                            MessageBox.Show("Unable to connect DB", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Application.Exit();
                        }
                        else
                        {
                            MessageBox.Show("Fatal Error please contact the developer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    ExceptionLogger.LogException(ex);
                    this.Hide();
                    frmLicence.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
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
                if (isinfoextratorRunTime)
                {
                    lblStatus.Text = lbxInfo.Items.Count.ToString();
                    lblCurrentCountry.Text = Config.Config.europeanCountries.ElementAt(Config.Config.currentCountryIndex).Key;
                    lblCurrentTitle.Text = Config.Config.titlesForInfoExtraction.ElementAt(Config.Config.currentTitleIndex);
                    lblInfoPage.Text = "Current Page:" + Config.Config.currentInfoPageIndex;

                }
                else
                {
                    lblStatus.Text = text;
                }

            }
        }
        private void UpdatePhoneEmailListbox(string PhoneEmail)
        {
            if (lbxInfo.InvokeRequired)
            {
                lbxInfo.Invoke(new UpdateInfoListboxDelegate(UpdatePhoneEmailListbox), PhoneEmail);
            }
            else
            {
                if (!lbxInfo.Items.Contains(PhoneEmail) && !string.IsNullOrEmpty(PhoneEmail) && PhoneEmail.Replace(" ", "") != "^")
                {
                    lbxInfo.Items.Add(PhoneEmail);
                }
            }
        }
        private void UpdateStatusLabelThread()
        {
            while (true)
            {
                int count = Config.Config.successfulJobApplicationCounter;

                // Update the label with the count
                string labelText = $"Applied: {count} jobs";
                UpdateStatusLabel(labelText);

                // Delay for a specific duration before updating again
                Thread.Sleep(1000);

            }
        }
        private void UpdateListPhoneEmailThread()
        {
            while (true)
            {
                // Get the successful job application count from Config
                var Item = Config.Config.PhoneAndEmails;

                // Update the label with the count
                //string labelText = $"Applied: {count} jobs";
                UpdatePhoneEmailListbox(Item);

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
                LicenceTable parsedLicenseTable = LicenseKeyManager.ParseLicenseKey(readLicenseKey, ref isConnectionOK);
                LicenseKeyManager.setOnlineStatus(parsedLicenseTable, false);


                if (chbxRememberMe.Checked)
                {
                    saveIndexes();
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
        public void saveIndexes()
        {
            if (isinfoextratorRunTime)
            {
                IndexManager.SaveIndexes(Config.Config.currentInfoPageIndex, Config.Config.currentTitleIndex, Config.Config.currentCountryIndex);
            }
        }
        private void btnStartApplying_Click(object sender, EventArgs e)
        {

            if (CheckForRequiredItems())
            {
                AddElementsToList();
                try
                {
                    cancellationTokenSource = new CancellationTokenSource();
                    var cancellationToken = cancellationTokenSource.Token;
                    statusUpdateThread = new Thread(UpdateStatusLabelThread);
                    statusUpdateThread.Start();
                    if (isinfoextratorRunTime)
                    {
                        phoneEmailThread = new Thread(UpdateListPhoneEmailThread);
                        phoneEmailThread.Start();
                        operationThread = new Thread(() =>
                        {
                            Linkedin linkedin = new Linkedin();
                            linkedin.LinkInfoExtract(cancellationToken);
                        });
                    }
                    else
                    {
                        operationThread = new Thread(() =>
                        {
                            Linkedin linkedin = new Linkedin();
                            linkedin.LinkJobApply(cancellationToken);
                        });
                    }

                    operationThread.Start();
                }
                catch (Exception ex)
                {
                    ExceptionLogger.LogException(ex);
                } 
            }

        }
        public bool CheckForRequiredItems()
        {
            if (!isinfoextratorRunTime)
            {
                if (string.IsNullOrEmpty(tbxEmail.Text))
                {
                    MessageBox.Show("Please enter an Email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }
                if (string.IsNullOrEmpty(tbxPassword.Text))
                {
                    MessageBox.Show("Please enter a Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }
                if (lbxKeywords.Items.Count == 0)
                {
                    MessageBox.Show("Please add at least one Keyword", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (lbxLocations.Items.Count == 0)
                {
                    MessageBox.Show("Please add at least one Location", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (cbxDatePosted.SelectedIndex== -1)
                {
                    MessageBox.Show("Please select a Date Posted option", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }
                if (cbxCommuting.SelectedIndex== -1)
                {
                    MessageBox.Show("Please select a Commuting option", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }
                if (cbxVisaSponsorship.SelectedIndex== -1)
                {
                    MessageBox.Show("Please select a Visa Sponsorship option", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }
                if (string.IsNullOrEmpty(tbxCity.Text))
                {
                    MessageBox.Show("Please enter a City", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }
                if (string.IsNullOrEmpty(tbxNoticePeriod.Text))
                {
                    MessageBox.Show("Please enter a Notice Period value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }
                if (string.IsNullOrEmpty(tbxSalary.Text))
                {
                    MessageBox.Show("Please enter some Salary", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }
                
            }
            return true;
        }
        private void btnAddCountry_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbxLocation.Text))
                {
                    MessageBox.Show("Please enter a location", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
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
                if (string.IsNullOrEmpty(tbxKeywords.Text))
                {
                    MessageBox.Show("Please enter a keyword", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
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
                btnStopApplying.Text = "Please Wait..";
                btnStopApplying.BackColor = Color.OrangeRed;
                btnStopApplying.ForeColor = Color.Black;
                if (isinfoextratorRunTime)
                {
                    saveIndexes();
                    phoneEmailThread?.Abort();
                    statusUpdateThread?.Abort();

                    operationThread.Abort();
                    operationThread.Join();
                }
                else
                {
                    statusUpdateThread?.Abort();

                    operationThread.Abort();
                    operationThread.Join();
                }

                btnStopApplying.BackColor = Color.WhiteSmoke;
                btnStopApplying.ForeColor = Color.OrangeRed;
                btnStopApplying.Text = "Stop Applying";
            }
            catch (Exception ex) { ExceptionLogger.LogException(ex); }
        }
        #region Helper Method
        public void AddElementsToList()
        {
            ClearAllSettings();
            var checkedButton = this.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

            Config.Config.Browser = checkedButton.Text.ToLower();
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
                radioFirefox.Checked = true;
                cbxDatePosted.SelectedIndex = 0;
                cbxCommuting.SelectedIndex = 0;
                cbxVisaSponsorship.SelectedIndex = 0;
                Config.Config.DatePosted.Clear();
                Config.Config.DatePosted.Add(cbxDatePosted.GetItemText(this.cbxDatePosted.SelectedItem));

                if (isinfoextratorRunTime)
                {
                    IndexManager.ReadIndexes(out Config.Config.currentInfoPageIndex, out Config.Config.currentTitleIndex, out Config.Config.currentCountryIndex);
                    lblCurrentCountry.Text = Config.Config.europeanCountries.ElementAt(Config.Config.currentCountryIndex).Key;
                    lblCurrentTitle.Text = Config.Config.titlesForInfoExtraction.ElementAt(Config.Config.currentTitleIndex);
                    lblInfoPage.Text = "Current Page:" + Config.Config.currentInfoPageIndex;
                }


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
                    cbxCommuting.SelectedIndex = userDataManager.cbxCommutingIndex;
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
        public void SetTabsPages(bool isinfoextratorRunTime)
        {
            this.Size = new Size(1058, 509);
            
            if (isinfoextratorRunTime)
            {
                grbxInfo.Location = new Point(354, 6);
                grbxPreferences.Visible = false;
                grbxInfo.Visible = true;
                btnStartApplying.Text = "Start Extracting";
                btnStopApplying.Text = "Stop Extracting";
            }
            else
            {
                grbxInfo.Visible = false;
                grbxPreferences.Visible = true;
                grbxPreferences.Location = new Point(354, 6);
                btnStartApplying.Text = "Start Applying";
                btnStopApplying.Text = "Stop Applying";
            }
        }
        #endregion

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string infoList = "";
            foreach (var item in lbxInfo.Items)
            {
                infoList += item + "*";
            }


            SaveToCsv(infoList);
        }
        public static void SaveToCsv(string dataString)
        {
            // Split dataString into individual entries
            string[] entries = dataString.Split('*');

            // Create the CSV file using a SaveFileDialog
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV Files|*.csv|All Files|*.*";
                saveFileDialog.Title = "Save CSV File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = saveFileDialog.FileName;

                    // Write the data to the CSV file
                    using (StreamWriter file = new StreamWriter(filename, append: true))
                    {
                        // Check if the file is empty, if so, write the header
                        if (file.BaseStream.Length == 0)
                        {
                            file.WriteLine("name,email,phone,company");
                        }

                        foreach (string entry in entries)
                        {
                            // Split each entry by '|' to extract name, email, phone, and company values
                            string[] values = entry.Split('^');

                            if (values.Length != 4)
                            {
                                Console.WriteLine($"Skipping invalid entry: {entry}");
                                continue;
                            }

                            string name = values[0];
                            string email = values[1];
                            string phone = values[2];
                            string company = values[3];

                            // Prepare the data to be saved in the CSV file
                            string[] data = new string[] { name, email, phone, company };

                            // Write the data to the CSV file
                            file.WriteLine(string.Join(",", data));
                        }
                    }

                    Console.WriteLine("Data saved to CSV file successfully.");
                }
                else
                {
                    Console.WriteLine("File selection canceled. Data not saved.");
                }
            }
        }

        private void lbxLocations_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int index = lbxLocations.IndexFromPoint(e.Location);

                if (index != ListBox.NoMatches)
                {
                    // Remove the selected item from the ListBox
                    lbxLocations.Items.RemoveAt(index);
                }
            }
            catch (Exception)
            {

            }
        }

        private void lbxKeywords_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int index = lbxKeywords.IndexFromPoint(e.Location);

                if (index != ListBox.NoMatches)
                {
                    // Remove the selected item from the ListBox
                    lbxKeywords.Items.RemoveAt(index);
                }
            }
            catch (Exception)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmUpdate frmUpdate = new frmUpdate();
            frmUpdate.ShowDialog();
        }
    }
}
