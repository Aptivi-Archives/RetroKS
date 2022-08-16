using System;
using System.Diagnostics;

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

    static class Network
    {

        public static void CheckNetworkKernel()
        {

            if (NetworkInterface.GetIsNetworkAvailable())
            {
                TextWriterColor.W("net: Network available." + Kernel.NewLine + "net: Checking for connectivity..." + Kernel.NewLine + "net: Write address, or URL: ", "input");
                string AnswerPing = Console.ReadLine();
                if (AnswerPing != "q")
                {
                    PingTargetKernel(AnswerPing);
                }
                else
                {
                    TextWriterColor.Wln("Network checking has been cancelled.", "neutralText");
                }
            }
            else
            {
                TextWriterColor.Wln("net: Network not available.", "neutralText");
            }

        }

        public static void CheckNetworkCommand()
        {

            if (NetworkInterface.GetIsNetworkAvailable())
            {
                TextWriterColor.W("net: Write address, or URL: ", "input");
                string AnswerPing = Console.ReadLine();
                if (AnswerPing != "q")
                {
                    PingTarget(AnswerPing);
                }
                else
                {
                    TextWriterColor.Wln("Network checking has been cancelled.", "neutralText");
                }
            }
            else
            {
                TextWriterColor.Wln("net: Network not available.", "neutralText");
            }

        }

        public static void PingTargetKernel(string Address)
        {
            try
            {
                var Pinger = new Ping();
                if (Pinger.Send(Address).Status == IPStatus.Success)
                {
                    TextWriterColor.Wln("net: Connection is ready.", "neutralText");
                }
            }
            catch (Exception ex)
            {
                TextWriterColor.Wln("net: Connection is not ready, server error, or connection problem.", "neutralText", ex.Message);
            }
        }

        public static void PingTarget(string Address, short repeatTimes = 3)
        {
            try
            {
                var s = new Stopwatch();
                var Pinger = new Ping();
                if (repeatTimes != 1 & !(repeatTimes < 0))
                {
                    for (short i = 1, loopTo = repeatTimes; i <= loopTo; i++)
                    {
                        s.Start();
                        if (Pinger.Send(Address).Status == IPStatus.Success)
                        {
                            TextWriterColor.Wln("{0}/{1} {2}: {3} ms", "neutralText", repeatTimes, i, Address, s.ElapsedMilliseconds.ToString());
                        }
                        s.Reset();
                    }
                }
                else if (repeatTimes == 1)
                {
                    s.Start();
                    if (Pinger.Send(Address).Status == IPStatus.Success)
                    {
                        TextWriterColor.Wln("net: Got response from {0} in {1} ms", "neutralText", Address, s.ElapsedMilliseconds.ToString());
                    }
                    s.Stop();
                }
            }
            catch (Exception ex)
            {
                TextWriterColor.Wln("net: Site was down, isn't reachable, server error or connection problem. {0}", "neutralText", ex.Message);
            }
        }

    }
}