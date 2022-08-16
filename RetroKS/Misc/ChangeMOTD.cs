using System;

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

    static class ChangeMOTD
    {

        public static void ChangeMessage()
        {

            // New message of the day
            TextWriterColor.W("Write a new Message Of The Day: ", "input");
            string newmotd = Console.ReadLine();
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
}