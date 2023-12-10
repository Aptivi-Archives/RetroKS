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
using System.Linq;
using Terminaux.Reader;

namespace RetroKS
{
    static class TemplateSet
    {

        public static void TemplatePrompt()
        {

            TextWriterColor.W("Available templates: {0}" + Kernel.NewLine + "Template: ", "input", string.Join(", ", Templates.colorTemplates));
            string answertemplate = TermReader.Read();
            templateSet(answertemplate);

        }

        internal static void templateSet(string theme)
        {

            if (Templates.colorTemplates.Contains(theme) == true)
            {
                if (theme == "Default")
                {
                    ColorSet.ResetColors();
                    Flags.templateSetExitFlag = true;
                }
                else if (theme == "RedConsole")
                {
                    ColorInitialize.inputColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.inputColorRC)));
                    ColorInitialize.licenseColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.licenseColorRC)));
                    ColorInitialize.contKernelErrorColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.contKernelErrorColorRC)));
                    ColorInitialize.uncontKernelErrorColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.uncontKernelErrorColorRC)));
                    ColorInitialize.hostNameShellColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.hostNameShellColorRC)));
                    ColorInitialize.userNameShellColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.userNameShellColorRC)));
                    ColorInitialize.backgroundColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.backgroundColorRC)));
                    ColorInitialize.neutralTextColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.neutralTextColorRC)));
                    LoadBackground.Load();
                    Flags.templateSetExitFlag = true;
                }
                else if (theme == "Bluespire")
                {
                    ColorInitialize.inputColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.inputColorBS)));
                    ColorInitialize.licenseColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.licenseColorBS)));
                    ColorInitialize.contKernelErrorColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.contKernelErrorColorBS)));
                    ColorInitialize.uncontKernelErrorColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.uncontKernelErrorColorBS)));
                    ColorInitialize.hostNameShellColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.hostNameShellColorBS)));
                    ColorInitialize.userNameShellColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.userNameShellColorBS)));
                    ColorInitialize.backgroundColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.backgroundColorBS)));
                    ColorInitialize.neutralTextColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.neutralTextColorBS)));
                    LoadBackground.Load();
                    Flags.templateSetExitFlag = true;
                }
                else if (theme == "Hacker")
                {
                    ColorInitialize.inputColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.inputColorHckr)));
                    ColorInitialize.licenseColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.licenseColorHckr)));
                    ColorInitialize.contKernelErrorColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.contKernelErrorColorHckr)));
                    ColorInitialize.uncontKernelErrorColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.uncontKernelErrorColorHckr)));
                    ColorInitialize.hostNameShellColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.hostNameShellColorHckr)));
                    ColorInitialize.userNameShellColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.userNameShellColorHckr)));
                    ColorInitialize.backgroundColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.backgroundColorHckr)));
                    ColorInitialize.neutralTextColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.neutralTextColorHckr)));
                    LoadBackground.Load();
                    Flags.templateSetExitFlag = true;
                }
                else if (theme == "LinuxUncolored")
                {
                    ColorInitialize.inputColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.inputColorLUnc)));
                    ColorInitialize.licenseColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.licenseColorLUnc)));
                    ColorInitialize.contKernelErrorColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.contKernelErrorColorLUnc)));
                    ColorInitialize.uncontKernelErrorColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.uncontKernelErrorColorLUnc)));
                    ColorInitialize.hostNameShellColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.hostNameShellColorLUnc)));
                    ColorInitialize.userNameShellColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.userNameShellColorLUnc)));
                    ColorInitialize.backgroundColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.backgroundColorLUnc)));
                    ColorInitialize.neutralTextColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.neutralTextColorLUnc)));
                    LoadBackground.Load();
                    Flags.templateSetExitFlag = true;
                }
                else if (theme == "LinuxColoredDef")
                {
                    ColorInitialize.inputColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.inputColorLcDef)));
                    ColorInitialize.licenseColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.licenseColorLcDef)));
                    ColorInitialize.contKernelErrorColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.contKernelErrorColorLcDef)));
                    ColorInitialize.uncontKernelErrorColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.uncontKernelErrorColorLcDef)));
                    ColorInitialize.hostNameShellColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.hostNameShellColorLcDef)));
                    ColorInitialize.userNameShellColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.userNameShellColorLcDef)));
                    ColorInitialize.backgroundColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.backgroundColorLcDef)));
                    ColorInitialize.neutralTextColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.neutralTextColorLcDef)));
                    LoadBackground.Load();
                    Flags.templateSetExitFlag = true;
                }
            }
            else
            {
                TextWriterColor.Wln("Invalid color template {0}", "neutralText", theme);
            }

        }

    }
}
