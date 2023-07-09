using LinkedinJAASerialGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkedinJAASerial
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //string serialKey = LicenseKeyVerifier.GenerateLicenseKey(tbxEmail.Text);
            //DatabaseConnector.InsertLicenceTable(new LicenceTable { email = tbxEmail.Text, isactive = true, isdeleted = false, serialkey = serialKey });
        }

        private void btnGenerateLicence_Click(object sender, EventArgs e)
        {
            try
            {
                rtbxLicence.Text = "";
                string serialKey = LicenseKeyVerifier.GenerateLicenseKey(tbxEmail.Text);
                DatabaseConnector.InsertLicenceTable(new LicenceTable { email = tbxEmail.Text, isactive = true, isdeleted = false, serialkey = serialKey });
                rtbxLicence.Text = serialKey;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }

        private void btnSearchLicence_Click(object sender, EventArgs e)
        {
            try
            {
                rtbxResult.Text = "";
                LicenceTable result = null;
                if (!string.IsNullOrEmpty(tbxEmailVerification.Text))
                {
                    result = DatabaseConnector.GetLicenceTableByEmail(tbxEmailVerification.Text);
                }
                else
                {
                    result = DatabaseConnector.GetLicenceTableBySerialKey(tbxLicence.Text);
                }               
                rtbxResult.Text = $"{result.serialkey}";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            listbStats.Items.Clear();
            List<LicenceTable> AllLicences = DatabaseConnector.RetrieveLicenceTables();
            lblActiveCount.Text= "Online Users: " + (AllLicences.Where(p => p.isonline == true).Count().ToString())+" - "+"Active Users: "+(AllLicences.Where(p=>p.isactive==true).Count().ToString());
            foreach (var licence in AllLicences)
            {
                string licenceInfoText = $"{licence.email} - {(licence.isactive? "Active":"Inactive")} {(licence.isonline ? " - Online" : "")} {(licence.isdeleted ? " - Deleted" : "")}";
                listbStats.Items.Add(licenceInfoText);
            }
        }
    }
}
