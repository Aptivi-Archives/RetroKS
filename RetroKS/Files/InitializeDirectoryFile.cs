
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

using System;

namespace RetroKS
{
    static class InitializeDirectoryFile
    {

        /// <summary>
        /// Platform-dependent home path
        /// </summary>
        public static string HomePath
        {
            get
            {
                if (PlatformDetector.IsOnUnix())
                {
                    return Environment.GetEnvironmentVariable("HOME");
                }
                else
                {
                    return Environment.GetEnvironmentVariable("USERPROFILE").Replace(@"\", "/");
                }
            }
        }

        /// <summary>
        /// Platform-dependent application data path
        /// </summary>
        public static string AppDataPath
        {
            get
            {
                if (PlatformDetector.IsOnUnix())
                {
                    return Environment.GetEnvironmentVariable("HOME") + "/.config/retroks/";
                }
                else
                {
                    return (Environment.GetEnvironmentVariable("LOCALAPPDATA") + "/RetroKS/").Replace(@"\", "/");
                }
            }
        }

        public static void Init()
        {
            ListFolders.AvailableDirs.AddRange(new[] { "boot", "bin", "dev", "etc", "lib", "proc", "usr", "var" });
        }

    }
}