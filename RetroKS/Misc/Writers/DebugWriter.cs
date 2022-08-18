
// RetroKS  Copyright (C) 2018  Aptivi
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
using System.IO;

namespace RetroKS
{

    static class DebugWriter
    {

        public static StreamWriter dbgWriter = new StreamWriter(InitializeDirectoryFile.AppDataPath + @"\kernelDbg.log");

        public static void Wdbg(string text, bool line, params object[] vars)
        {

            if (Flags.DebugMode == true)
            {
                if (line == false)
                {
                    dbgWriter.Write(Convert.ToDateTime(TimeDate.strKernelTimeDate).ToShortDateString() + " " + Convert.ToDateTime(TimeDate.strKernelTimeDate).ToShortTimeString() + ": " + text, vars);
                }
                else if (line == true)
                {
                    dbgWriter.WriteLine(Convert.ToDateTime(TimeDate.strKernelTimeDate).ToShortDateString() + " " + Convert.ToDateTime(TimeDate.strKernelTimeDate).ToShortTimeString() + ": " + text, vars);
                }
            }

        }

    }
}