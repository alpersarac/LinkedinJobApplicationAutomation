using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LinkedinJAASerialGenerator
{

    public class LicenseKeyVerifier
    {
        private const int LicenseValidityPeriodInDays = 30;

        public static bool VerifyLicenseKey(string userSpecificInfo, string licenseKey)
        {
            // Generate a key based on user-specific information
            string generatedKey = GenerateLicenseKey(userSpecificInfo);

            // Compare the generated key with the provided license key
            bool isValidKey = string.Equals(generatedKey, licenseKey, StringComparison.OrdinalIgnoreCase);

            if (isValidKey)
            {
                // Check if the license key has expired
                bool isExpired = CheckLicenseKeyExpiration(licenseKey);
                isValidKey = !isExpired;
            }

            return isValidKey;
        }

        public static string GenerateLicenseKey(string userSpecificInfo)
        {
            // Generate a unique key based on user-specific information and current timestamp
            using (SHA256 sha256 = SHA256.Create())
            {
                string timeStamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
                string combinedInfo = userSpecificInfo + timeStamp;

                byte[] combinedInfoBytes = Encoding.UTF8.GetBytes(combinedInfo);
                byte[] hashBytes = sha256.ComputeHash(combinedInfoBytes);

                // Format the license key (optional)
                string formattedKey = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

                return formattedKey;
            }
        }

        private static bool CheckLicenseKeyExpiration(string licenseKey)
        {
            // Extract the timestamp from the license key
            string timeStampHex = licenseKey.Substring(licenseKey.Length - 14);
            long timeStampTicks = long.Parse(timeStampHex, System.Globalization.NumberStyles.HexNumber);
            DateTime timeStamp = new DateTime(timeStampTicks);

            // Calculate the expiration date based on the validity period
            DateTime expirationDate = timeStamp.AddDays(LicenseValidityPeriodInDays);

            // Check if the expiration date has passed
            bool isExpired = DateTime.UtcNow > expirationDate;

            return isExpired;
        }
    }


}
