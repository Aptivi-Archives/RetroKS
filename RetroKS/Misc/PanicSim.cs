
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
using Terminaux.Reader;

namespace RetroKS
{
    static class PanicSim
    {

        public static void panicPrompt()
        {

            TextWriterColor.W("Write a message: ", "input");
            string kpmsg = TermReader.Read();
            if (string.IsNullOrEmpty(kpmsg))
            {
                TextWriterColor.Wln("Blank message.", "neutralText");
            }
            else if (kpmsg == "q")
            {
                TextWriterColor.Wln("Text printing has been cancelled.", "neutralText");
            }
            else
            {
                TextWriterColor.W("Write error type: ", "input");
                char kpet = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (Convert.ToString(kpet) == "")
                {
                    TextWriterColor.Wln("Blank error type", "neutralText");
                }
                else if (Convert.ToString(kpet) == "q")
                {
                    TextWriterColor.Wln("Text printing has been cancelled.", "neutralText");
                }
                else if (Convert.ToString(kpet) == "S" | Convert.ToString(kpet) == "U" | Convert.ToString(kpet) == "D" | Convert.ToString(kpet) == "F" | Convert.ToString(kpet) == "C")
                {
                    TextWriterColor.W("Restart time in seconds: ", "input");
                    string kptime = TermReader.Read();
                    if (string.IsNullOrEmpty(kptime))
                    {
                        TextWriterColor.Wln("Blank time", "neutralText");
                    }
                    else if (Convert.ToDouble(kptime) <= 3600d & (Convert.ToString(kpet) != "C" | Convert.ToString(kpet) != "D"))
                    {
                        KernelTools.KernelError(kpet, true, Convert.ToInt64(kptime), kpmsg);
                    }
                    else if (Convert.ToDouble(kptime) <= 3600d & Convert.ToString(kpet) == "C" | Convert.ToDouble(kptime) <= 0d & Convert.ToString(kpet) == "C" | Convert.ToDouble(kptime) <= 3600d & Convert.ToString(kpet) == "D" | Convert.ToDouble(kptime) <= 0d & Convert.ToString(kpet) == "D")
                    {
                        KernelTools.KernelError(kpet, false, 0L, kpmsg);
                    }
                    else if (Convert.ToDouble(kptime) <= 0d & Convert.ToString(kpet) != "C")
                    {
                        TextWriterColor.Wln("Invalid time.", "neutralText");
                    }
                    else if (kptime == "q")
                    {
                        TextWriterColor.Wln("Text printing has been cancelled.", "neutralText");
                    }
                }
                else
                {
                    TextWriterColor.Wln("Invalid error type", "neutralText");
                }
            }

        }

    }
}
