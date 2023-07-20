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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                    var result = DatabaseConnector.InsertLicenceTable(new LicenceTable { email = "", isactive = false, isdeleted = false, serialkey = serialKey, expirydate = DateTime.Now.AddDays(days), macAddress = "NOTUSED" });
                    if (result == true)
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

            List<LicenceTable> AllLicences = DatabaseConnector.RetrieveLicenceTables();
            lblActiveCount.Text = "Online Users: " + (AllLicences.Where(p => p.isonline == true).Count().ToString()) + " - " + "Active Users: " + (AllLicences.Where(p => p.isactive == true).Count().ToString());

            lwStats.Items.Clear();
            lwStats.Columns.Clear();
            lwStats.View = View.Details;

            lwStats.Columns.Add("Email", 250);
            lwStats.Columns.Add("Serial Key", 100);
            lwStats.Columns.Add("Is Active", 80);
            lwStats.Columns.Add("Is Deleted", 80);
            lwStats.Columns.Add("Is Online", 80);
            lwStats.Columns.Add("MAC Address", 120);
            lwStats.Columns.Add("Expiry Date", 85);
            lwStats.Columns.Add("Last Online Date", 135);

            foreach (var licence in AllLicences)
            {
                ListViewItem listViewItem = new ListViewItem(new string[]
                {
                        licence.email,
                        licence.serialkey,
                        licence.isactive.ToString(),
                        licence.isdeleted.ToString(),
                        licence.isonline.ToString(),
                        licence.macAddress,
                        licence.expirydate.ToString("dd/MM/yyyy"),
                        licence.lastonlinedate.HasValue? licence.lastonlinedate.Value.ToString("dd/MM/yyyy hh:mm:ss"):"Never Online"
                });

                listViewItem.BackColor = GetItemBackgroundColor(licence); // Set the background color

                lwStats.Items.Add(listViewItem);

            }
        }
        Color GetItemBackgroundColor(LicenceTable item)
        {
            if (item.isdeleted)
                return Color.DarkGray;
            else if (item.isonline)
                return Color.LightGreen;
            else if (!item.isactive)
                return Color.LightYellow;
            else
                return Color.CadetBlue;
        }
        public class ListBoxItem
        {
            public string Text { get; set; }
            public Color BackgroundColor { get; set; }

            public override string ToString()
            {
                return Text; // Display the Text property in the ListBox
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

            rhtbxEncrypted.Text = BasicEncryption.EncryptConnectionString(tbxEncryptLicence.Text);
        }
    }
}
