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

        public static LicenceTable ParseLicenseKey(string licenseKey,ref bool isConnectionOK)
        {
            
            LicenceTable licenceTable = DatabaseConnector.GetLicenceTableBySerialKey(licenseKey,ref isConnectionOK);
            
            return licenceTable;
        }
        public static bool UpdateActiveStatusLicence(LicenceTable licenseKey)
        {
            licenseKey.isactive=true;
            DatabaseConnector.UpdateLicenceTable(licenseKey);

            return true;
        }
        public static bool setOnlineStatus(LicenceTable licenseKey,bool isOnline)
        {
            licenseKey.isonline = isOnline;
            DatabaseConnector.UpdateLicenceTable(licenseKey);

            return true;
        }
        public static bool SetMacAddress(LicenceTable licenseKey, string macAddress)
        {
            DatabaseConnector.SetMacAddressById(licenseKey.id, macAddress);
            return true;
        }


    }
}
