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
    public partial class frmMain : Form
    {
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
                var isExpired = LicenseKeyVerifier.CheckLicenseKeyExpiration(parsedLicenseTable.serialkey);
                if (isExpired) 
                {
                    this.Hide();
                    frmLicence.ShowDialog();
                }
            }
            catch (Exception)
            {
                this.Hide();
                frmLicence.ShowDialog();
            }
            
        }
    }
}
