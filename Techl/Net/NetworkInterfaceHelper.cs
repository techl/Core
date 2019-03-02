// working
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace Techl.Net
{
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    public static class NetworkInterfaceHelper
    {
        #region GetBestLocalIPAddress

        [DllImport("Iphlpapi.dll")]
        internal static extern int GetBestInterface(uint destAddr, out uint bestIfIndex);

        private static NetworkInterface GetNetworkInterfaceByIndex(uint index)
        {
               // Search in all network interfaces that support IPv4.
               NetworkInterface ipv4Interface = (from thisInterface in NetworkInterface.GetAllNetworkInterfaces()
                                              where thisInterface.Supports(NetworkInterfaceComponent.IPv4)
                                              let ipv4Properties = thisInterface.GetIPProperties().GetIPv4Properties()
                                              where ipv4Properties != null && ipv4Properties.Index == index
                                              select thisInterface).SingleOrDefault();
            if (ipv4Interface != null)
                return ipv4Interface;

            // Search in all network interfaces that support IPv6.
            NetworkInterface ipv6Interface = (from thisInterface in NetworkInterface.GetAllNetworkInterfaces()
                                              where thisInterface.Supports(NetworkInterfaceComponent.IPv6)
                                              let ipv6Properties = thisInterface.GetIPProperties().GetIPv6Properties()
                                              where ipv6Properties != null && ipv6Properties.Index == index
                                              select thisInterface).SingleOrDefault();

            return ipv6Interface;
        }

        public static IPAddress GetBestLocalIPAddress(IPAddress destinationAddress)
        {
            uint index = 0;
            int result = GetBestInterface(BitConverter.ToUInt32(destinationAddress.GetAddressBytes(), 0), out index);
            if (result != 0)
            {
                throw new Win32Exception(result);
            }

            var networkInterface = GetNetworkInterfaceByIndex(index);
            var ipProperties = networkInterface.GetIPProperties();

            var ipv4 = ipProperties.UnicastAddresses.Where(i => i.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
            if (ipv4.Any())
                return ipv4.First().Address;
            else
                return ipProperties.UnicastAddresses.FirstOrDefault()?.Address;
        }

        #endregion

        public static IPAddress GetBesLocalIPAddressManaged(string destinationAddress)
        {
            UdpClient udp = new UdpClient(destinationAddress, 1);
            return ((IPEndPoint)udp.Client.LocalEndPoint).Address;
        }
    }
}
