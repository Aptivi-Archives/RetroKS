
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
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using Terminaux.Reader;

namespace RetroKS
{

    static class GetCommand
    {

        // Variables
        public static string answernewuser;                                                                          // Input for new user name
        public static string answerpassword;                                                                         // Input for new password
        public static string answerbeep;                                                                             // Input for beep frequency
        public static string answerbeepms;                                                                           // Input for beep milliseconds
        public static double key;
        public static ConsoleColor[] colors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));  // Console Colors
        public static BackgroundWorker backgroundWorker1;
        public static string answerecho;                                                                             // Input for printing string
        public static BackgroundWorker backgroundWorker2;

        static GetCommand()
        {
            backgroundWorker1 = new BackgroundWorker();                       // Black / White disco
            backgroundWorker2 = new BackgroundWorker();                       // 16-bit Colored Disco
        }

        public static void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

            string ColorConsole = "Black";
            while (true)
            {
                Thread.Sleep(50);
                if (backgroundWorker2.CancellationPending == true)
                {
                    e.Cancel = true;
                    Console.ResetColor();
                    Console.Clear();
                    Shell.commandPromptWrite();
                    Console.ForegroundColor = (ConsoleColor)Convert.ToInt32(ColorInitialize.inputColor);
                    break;
                }
                if (ColorConsole == "White")
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    ColorConsole = "Black";
                    Console.Clear();
                }
                else if (ColorConsole == "Black")
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    ColorConsole = "White";
                    Console.Clear();
                }
            }

        }

        public static void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            while (true)
            {
                bool exitDo = false;
                foreach (var color in colors)
                {
                    Thread.Sleep(250);
                    if (backgroundWorker1.CancellationPending == true)
                    {
                        e.Cancel = true;
                        Console.ResetColor();
                        Console.Clear();
                        Shell.commandPromptWrite();
                        Console.ForegroundColor = (ConsoleColor)Convert.ToInt32(ColorInitialize.inputColor);
                        exitDo = true;
                        break;
                    }
                    else
                    {
                        Console.BackgroundColor = color;
                        Console.Clear();
                    }
                }

                if (exitDo)
                {
                    break;
                }
            }

        }

        public static void DiscoSystem(bool BlackWhite = false)
        {

            if (BlackWhite == false)
            {
                backgroundWorker1.WorkerSupportsCancellation = true;
                backgroundWorker1.RunWorkerAsync();
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    backgroundWorker1.CancelAsync();
                }
            }
            else if (BlackWhite == true)
            {
                backgroundWorker2.WorkerSupportsCancellation = true;
                backgroundWorker2.RunWorkerAsync();
                if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    backgroundWorker2.CancelAsync();
                }
            }

        }

        public static void ExecuteCommand(string requestedCommand)
        {

            try
            {
                int index = requestedCommand.IndexOf(" ");
                if (index == -1)
                {
                    index = requestedCommand.Length;
                }
                if (requestedCommand.Substring(0, index) == "help")
                {

                    if (requestedCommand == "help")
                    {
                        HelpSystem.ShowHelp();
                    }
                    else
                    {
                        var words = requestedCommand.Split(new[] { ' ' });
                        var c = default(int);
                        for (int arg = 1, loopTo = words.Count() - 1; arg <= loopTo; arg++)
                            c = c + words[arg].Count() + 1;
                        string strArgs = requestedCommand.Substring(requestedCommand.IndexOf(" "), c);
                        var args = strArgs.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (args.Count() - 1 == 0)
                        {
                            HelpSystem.ShowHelp(args[0]);
                        }
                        else
                        {
                            TextWriterColor.Wln("Usage: help [command]" + Kernel.NewLine + "       help: to get all commands", "neutralText");
                        }
                    }
                }

                else if (requestedCommand.Substring(0, index) == "adduser")
                {

                    if (requestedCommand == "adduser")
                    {
                        UserManagement.addUser();
                        TextWriterColor.Wln("Tip: You can add permissions to new users by using 'addperm' and then writing their username." + Kernel.NewLine + "     You can also edit permissions for existing usernames by using 'editperm'.", "neutralText");
                    }
                    else
                    {
                        var words = requestedCommand.Split(new[] { ' ' });
                        var c = default(int);
                        for (int arg = 1, loopTo1 = words.Count() - 1; arg <= loopTo1; arg++)
                            c = c + words[arg].Count() + 1;
                        string strArgs = requestedCommand.Substring(requestedCommand.IndexOf(" "), c);
                        var args = strArgs.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (args.Count() - 1 == 0)
                        {
                            UserManagement.newPassword(args[0]);
                        }
                        else if (args.Count() - 1 == 2)
                        {
                            UserManagement.adduser(args[0], args[1]);
                        }
                        else
                        {
                            TextWriterColor.Wln("Usage: adduser <userName> [password] [confirm]" + Kernel.NewLine + "       adduser: to be prompted about new username and password", "neutralText");
                        }
                    }
                }

                else if (requestedCommand.Substring(0, index) == "annoying-sound" | requestedCommand.Substring(0, index) == "beep")
                {

                    // Beep system initialization
                    if (requestedCommand == "annoying-sound" | requestedCommand == "beep")
                    {
                        BeepType.BeepFreq();
                    }
                    else
                    {
                        var words = requestedCommand.Split(new[] { ' ' });
                        var c = default(int);
                        for (int arg = 1, loopTo2 = words.Count() - 1; arg <= loopTo2; arg++)
                            c = c + words[arg].Count() + 1;
                        string strArgs = requestedCommand.Substring(requestedCommand.IndexOf(" "), c);
                        var args = strArgs.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (args.Count() - 1 == 1)
                        {
                            BeepType.Beep(Convert.ToInt32(args[0]), Convert.ToDouble(args[1]));
                        }
                        else
                        {
                            TextWriterColor.Wln("Usage: annoying-sound/beep <Frequency:Hz> <Time:Seconds>" + Kernel.NewLine + "       annoying-sound/beep: to be prompted about beeping.", "neutralText");
                        }
                    }
                }

                else if (requestedCommand.Substring(0, index) == "arginj")
                {

                    // Argument Injection
                    if (requestedCommand == "arginj")
                    {
                        ArgumentPrompt.answerargs = "";
                        ArgumentPrompt.PromptArgs(true);
                    }
                    else
                    {
                        var words = requestedCommand.Split(new[] { ' ' });
                        var c = default(int);
                        for (int arg = 1, loopTo3 = words.Count() - 1; arg <= loopTo3; arg++)
                            c = c + words[arg].Count() + 1;
                        string strArgs = requestedCommand.Substring(requestedCommand.IndexOf(" ") + 1, c - 1);
                        var args = strArgs.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (args.Count() - 1 >= 0)
                        {
                            ArgumentPrompt.answerargs = string.Join(",", args);
                            Flags.argsInjected = true;
                            TextWriterColor.Wln("Injected arguments, {0}, will be scheduled to run at next reboot.", "neutralText", ArgumentPrompt.answerargs);
                        }
                        else
                        {
                            TextWriterColor.Wln("Usage: arginj [Arguments sep. by commas]" + Kernel.NewLine + "       arginj: to be prompted about boot arguments.", "neutralText");
                        }
                    }
                }

                else if (requestedCommand.Substring(0, index) == "calc")
                {

                    if (requestedCommand != "calc")
                    {
                        var words = requestedCommand.Split(new[] { ' ' });
                        var c = default(int);
                        for (int arg = 1, loopTo4 = words.Count() - 1; arg <= loopTo4; arg++)
                            c = c + words[arg].Count() + 1;
                        string strArgs = requestedCommand.Substring(requestedCommand.IndexOf(" "), c);
                        var args = strArgs.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (args.Count() - 1 > 1)
                        {
                            stdCalc.expressionCalculate(args);
                        }
                        else
                        {
                            TextWriterColor.Wln("Usage: calc <expression> ...", "neutralText");
                        }
                    }
                    else
                    {
                        TextWriterColor.Wln("Usage: calc <expression> ...", "neutralText");
                    }
                }

                else if (requestedCommand == "cdir" | requestedCommand == "currentdir")
                {

                    // Current directory
                    TextWriterColor.Wln("Current directory: {0}", "neutralText", CurrentDir.currDir);
                }

                else if (requestedCommand.Substring(0, index) == "cd" | requestedCommand.Substring(0, index) == "chdir" | requestedCommand.Substring(0, index) == "changedir")
                {

                    var words = requestedCommand.Split(new[] { ' ' });
                    var c = default(int);
                    for (int arg = 1, loopTo5 = words.Count() - 1; arg <= loopTo5; arg++)
                        c = c + words[arg].Count() + 1;
                    string strArgs = requestedCommand.Substring(requestedCommand.IndexOf(" "), c);
                    var args = strArgs.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (args.Count() - 1 == 0)
                    {
                        if (ListFolders.AvailableDirs.Contains(args[0]) & CurrentDir.currDir == "/")
                        {
                            CurrentDir.setCurrDir(args[0]);
                        }
                        else if (args[0] == "..")
                        {
                            CurrentDir.setCurrDir("");
                        }
                        else
                        {
                            TextWriterColor.Wln("Directory {0} not found", "neutralText", args[0]);
                        }
                    }
                    else
                    {
                        TextWriterColor.Wln("Usage: chdir/changedir/cd <directory> OR ..", "neutralText");
                    }
                }

                else if (requestedCommand.Substring(0, index) == "chhostname")
                {

                    if (requestedCommand == "chhostname")
                    {
                        HostName.ChangeHostName();
                    }
                    else
                    {
                        string newhost = requestedCommand.Substring(11);
                        if (string.IsNullOrEmpty(newhost))
                        {
                            TextWriterColor.Wln("Blank host name.", "neutralText");
                            TextWriterColor.Wln("Usage: chhostname <HostName>" + Kernel.NewLine + "       chhostname: to be prompted about changing host name.", "neutralText");
                        }
                        else if (newhost.Length <= 3)
                        {
                            TextWriterColor.Wln("The host name length must be at least 4 characters.", "neutralText");
                            TextWriterColor.Wln("Usage: chhostname <HostName>" + Kernel.NewLine + "       chhostname: to be prompted about changing host name.", "neutralText");
                        }
                        else if (newhost.Contains(" "))
                        {
                            TextWriterColor.Wln("Spaces are not allowed.", "neutralText");
                            TextWriterColor.Wln("Usage: chhostname <HostName>" + Kernel.NewLine + "       chhostname: to be prompted about changing host name.", "neutralText");
                        }
                        else if (newhost.IndexOfAny("[~`!@#$%^&*()-+=|{}':;.,<>/?]".ToCharArray()) != -1)
                        {
                            TextWriterColor.Wln("Special characters are not allowed.", "neutralText");
                            TextWriterColor.Wln("Usage: chhostname <HostName>" + Kernel.NewLine + "       chhostname: to be prompted about changing host name.", "neutralText");
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

                else if (requestedCommand.Substring(0, index) == "chmotd")
                {

                    if (requestedCommand == "chmotd")
                    {
                        ChangeMOTD.ChangeMessage();
                    }
                    else
                    {
                        string newmotd = requestedCommand.Substring(7);
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

                else if (requestedCommand.Substring(0, index) == "choice")
                {

                    if (requestedCommand == "choice")
                    {
                        TextWriterColor.W("Write a question: ", "input");
                        string question = TermReader.Read();
                        if (string.IsNullOrEmpty(question))
                        {
                            TextWriterColor.Wln("Blank question. Try again.", "neutralText");
                        }
                        else if (question == "q")
                        {
                            TextWriterColor.Wln("Choice creation has been cancelled.", "neutralText");
                        }
                        else
                        {
                            TextWriterColor.W("Write choice sets, Ex. Y/N/M/D/F/...: ", "input");
                            string sets = TermReader.Read();
                            if (string.IsNullOrEmpty(sets))
                            {
                                TextWriterColor.Wln("Blank choice sets. Try again.", "neutralText");
                            }
                            else if (!sets.Contains("/") & !(sets.Length - 1 == 0))
                            {
                                TextWriterColor.Wln("Cease using choice sets that is, Ex. YNMDF, Y,N,M,D,F, etc.", "neutralText");
                            }
                            else if (sets.Length - 1 == 0)
                            {
                                TextWriterColor.Wln("One choice set. Try again.", "neutralText");
                            }
                            else if (sets == "q")
                            {
                                TextWriterColor.Wln("Choice creation has been cancelled.", "neutralText");
                            }
                            else
                            {
                                TextWriterColor.W("{0} <{1}> ", "input", question, sets);
                                string answerchoice = Convert.ToString(Console.ReadKey().KeyChar);
                                var answerchoices = sets.Split('/');
                                foreach (var choiceset in answerchoices)
                                {
                                    if ((answerchoice ?? "") == (choiceset ?? ""))
                                    {
                                        TextWriterColor.Wln(Kernel.NewLine + "Choice {0} selected.", "neutralText", answerchoice);
                                    }
                                    else if (answerchoice == "q")
                                    {
                                        TextWriterColor.Wln(Kernel.NewLine + "Choice has been cancelled.", "neutralText");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        var words = requestedCommand.Split(new[] { ' ' });
                        var c = default(int);
                        for (int arg = 1, loopTo6 = words.Count() - 1; arg <= loopTo6; arg++)
                            c = c + words[arg].Count() + 1;
                        string strArgs = requestedCommand.Substring(requestedCommand.IndexOf(" "), c);
                        var args = strArgs.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (args.Count() - 1 == 1)
                        {
                            TextWriterColor.W("{0} <{1}> ", "input", args[0], args[1]);
                            string answerchoice = Convert.ToString(Console.ReadKey().KeyChar);
                            var answerchoices = args[1].Split('/');
                            foreach (var choiceset in answerchoices)
                            {
                                if ((answerchoice ?? "") == (choiceset ?? ""))
                                {
                                    TextWriterColor.Wln(Kernel.NewLine + "Choice {0} selected.", "neutralText", answerchoice);
                                }
                                else if (answerchoice == "q")
                                {
                                    TextWriterColor.Wln(Kernel.NewLine + "Choice has been cancelled.", "neutralText");
                                }
                            }
                        }
                        else
                        {
                            TextWriterColor.Wln("Usage: choice <Question> <sets>" + Kernel.NewLine + "       choice: to be prompted about choices.", "neutralText");
                        }
                    }
                }

                else if (requestedCommand == "chpwd")
                {

                    UserManagement.changePassword();
                }

                else if (requestedCommand.Substring(0, index) == "chusrname")
                {

                    if (requestedCommand == "chusrname")
                    {
                        UserManagement.changeName();
                    }
                    else
                    {
                        bool DoneFlag = false;
                        var words = requestedCommand.Split(new[] { ' ' });
                        var c = default(int);
                        for (int arg = 1, loopTo7 = words.Count() - 1; arg <= loopTo7; arg++)
                            c = c + words[arg].Count() + 1;
                        string strArgs = requestedCommand.Substring(requestedCommand.IndexOf(" "), c);
                        var args = strArgs.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (args.Count() - 1 == 1)
                        {
                            if (Login.userword.ContainsKey(args[0]) == true)
                            {
                                if (!(Login.userword.ContainsKey(args[1]) == true))
                                {
                                    DoneFlag = true;
                                    string temporary = Login.userword[args[0]];
                                    Login.userword.Remove(args[0]);
                                    Login.userword.Add(args[1], temporary);
                                    Groups.permissionEditForNewUser(args[0], args[1]);
                                    TextWriterColor.Wln("Username has been changed to {0}!", "neutralText", args[1]);
                                    if ((args[0] ?? "") == (Login.signedinusrnm ?? ""))
                                    {
                                        Login.LoginPrompt();
                                    }
                                }
                                else
                                {
                                    TextWriterColor.Wln("The new name you entered is already found.", "neutralText");
                                    return;
                                }
                            }
                            if (DoneFlag == false)
                            {
                                TextWriterColor.Wln("User {0} not found.", "neutralText", args[0]);
                                UserManagement.changePassword();
                            }
                        }
                        else
                        {
                            TextWriterColor.Wln("Usage: chusrname <oldUserName> <newUserName>" + Kernel.NewLine + "       chusrname: to be prompted about changing usernames.", "neutralText");
                        }
                    }
                }

                else if (requestedCommand == "cls")
                {

                    Console.Clear();
                }

                else if (requestedCommand == "debuglog")
                {

                    if (Flags.DebugMode == true)
                    {
                        string line;
                        using (var dbglog = File.Open(InitializeDirectoryFile.AppDataPath + @"\kernelDbg.log", FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
                        using (var reader = new StreamReader(dbglog))
                        {
                            line = reader.ReadLine();
                            while (reader.EndOfStream != true)
                            {
                                TextWriterColor.Wln(line, "neutralText");
                                line = reader.ReadLine();
                            }
                        }
                    }
                    else
                    {
                        TextWriterColor.Wln("Debugging not enabled.", "neutralText");
                    }
                }

                else if (requestedCommand == "disco")
                {

                    // The disco system.
                    DiscoSystem();
                }

                else if (requestedCommand.Substring(0, index) == "echo")
                {

                    if (requestedCommand == "echo")
                    {
                        TextWriterColor.W("Write any text: ", "input");
                        answerecho = TermReader.Read();
                        if (answerecho == "q")
                        {
                            TextWriterColor.Wln("Text printing has been cancelled.", "neutralText");
                        }
                        else
                        {
                            TextWriterColor.Wln(answerecho, "neutralText");
                        }
                    }
                    else
                    {
                        var words = requestedCommand.Split(new[] { ' ' });
                        var c = default(int);
                        for (int arg = 1, loopTo8 = words.Count() - 1; arg <= loopTo8; arg++)
                            c = c + words[arg].Count() + 1;
                        string strArgs = requestedCommand.Substring(requestedCommand.IndexOf(" "), c);
                        var args = strArgs.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (args.Count() - 1 >= 0)
                        {
                            TextWriterColor.Wln(string.Join(" ", args), "neutralText");
                        }
                        else
                        {
                            TextWriterColor.Wln("Usage: echo <text>" + Kernel.NewLine + "       echo: to be prompted about text printing.", "neutralText");
                        }
                    }
                }

                else if (requestedCommand == "future-eyes-destroyer" | requestedCommand == "fed")
                {

                    // Disco system, in monochrome
                    DiscoSystem(true);
                }

                else if (requestedCommand.Substring(0, index) == "ls" | requestedCommand.Substring(0, index) == "list")
                {

                    // Lists folders and files
                    if (requestedCommand == "ls" | requestedCommand == "list")
                    {
                        if (CurrentDir.currDir == "/")
                        {
                            TextWriterColor.Wln(string.Join(", ", ListFolders.AvailableDirs), "neutralText");
                        }
                        else
                        {
                            ListFolders.list(CurrentDir.currDir.Substring(1));
                        }
                    }
                    else
                    {
                        var words = requestedCommand.Split(new[] { ' ' });
                        var c = default(int);
                        for (int arg = 1, loopTo9 = words.Count() - 1; arg <= loopTo9; arg++)
                            c = c + words[arg].Count() + 1;
                        string strArgs = requestedCommand.Substring(requestedCommand.IndexOf(" "), c);
                        var args = strArgs.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (args.Count() - 1 == 0)
                        {
                            if (ListFolders.AvailableDirs.Contains(args[0]) | args[0] == ".." | args[0] == "/" | ListFolders.AvailableDirs.Contains(args[0].Substring(1)) & (args[0].StartsWith("/") | args[0].StartsWith("..")))
                            {
                                ListFolders.list(args[0]);
                            }
                            else
                            {
                                TextWriterColor.Wln("Directory {0} not found", "neutralText", args[0]);
                            }
                        }
                        else
                        {
                            TextWriterColor.Wln("Usage: ls/list [oneDirectory]" + Kernel.NewLine + "       ls/list: to get current directory.", "neutralText");
                        }
                    }
                }

                else if (requestedCommand == "logout")
                {

                    // Logs out of the user
                    Login.LoginPrompt();
                }

                else if (requestedCommand == "netinfo")
                {

                    NetworkTools.getProperties();
                }

                else if (requestedCommand.Substring(0, index) == "mkdir" | requestedCommand.Substring(0, index) == "md")
                {

                    if (requestedCommand != "mkdir" | requestedCommand != "md")
                    {
                        var words = requestedCommand.Split(new[] { ' ' });
                        var c = default(int);
                        for (int arg = 1, loopTo10 = words.Count() - 1; arg <= loopTo10; arg++)
                            c = c + words[arg].Count() + 1;
                        string strArgs = requestedCommand.Substring(requestedCommand.IndexOf(" "), c);
                        var args = strArgs.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (args.Count() - 1 == 0)
                        {
                            ListFolders.AvailableDirs.Add(args[0]);
                        }
                        else
                        {
                            TextWriterColor.Wln("Usage: md/mkdir <anything>", "neutralText");
                        }
                    }
                    else
                    {
                        TextWriterColor.Wln("Usage: md/mkdir <anything>", "neutralText");
                    }
                }

                else if (requestedCommand.Substring(0, index) == "panicsim")
                {

                    // Kernel panic simulator
                    if (requestedCommand == "panicsim")
                    {
                        PanicSim.panicPrompt();
                    }
                    else
                    {
                        var words = requestedCommand.Split(new[] { ' ' });
                        var c = default(int);
                        for (int arg = 1, loopTo11 = words.Count() - 1; arg <= loopTo11; arg++)
                            c = c + words[arg].Count() + 1;
                        string strArgs = requestedCommand.Substring(requestedCommand.IndexOf(" "), c);
                        var args = strArgs.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (args.Count() - 1 == 0)
                        {
                            KernelTools.KernelError('C', false, 0L, args[0]);
                        }
                        else if (args.Count() - 1 == 1)
                        {
                            if (args[1] != "C")
                            {
                                KernelTools.KernelError(Convert.ToChar(args[1]), true, 30L, args[0]);
                            }
                            else if (args[1] == "C")
                            {
                                KernelTools.KernelError(Convert.ToChar(args[1]), false, 0L, args[0]);
                            }
                            else if (args[1] == "D")
                            {
                                KernelTools.KernelError(Convert.ToChar(args[1]), true, 5L, args[0]);
                            }
                            else
                            {
                                TextWriterColor.Wln("Usage: panicsim <message> [S/F/D/[C]/U] [RebootTime:Seconds]" + Kernel.NewLine + "       panicsim: to be prompted about panic simulator options.", "neutralText");
                            }
                        }
                        else if (args.Count() - 1 == 2)
                        {
                            if (Convert.ToDouble(args[2]) <= 3600d & (args[1] != "C" | args[1] != "D"))
                            {
                                KernelTools.KernelError(Convert.ToChar(args[1]), true, Convert.ToInt64(args[2]), args[0]);
                            }
                            else if (Convert.ToDouble(args[2]) <= 3600d & args[1] == "C" | Convert.ToDouble(args[2]) <= 0d & args[1] == "C")
                            {
                                KernelTools.KernelError(Convert.ToChar(args[1]), false, 0L, args[0]);
                            }
                            else if (Convert.ToDouble(args[2]) <= 5d & args[1] == "D")
                            {
                                KernelTools.KernelError(Convert.ToChar(args[1]), true, Convert.ToInt64(args[2]), args[0]);
                            }
                            else
                            {
                                TextWriterColor.Wln("Usage: panicsim <message> [S/F/D/[C]/U] [RebootTime:Seconds]" + Kernel.NewLine + "       panicsim: to be prompted about panic simulator options.", "neutralText");
                            }
                        }
                        else
                        {
                            TextWriterColor.Wln("Usage: panicsim <message> [S/F/D/[C]/U] [RebootTime:Seconds]" + Kernel.NewLine + "       panicsim: to be prompted about panic simulator options.", "neutralText");
                        }
                    }
                }

                else if (requestedCommand.Substring(0, index) == "perm")
                {

                    if (requestedCommand == "perm")
                    {
                        Groups.permissionPrompt();
                    }
                    else
                    {
                        var words = requestedCommand.Split(new[] { ' ' });
                        var c = default(int);
                        for (int arg = 1, loopTo12 = words.Count() - 1; arg <= loopTo12; arg++)
                            c = c + words[arg].Count() + 1;
                        string strArgs = requestedCommand.Substring(requestedCommand.IndexOf(" "), c);
                        var args = strArgs.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (args.Count() - 1 == 2)
                        {
                            Groups.permission(args[1], args[0], args[2]);
                        }
                        else
                        {
                            TextWriterColor.Wln("Usage: perm <userName> <Admin/Disabled> <Allow/Disallow>" + Kernel.NewLine + "       perm: to be prompted about permission setting.", "neutralText");
                        }
                    }
                }

                else if (requestedCommand.Substring(0, index) == "ping")
                {

                    if (requestedCommand == "ping")
                    {
                        Network.CheckNetworkCommand();
                    }
                    else
                    {
                        var words = requestedCommand.Split(new[] { ' ' });
                        var c = default(int);
                        for (int arg = 1, loopTo13 = words.Count() - 1; arg <= loopTo13; arg++)
                            c = c + words[arg].Count() + 1;
                        string strArgs = requestedCommand.Substring(requestedCommand.IndexOf(" "), c);
                        var args = strArgs.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (args.Count() - 1 == 0)
                        {
                            Network.PingTarget(args[0], 1);
                        }
                        else if (args.Count() - 1 == 1)
                        {
                            Network.PingTarget(args[0], Convert.ToInt16(args[1]));
                        }
                        else
                        {
                            TextWriterColor.Wln("Usage: ping <Address> [repeatTimes]" + Kernel.NewLine + "       ping: to get prompted about writing address.", "neutralText");
                        }
                    }
                }

                else if (requestedCommand.Substring(0, index) == "read")
                {

                    if (requestedCommand == "read")
                    {
                        TextWriterColor.W("Write a file (directories will be scanned): ", "input");
                        string readfile = TermReader.Read();
                        if (string.IsNullOrEmpty(readfile))
                        {
                            TextWriterColor.Wln(string.Join(", ", ListFolders.AvailableDirs), "neutralText");
                        }
                        else if (readfile == "q")
                        {
                            TextWriterColor.Wln("Listing has been cancelled.", "neutralText");
                        }
                        else if (FileContents.AvailableFiles.Contains(readfile))
                        {
                            FileContents.readContents(readfile);
                        }
                        else
                        {
                            TextWriterColor.Wln("{0} is not found.", "neutralText", readfile);
                        }
                    }
                    else
                    {
                        var words = requestedCommand.Split(new[] { ' ' });
                        var c = default(int);
                        for (int arg = 1, loopTo14 = words.Count() - 1; arg <= loopTo14; arg++)
                            c = c + words[arg].Count() + 1;
                        string strArgs = requestedCommand.Substring(requestedCommand.IndexOf(" "), c);
                        var args = strArgs.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (args.Count() - 1 == 0)
                        {
                            if (FileContents.AvailableFiles.Contains(args[0]))
                            {
                                FileContents.readContents(args[0]);
                            }
                            else
                            {
                                TextWriterColor.Wln("{0} is not found.", "neutralText", args[0]);
                            }
                        }
                        else
                        {
                            TextWriterColor.Wln("Usage: read <file>" + Kernel.NewLine + "       read: to get prompted about reading file contents.", "neutralText");
                        }
                    }
                }

                else if (requestedCommand == "reloadconfig")
                {

                    // Reload configuration
                    if (File.Exists(InitializeDirectoryFile.AppDataPath + @"\kernelConfig.ini") == true)
                    {
                        Kernel.configReader = new StreamReader(InitializeDirectoryFile.AppDataPath + @"\kernelConfig.ini");
                    }
                    else
                    {
                        Config.createConfig(false);
                        Kernel.configReader = new StreamReader(InitializeDirectoryFile.AppDataPath + @"\kernelConfig.ini");
                    }
                    Config.readConfig();
                    TextWriterColor.Wln("Configuration reloaded. You might need to reboot the kernel for some changes to take effect.", "neutralText");
                }

                else if (requestedCommand == "reboot")
                {

                    // Reboot the simulated system
                    TextWriterColor.Wln("Rebooting...", "neutralText");
#if NETFRAMEWORK
                    Console.Beep(870, 250);
#else
                    Console.Beep();
#endif
                    KernelTools.ResetEverything();
                    Console.Clear();
                    EntryPoint.Main();
                }

                else if (requestedCommand.Substring(0, index) == "rmdir" | requestedCommand.Substring(0, index) == "rd")
                {

                    if (requestedCommand != "rmdir" | requestedCommand != "rd")
                    {
                        var words = requestedCommand.Split(new[] { ' ' });
                        var c = default(int);
                        for (int arg = 1, loopTo15 = words.Count() - 1; arg <= loopTo15; arg++)
                            c = c + words[arg].Count() + 1;
                        string strArgs = requestedCommand.Substring(requestedCommand.IndexOf(" "), c);
                        var args = strArgs.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (args.Count() - 1 == 0)
                        {
                            ListFolders.AvailableDirs.Remove(args[0]);
                        }
                        else
                        {
                            TextWriterColor.Wln("Usage: rd/rmdir <directory>", "neutralText");
                        }
                    }
                    else
                    {
                        TextWriterColor.Wln("Usage: rd/rmdir <directory>", "neutralText");
                    }
                }

                else if (requestedCommand.Substring(0, index) == "rmuser")
                {

                    if (requestedCommand == "rmuser")
                    {
                        UserManagement.removeUser();
                    }
                    else
                    {
                        var words = requestedCommand.Split(new[] { ' ' });
                        var c = default(int);
                        for (int arg = 1, loopTo16 = words.Count() - 1; arg <= loopTo16; arg++)
                            c = c + words[arg].Count() + 1;
                        string strArgs = requestedCommand.Substring(requestedCommand.IndexOf(" "), c);
                        var args = strArgs.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (args.Count() - 1 == 0)
                        {
                            UserManagement.removeUserFromDatabase(args[0]);
                        }
                        else
                        {
                            TextWriterColor.Wln("Usage: rmuser <Username>" + Kernel.NewLine + "       rmuser: to get prompted about removing usernames.", "neutralText");
                        }
                    }
                }

                else if (requestedCommand.Substring(0, index) == "scical")
                {

                    if (requestedCommand != "scical")
                    {
                        var words = requestedCommand.Split(new[] { ' ' });
                        var c = default(int);
                        for (int arg = 1, loopTo17 = words.Count() - 1; arg <= loopTo17; arg++)
                            c = c + words[arg].Count() + 1;
                        string strArgs = requestedCommand.Substring(requestedCommand.IndexOf(" "), c);
                        var args = strArgs.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (args[0] != "sqrt" & args[0] != "tan" & args[0] != "sin" & args[0] != "cos" & args[0] != "floor" & args[0] != "ceiling" & args[0] != "abs" & args.Count() - 1 > 1)
                        {
                            sciCalc.expressionCalculate(false, args);
                        }
                        else if ((args[0] == "sqrt" | args[0] == "tan" | args[0] == "sin" | args[0] == "cos" | args[0] == "floor" | args[0] == "ceiling" | args[0] == "abs") & args.Count() - 1 == 1)
                        {
                            sciCalc.expressionCalculate(true, args);
                        }
                        else
                        {
                            TextWriterColor.Wln("Usage: scical <expression1|pi|e> <+|-|*|/|%> <expression2|pi|e> ..." + Kernel.NewLine + "       scical <sqrt|tan|sin|cos> <number>", "neutralText");
                        }
                    }
                    else
                    {
                        TextWriterColor.Wln("Usage: scical <expression1|pi|e> <+|-|*|/|%> <expression2|pi|e> ..." + Kernel.NewLine + "       scical <sqrt|tan|sin|cos> <number>", "neutralText");
                    }
                }

                else if (requestedCommand.Substring(0, index) == "setcolors")
                {

                    if (requestedCommand == "setcolors")
                    {
                        TextWriterColor.Wln("Available Colors: {0}" + Kernel.NewLine + "Press ENTER only on questions and defaults will be used.", "neutralText", string.Join(", ", ColorInitialize.availableColors));
                        ColorSet.SetColorSteps();
                    }
                    else
                    {
                        var words = requestedCommand.Split(new[] { ' ' });
                        var c = default(int);
                        for (int arg = 1, loopTo18 = words.Count() - 1; arg <= loopTo18; arg++)
                            c = c + words[arg].Count() + 1;
                        string strArgs = requestedCommand.Substring(requestedCommand.IndexOf(" "), c);
                        var args = strArgs.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (args.Count() - 1 == 7)
                        {
                            if (ColorInitialize.availableColors.Contains(args[0]) & ColorInitialize.availableColors.Contains(args[1]) & ColorInitialize.availableColors.Contains(args[2]) & ColorInitialize.availableColors.Contains(args[3]) & ColorInitialize.availableColors.Contains(args[4]) & ColorInitialize.availableColors.Contains(args[5]) & ColorInitialize.availableColors.Contains(args[6]) & ColorInitialize.availableColors.Contains(args[7]))
                            {
                                ColorInitialize.inputColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), args[0]));
                                ColorInitialize.licenseColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), args[1]));
                                ColorInitialize.contKernelErrorColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), args[2]));
                                ColorInitialize.uncontKernelErrorColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), args[3]));
                                ColorInitialize.hostNameShellColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), args[4]));
                                ColorInitialize.userNameShellColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), args[5]));
                                ColorInitialize.backgroundColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), args[6]));
                                ColorInitialize.neutralTextColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), args[7]));
                                LoadBackground.Load();
                            }
                            else if (args.Contains("def"))
                            {
                                if (Array.IndexOf(args, "") == 0)
                                {
                                    args[0] = "White";
                                    ColorInitialize.inputColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), args[0]));
                                }
                                else if (Array.IndexOf(args, "") == 1)
                                {
                                    args[1] = "White";
                                    ColorInitialize.licenseColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), args[1]));
                                }
                                else if (Array.IndexOf(args, "") == 2)
                                {
                                    args[2] = "Yellow";
                                    ColorInitialize.contKernelErrorColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), args[2]));
                                }
                                else if (Array.IndexOf(args, "") == 3)
                                {
                                    args[3] = "Red";
                                    ColorInitialize.uncontKernelErrorColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), args[3]));
                                }
                                else if (Array.IndexOf(args, "") == 4)
                                {
                                    args[4] = "DarkGreen";
                                    ColorInitialize.hostNameShellColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), args[4]));
                                }
                                else if (Array.IndexOf(args, "") == 5)
                                {
                                    args[5] = "Green";
                                    ColorInitialize.userNameShellColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), args[5]));
                                }
                                else if (Array.IndexOf(args, "") == 6)
                                {
                                    args[6] = "Black";
                                    ColorInitialize.backgroundColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), args[6]));
                                    LoadBackground.Load();
                                }
                                else if (Array.IndexOf(args, "") == 7)
                                {
                                    args[7] = "Gray";
                                    ColorInitialize.neutralTextColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), args[7]));
                                }
                            }
                            else if (args.Contains("RESET"))
                            {
                                ColorSet.ResetColors();
                                TextWriterColor.Wln("Everything is reset to normal settings.", "neutralText");
                            }
                            else
                            {
                                TextWriterColor.Wln("One or more of the colors is invalid.", "neutralText");
                            }
                        }
                        else
                        {
                            TextWriterColor.Wln("Usage: setcolors <inputColor/def> <licenseColor/def> <contKernelErrorColor/def> <uncontKernelErrorColor/def> <hostNameShellColor/def> <userNameShellColor/def> <backgroundColor/def> <neutralTextColor/def>" + Kernel.NewLine + "       setcolors: to get prompted about setting colors." + Kernel.NewLine + "       Friends of setcolors: setthemes", "neutralText");
                        }
                    }
                }

                else if (requestedCommand.Substring(0, index) == "setthemes")
                {

                    if (requestedCommand == "setthemes")
                    {
                        TemplateSet.TemplatePrompt();
                    }
                    else
                    {
                        var words = requestedCommand.Split(new[] { ' ' });
                        var c = default(int);
                        for (int arg = 1, loopTo19 = words.Count() - 1; arg <= loopTo19; arg++)
                            c = c + words[arg].Count() + 1;
                        string strArgs = requestedCommand.Substring(requestedCommand.IndexOf(" "), c);
                        var args = strArgs.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (args.Count() - 1 == 0)
                        {
                            TemplateSet.templateSet(args[0]);
                        }
                        else
                        {
                            TextWriterColor.Wln("Usage: setthemes <Theme>" + Kernel.NewLine + "       setthemes: to get prompted about setting themes." + Kernel.NewLine + "       Friends of setthemes: setcolors", "neutralText");
                        }
                    }
                }

                else if (requestedCommand == "showtd")
                {

                    TimeDate.ShowTime();
                }

                else if (requestedCommand == "showmotd")
                {

                    // Show changes to MOTD, or current
                    TextWriterColor.Wln(Kernel.MOTD, "neutralText");
                }

                else if (requestedCommand == "shutdown")
                {

                    // Shuts down the simulated system
                    TextWriterColor.Wln("Shutting down...", "neutralText");
#if NETFRAMEWORK
                    Console.Beep(870, 250);
#else
                    Console.Beep();
#endif
                    KernelTools.ResetEverything();
                    DebugWriter.dbgWriter.Close();
                    DebugWriter.dbgWriter.Dispose();
                    Console.Clear();
                    Flags.ShuttingDown = true;
                }

                else if (requestedCommand == "sysinfo")
                {

                    // Shows system information
                    TextWriterColor.Wln(
                        "Kernel Version: {0}" + Kernel.NewLine +
                        "Shell (uesh) version: {1}", "neutralText", Kernel.KernelVersion, Shell.ueshversion);
                }

                else if (requestedCommand.Substring(0, index) == "unitconv")
                {

                    if (requestedCommand != "unitconv")
                    {
                        var words = requestedCommand.Split(new[] { ' ' });
                        var c = default(int);
                        for (int arg = 1, loopTo20 = words.Count() - 1; arg <= loopTo20; arg++)
                            c = c + words[arg].Count() + 1;
                        string strArgs = requestedCommand.Substring(requestedCommand.IndexOf(" "), c);
                        var args = strArgs.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (args.Count() - 1 == 2)
                        {
                            unitConv.Converter(args[0], args[1], args[2]);
                        }
                        else
                        {
                            TextWriterColor.Wln("Usage: unitconv <sourceUnit> <targetUnit> <value>" + Kernel.NewLine + "Units: B, KB, MB, GB, TB, Bits, Octal, Binary, Decimal, Hexadecimal, mm, cm, m, km, Fahrenheit, Celsius, Kelvin, " + "j, kj, m/s, km/h, cm/ms, Kilograms, Grams, Tons, Kilotons, Megatons, kn, n, Hz, kHz, MHz, GHz, Number (source only), " + "Money (target only), Percent (target only), Centivolts, Volts, Kilovolts, Watts, Kilowatts, Milliliters, Liters, " + "Kiloliters, Gallons, Ounces, Feet, Inches, Yards and Miles.", "neutralText");
                        }
                    }
                    else
                    {
                        TextWriterColor.Wln("Usage: unitconv <sourceUnit> <targetUnit> <value>" + Kernel.NewLine + "Units: B, KB, MB, GB, TB, Bits, Octal, Binary, Decimal, Hexadecimal, mm, cm, m, km, Fahrenheit, Celsius, Kelvin, " + "j, kj, m/s, km/h, cm/ms, Kilograms, Grams, Tons, Kilotons, Megatons, kn, n, Hz, kHz, MHz, GHz, Number (source only), " + "Money (target only), Percent (target only), Centivolts, Volts, Kilovolts, Watts, Kilowatts, Milliliters, Liters, " + "Kiloliters, Gallons, Ounces, Feet, Inches, Yards and Miles.", "neutralText");
                    }
                }

                else if (requestedCommand == "version")
                {

                    // Shows current kernel version
                    TextWriterColor.Wln("Version: {0}", "neutralText", Kernel.KernelVersion);

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
