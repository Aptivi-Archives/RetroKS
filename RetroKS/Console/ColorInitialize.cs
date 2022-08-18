
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
    static class ColorInitialize
    {

        // Variables for colors used by previous versions of Kernel.
        public static object inputColor = ConsoleColor.White;
        public static object licenseColor = ConsoleColor.White;
        public static object contKernelErrorColor = ConsoleColor.Yellow;
        public static object uncontKernelErrorColor = ConsoleColor.Red;
        public static object hostNameShellColor = ConsoleColor.DarkGreen;
        public static object userNameShellColor = ConsoleColor.Green;
        public static object backgroundColor = ConsoleColor.Black;
        public static object neutralTextColor = ConsoleColor.Gray;

        // Array for available colors
        public static string[] availableColors = new string[] { "White", "Gray", "DarkGray", "DarkRed", "Red", "DarkYellow", "Yellow", "DarkGreen", "Green", "DarkCyan", "Cyan", "DarkBlue", "Blue", "DarkMagenta", "Magenta", "RESET", "THEME" };

    }
}