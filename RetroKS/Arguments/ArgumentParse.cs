
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
    static class ArgumentParse
    {

        // Variables
        public static string arguser;                    // A username
        public static string argword;                    // A password
        public static string argcommands;                // Commands entered
        public static string[] argcmds;

        public static void ParseArguments()
        {

            // Check for the arguments written by the user
            try
            {
                Kernel.BootArgs = ArgumentPrompt.answerargs.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0, loopTo = Kernel.BootArgs.Count() - 1; i <= loopTo; i++)
                {
                    int indexArg = Kernel.BootArgs[i].IndexOf(" ");
                    if (indexArg == -1)
                    {
                        indexArg = Kernel.BootArgs[i].Count();
                        Kernel.BootArgs[i] = Kernel.BootArgs[i].Substring(0, indexArg);
                    }
                    if (Kernel.AvailableArgs.Contains(Kernel.BootArgs[i].Substring(0, indexArg)))
                    {
                        if (Kernel.BootArgs[i].Contains("motd"))
                        {

                            if (Kernel.BootArgs[i] == "motd")
                            {
                                ChangeMOTD.ChangeMessage();
                            }
                            else
                            {
                                string newmotd = Kernel.BootArgs[i].Substring(5);
                                if (string.IsNullOrEmpty(newmotd))
                                {
                                    TextWriterColor.Wln("Blank message of the day.", "neutralText");
                                }
                                else if (newmotd == "q")
                                {
                                    TextWriterColor.Wln("MOTD changing has been cancelled.", "neutralText");
                                }
                                else
                                {
                                    TextWriterColor.W("Changing MOTD...", "neutralText");
                                    Kernel.MOTD = newmotd;
                                    TextWriterColor.Wln(" Done!" + Kernel.NewLine + "Please log-out, or use 'showmotd' to see the changes", "neutralText");
                                }
                            }
                        }

                        else if (Kernel.BootArgs[i] == "nohwprobe")
                        {

                            // Disables automatic hardware probing.
                            Flags.ProbeFlag = false;
                        }

                        else if (Kernel.BootArgs[i].Contains("chkn=1"))
                        {

                            // Makes a kernel check for connectivity on boot
                            Network.CheckNetworkKernel();
                        }

                        else if (Kernel.BootArgs[i] == "preadduser")
                        {

                            TextWriterColor.W("Write username: ", "input");
                            arguser = TermReader.Read();
                            if (arguser.Contains(" "))
                            {
                                TextWriterColor.Wln("Spaces are not allowed.", "neutralText");
                            }
                            else if (arguser.IndexOfAny("[~`!@#$%^&*()-+=|{}':;.,<>/?]".ToCharArray()) != -1)
                            {
                                TextWriterColor.Wln("Special characters are not allowed.", "neutralText");
                            }
                            else if (arguser == "q")
                            {
                                TextWriterColor.Wln("Username creation has been cancelled.", "neutralText");
                            }
                            else
                            {
                                TextWriterColor.W("Write password: ", "input");
                                argword = TermReader.Read();
                                if (argword.Contains(" "))
                                {
                                    TextWriterColor.Wln("Spaces are not allowed.", "neutralText");
                                }
                                else if (argword.IndexOfAny("[~`!@#$%^&*()-+=|{}':;.,<>/?]".ToCharArray()) != -1)
                                {
                                    TextWriterColor.Wln("Special characters are not allowed.", "neutralText");
                                }
                                else if (argword == "q")
                                {
                                    TextWriterColor.Wln("Username creation has been cancelled.", "neutralText");
                                }
                                else
                                {
                                    TextWriterColor.W("Confirm: ", "input");
                                    string answerpasswordconfirm = TermReader.Read();
                                    if (answerpasswordconfirm.Contains(" "))
                                    {
                                        TextWriterColor.Wln("Spaces are not allowed.", "neutralText");
                                    }
                                    else if (answerpasswordconfirm.IndexOfAny("[~`!@#$%^&*()-+=|{}':;.,<>/?]".ToCharArray()) != -1)
                                    {
                                        TextWriterColor.Wln("Special characters are not allowed.", "neutralText");
                                    }
                                    else if ((argword ?? "") == (answerpasswordconfirm ?? ""))
                                    {
                                        Flags.CruserFlag = true;
                                    }
                                    else if ((argword ?? "") != (answerpasswordconfirm ?? ""))
                                    {
                                        TextWriterColor.Wln("Password doesn't match.", "neutralText");
                                    }
                                    else if (answerpasswordconfirm == "q")
                                    {
                                        TextWriterColor.Wln("Username creation has been cancelled.", "neutralText");
                                    }
                                }
                            }
                        }


                        else if (Kernel.BootArgs[i].Contains("hostname"))
                        {

                            if (Kernel.BootArgs[i] == "hostname")
                            {
                                HostName.ChangeHostName();
                            }
                            else
                            {
                                string newhost = Kernel.BootArgs[i].Substring(9);
                                if (string.IsNullOrEmpty(newhost))
                                {
                                    TextWriterColor.Wln("Blank host name.", "neutralText");
                                }
                                else if (newhost.Length <= 3)
                                {
                                    TextWriterColor.Wln("The host name length must be at least 4 characters.", "neutralText");
                                }
                                else if (newhost.Contains(" "))
                                {
                                    TextWriterColor.Wln("Spaces are not allowed.", "neutralText");
                                }
                                else if (newhost.IndexOfAny("[~`!@#$%^&*()-+=|{}':;.,<>/?]".ToCharArray()) != -1)
                                {
                                    TextWriterColor.Wln("Special characters are not allowed.", "neutralText");
                                }
                                else if (newhost == "q")
                                {
                                    TextWriterColor.Wln("Host name changing has been cancelled.", "neutralText");
                                }
                                else
                                {
                                    TextWriterColor.Wln("Changing from: {0} to {1}...", "neutralText", Kernel.Host, newhost);
                                    Kernel.Host = newhost;
                                }
                            }
                        }

                        else if (Kernel.BootArgs[i] == "quiet")
                        {

                            Flags.Quiet = true;
                        }

                        else if (Kernel.BootArgs[i] == "gpuprobe")
                        {

                            Flags.GPUProbeFlag = true;
                        }

                        else if (Kernel.BootArgs[i].Contains("cmdinject"))
                        {

                            // Command Injector argument
                            if (Kernel.BootArgs[i] == "cmdinject")
                            {
                                TextWriterColor.W("Available commands: {0}" + Kernel.NewLine + "Write command: ", "input", string.Join(", ", Shell.availableCommands));
                                argcmds = TermReader.Read().Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                                argcommands = string.Join(", ", argcmds);
                                if (argcommands != "q")
                                {
                                    Flags.CommandFlag = true;
                                }
                                else
                                {
                                    TextWriterColor.Wln("Command injection has been cancelled.", "neutralText");
                                }
                            }
                            else
                            {
                                argcmds = Kernel.BootArgs[i].Substring(10).Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                                argcommands = string.Join(", ", argcmds);
                                Flags.CommandFlag = true;
                            }
                        }

                        else if (Kernel.BootArgs[i] == "debug")
                        {

                            Flags.DebugMode = true;
                            DebugWriter.dbgWriter.AutoFlush = true;
                        }

                        else if (Kernel.BootArgs[i] == "help")
                        {

                            TextWriterColor.Wln("Separate boot arguments with commas without spaces, for example, 'motd,gpuprobe'" + Kernel.NewLine + "Separate commands on 'cmdinject' with colons without spaces, for example, 'cmdinject setthemes Hacker:beep 1024 0.5'" + Kernel.NewLine + "Note that the 'debug' argument does not fully cover the kernel.", "neutralText");

                            ArgumentPrompt.answerargs = "";
                            Flags.argsFlag = false;
                            Flags.argsInjected = false;
                            ArgumentPrompt.PromptArgs();
                            if (Flags.argsFlag == true)
                            {
                                ParseArguments();
                            }

                        }
                    }
                    else
                    {
                        TextWriterColor.Wln("bargs: The requested argument {0} is not found.", "neutralText", Kernel.BootArgs[i].Substring(0, indexArg));
                    }
                }
            }
            catch (Exception ex)
            {
                KernelTools.KernelError('U', true, 5L, "bargs: Unrecoverable error in argument: " + ex.Message);
            }

        }

    }
}
