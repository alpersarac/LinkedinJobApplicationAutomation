using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedinJobApplier.Browser
{
    public static class FirefoxHelper
    {
        public static bool IsFirefoxInstalled()
        {
            // The registry key where Firefox installation information is stored
            const string firefoxRegistryKey = @"SOFTWARE\Mozilla\Mozilla Firefox";

            // The value name where the installation path is stored
            string firefoxInstallPathValueName = GetFirefoxInstallPath();

            // Attempt to read the Firefox installation path from the registry
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(firefoxRegistryKey))
            {
                if (key != null)
                {
                    string installPath = key.GetValue(firefoxInstallPathValueName) as string;

                    // If the installation path is not null or empty, then Firefox is installed
                    if (!string.IsNullOrEmpty(installPath))
                    {
                        return true;
                    }
                }
            }

            // If we reach this point, Firefox is not installed or the registry key couldn't be accessed
            return false;
        }
        public static string GetFirefoxInstallPath()
        {
            // The registry key where Firefox installation information is stored
            const string firefoxRegistryKey = @"SOFTWARE\Mozilla\Mozilla Firefox";

            // Attempt to open the main Firefox registry key
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(firefoxRegistryKey))
            {
                if (key != null)
                {
                    // Get all the value names under the main key
                    string[] valueNames = key.GetValueNames();

                    // Look for a value that contains the word "Install" in its name
                    foreach (string valueName in valueNames)
                    {
                        if (valueName.Contains("Install"))
                        {
                            // If the value is present, return the installation path
                            return key.GetValue(valueName) as string;
                        }
                    }
                }
            }

            // If the key or value is not found, return an empty string or handle the situation accordingly
            return string.Empty;
        }
    }
}
