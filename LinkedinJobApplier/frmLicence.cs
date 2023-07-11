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
                    LicenseKeyManager.UpdateActiveStatusLicence(parsedLicenseTable);
                    LicenseKeyManager.setOnlineStatus(parsedLicenseTable, true);
                    MessageBox.Show("Registration is successful");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Registration key is wrong");
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
    }
}
