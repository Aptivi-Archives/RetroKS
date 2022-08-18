
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

namespace RetroKS
{
    static class FileContents
    {

        public static string[] AvailableFiles = new string[] { "loader", "hdpack", "libuesh.elb", "kernel", "login", "uesh" };

        public static void readContents(string filename)
        {

            if (filename == "loader")
            {

                TextWriterColor.Wln("Boot_Version = {0}", "neutralText", Kernel.KernelVersion);
            }

            else if (filename == "hdpack")
            {

                TextWriterColor.Wln("System", "neutralText");
            }

            else if (filename == "libuesh.elb")
            {

                TextWriterColor.Wln("[startelb]=ueshlib-<UESH Library Version 0.0.3>-", "neutralText");
            }

            else if (filename == "kernel")
            {

                TextWriterColor.Wln("Kernel process PID: 1" + Kernel.NewLine + "Priority: High" + Kernel.NewLine + "Importance: High, and shouldn't be killed.", "neutralText");
            }

            else if (filename == "login")
            {

                TextWriterColor.Wln("Login process PID: 2" + Kernel.NewLine + "Priority: Normal" + Kernel.NewLine + "Importance: High, and shouldn't be killed.", "neutralText");
            }

            else if (filename == "uesh")
            {

                TextWriterColor.Wln("UESH process PID: 3" + Kernel.NewLine + "Priority: Normal" + Kernel.NewLine + "Importance: Normal." + Kernel.NewLine + "Short For: Unified Eofla SHell", "neutralText");

            }

        }

    }
}