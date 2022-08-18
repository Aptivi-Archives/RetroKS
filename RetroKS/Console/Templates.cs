
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
    static class Templates
    {

        // Templates array (available ones)
        public static string[] colorTemplates = new string[] { "Default", "RedConsole", "Bluespire", "Hacker", "LinuxUncolored", "LinuxColoredDef" };

        // Variables for the "Default" theme
        public static object inputColorDef = ColorInitialize.inputColor;
        public static object licenseColorDef = ColorInitialize.licenseColor;
        public static object contKernelErrorColorDef = ColorInitialize.contKernelErrorColor;
        public static object uncontKernelErrorColorDef = ColorInitialize.uncontKernelErrorColor;
        public static object hostNameShellColorDef = ColorInitialize.hostNameShellColor;
        public static object userNameShellColorDef = ColorInitialize.userNameShellColor;
        public static object backgroundColorDef = ColorInitialize.backgroundColor;
        public static object neutralTextColorDef = ColorInitialize.neutralTextColor;

        // Variables for the "RedConsole" theme
        public static object inputColorRC = ConsoleColor.Red;
        public static object licenseColorRC = ConsoleColor.Red;
        public static object contKernelErrorColorRC = ConsoleColor.Red;
        public static object uncontKernelErrorColorRC = ConsoleColor.DarkRed;
        public static object hostNameShellColorRC = ConsoleColor.DarkRed;
        public static object userNameShellColorRC = ConsoleColor.Red;
        public static object backgroundColorRC = ConsoleColor.Black;
        public static object neutralTextColorRC = ConsoleColor.Red;

        // Variables for the "Bluespire" theme
        public static object inputColorBS = ConsoleColor.Cyan;
        public static object licenseColorBS = ConsoleColor.Cyan;
        public static object contKernelErrorColorBS = ConsoleColor.Blue;
        public static object uncontKernelErrorColorBS = ConsoleColor.Blue;
        public static object hostNameShellColorBS = ConsoleColor.Blue;
        public static object userNameShellColorBS = ConsoleColor.Blue;
        public static object backgroundColorBS = ConsoleColor.DarkCyan;
        public static object neutralTextColorBS = ConsoleColor.Cyan;

        // Variables for the "Hacker" theme
        public static object inputColorHckr = ConsoleColor.Green;
        public static object licenseColorHckr = ConsoleColor.Green;
        public static object contKernelErrorColorHckr = ConsoleColor.Green;
        public static object uncontKernelErrorColorHckr = ConsoleColor.Green;
        public static object hostNameShellColorHckr = ConsoleColor.Green;
        public static object userNameShellColorHckr = ConsoleColor.Green;
        public static object backgroundColorHckr = ConsoleColor.DarkGray;
        public static object neutralTextColorHckr = ConsoleColor.Green;

        // Variables for the "LinuxUncolored" theme
        public static object inputColorLUnc = ConsoleColor.Gray;
        public static object licenseColorLUnc = ConsoleColor.Gray;
        public static object contKernelErrorColorLUnc = ConsoleColor.Gray;
        public static object uncontKernelErrorColorLUnc = ConsoleColor.Gray;
        public static object hostNameShellColorLUnc = ConsoleColor.Gray;
        public static object userNameShellColorLUnc = ConsoleColor.Gray;
        public static object backgroundColorLUnc = ConsoleColor.Black;
        public static object neutralTextColorLUnc = ConsoleColor.Gray;

        // Variables for the "LinuxColoredDef" theme
        // If there is a mistake in colors, please fix it.
        public static object inputColorLcDef = ConsoleColor.Gray;
        public static object licenseColorLcDef = ConsoleColor.Gray;
        public static object contKernelErrorColorLcDef = ConsoleColor.Gray;
        public static object uncontKernelErrorColorLcDef = ConsoleColor.Gray;
        public static object hostNameShellColorLcDef = ConsoleColor.Blue;
        public static object userNameShellColorLcDef = ConsoleColor.Blue;
        public static object backgroundColorLcDef = ConsoleColor.Black;
        public static object neutralTextColorLcDef = ConsoleColor.Gray;

    }
}