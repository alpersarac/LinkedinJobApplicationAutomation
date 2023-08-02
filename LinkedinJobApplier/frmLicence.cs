using Helper;
using LinkedinJAASerial;
using LinkedinJAASerialGenerator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkedinJobApplier
{
    public partial class frmLicence : Form
    {
        bool isRegistered = false;
        frmMain _frmMainObj = null;
        public frmLicence(frmMain frmMainObj)
        {
            InitializeComponent();
            _frmMainObj = frmMainObj;
            this.BringToFront();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string licenseKey = tbxLicence.Text.Replace(" ", "");
                string email = tbxEmail.Text;
                bool isConnectionOK = false;
                DateTime? currentDateTime = new DateTime();

                currentDateTime = WordTimerManager.GetCurrentDateTime();
                if (currentDateTime == null)
                {
                    MessageBox.Show("Unable connect to internet, please check your internet connection", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (string.IsNullOrEmpty(licenseKey))
                    {
                        MessageBox.Show("Enter a licence key", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!Checker.CheckEmail(tbxEmail.Text) || string.IsNullOrEmpty(email))
                    {
                        MessageBox.Show("Enter an valid email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    LicenceTable parsedLicenseTable = LicenseKeyManager.ParseLicenseKey(licenseKey, ref isConnectionOK);
                    if (parsedLicenseTable.expirydate < DateTime.Now)
                    {
                        MessageBox.Show("Licence is expired", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (parsedLicenseTable != null && !parsedLicenseTable.isonline)
                    {
                        // Encrypt and save the license key
                        LicenseKeyManager.SaveLicenseKey(licenseKey);

                        LicenseKeyManager.SetMacAddress(parsedLicenseTable, email, NetworkHelper.GetActiveMacAddress());
                        MessageBox.Show("Registration is successfully completed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isRegistered = true;
                        this.Hide();
                        _frmMainObj.SetTabsPages(parsedLicenseTable.isinfoextrator);
                        _frmMainObj.Show();
                        //----show frmmain
                    }
                    else
                    {
                        MessageBox.Show("Registration key is wrong", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        isRegistered = false;
                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                MessageBox.Show("There is an exception please contact the developer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLicence_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLicence_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isRegistered)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    // Cancel the closing operation
                    Console.WriteLine("Closing");
                    e.Cancel = true;
                }
            }

        }
    }
}
