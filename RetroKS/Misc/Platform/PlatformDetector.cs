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

using System;

namespace RetroKS
{
    static class PlatformDetector
    {

        /// <summary>
        /// Is this system a Windows system?
        /// </summary>
        public static bool IsOnWindows()
        {
            return Environment.OSVersion.Platform == PlatformID.Win32NT;
        }

        /// <summary>
        /// Is this system a Unix system? True for macOS, too!
        /// </summary>
        public static bool IsOnUnix()
        {
            return Environment.OSVersion.Platform == PlatformID.Unix;
        }

        /// <summary>
        /// Are we running KS on Mono?
        /// </summary>
        public static bool IsOnMonoRuntime()
        {
            return Type.GetType("Mono.Runtime") is not null;
        }

    }
}