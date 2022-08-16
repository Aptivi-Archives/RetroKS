using System;
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

    static class HostName
    {

        public static void ChangeHostName()
        {

            // Change host-name to custom name
            TextWriterColor.W("Write a new host name: ", "input");
            string newhost = Console.ReadLine();
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
}