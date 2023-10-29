
// RetroKS  Copyright (C) 2022  Aptivi
// 
// This file is part of RetroKS
// 
// RetroKS is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// RetroKS is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using System.Net.NetworkInformation;

namespace RetroKS
{

    static class NetworkTools
    {

        public static long adapterNumber;

        public static void GetProperties()
        {

            var adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                adapterNumber++;
                if (adapter.Supports(NetworkInterfaceComponent.IPv4) == false)
                {
                    if (Flags.DebugMode == true)
                    {
                        DebugWriter.Wdbg("{0} doesn't support IPv4 because ASSERT(adapter.Supp(IPv4) = True) = False.", true, adapter.Description);
                    }
                    continue;
                }
                else if (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet | adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet3Megabit | adapter.NetworkInterfaceType == NetworkInterfaceType.FastEthernetFx | adapter.NetworkInterfaceType == NetworkInterfaceType.FastEthernetT | adapter.NetworkInterfaceType == NetworkInterfaceType.GigabitEthernet | adapter.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    var adapterProperties = adapter.GetIPProperties();
                    var p = adapterProperties.GetIPv4Properties();
                    var s = adapter.GetIPv4Statistics();
                    if (p is null)
                    {
                        TextWriterColor.Wln("Failed to get properties for adapter {0}", "neutralText", adapter.Description);
                    }
                    else if (s is null)
                    {
                        TextWriterColor.Wln("Failed to get statistics for adapter {0}", "neutralText", adapter.Description);
                    }
                    TextWriterColor.Wln("Adapter Number: {0}" + Kernel.NewLine + "Adapter Name: {1}" + Kernel.NewLine + "Maximum Transmission Unit: {2} Units" + Kernel.NewLine + "Non-unicast packets: {3}/{4}" + Kernel.NewLine + "Unicast packets: {5}/{6}" + Kernel.NewLine + "Error incoming/outgoing packets: {7}/{8}", "neutralText", adapterNumber, adapter.Description, p.Mtu, s.NonUnicastPacketsSent, s.NonUnicastPacketsReceived, s.UnicastPacketsSent, s.UnicastPacketsReceived, s.IncomingPacketsWithErrors, s.OutgoingPacketsWithErrors);
                }
                else
                {
                    if (Flags.DebugMode == true)
                    {
                        DebugWriter.Wdbg("Adapter {0} doesn't belong in netinfo because the type is {1}", true, adapter.Description, adapter.NetworkInterfaceType);
                    }
                    continue;
                }
            }

        }

    }
}
