
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

// We have separated below subs from Login.vb for easy management of user tools.

using System;
using System.Linq;

namespace RetroKS
{
    static class UserManagement
    {

        public static void initializeMainUsers()
        {

            // Check if the process is done, then do nothing if it is done.
            if (Flags.MainUserDone == false)
            {

                // Main users will be initialized
                if (Flags.setRootPasswd == true)
                {
                    Login.userword.Add("root", Flags.RootPasswd);
                }
                else
                {
                    Login.userword.Add("root", "toor");
                }
                DebugWriter.Wdbg("Dictionary {0}.userword has been added, result: userword = {1}", true, Login.userword, string.Join(", ", Login.userword.ToArray()));
                Groups.adminList.Add("root", true);
                Groups.disabledList.Add("root", false);

                // Print each main user initialized, if quiet mode wasn't passed
                if (Flags.Quiet == false)
                {
                    TextWriterColor.Wln("usrmgr: System usernames: {0}", "neutralText", string.Join(", ", Login.userword.Keys.ToArray()));
                }

                // Send signal to kernel that this function is done
                Flags.MainUserDone = true;
            }

        }

        public static void initializeUser(string uninitUser, string unpassword = "")
        {

            // Do not confuse with initializeUsers. It initializes user.
            try
            {
                Login.userword.Add(uninitUser, unpassword);
                DebugWriter.Wdbg("userword = {1}", true, Login.userword, string.Join(", ", Login.userword.ToArray()));
                Groups.adminList.Add(uninitUser, false);
                Groups.disabledList.Add(uninitUser, false);
            }
            catch (Exception ex)
            {
                if (Flags.DebugMode == true)
                {
                    TextWriterColor.Wln("Error trying to add username." + Kernel.NewLine + "Error {0}: {1}" + Kernel.NewLine + "{2}", "neutralText", ex.HResult, ex.Message, ex.StackTrace);
                    DebugWriter.Wdbg(ex.StackTrace, true);
                }
                else
                {
                    TextWriterColor.Wln("Error trying to add username." + Kernel.NewLine + "Error {0}: {1}", "neutralText", ex.HResult, ex.Message);
                }
            }

        }

        public static void adduser(string newUser, string newPassword = "")
        {

            // Adds users
            if (Flags.Quiet == false)
            {
                TextWriterColor.Wln("usrmgr: Creating username {0}...", "neutralText", newUser);
            }
            if (string.IsNullOrEmpty(newPassword))
            {
                initializeUser(newUser);
            }
            else
            {
                initializeUser(newUser, newPassword);
            }

        }

        public static void resetUsers()
        {

            // Resets users and permissions
            Groups.adminList.Clear();
            Groups.disabledList.Clear();
            Login.userword.Clear();

            // Resets outputs
            Login.password = null;
            Flags.LoginFlag = false;
            Flags.CruserFlag = false;
            Flags.MainUserDone = false;
            Login.signedinusrnm = null;

            // Resets inputs
            GetCommand.answernewuser = null;
            Login.answerpass = null;
            GetCommand.answerpassword = null;
            Login.answeruser = null;
            ArgumentParse.arguser = null;
            ArgumentParse.argword = null;

        }

        public static void changeName()
        {

            // Variables
            bool DoneFlag = false;
            ;

            // Prompts user to enter a new username
            try
            {
                TextWriterColor.W("Username to be changed: ", "input");
                string answernuser = Console.ReadLine();
                if (answernuser.Contains(" "))
                {
                    TextWriterColor.Wln("Spaces are not allowed.", "neutralText");
                    changePassword();
                }
                else if (answernuser.IndexOfAny("[~`!@#$%^&*()-+=|{}':;.,<>/?]".ToCharArray()) != -1)
                {
                    TextWriterColor.Wln("Special characters are not allowed.", "neutralText");
                    changePassword();
                }
                else if (answernuser == "q")
                {
                    TextWriterColor.Wln("Username changing has been cancelled.", "neutralText");
                }
                else
                {
                    foreach (string user in Login.userword.Keys.ToArray())
                    {
                        if ((user ?? "") == (answernuser ?? ""))
                        {
                            DoneFlag = true;
                            TextWriterColor.W("Username to change to: ", "input");
                            Console.ForegroundColor = (ConsoleColor)Convert.ToInt32(ColorInitialize.inputColor);
                            string answerNewUserTemp = Console.ReadLine();
                            if (answerNewUserTemp.Contains(" "))
                            {
                                TextWriterColor.Wln("Spaces are not allowed.", "neutralText");
                                changePassword();
                            }
                            else if (answerNewUserTemp.IndexOfAny("[~`!@#$%^&*()-+=|{}':;.,<>/?]".ToCharArray()) != -1)
                            {
                                TextWriterColor.Wln("Special characters are not allowed.", "neutralText");
                                changePassword();
                            }
                            else if (answerNewUserTemp == "q")
                            {
                                TextWriterColor.Wln("Username changing has been cancelled.", "neutralText");
                            }
                            else if (Login.userword.ContainsKey(answernuser) == true)
                            {
                                if (!(Login.userword.ContainsKey(answerNewUserTemp) == true))
                                {
                                    string temporary = Login.userword[answernuser];
                                    DebugWriter.Wdbg("userword.ToBeRemoved = {0}", true, string.Join(", ", Convert.ToString(Login.userword[answernuser].ToArray())));
                                    Login.userword.Remove(answernuser);
                                    Login.userword.Add(answerNewUserTemp, temporary);
                                    DebugWriter.Wdbg("userword.Added = {0}", true, Login.userword[answerNewUserTemp]);
                                    Groups.permissionEditForNewUser(answernuser, answerNewUserTemp);
                                    TextWriterColor.Wln("Username has been changed to {0}!", "neutralText", answerNewUserTemp);
                                    if ((answernuser ?? "") == (Login.signedinusrnm ?? ""))
                                    {
                                        DebugWriter.Wdbg("{0}.Logout.Execute(because ASSERT({0} = {1}) = True)", true, answernuser, Login.signedinusrnm);
                                        Login.LoginPrompt();
                                    }
                                }
                                else
                                {
                                    DebugWriter.Wdbg("ASSERT(userwordDict.Cont({0})) = True", true, answerNewUserTemp);
                                    TextWriterColor.Wln("The new name you entered is already found.", "neutralText");
                                }
                            }
                        }
                    }
                }
                if (DoneFlag == false)
                {
                    DebugWriter.Wdbg("ASSERT(isFound({0})) = False", true, answernuser);
                    TextWriterColor.Wln("User {0} not found.", "neutralText", answernuser);
                    changePassword();
                }
            }
            catch (Exception ex)
            {
                TextWriterColor.Wln("Failed to change name: {0}", "neutralText", ex.Message);
            }
        }


        public static void changePassword()
        {
            // Prompts user to enter current password
            try
            {
                Login.password = Login.userword[Login.answeruser];

                // Checks if there is a password
                if (Login.password != default)
                {
                    TextWriterColor.W("Current password: ", "input");
                    Login.answerpass = Console.ReadLine();
                    if (Login.answerpass.Contains(" "))
                    {
                        TextWriterColor.Wln("Spaces are not allowed.", "neutralText");
                        changePassword();
                    }
                    else if (Login.answerpass.IndexOfAny("[~`!@#$%^&*()-+=|{}':;.,<>/?]".ToCharArray()) != -1)
                    {
                        TextWriterColor.Wln("Special characters are not allowed.", "neutralText");
                        changePassword();
                    }
                    else if (Login.answerpass == "q")
                    {
                        TextWriterColor.Wln("Password changing has been cancelled.", "neutralText");
                    }
                    else if (Login.userword.TryGetValue(Login.answeruser, out Login.password) && (Login.password ?? "") == (Login.answerpass ?? ""))
                    {
                        changePasswordPrompt(Login.answeruser);
                    }
                    else
                    {
                        TextWriterColor.Wln(Kernel.NewLine + "Wrong password.", "neutralText");
                        changePassword();
                    }
                }
                else
                {
                    changePasswordPrompt(Login.answeruser);
                }
            }
            catch (Exception ex)
            {
                TextWriterColor.Wln("Failed to change password: {0}", "neutralText", ex.Message);
            }
        }

        public static void changePasswordPrompt(string usernamerequestedChange)
        {

            // Prompts user to enter new password
            TextWriterColor.W("New password: ", "input");
            string answernewpass = Console.ReadLine();
            if (answernewpass.Contains(" "))
            {
                TextWriterColor.Wln("Spaces are not allowed.", "neutralText");
                changePasswordPrompt(usernamerequestedChange);
            }
            else if (answernewpass.IndexOfAny("[~`!@#$%^&*()-+=|{}':;.,<>/?]".ToCharArray()) != -1)
            {
                TextWriterColor.Wln("Special characters are not allowed.", "neutralText");
                changePasswordPrompt(usernamerequestedChange);
            }
            else if (answernewpass == "q")
            {
                TextWriterColor.Wln("Password changing has been cancelled.", "neutralText");
            }
            else
            {
                TextWriterColor.W("Confirm: ", "input");
                string answernewpassconfirm = Console.ReadLine();
                if (answernewpassconfirm.Contains(" "))
                {
                    TextWriterColor.Wln("Spaces are not allowed.", "neutralText");
                    changePasswordPrompt(usernamerequestedChange);
                }
                else if (answernewpassconfirm.IndexOfAny("[~`!@#$%^&*()-+=|{}':;.,<>/?]".ToCharArray()) != -1)
                {
                    TextWriterColor.Wln("Special characters are not allowed.", "neutralText");
                    changePasswordPrompt(usernamerequestedChange);
                }
                else if (answernewpassconfirm == "q")
                {
                    TextWriterColor.Wln("Password changing has been cancelled.", "neutralText");
                }
                else if ((answernewpassconfirm ?? "") == (answernewpass ?? ""))
                {
                    Login.userword[usernamerequestedChange] = answernewpass;
                }
                else if ((answernewpassconfirm ?? "") != (answernewpass ?? ""))
                {
                    TextWriterColor.Wln("Passwords doesn't match.", "neutralText");
                    changePasswordPrompt(usernamerequestedChange);
                }
            }

        }

        public static void removeUser()
        {

            // Removes user from the username and password list
            TextWriterColor.W("Username to be removed: ", "input");
            string answerrmuser = Console.ReadLine();
            removeUserFromDatabase(answerrmuser);

        }

        // This sub is an accomplice of in-shell command arguments.
        internal static void removeUserFromDatabase(string user)
        {

            try
            {
                if (user.Contains(" "))
                {
                    TextWriterColor.Wln("Spaces are not allowed.", "neutralText");
                    if (Shell.strcommand == "rmuser")
                    {
                        removeUser();
                    }
                    user = null;
                }
                else if (user == "q")
                {
                    user = null;
                }
                else if (user.IndexOfAny("[~`!@#$%^&*()-+=|{}':;.,<>/?]".ToCharArray()) != -1)
                {
                    TextWriterColor.Wln("Special characters are not allowed.", "neutralText");
                    if (Shell.strcommand == "rmuser")
                    {
                        removeUser();
                    }
                    user = null;
                }
                else if (string.IsNullOrEmpty(user))
                {
                    TextWriterColor.Wln("Blank username.", "neutralText");
                    if (Shell.strcommand == "rmuser")
                    {
                        removeUser();
                    }
                    user = null;
                }
                else if (Login.userword.ContainsKey(user) == false)
                {
                    DebugWriter.Wdbg("ASSERT(isFound({0})) = False", true, user);
                    TextWriterColor.Wln("User {0} not found.", "neutralText", user);
                    if (Shell.strcommand == "rmuser")
                    {
                        removeUser();
                    }
                    user = null;
                }
                else
                {
                    foreach (string usersRemove in Login.userword.Keys.ToArray())
                    {
                        if ((usersRemove ?? "") == (user ?? "") & user == "root")
                        {
                            TextWriterColor.Wln("User {0} isn't allowed to be removed.", "neutralText", user);
                            if (Shell.strcommand == "rmuser")
                            {
                                removeUser();
                            }
                            user = null;
                        }
                        else if ((user ?? "") == (usersRemove ?? "") & (usersRemove ?? "") == (Login.signedinusrnm ?? ""))
                        {
                            TextWriterColor.Wln("User {0} is already logged in. Log-out and log-in as another admin.", "neutralText", user);
                            DebugWriter.Wdbg("ASSERT({0}.isLoggedIn(ASSERT({0} = {1}) = True)) = True", true, user, Login.signedinusrnm);
                            if (Shell.strcommand == "rmuser")
                            {
                                removeUser();
                            }
                            user = null;
                        }
                        else if ((usersRemove ?? "") == (user ?? "") & user != "root")
                        {
                            Groups.adminList.Remove(user);
                            Groups.disabledList.Remove(user);
                            DebugWriter.Wdbg("userword.ToBeRemoved = {0}", true, string.Join(", ", Convert.ToString(Login.userword[user].ToArray())));
                            Login.userword.Remove(user);
                            TextWriterColor.Wln("User {0} removed.", "neutralText", user);
                            user = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (Flags.DebugMode == true)
                {
                    TextWriterColor.Wln("Error trying to add username." + Kernel.NewLine + "Error {0}: {1}" + Kernel.NewLine + "{2}", "neutralText", ex.HResult, ex.Message, ex.StackTrace);
                    DebugWriter.Wdbg(ex.StackTrace, true);
                }
                else
                {
                    TextWriterColor.Wln("Error trying to add username." + Kernel.NewLine + "Error {0}: {1}", "neutralText", ex.HResult, ex.Message);
                }
            }


        }

        public static void addUser()
        {

            // Prompt user to write username to be added
            TextWriterColor.W("Write username: ", "input");
            GetCommand.answernewuser = Console.ReadLine();
            if (GetCommand.answernewuser.Contains(" "))
            {
                TextWriterColor.Wln("Spaces are not allowed.", "neutralText");
            }
            else if (GetCommand.answernewuser.IndexOfAny("[~`!@#$%^&*()-+=|{}':;.,<>/?]".ToCharArray()) != -1)
            {
                TextWriterColor.Wln("Special characters are not allowed.", "neutralText");
            }
            else if (GetCommand.answernewuser == "q")
            {
                TextWriterColor.Wln("Username creation has been cancelled.", "neutralText");
            }
            else
            {
                newPassword(GetCommand.answernewuser);
            }

        }

        public static void newPassword(string user)
        {

            TextWriterColor.W("Write password: ", "input");
            GetCommand.answerpassword = Console.ReadLine();
            if (GetCommand.answerpassword.Contains(" "))
            {
                TextWriterColor.Wln("Spaces are not allowed.", "neutralText");
            }
            else if (GetCommand.answerpassword.IndexOfAny("[~`!@#$%^&*()-+=|{}':;.,<>/?]".ToCharArray()) != -1)
            {
                TextWriterColor.Wln("Special characters are not allowed.", "neutralText");
            }
            else if (GetCommand.answerpassword == "q")
            {
                TextWriterColor.Wln("Username creation has been cancelled.", "neutralText");
            }
            else
            {
                TextWriterColor.W("Confirm: ", "input");
                string answerpasswordconfirm = Console.ReadLine();
                if (answerpasswordconfirm.Contains(" "))
                {
                    TextWriterColor.Wln("Spaces are not allowed.", "neutralText");
                }
                else if (answerpasswordconfirm.IndexOfAny("[~`!@#$%^&*()-+=|{}':;.,<>/?]".ToCharArray()) != -1)
                {
                    TextWriterColor.Wln("Special characters are not allowed.", "neutralText");
                }
                else if (answerpasswordconfirm == "q")
                {
                    TextWriterColor.Wln("Username creation has been cancelled.", "neutralText");
                }
                else if ((GetCommand.answerpassword ?? "") == (answerpasswordconfirm ?? ""))
                {
                    adduser(user, GetCommand.answerpassword);
                }
                else if ((GetCommand.answerpassword ?? "") != (answerpasswordconfirm ?? ""))
                {
                    TextWriterColor.Wln("Password doesn't match.", "neutralText");
                }
            }

        }

    }
}