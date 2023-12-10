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
using System.Reflection;

namespace RetroKS
{

    static class Kernel
    {

        // Variables
        public static string KernelVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public static string[] BootArgs;
        public static string[] AvailableArgs =
            new string[] { "motd", "nohwprobe", "chkn=1", "preadduser", "hostname", "quiet", "gpuprobe", "cmdinject", "debug", "help" };
        public static string[] availableCMDLineArgs =
            new string[] { "createConf", "promptArgs" };
        public static string slotsUsedName;
        public static int slotsUsedNum;
        public static int totalSlots;
        public static StreamReader configReader;
        public static string Host;
        public static string MOTD;
        public readonly static string NewLine = Environment.NewLine;

        public static void KernelMain()
        {

            // A title
            Console.Title = "RetroKS version " + KernelVersion;

            try
            {
                // Parse real command-line arguments
                foreach (var argu in Environment.GetCommandLineArgs())
                    CommandLineArgsParse.parseCMDArguments(argu);

                // Make an app data folder
                if (!Directory.Exists(InitializeDirectoryFile.AppDataPath))
                    Directory.CreateDirectory(InitializeDirectoryFile.AppDataPath);

                // Create config file and then read it
                Config.checkForUpgrade();
                if (File.Exists(InitializeDirectoryFile.AppDataPath + @"\kernelConfig.ini") == true)
                {
                    configReader = new StreamReader(InitializeDirectoryFile.AppDataPath + @"\kernelConfig.ini");
                }
                else
                {
                    Config.createConfig(false);
                    configReader = new StreamReader(InitializeDirectoryFile.AppDataPath + @"\kernelConfig.ini");
                }
                Config.readConfig();

                // Show introduction. Don't remove license.
                TextWriterColor.Wln("|--+---> Welcome to the kernel, version {0} <---+--|", "neutralText", KernelVersion);
                TextWriterColor.Wln(NewLine + "    RetroKS  Copyright (C) 2022  Aptivi" + NewLine + "    This program comes with ABSOLUTELY NO WARRANTY, not even " + NewLine + "    MERCHANTABILITY or FITNESS for particular purposes." + NewLine + "    This is free software, and you are welcome to redistribute it" + NewLine + "    under certain conditions; See COPYING file in source code." + NewLine, "license");

                // Phase 0: Initialize time and files, and check for quietness
                if (Flags.argsOnBoot == true)
                {
                    ArgumentPrompt.PromptArgs();
                    if (Flags.argsFlag == true)
                    {
                        ArgumentParse.ParseArguments();
                    }
                }
                if (Flags.argsInjected == true)
                {
                    ArgumentParse.ParseArguments();
                    ArgumentPrompt.answerargs = "";
                    Flags.argsInjected = false;
                }
                if (Flags.TimeDateIsSet == false)
                {
                    TimeDate.InitializeTimeDate();
                    Flags.TimeDateIsSet = true;
                }
                InitializeDirectoryFile.Init();
                DebugWriter.Wdbg("Kernel initialized, version {0}.", true, KernelVersion);
                if (Flags.Quiet == true | Flags.quietProbe == true)
                {
                    // Continue the kernel, and don't print messages
                    // Phase 1: Username management
                    UserManagement.initializeMainUsers();
                    if (Flags.enableDemo == true)
                    {
                        UserManagement.adduser("demo");
                    }
                    Flags.LoginFlag = true;

                    // Phase 2: Check for pre-user making
                    if (Flags.CruserFlag == true)
                    {
                        UserManagement.adduser(ArgumentParse.arguser, ArgumentParse.argword);
                    }

                    // Phase 3: Free unused RAM and log-in
                    DisposeExit.DisposeAll();
                    if (Flags.LoginFlag == true & Flags.maintenance == false)
                    {
                        Login.LoginPrompt();
                    }
                    else if (Flags.LoginFlag == true & Flags.maintenance == true)
                    {
                        Flags.LoginFlag = false;
                        TextWriterColor.Wln("Enter the admin password for maintenance.", "neutralText");
                        Login.answeruser = "root";
                        Login.showPasswordPrompt("root");
                    }
                }
                else
                {
                    // Continue the kernel
                    // Phase 1: Username management
                    UserManagement.initializeMainUsers();
                    if (Flags.enableDemo == true)
                    {
                        UserManagement.adduser("demo");
                    }
                    Flags.LoginFlag = true;

                    // Phase 2: Check for pre-user making
                    if (Flags.CruserFlag == true)
                    {
                        UserManagement.adduser(ArgumentParse.arguser, ArgumentParse.argword);
                    }

                    // Phase 3: Free unused RAM and log-in if the kernel isn't on maintenance mode
                    DisposeExit.DisposeAll();
                    if (Flags.LoginFlag == true & Flags.maintenance == false)
                    {
                        Login.LoginPrompt();
                    }
                    else if (Flags.LoginFlag == true & Flags.maintenance == true)
                    {
                        Flags.LoginFlag = false;
                        TextWriterColor.Wln("Enter the admin password for maintenance.", "neutralText");
                        Login.answeruser = "root";
                        Login.showPasswordPrompt("root");
                    }
                }
            }
            catch (Exception ex)
            {
                if (Flags.DebugMode == true)
                {
                    TextWriterColor.Wln(ex.StackTrace, "uncontError");
                    DebugWriter.Wdbg(ex.StackTrace, true);
                }
                KernelTools.KernelError('U', true, 5L, "Kernel Error while booting: " + ex.Message);
            }

        }

    }
}
