using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Helper
{
    public static class UpdateHelper
    {
        private static string ftpServerUrl = "ftp://87.248.157.31/";
        private static string localAppPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static string localVersionFilePath = "version.txt";
        private static string ftpUsername = "alper";
        private static string ftpPassword = "Sarac.4242";

        public static void CheckForUpdates()
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
                        CreateOrUpdateVersionFile(latestVersion);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors during update checking
                //MessageBox.Show("Error checking for updates: " + ex.Message);
            }
        }

        private static string GetLocalVersion()
        {
            string versionPath = Path.Combine(localAppPath, localVersionFilePath);
            if (File.Exists(versionPath))
                return File.ReadAllText(versionPath);

            return "0.0.0.0"; // Default version if the file doesn't exist
        }

        private static string GetLatestVersion()
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
               // MessageBox.Show("Error updating application: " + ex.Message);
            }

            return responseData;
        }


        private static bool IsUpdateAvailable(string localVersion, string latestVersion)
        {
            Version currentVersion = new Version(localVersion);
            Version latest = new Version(latestVersion);

            return latest > currentVersion;
        }

        private static void DownloadAndInstallUpdate()
        {
            string updateFolder = Path.Combine(localAppPath, "UpdateTemp"); // New folder for the update
            string updateFilePath = Path.Combine(updateFolder, "Update.zip");
            string updateUrl = ftpServerUrl + "Update.zip";

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(updateUrl);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                request.UsePassive = false; // Explicitly set Passive Mode to false
                request.Proxy = new WebProxy();

                // Create the update folder if it doesn't exist
                if (!Directory.Exists(updateFolder))
                {
                    Directory.CreateDirectory(updateFolder);
                }

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

                // Extract the update files to the update folder
                ZipFile.ExtractToDirectory(updateFilePath, updateFolder);

                // Run the update executable (e.g., Updater.exe) to install the update
                string updaterPath = Path.Combine(updateFolder, "Updater.msi");
                Process.Start(updaterPath);

                // Wait for the update process to complete
                Process updaterProcess = Process.GetProcessesByName("Updater").FirstOrDefault();
                if (updaterProcess != null)
                {
                    updaterProcess.WaitForExit();
                }

                // Delete the update folder and its contents after the update is completed
                if (Directory.Exists(updateFolder))
                {
                    Directory.Delete(updateFolder, true);
                }
            }
            catch (WebException ex)
            {
                // Handle any errors during the update process
                // MessageBox.Show("Error updating application: " + ex.Message);
            }
        }

        private static string GetCurrentAppVersion()
        {
            try
            {
                // Get the version information from the executing assembly.
                Version version = Assembly.GetExecutingAssembly().GetName().Version;
                return version.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting current app version: {ex.Message}");
                return "0.0.0.0"; // Default version if the version cannot be retrieved.
            }
        }

        private static void CreateOrUpdateVersionFile(string version)
        {
            string versionFilePath = Path.Combine(localAppPath, localVersionFilePath);

            try
            {
                // Check if the version file exists and read its content.
                if (File.Exists(versionFilePath))
                {
                    string existingVersion = File.ReadAllText(versionFilePath);

                    if (existingVersion == version)
                    {
                        // The version file already exists and has the same version.
                        Console.WriteLine("Version file already exists with the same version.");
                        return;
                    }
                }

                // Write the version information to the file or update the existing file.
                File.WriteAllText(versionFilePath, version);
                Console.WriteLine($"Version file {(File.Exists(versionFilePath) ? "updated" : "created")} with version: {version}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating or updating version file: {ex.Message}");
            }
        }

    }
}
