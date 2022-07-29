
'    RetroKS  Copyright (C) 2022  EoflaOE
'
'    This file is part of RetroKS
'
'    RetroKS is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    RetroKS is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with this program.  If not, see <https://www.gnu.org/licenses/>.

Imports System.Net.NetworkInformation

Module NetworkTools

    Public adapterNumber As Long

    Sub getProperties()

        Dim proper As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces
        For Each adapter As NetworkInterface In adapters
            adapterNumber = adapterNumber + 1
            If adapter.Supports(NetworkInterfaceComponent.IPv4) = False Then
                If DebugMode = True Then
                    Wdbg("{0} doesn't support IPv4 because ASSERT(adapter.Supp(IPv4) = True) = False.", True, adapter.Description)
                End If
                GoTo Cont
            ElseIf adapter.NetworkInterfaceType = NetworkInterfaceType.Ethernet Or _
                    adapter.NetworkInterfaceType = NetworkInterfaceType.Ethernet3Megabit Or _
                    adapter.NetworkInterfaceType = NetworkInterfaceType.FastEthernetFx Or _
                    adapter.NetworkInterfaceType = NetworkInterfaceType.FastEthernetT Or _
                    adapter.NetworkInterfaceType = NetworkInterfaceType.GigabitEthernet Or _
                    adapter.NetworkInterfaceType = NetworkInterfaceType.Wireless80211 Then
                Dim adapterProperties As IPInterfaceProperties = adapter.GetIPProperties()
                Dim p As IPv4InterfaceProperties = adapterProperties.GetIPv4Properties
                Dim s As IPv4InterfaceStatistics = adapter.GetIPv4Statistics
                If p Is Nothing Then
                    Wln("Failed to get properties for adapter {0}", "neutralText", adapter.Description)
                ElseIf s Is Nothing Then
                    Wln("Failed to get statistics for adapter {0}", "neutralText", adapter.Description)
                End If
                Wln("Adapter Number: {0}" + vbNewLine + 
                    "Adapter Name: {1}" + vbNewLine + 
                    "Maximum Transmission Unit: {2} Units" + vbNewLine + 
                    "DHCP Enabled: {3}" + vbNewLine + 
                    "Non-unicast packets: {4}/{5}" + vbNewLine + 
                    "Unicast packets: {6}/{7}" + vbNewLine + 
                    "Error incoming/outgoing packets: {8}/{9}", "neutralText", _
                    adapterNumber, adapter.Description, p.Mtu, p.IsDhcpEnabled, s.NonUnicastPacketsSent, s.NonUnicastPacketsReceived, _
                    s.UnicastPacketsSent, s.UnicastPacketsReceived, s.IncomingPacketsWithErrors, s.OutgoingPacketsWithErrors)
            Else
                If DebugMode = True Then
                    Wdbg("Adapter {0} doesn't belong in netinfo because the type is {1}", True, adapter.Description, adapter.NetworkInterfaceType)
                End If
                GoTo Cont
            End If
Cont:
        Next

    End Sub

End Module
