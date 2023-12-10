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
using System.IO;

namespace RetroKS
{

    static class Config
    {

        public static void createConfig(bool CmdArg)
        {
            try
            {
                var writer = new StreamWriter(InitializeDirectoryFile.AppDataPath + @"\kernelConfig.ini");
                writer.WriteLine("Kernel Version = {0}" + Kernel.NewLine + "Customized Colors on Boot = False" + Kernel.NewLine + "User Name Shell Color = {1}" + Kernel.NewLine + "Host Name Shell Color = {2}" + Kernel.NewLine + "Continuable Kernel Error Color = {3}" + Kernel.NewLine + "Uncontinuable Kernel Error Color = {4}" + Kernel.NewLine + "Text Color = {5}" + Kernel.NewLine + "License Color = {6}" + Kernel.NewLine + "Create Demo Account = True" + Kernel.NewLine + "Change Root Password = False" + Kernel.NewLine + "Set Root Password to = toor" + Kernel.NewLine + "Maintenance Mode = False" + Kernel.NewLine + "Prompt for Arguments on Boot = False" + Kernel.NewLine + "Clear Screen on Log-in = False" + Kernel.NewLine + "Show MOTD on Log-in = True" + Kernel.NewLine + "Simplified Help Command = False" + Kernel.NewLine + "Colored Shell = True" + Kernel.NewLine + "Probe Slots = True" + Kernel.NewLine + "Quiet Probe = False" + Kernel.NewLine + "Probe GPU = False" + Kernel.NewLine + "Background Color = {7}" + Kernel.NewLine + "Input Color = {8}", Kernel.KernelVersion, ColorInitialize.userNameShellColor, ColorInitialize.hostNameShellColor, ColorInitialize.contKernelErrorColor, ColorInitialize.uncontKernelErrorColor, ColorInitialize.neutralTextColor, ColorInitialize.licenseColor, ColorInitialize.backgroundColor, ColorInitialize.inputColor);





















                writer.Close();
                writer.Dispose();
                if (CmdArg == true)
                {
                    DisposeExit.DisposeAll();
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                if (Flags.DebugMode == true)
                {
                    DebugWriter.Wdbg(ex.StackTrace, true);
                    TextWriterColor.Wln("There is an error trying to create configuration: {0}." + Kernel.NewLine + ex.StackTrace, "neutralText", ex.Message);
                }
                else
                {
                    TextWriterColor.Wln("There is an error trying to create configuration.", "neutralText");
                }
                if (CmdArg == true)
                {
                    DisposeExit.DisposeAll();
                    Environment.Exit(2);
                }
            }
        }

        public static void checkForUpgrade()
        {
            try
            {
                var lns = File.ReadAllLines(InitializeDirectoryFile.AppDataPath + @"\kernelConfig.ini");
                if (lns[0].Contains("Kernel Version = ") & (lns[0].Replace("Kernel Version = ", "") ?? "") != (Kernel.KernelVersion ?? ""))
                {
                    if (lns.Length > 0 && lns[0].StartsWith("Kernel Version = "))
                    {
                        TextWriterColor.Wln("An upgrade from {0} to {1} was detected. Updating configuration file...", "neutralText", lns[0].Replace("Kernel Version = ", ""), Kernel.KernelVersion);
                        lns[0] = "Kernel Version = " + Kernel.KernelVersion;
                        File.WriteAllLines(InitializeDirectoryFile.AppDataPath + @"\kernelConfig.ini", lns);
                    }
                }
            }
            catch (Exception ex)
            {
                if (Flags.DebugMode == true)
                {
                    DebugWriter.Wdbg(ex.StackTrace, true);
                    TextWriterColor.Wln("There is an error trying to update configuration: {0}." + Kernel.NewLine + ex.StackTrace, "neutralText", ex.Message);
                }
                else
                {
                    TextWriterColor.Wln("There is an error trying to update configuration.", "neutralText");
                }
            }
        }

        public static void readConfig()
        {
            try
            {
                string line = Kernel.configReader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    if (line.Contains("Customized Colors on Boot = "))
                    {
                        if (line.Replace("Customized Colors on Boot = ", "") == "True")
                        {
                            Flags.customColor = true;
                        }
                        else
                        {
                            Flags.customColor = false;
                        }
                    }
                    else if (line.Contains("User Name Shell Color = "))
                    {
                        ColorInitialize.userNameShellColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), line.Replace("User Name Shell Color = ", "")));
                    }
                    else if (line.Contains("Host Name Shell Color = "))
                    {
                        ColorInitialize.hostNameShellColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), line.Replace("Host Name Shell Color = ", "")));
                    }
                    else if (line.Contains("Continuable Kernel Error Color = "))
                    {
                        ColorInitialize.contKernelErrorColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), line.Replace("Continuable Kernel Error Color = ", "")));
                    }
                    else if (line.Contains("Uncontinuable Kernel Error Color = "))
                    {
                        ColorInitialize.uncontKernelErrorColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), line.Replace("Uncontinuable Kernel Error Color = ", "")));
                    }
                    else if (line.Contains("Text Color = "))
                    {
                        ColorInitialize.neutralTextColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), line.Replace("Text Color = ", "")));
                    }
                    else if (line.Contains("License Color = "))
                    {
                        ColorInitialize.licenseColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), line.Replace("License Color = ", "")));
                    }
                    else if (line.Contains("Background Color = "))
                    {
                        ColorInitialize.backgroundColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), line.Replace("Background Color = ", "")));
                        LoadBackground.Load();
                    }
                    else if (line.Contains("Input Color = "))
                    {
                        ColorInitialize.inputColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), line.Replace("Input Color = ", "")));
                    }
                    else if (line.Contains("Create Demo Account = "))
                    {
                        if (line.Replace("Create Demo Account = ", "") == "True")
                        {
                            Flags.enableDemo = true;
                        }
                        else if (line.Replace("Create Demo Account = ", "") == "False")
                        {
                            Flags.enableDemo = false;
                        }
                    }
                    else if (line.Contains("Change Root Password = "))
                    {
                        if (line.Replace("Change Root Password = ", "") == "True")
                        {
                            Flags.setRootPasswd = true;
                        }
                        else if (line.Replace("Change Root Password = ", "") == "False")
                        {
                            Flags.setRootPasswd = false;
                        }
                    }
                    else if (line.Contains("Set Root Password to = "))
                    {
                        if (Flags.setRootPasswd == true)
                        {
                            Flags.RootPasswd = line.Replace("Set Root Password to = ", "");
                        }
                    }
                    else if (line.Contains("Maintenance Mode = "))
                    {
                        if (line.Replace("Maintenance Mode = ", "") == "True")
                        {
                            Flags.maintenance = true;
                        }
                        else if (line.Replace("Maintenance Mode = ", "") == "False")
                        {
                            Flags.maintenance = false;
                        }
                    }
                    else if (line.Contains("Prompt for Arguments on Boot = "))
                    {
                        if (line.Replace("Prompt for Arguments on Boot = ", "") == "True")
                        {
                            Flags.argsOnBoot = true;
                        }
                        else if (line.Replace("Prompt for Arguments on Boot = ", "") == "False")
                        {
                            Flags.argsOnBoot = false;
                        }
                    }
                    else if (line.Contains("Clear Screen on Log-in = "))
                    {
                        if (line.Replace("Clear Screen on Log-in = ", "") == "True")
                        {
                            Flags.clsOnLogin = true;
                        }
                        else if (line.Replace("Clear Screen on Log-in = ", "") == "False")
                        {
                            Flags.clsOnLogin = false;
                        }
                    }
                    else if (line.Contains("Show MOTD on Log-in = "))
                    {
                        if (line.Replace("Show MOTD on Log-in = ", "") == "True")
                        {
                            Flags.showMOTD = true;
                        }
                        else if (line.Replace("Show MOTD on Log-in = ", "") == "False")
                        {
                            Flags.showMOTD = false;
                        }
                    }
                    else if (line.Contains("Simplified Help Command = "))
                    {
                        if (line.Replace("Simplified Help Command = ", "") == "True")
                        {
                            Flags.simHelp = true;
                        }
                        else if (line.Replace("Simplified Help Command = ", "") == "False")
                        {
                            Flags.simHelp = false;
                        }
                    }
                    else if (line.Contains("Colored Shell = "))
                    {
                        if (line.Replace("Colored Shell = ", "") == "False")
                        {
                            TemplateSet.templateSet("LinuxUncolored");
                        }
                    }
                    else if (line.Contains("Probe Slots = "))
                    {
                        if (line.Replace("Probe Slots = ", "") == "True")
                        {
                            Flags.slotProbe = true;
                        }
                        else if (line.Replace("Probe Slots = ", "") == "False")
                        {
                            Flags.slotProbe = false;
                        }
                    }
                    else if (line.Contains("Quiet Probe = "))
                    {
                        if (line.Replace("Quiet Probe = ", "") == "True")
                        {
                            Flags.quietProbe = true;
                        }
                        else if (line.Replace("Quiet Probe = ", "") == "False")
                        {
                            Flags.quietProbe = false;
                        }
                    }
                    else if (line.Contains("Probe GPU = "))
                    {
                        if (line.Replace("Probe GPU = ", "") == "True")
                        {
                            Flags.GPUProbeFlag = true;
                        }
                        else if (line.Replace("Probe GPU = ", "") == "False")
                        {
                            Flags.GPUProbeFlag = false;
                        }
                    }
                    line = Kernel.configReader.ReadLine();
                }
                Kernel.configReader.Close();
                Kernel.configReader.Dispose();
            }
            catch (Exception ex)
            {
                if (Flags.DebugMode == true)
                {
                    DebugWriter.Wdbg(ex.StackTrace, true);
                    TextWriterColor.Wln("There is an error trying to read configuration: {0}." + Kernel.NewLine + ex.StackTrace, "neutralText", ex.Message);
                }
                else
                {
                    TextWriterColor.Wln("There is an error trying to read configuration.", "neutralText");
                }
            }
        }

    }
}