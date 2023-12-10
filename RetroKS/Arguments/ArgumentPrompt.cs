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
using Terminaux.Reader;

namespace RetroKS
{

    static class ArgumentPrompt
    {

        // Variables
        public static string answerargs;                                                     // Input for arguments

        public static void PromptArgs(bool InjMode = false)
        {

            // Checks if the arguments are injected
            if (Flags.argsInjected == true)
            {
                Flags.argsInjected = false;
                ArgumentParse.ParseArguments();
            }
            else
            {
                // Shows available arguments and prompts for it
                TextWriterColor.W("Available arguments: {0}" + Kernel.NewLine + "Arguments ('help' for help): ", "input", string.Join(", ", Kernel.AvailableArgs));
                answerargs = TermReader.Read();

                // Make a kernel check for arguments later if anything is entered
                if (!string.IsNullOrEmpty(answerargs) & InjMode == false)
                {
                    Flags.argsFlag = true;
                }
                else if (!string.IsNullOrEmpty(answerargs) & InjMode == true)
                {
                    Flags.argsInjected = true;
                    TextWriterColor.Wln("Injected arguments will be scheduled to run at next reboot.", "neutralText");
                }
                else if (answerargs == "q" & InjMode == true)
                {
                    TextWriterColor.Wln("Argument Injection has been cancelled.", "neutralText");
                }
            }

        }

    }
}
