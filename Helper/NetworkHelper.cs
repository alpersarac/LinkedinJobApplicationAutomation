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
        public static string GetMacAddress()
        {
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up &&
                    networkInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    PhysicalAddress physicalAddress = networkInterface.GetPhysicalAddress();
                    byte[] macBytes = physicalAddress.GetAddressBytes();
                    string macAddress = BitConverter.ToString(macBytes);
                    return macAddress;
                }
            }

            return string.Empty; // MAC address not found
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
