using Helper;
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
                if (!Checker.CheckEmail(tbxEmail.Text))
                {
                    MessageBox.Show("Please enter a valid email");
                }
                else if (string.IsNullOrEmpty(tbxEmail.Text))
                {
                    MessageBox.Show("Enter an email address");
                }
                else if (string.IsNullOrEmpty(cbxDays.GetItemText(cbxDays.SelectedItem)))
                {
                    MessageBox.Show("Select some days");
                }
                else
                {
                    rtbxLicence.Text = "";
                    int days = Convert.ToInt32(cbxDays.GetItemText(cbxDays.SelectedItem));
                    string serialKey = LicenseKeyVerifier.GenerateLicenseKey(tbxEmail.Text);
                    var result = DatabaseConnector.InsertLicenceTable(new LicenceTable { email = tbxEmail.Text, isactive = false, isdeleted = false, serialkey = serialKey, expirydate = DateTime.Now.AddDays(days), macAddress="NOTUSED" });
                    if (result==true)
                    {
                        rtbxLicence.Text = serialKey;
                    }
                    else
                    {
                        MessageBox.Show("Not able to insert a licence key to DB");
                    }
                }
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
                    bool isConnectionOK = false;
                    result = DatabaseConnector.GetLicenceTableBySerialKey(tbxLicence.Text, ref isConnectionOK);
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
            lblActiveCount.Text = "Online Users: " + (AllLicences.Where(p => p.isonline == true).Count().ToString()) + " - " + "Active Users: " + (AllLicences.Where(p => p.isactive == true).Count().ToString());
            foreach (var licence in AllLicences)
            {
                string licenceInfoText = $"{licence.email} - {(licence.isactive ? "Active" : "Inactive")} {(licence.isonline ? " - Online" : "")} {(licence.isdeleted ? " - Deleted" : "")}";
                listbStats.Items.Add(licenceInfoText);
            }
        }

        private void btnGenerateConnectionStringFile_Click(object sender, EventArgs e)
        {
            
            //string connectionString = "Ø†ãB›E‹&G2‘O.a±1Î^@\u0006<aªIÊ‚Vó„qÕJ0e ÆäqW[\u001bÄG\u0011UˆçCÉ£•$¿àº\u0017p5M\u009d\u0003ë¨^ÕF#a\u001f2‚\u0014À«¬\u0015ß9¾ <_¢´¯Ï€Ò–©‡ÃÙÈ\bûxÚvù?Öû\u0003|_õ€t{\u000eˆ‡Þ¢¤J\u0018Å|\u0019 îx58¶^";
            //string filePath = "encrypted-connectionstring.bin";
            //string password = "Alper23";
            //
            //ConnectionStringDecryptor decryptor = new ConnectionStringDecryptor(password);
            //string ConnectionString = decryptor.DecryptConnectionStringFromString(connectionString);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
           

        }

       
        private void btnEncrpt_Click_1(object sender, EventArgs e)
        {
            
            rhtbxEncrypted.Text= BasicEncryption.EncryptConnectionString(tbxEncryptLicence.Text);
        }
    }
}
