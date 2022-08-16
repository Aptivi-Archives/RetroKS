using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

namespace RetroKS
{

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

    static class Login
    {

        // Variables
        public static Dictionary<string, string> userword = new Dictionary<string, string>();      // List of usernames and passwords
        public static string answeruser;                                 // Input of username
        public static string answerpass;                                 // Input of password
        public static string password;                                   // Password for user we're logging in to
        public static string signedinusrnm;                              // Username that is signed in

        public static void LoginPrompt()
        {

            // Prompts user to log-in
            if (Flags.clsOnLogin == true)
            {
                Console.Clear();
            }
            if (Flags.showMOTD == false)
            {
                TextWriterColor.W(Kernel.NewLine + "Username: ", "input");
            }
            else
            {
                TextWriterColor.W(Kernel.NewLine + Kernel.MOTD + Kernel.NewLine + Kernel.NewLine + "Username: ", "input");
            }
            answeruser = Console.ReadLine();
            if (answeruser.Contains(" "))
            {
                TextWriterColor.Wln("Spaces are not allowed.", "neutralText");
                LoginPrompt();
            }
            else if (answeruser.IndexOfAny("[~`!@#$%^&*()-+=|{}':;.,<>/?]".ToCharArray()) != -1)
            {
                TextWriterColor.Wln("Special characters are not allowed.", "neutralText");
                LoginPrompt();
            }
            else
            {
                showPasswordPrompt(answeruser);
            }

        }

        public static void showPasswordPrompt(string usernamerequested)
        {

            // Variables and error handler
            bool DoneFlag = false;
            ;

            // Prompts user to enter a user's password
            try
            {
                foreach (string availableUsers in userword.Keys.ToArray())
                {
                    if ((availableUsers ?? "") == (answeruser ?? "") & Groups.disabledList[availableUsers] == false)
                    {
                        DebugWriter.Wdbg("ASSERT({0} = {1}, {2} = False) = True, True", true, availableUsers, answeruser, Groups.disabledList[availableUsers]);
                        DoneFlag = true;
                        password = userword[usernamerequested];
                        // Check if there's the password
                        if (password != default)
                        {
                            TextWriterColor.W("{0}'s password: ", "input", usernamerequested);
                            answerpass = Console.ReadLine();
                            if (answerpass.Contains(" "))
                            {
                                TextWriterColor.Wln("Spaces are not allowed.", "neutralText");
                                if (Flags.maintenance == false)
                                {
                                    LoginPrompt();
                                }
                                else
                                {
                                    showPasswordPrompt(usernamerequested);
                                }
                            }
                            else if (answerpass.IndexOfAny("[~`!@#$%^&*()-+=|{}':;.,<>/?]".ToCharArray()) != -1)
                            {
                                TextWriterColor.Wln("Special characters are not allowed.", "neutralText");
                                if (Flags.maintenance == false)
                                {
                                    LoginPrompt();
                                }
                                else
                                {
                                    showPasswordPrompt(usernamerequested);
                                }
                            }
                            else if (userword.TryGetValue(usernamerequested, out password) && (password ?? "") == (answerpass ?? ""))
                            {
                                DebugWriter.Wdbg("ASSERT(Parse({0}, {1})) = True | ASSERT({1} = {2}) = True", true, usernamerequested, password, answerpass);
                                signIn(usernamerequested);
                            }
                            else
                            {
                                TextWriterColor.Wln(Kernel.NewLine + "Wrong password.", "neutralText");
                                if (Flags.maintenance == false)
                                {
                                    LoginPrompt();
                                }
                                else
                                {
                                    showPasswordPrompt(usernamerequested);
                                }
                            }
                        }
                        else
                        {
                            // Log-in instantly
                            signIn(usernamerequested);
                        }
                    }
                    else if ((availableUsers ?? "") == (answeruser ?? "") & Groups.disabledList[availableUsers] == true)
                    {
                        TextWriterColor.Wln("User is disabled.", "neutralText");
                        LoginPrompt();
                    }
                    if (Flags.ShuttingDown)
                        return;
                }
                if (DoneFlag == false)
                {
                    TextWriterColor.Wln(Kernel.NewLine + "Wrong username.", "neutralText");
                    LoginPrompt();
                }
            }
            catch (Exception ex)
            {
                TextWriterColor.Wln("Unknown login error: {0}", "neutralText", ex.Message);
            }
        }

        public static void signIn(string signedInUser)
        {

            // Initialize shell, and sign in to user.
            TextWriterColor.Wln(Kernel.NewLine + "Logged in successfully as {0}!", "neutralText", signedInUser);
            signedinusrnm = signedInUser;
            Shell.initializeShell();

        }

    }
}