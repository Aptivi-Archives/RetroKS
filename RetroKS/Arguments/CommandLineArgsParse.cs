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

using static System.Environment;
using System.Linq;
using System;

namespace RetroKS
{

    static class CommandLineArgsParse
    {

        public static void parseCMDArguments(string arg)
        {

            try
            {
                if (GetCommandLineArgs().Length != 0 & Kernel.availableCMDLineArgs.Contains(arg) == true)
                {
                    if (arg == "createConf")
                    {
                        Config.createConfig(true);
                    }
                    else if (arg == "promptArgs")
                    {
                        ArgumentPrompt.PromptArgs();
                        if (Flags.argsFlag == true)
                        {
                            ArgumentParse.ParseArguments();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (Flags.DebugMode == true)
                {
                    TextWriterColor.Wln("Error while parsing real command-line arguments: {0} " + Kernel.NewLine + "{1}", "neutralText", ex.Message, ex.StackTrace);
                    DebugWriter.Wdbg(ex.StackTrace, true);
                }
            }

        }

    }
}