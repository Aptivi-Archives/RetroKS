//
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
// but WITHOUT ANY WARRANTY, without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.
//

using System.Collections.Generic;

namespace RetroKS
{
    static class ListFolders
    {

        public static List<string> AvailableDirs = new List<string>();

        public static void list(string folder)
        {

            if (folder == "bin" | (folder.StartsWith("/") | folder.StartsWith("..")) & folder.Substring(1) == "bin")
            {

                TextWriterColor.Wln(string.Join("* ", Shell.availableCommands) + "*", "neutralText");
            }

            else if (folder == "boot" | (folder.StartsWith("/") | folder.StartsWith("..")) & folder.Substring(1) == "boot")
            {

                TextWriterColor.Wln("loader~", "neutralText");
            }

            else if (folder == "dev" | (folder.StartsWith("/") | folder.StartsWith("..")) & folder.Substring(1) == "dev")
            {

                TextWriterColor.Wln("{0}hdpack", "neutralText", Kernel.slotsUsedName);
            }

            else if (folder == "etc" | (folder.StartsWith("/") | folder.StartsWith("..")) & folder.Substring(1) == "etc")
            {

                TextWriterColor.Wln("There is nothing.", "neutralText");
            }

            else if (folder == "lib" | (folder.StartsWith("/") | folder.StartsWith("..")) & folder.Substring(1) == "lib")
            {

                TextWriterColor.Wln("libuesh.elb", "neutralText");
            }

            else if (folder == "proc" | (folder.StartsWith("/") | folder.StartsWith("..")) & folder.Substring(1) == "proc")
            {

                TextWriterColor.Wln("kernel~ login~ uesh~", "neutralText");
            }

            else if (folder == "usr" | (folder.StartsWith("/") | folder.StartsWith("..")) & folder.Substring(1) == "usr")
            {

                TextWriterColor.Wln("There is nothing.", "neutralText");
            }

            else if (folder == "var" | (folder.StartsWith("/") | folder.StartsWith("..")) & folder.Substring(1) == "var")
            {

                TextWriterColor.Wln("There is nothing.", "neutralText");
            }

            else if (folder == ".." | folder == "/")
            {

                TextWriterColor.Wln(string.Join(", ", AvailableDirs), "neutralText");
            }

            else
            {

                TextWriterColor.Wln("There is nothing.", "neutralText");

            }

        }

    }
}