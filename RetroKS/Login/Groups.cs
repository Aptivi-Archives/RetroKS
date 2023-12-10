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
using System.Collections.Generic;
using System.Linq;
using Terminaux.Reader;

namespace RetroKS
{
    static class Groups
    {

        // Variables
        public static Dictionary<string, bool> adminList = new Dictionary<string, bool>();         // Users that are allowed to have administrative access.
        public static Dictionary<string, bool> disabledList = new Dictionary<string, bool>();      // Users that are unable to login

        public static void permission(string type, string username, string mode, bool quiet = false)
        {

            // Variables
            bool DoneFlag = false;

            // Adds user into permission lists.
            try
            {
                if (mode == "Allow")
                {
                    foreach (string availableUsers in Login.userword.Keys.ToArray())
                    {
                        if ((username ?? "") == (availableUsers ?? ""))
                        {
                            if (type == "Admin")
                            {
                                DoneFlag = true;
                                adminList[username] = true;
                                DebugWriter.Wdbg("adminList.Added = {0}", true, adminList[username]);
                                if (quiet == false)
                                {
                                    TextWriterColor.Wln("The user {0} has been added to the admin list.", "neutralText", username);
                                }
                            }
                            else if (type == "Disabled")
                            {
                                DoneFlag = true;
                                disabledList[username] = true;
                                DebugWriter.Wdbg("disabledList.Added = {0}", true, disabledList[username]);
                                if (quiet == false)
                                {
                                    TextWriterColor.Wln("The user {0} has been added to the disabled list.", "neutralText", username);
                                }
                            }
                            else
                            {
                                if (quiet == false)
                                {
                                    TextWriterColor.Wln("Failed to add user into permission lists: invalid type {0}", "neutralText", type);
                                }
                                return;
                            }
                        }
                    }
                    if (DoneFlag == false & quiet == false)
                    {
                        DebugWriter.Wdbg("ASSERT(isFound({0})) = False", true, username);
                        TextWriterColor.Wln("Failed to add user into permission lists: invalid user {0}", "neutralText", username);
                    }
                }
                else if (mode == "Disallow")
                {
                    foreach (string availableUsers in Login.userword.Keys.ToArray())
                    {
                        if ((username ?? "") == (availableUsers ?? "") & (username ?? "") != (Login.signedinusrnm ?? ""))
                        {
                            if (type == "Admin")
                            {
                                DoneFlag = true;
                                DebugWriter.Wdbg("adminList.ToBeRemoved = {0}", true, username);
                                adminList[username] = false;
                                if (quiet == false)
                                {
                                    TextWriterColor.Wln("The user {0} has been removed from the admin list.", "neutralText", username);
                                }
                            }
                            else if (type == "Disabled")
                            {
                                DoneFlag = true;
                                DebugWriter.Wdbg("disabledList.ToBeRemoved = {0}", true, username);
                                disabledList[username] = false;
                                if (quiet == false)
                                {
                                    TextWriterColor.Wln("The user {0} has been removed from the disabled list.", "neutralText", username);
                                }
                            }
                            else
                            {
                                if (quiet == false)
                                {
                                    TextWriterColor.Wln("Failed to remove user from permission lists: invalid type {0}", "neutralText", type);
                                }
                                return;
                            }
                        }
                        else if ((username ?? "") == (Login.signedinusrnm ?? ""))
                        {
                            TextWriterColor.Wln("You are already logged in.", "neutralText");
                            return;
                        }
                    }
                    if (DoneFlag == false & quiet == false)
                    {
                        DebugWriter.Wdbg("ASSERT(isFound({0})) = False", true, username);
                        TextWriterColor.Wln("Failed to remove user from permission lists: invalid user {0}", "neutralText", username);
                    }
                }
                else if (quiet == false)
                {
                    TextWriterColor.Wln("You have found a bug in the permission system: invalid mode {0}", "neutralText", mode);
                }
            }
            catch (Exception ex)
            {
                if (Flags.DebugMode == true)
                {
                    TextWriterColor.Wln("You have either found a bug, or the permission you tried to add or remove is already done, or other error." + Kernel.NewLine + "Error {0}: {1}" + Kernel.NewLine + "{2}", "neutralText", ex.HResult, ex.Message, ex.StackTrace);
                    DebugWriter.Wdbg(ex.StackTrace, true);
                }
                else
                {
                    TextWriterColor.Wln("You have either found a bug, or the permission you tried to add or remove is already done, or other error." + Kernel.NewLine + "Error {0}: {1}", "neutralText", ex.HResult, ex.Message);
                }
            }

        }

        public static void permissionEditForNewUser(string oldName, string username)
        {

            // Edit username (continuation for changeName() sub)
            try
            {
                if (adminList.ContainsKey(oldName) == true & disabledList.ContainsKey(oldName) == true)
                {
                    bool temporary1 = adminList[oldName];
                    bool temporary2 = disabledList[oldName];
                    DebugWriter.Wdbg("adminList.ToBeRemoved = {0}", true, string.Join(", ", oldName));
                    DebugWriter.Wdbg("disabledList.ToBeRemoved = {0}", true, string.Join(", ", oldName));
                    adminList.Remove(oldName);
                    disabledList.Remove(oldName);
                    adminList.Add(username, temporary1);
                    disabledList.Add(username, temporary2);
                    DebugWriter.Wdbg("adminList.Added = {0}", true, adminList[username]);
                    DebugWriter.Wdbg("disabledList.Added = {0}", true, disabledList[username]);
                }
            }
            catch (Exception ex)
            {
                if (Flags.DebugMode == true)
                {
                    TextWriterColor.Wln("You have either found a bug, or the permission you tried to edit for a new user has failed." + Kernel.NewLine + "Error {0}: {1}" + Kernel.NewLine + "{2}", "neutralText", ex.HResult, ex.Message, ex.StackTrace);
                    DebugWriter.Wdbg(ex.StackTrace, true);
                }
                else
                {
                    TextWriterColor.Wln("You have either found a bug, or the permission you tried to edit for a new user has failed." + Kernel.NewLine + "Error {0}: {1}", "neutralText", ex.HResult, ex.Message);
                }
            }

        }

        public static void permissionPrompt()
        {

            // Variables
            bool DoneFlag = false;

            // Asks for username, and then permission prompts.
            try
            {
                TextWriterColor.W("Username to be managed: ", "input");
                string answermuser = TermReader.Read();
                if (answermuser == "q")
                {
                    return;
                }
                else
                {
                    foreach (string userPerm in Login.userword.Keys.ToArray())
                    {
                        if ((userPerm ?? "") == (answermuser ?? "") & answermuser != "root")
                        {
                            TextWriterColor.W("Type (Admin / Disabled): ", "input");
                            string answermtype = TermReader.Read();
                            if (answermtype == "Admin" | answermtype == "Disabled")
                            {
                                TextWriterColor.W("Add or remove? <Add/Remove> ", "input");
                                string answermaddremove = TermReader.Read();
                                if (answermaddremove == "Add" | answermaddremove == "Remove")
                                {
                                    permission(answermtype, Convert.ToString(true), answermuser, Convert.ToBoolean(answermaddremove));
                                }
                                else
                                {
                                    TextWriterColor.Wln("Type {0} not found.", "neutralText", answermtype);
                                }
                            }
                            else
                            {
                                TextWriterColor.Wln("Invalid type {0}.", "neutralText", answermtype);
                                return;
                            }
                        }
                        else if ((userPerm ?? "") == (answermuser ?? "") & answermuser == "root")
                        {
                            TextWriterColor.Wln("User {0}'s permission cannot be changed.", "neutralText", answermuser);
                            return;
                        }
                    }
                    if (DoneFlag == false)
                    {
                        TextWriterColor.Wln("User {0} not found.", "neutralText", answermuser);
                    }
                }
            }
            catch (Exception ex)
            {
                TextWriterColor.Wln("Failed to change permission: {0}", "neutralText", ex.Message);
            }

        }

        public static void permissionEditingPrompt()
        {

            // Variables
            bool DoneFlag = false;

            // Asks for username, and then permission prompts.
            try
            {
                TextWriterColor.W("Username to be managed: ", "input");
                string answermuser = TermReader.Read();
                if (answermuser == "q")
                {
                    return;
                }
                else
                {
                    foreach (string userPerm in Login.userword.Keys.ToArray())
                    {
                        if ((userPerm ?? "") == (answermuser ?? "") & answermuser != "root")
                        {
                            TextWriterColor.W("Type (Admin / Disabled): ", "input");
                            string answermtype = TermReader.Read();
                            if (answermtype == "Admin" | answermtype == "Disabled")
                            {
                                TextWriterColor.W("Is the user allowed? <y/n> ", "input");
                                string answermallow = TermReader.Read();
                                if (answermallow == "y")
                                {
                                    permission(answermtype, answermuser, "Allow");
                                    DoneFlag = true;
                                }
                                else if (answermallow == "n")
                                {
                                    permission(answermtype, answermuser, "Disallow");
                                    DoneFlag = true;
                                }
                                else
                                {
                                    TextWriterColor.Wln("Invalid choice", "neutralText");
                                }
                            }
                            else
                            {
                                TextWriterColor.Wln("Type {0} not found.", "neutralText", answermtype);
                            }
                        }
                        else if ((userPerm ?? "") == (answermuser ?? "") & answermuser == "root")
                        {
                            TextWriterColor.Wln("User {0}'s permission cannot be changed.", "neutralText", answermuser);
                            return;
                        }
                        else if (userPerm == "q")
                        {
                            return;
                        }
                    }
                    if (DoneFlag == false)
                    {
                        TextWriterColor.Wln("User {0} not found.", "neutralText", answermuser);
                    }
                }
            }
            catch (Exception ex)
            {
                TextWriterColor.Wln("Failed to edit permission: {0}", "neutralText", ex.Message);
            }


        }

    }
}
