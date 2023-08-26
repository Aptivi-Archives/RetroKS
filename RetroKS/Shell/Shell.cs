
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
using System.Linq;
using Terminaux.Reader;

namespace RetroKS
{
    static class Shell
    {

        // Available Commands (availableCommands())
        // Admin-Only commands (strictCmds())
        public static string ueshversion = "0.0.4";                  // Current shell version
        public static string strcommand;                             // Written Command
        public static string[] availableCommands = new string[] { "help", "logout", "version", "currentdir", "list", "changedir", "cdir", "ls", "chdir", "cd", "read", "echo", "choice", "shutdown", "reboot", "disco", "future-eyes-destroyer", "beep", "annoying-sound", "adduser", "chmotd", "chhostname", "showmotd", "fed", "ping", "showtd", "chpwd", "sysinfo", "arginj", "panicsim", "setcolors", "rmuser", "cls", "perm", "chusrname", "setthemes", "netinfo", "calc", "scical", "unitconv", "md", "mkdir", "rd", "rmdir", "debuglog", "reloadconfig" };
        public static string[] strictCmds = new string[] { "adduser", "perm", "arginj", "chhostname", "chmotd", "chusrname", "rmuser", "netinfo", "debuglog", "reloadconfig" };

        // For contributors: For each added command, you should also add a command in availableCommands array so there is no problems detecting your new command.
        // For each added admin command, you should also add a command in strictCmds array after performing above procedure so there is no problems 
        // checking if user has Admin permission to use your new admin command.

        public static void initializeShell()
        {

            // Initialize Shell
            getLine(true);
            commandPromptWrite();
            DisposeExit.DisposeAll();
            Console.ForegroundColor = (ConsoleColor)Convert.ToInt32(ColorInitialize.inputColor);
            strcommand = TermReader.Read();
            getLine();

        }

        public static void commandPromptWrite()
        {

            if (Groups.adminList[Login.signedinusrnm] == true)
            {
                TextWriterColor.W("[", "def");
                TextWriterColor.W("{0}", "userName", Login.signedinusrnm);
                TextWriterColor.W("@", "def");
                TextWriterColor.W("{0}", "hostName", Kernel.Host);
                TextWriterColor.W("]{0} # ", "def", CurrentDir.currDir);
            }
            else
            {
                TextWriterColor.W("[", "def");
                TextWriterColor.W("{0}", "userName", Login.signedinusrnm);
                TextWriterColor.W("@", "def");
                TextWriterColor.W("{0}", "hostName", Kernel.Host);
                TextWriterColor.W("]{0} $ ", "def", CurrentDir.currDir);
            }

        }

        public static void getLine(bool ArgsMode = false)
        {

            // Reads command written by user
            try
            {
                if (ArgsMode == false)
                {
                    if (string.IsNullOrEmpty(strcommand) | strcommand.StartsWith(" ") == true)
                    {
                        if (!Flags.ShuttingDown)
                            initializeShell();
                    }
                    else
                    {
                        var groupCmds = strcommand.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var cmd in groupCmds)
                        {
                            int indexCmd = cmd.IndexOf(" ");
                            string commandName = "";
                            if (indexCmd == -1)
                            {
                                indexCmd = cmd.Count();
                            }
                            commandName = cmd.Substring(0, indexCmd);
                            if (Groups.adminList[Login.signedinusrnm] == false & strictCmds.Contains(commandName) == true)
                            {
                                DebugWriter.Wdbg("Cmd exec {0} failed: adminList.ASSERT(signedinusrnm) = False, strictCmds.Cont({0}.Substr(0, {1})) = True", true, commandName, indexCmd);
                                TextWriterColor.Wln("You don't have permission to use {0}", "neutralText", commandName);
                            }
                            else if (Flags.maintenance == true & cmd.Contains("logout"))
                            {
                                DebugWriter.Wdbg("Cmd exec {0} failed: maintenance = True && input.Cont(\"logout\") = True", true, commandName, indexCmd);
                                TextWriterColor.Wln("Shell message: The requested command {0} is not allowed to run in maintenance mode.", "neutralText", commandName);
                            }
                            else if (Groups.adminList[Login.signedinusrnm] == true & strictCmds.Contains(commandName) == true | availableCommands.Contains(commandName))
                            {
                                DebugWriter.Wdbg("Cmd exec: {0}", true, commandName);
                                GetCommand.ExecuteCommand(cmd);
                            }
                            else
                            {
                                DebugWriter.Wdbg("Cmd exec {0} failed: availableCmds.Cont({0}.Substring(0, {1})) = False", true, commandName, indexCmd);
                                TextWriterColor.Wln("Shell message: The requested command {0} is not found. See 'help' for available commands.", "neutralText", commandName);
                            }
                        }
                        if (!Flags.ShuttingDown)
                            initializeShell();
                    }
                }
                else if (ArgsMode == true & Flags.CommandFlag == true)
                {
                    Flags.CommandFlag = false;
                    foreach (var cmd in ArgumentParse.argcmds)
                    {
                        int indexCmd = cmd.IndexOf(" ");
                        string commandName = "";
                        if (indexCmd == -1)
                        {
                            indexCmd = cmd.Count();
                        }
                        commandName = cmd.Substring(0, indexCmd);
                        if (availableCommands.Contains(commandName))
                        {
                            if (string.IsNullOrEmpty(cmd) | cmd.StartsWith(" ") == true)
                            {
                                initializeShell();
                            }
                            else if (Groups.adminList[Login.signedinusrnm] == true & strictCmds.Contains(commandName) == true)
                            {
                                DebugWriter.Wdbg("Cmd exec: {0}", true, commandName);
                                GetCommand.ExecuteCommand(cmd);
                            }
                            else if (Groups.adminList[Login.signedinusrnm] == false & strictCmds.Contains(commandName) == true)
                            {
                                DebugWriter.Wdbg("Cmd exec {0} failed: adminList.ASSERT(signedinusrnm) = False, strictCmds.Cont({0}.Substr(0, {1})) = True", true, commandName, indexCmd);
                                TextWriterColor.Wln("You don't have permission to use {0}", "neutralText", commandName);
                            }
                            else if (cmd == "logout" | cmd == "shutdown" | cmd == "reboot")
                            {
                                DebugWriter.Wdbg("Cmd exec {0} failed: {0} = (\"logout\" | \"shutdown\" | \"reboot\") = True", true, commandName);
                                TextWriterColor.Wln("Shell message: Command {0} is not allowed to run on log in.", "neutralText", cmd);
                            }
                            else
                            {
                                DebugWriter.Wdbg("Cmd exec: {0}", true, commandName);
                                GetCommand.ExecuteCommand(cmd);
                            }
                        }
                        else
                        {
                            DebugWriter.Wdbg("Cmd exec {0} failed: availableCmds.Cont({0}.Substring(0, {1})) = False", true, commandName, indexCmd);
                            TextWriterColor.Wln("Shell message: The requested command {0} is not found.", "neutralText", cmd.Substring(0, cmd.Count() - 1));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (Flags.DebugMode == true)
                {
                    TextWriterColor.Wln("Error trying to execute command." + Kernel.NewLine + "Error {0}: {1}" + Kernel.NewLine + "{2}", "neutralText", ex.HResult, ex.Message, ex.StackTrace);
                    DebugWriter.Wdbg(ex.StackTrace, true);
                }
                else
                {
                    TextWriterColor.Wln("Error trying to execute command." + Kernel.NewLine + "Error {0}: {1}", "neutralText", ex.HResult, ex.Message);
                }
            }

        }

    }
}
