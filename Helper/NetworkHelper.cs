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
        public static List<string> GetMacAddress()
        {
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            List<string> macAddresses = new List<string>();
            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up &&
                    networkInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    PhysicalAddress physicalAddress = networkInterface.GetPhysicalAddress();
                    byte[] macBytes = physicalAddress.GetAddressBytes();
                    string macAddress = BitConverter.ToString(macBytes);
                    macAddresses.Add(macAddress);
                }
            }

            return macAddresses; // MAC address not found
        }
    }
}
