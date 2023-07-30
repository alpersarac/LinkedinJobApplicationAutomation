using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Helper
{
    public static class NetworkHelper
    {
        public static string GetActiveMacAddress()
        {
            NetworkInterface activeInterface = null;

            // Get all network interfaces on the system
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            // Find the active network interface
            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up &&
                    (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                     networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211))
                {
                    activeInterface = networkInterface;
                    break; // Stop after finding the first active interface
                }
            }

            if (activeInterface != null)
            {
                PhysicalAddress physicalAddress = activeInterface.GetPhysicalAddress();
                return BitConverter.ToString(physicalAddress.GetAddressBytes());
            }
            else
            {
                return null; // No active network interface found
            }
        }
        public static List<string> GetMacAddresses()
        {
            List<string> macAddresses = new List<string>();
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                    networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    PhysicalAddress physicalAddress = networkInterface.GetPhysicalAddress();
                    string macAddress = BitConverter.ToString(physicalAddress.GetAddressBytes());
                    macAddresses.Add(macAddress);
                }
            }

            return macAddresses;
        }
    }
}
