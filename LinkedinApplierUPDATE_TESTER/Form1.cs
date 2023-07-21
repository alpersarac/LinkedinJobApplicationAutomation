using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkedinApplierUPDATE_TESTER
{
    public partial class Form1 : Form
    {
        private string ftpServerUrl = "ftp://87.248.157.31/";
        private string localAppPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private string localVersionFilePath = "version.txt";
        private string ftpUsername = "alper";
        private string ftpPassword = "Sarac.4242";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckForUpdates();
        }
        private void CheckForUpdates()
        {
            try
            {
                string localVersion = GetLocalVersion();
                string latestVersion = GetLatestVersion();

                if (IsUpdateAvailable(localVersion, latestVersion))
                {
                    if (MessageBox.Show("An update is available. Do you want to download and install it?", "Update Available", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DownloadAndInstallUpdate();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors during update checking
                MessageBox.Show("Error checking for updates: " + ex.Message);
            }
        }

        private string GetLocalVersion()
        {
            string versionPath = Path.Combine(localAppPath, localVersionFilePath);
            if (File.Exists(versionPath))
                return File.ReadAllText(versionPath);

            return "0.0.0.0"; // Default version if the file doesn't exist
        }

        private string GetLatestVersion()
        {
            string latestVersionUrl = ftpServerUrl + "version.txt";
            string responseData = string.Empty;

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(latestVersionUrl);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
            request.UsePassive = false; // Explicitly set Passive Mode to false
            request.Proxy = new WebProxy();

            try
            {
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            responseData = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle any errors during the update process
                MessageBox.Show("Error updating application: " + ex.Message);
            }

            return responseData;
        }


        private bool IsUpdateAvailable(string localVersion, string latestVersion)
        {
            Version currentVersion = new Version(localVersion);
            Version latest = new Version(latestVersion);

            return latest > currentVersion;
        }

        private void DownloadAndInstallUpdate()
        {
            string updateFilePath = Path.Combine(localAppPath, "Update.zip");
            string updateUrl = ftpServerUrl + "Update.zip";

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(updateUrl);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                request.UsePassive = false; // Explicitly set Passive Mode to false
                request.Proxy = new WebProxy();

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (FileStream fileStream = new FileStream(updateFilePath, FileMode.Create))
                        {
                            byte[] buffer = new byte[1024];
                            int bytesRead;
                            while ((bytesRead = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                fileStream.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                }

                // Extract the update files here (you can use a library like SharpZipLib or built-in ZipArchive class)

                // Run the update executable (e.g., Updater.exe) to install the update
                string updaterPath = Path.Combine(localAppPath, "Updater.exe");
                Process.Start(updaterPath);

                // Close the application to allow the updater to take over
                Application.Exit();
            }
            catch (WebException ex)
            {
                // Handle any errors during the update process
                MessageBox.Show("Error updating application: " + ex.Message);
            }
        }

    }
}

    

