using System;

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

using static System.Console;

namespace RetroKS
{

    // This module is very important to reduce line numbers when there is color.
    static class TextWriterColor
    {

        /// <summary>
    /// Outputs the text into the terminal prompt, and sets colors as needed.
    /// </summary>
    /// <param name="text">A sentence that will be written to the terminal prompt. Supports {0}, {1}, ...</param>
    /// <param name="colorType">A type of colors that will be changed. Any of neutralText, input, contError, uncontError, hostName, userName, def, or license.</param>
    /// <param name="vars">Endless amounts of any variables that is separated by commas.</param>
    /// <remarks>This is used to reduce number of lines containing "System.Console.ForegroundColor = " and "System.Console.ResetColor()" text.</remarks>
        public static void W(string text, string colorType, params object[] vars)
        {
            try
            {
                if (colorType == "neutralText")
                {
                    ForegroundColor = (ConsoleColor)Convert.ToInt32(ColorInitialize.neutralTextColor);
                }
                else if (colorType == "input")
                {
                    ForegroundColor = (ConsoleColor)Convert.ToInt32(ColorInitialize.neutralTextColor);
                }
                else if (colorType == "contError")
                {
                    ForegroundColor = (ConsoleColor)Convert.ToInt32(ColorInitialize.contKernelErrorColor);
                }
                else if (colorType == "uncontError")
                {
                    ForegroundColor = (ConsoleColor)Convert.ToInt32(ColorInitialize.uncontKernelErrorColor);
                }
                else if (colorType == "hostName")
                {
                    ForegroundColor = (ConsoleColor)Convert.ToInt32(ColorInitialize.hostNameShellColor);
                }
                else if (colorType == "userName")
                {
                    ForegroundColor = (ConsoleColor)Convert.ToInt32(ColorInitialize.userNameShellColor);
                }
                else if (colorType == "license")
                {
                    ForegroundColor = (ConsoleColor)Convert.ToInt32(ColorInitialize.licenseColor);
                }
                else if (colorType == "def")
                {
                    ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    return;
                }
                Write(text, vars);
                if (BackgroundColor == ConsoleColor.Black)
                {
                    ResetColor();
                }
                if (colorType == "input")
                {
                    ForegroundColor = (ConsoleColor)Convert.ToInt32(ColorInitialize.inputColor);
                }
            }
            catch (Exception)
            {
                KernelTools.KernelError('C', false, 0L, "There is a serious error when printing text.");
            }
        }

        /// <summary>
    /// Outputs the text into the terminal prompt, sets colors as needed, and returns a new line.
    /// </summary>
    /// <param name="text">A sentence that will be written to the terminal prompt. Supports {0}, {1}, ...</param>
    /// <param name="colorType">A type of colors that will be changed.  Any of neutralText, input, contError, uncontError, hostName, userName, def, or license.</param>
    /// <param name="vars">Endless amounts of any variables that is separated by commas.</param>
    /// <remarks>This is used to reduce number of lines containing "System.Console.ForegroundColor = " and "System.Console.ResetColor()" text.</remarks>
        public static void Wln(string text, string colorType, params object[] vars)
        {
            try
            {
                if (colorType == "neutralText")
                {
                    ForegroundColor = (ConsoleColor)Convert.ToInt32(ColorInitialize.neutralTextColor);
                }
                else if (colorType == "input")
                {
                    ForegroundColor = (ConsoleColor)Convert.ToInt32(ColorInitialize.neutralTextColor);
                }
                else if (colorType == "contError")
                {
                    ForegroundColor = (ConsoleColor)Convert.ToInt32(ColorInitialize.contKernelErrorColor);
                }
                else if (colorType == "uncontError")
                {
                    ForegroundColor = (ConsoleColor)Convert.ToInt32(ColorInitialize.uncontKernelErrorColor);
                }
                else if (colorType == "hostName")
                {
                    ForegroundColor = (ConsoleColor)Convert.ToInt32(ColorInitialize.hostNameShellColor);
                }
                else if (colorType == "userName")
                {
                    ForegroundColor = (ConsoleColor)Convert.ToInt32(ColorInitialize.userNameShellColor);
                }
                else if (colorType == "license")
                {
                    ForegroundColor = (ConsoleColor)Convert.ToInt32(ColorInitialize.licenseColor);
                }
                else if (colorType == "def")
                {
                    ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    return;
                }
                WriteLine(text, vars);
                if (BackgroundColor == ConsoleColor.Black)
                {
                    ResetColor();
                }
                if (colorType == "input")
                {
                    ForegroundColor = (ConsoleColor)Convert.ToInt32(ColorInitialize.inputColor);
                }
            }
            catch (Exception)
            {
                KernelTools.KernelError('C', false, 0L, "There is a serious error when printing text.");
            }
        }

    }
}