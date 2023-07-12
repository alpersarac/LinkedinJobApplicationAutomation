using Helper;
using LinkedinJAASerial;
using LinkedinJAASerialGenerator;
using System;
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
        public frmLicence()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string licenseKey = tbxLicence.Text;
                bool isConnectionOK = false;
                LicenceTable parsedLicenseTable = LicenseKeyManager.ParseLicenseKey(licenseKey,ref isConnectionOK);
                if (!parsedLicenseTable.isonline)
                {
                    // Encrypt and save the license key
                    LicenseKeyManager.SaveLicenseKey(licenseKey);
                    //LicenseKeyManager.UpdateActiveStatusLicence(parsedLicenseTable);
                    //LicenseKeyManager.setOnlineStatus(parsedLicenseTable, true);
                    LicenseKeyManager.SetMacAddress(parsedLicenseTable,NetworkHelper.GetMacAddress());
                    MessageBox.Show("Registration is successful");
                    isRegistered = true;
                    this.Close();
                    //----show frmmain
                }
                else
                {
                    MessageBox.Show("Registration key is wrong");
                    isRegistered = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an exception please contact the developer");
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
            if (isRegistered)
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
