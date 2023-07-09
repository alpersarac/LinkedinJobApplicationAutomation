using LinkedinJAASerial;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LinkedinJobApplier
{
    using LinkedinJAASerialGenerator;
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    public class LicenseKeyManager
    {
        public static void SaveLicenseKey(string licenseKey)
        {
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(directoryPath, "license.key");

            // Save the license key to a file
            File.WriteAllText(filePath, licenseKey);
        }

        public static string ReadLicenseKey()
        {
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(directoryPath, "license.key");

            // Read the license key from the file
            string licenseKey = File.ReadAllText(filePath);

            return licenseKey;
        }

        public static LicenceTable ParseLicenseKey(string licenseKey)
        {
            LicenceTable licenceTable = DatabaseConnector.GetLicenceTableBySerialKey(licenseKey);
            
            return licenceTable;
        }
        public static bool GetExpiryDate(string licenseKey)
        {
            bool isExpired = LicenseKeyVerifier.CheckLicenseKeyExpiration(licenseKey);

            return isExpired;
        }

    }
}
