
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
using System.Linq;
using Terminaux.Reader;

namespace RetroKS
{
    static class ColorSet
    {

        // Private variables
        private static string answerColor;
        private static string currentStepMessage = "Color for input: ";
        private static int stepCurrent = 0;
        private static int i;

        // Variables
        public static string[] answersColor = new string[8];

        public static void UseDefaults()
        {
            // Use default settings in current step.
            if (i == 0)
            {
                answersColor[i] = "White";
            }
            else if (i == 1)
            {
                answersColor[i] = "White";
            }
            else if (i == 2)
            {
                answersColor[i] = "Yellow";
            }
            else if (i == 3)
            {
                answersColor[i] = "Red";
            }
            else if (i == 4)
            {
                answersColor[i] = "DarkGreen";
            }
            else if (i == 5)
            {
                answersColor[i] = "Green";
            }
            else if (i == 6)
            {
                answersColor[i] = "Black";
            }
            else if (i == 7)
            {
                answersColor[i] = "Gray";
            }
        }

        public static void SetColorSteps()
        {

            // Set colors of individual things.
            bool ResetFlag = false;
            bool DoneFlag = false;

            // Actual code
            for (int i = 0; i <= 8; i++)
            {
                if (i == 8)
                {
                    // Print summary of what is being changed, and evaluate "Live Mode"
                    ColorInitialize.inputColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), answersColor[0]));
                    ColorInitialize.licenseColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), answersColor[1]));
                    ColorInitialize.contKernelErrorColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), answersColor[2]));
                    ColorInitialize.uncontKernelErrorColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), answersColor[3]));
                    ColorInitialize.hostNameShellColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), answersColor[4]));
                    ColorInitialize.userNameShellColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), answersColor[5]));
                    ColorInitialize.backgroundColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), answersColor[6]));
                    ColorInitialize.neutralTextColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), answersColor[7]));
                    LoadBackground.Load();
                    TextWriterColor.Wln("Input Color: {0}" + Kernel.NewLine + "License Color: {1}" + Kernel.NewLine + "Cont. Kernel Error Color: {2}" + Kernel.NewLine + "Uncont. Kernel Error Color: {3}" + Kernel.NewLine + "Hostname Shell Color: {4}" + Kernel.NewLine + "Username Shell Color: {5}" + Kernel.NewLine + "Background Color: {6}" + Kernel.NewLine + "Text Color: {7}", "neutralText", answersColor[0], answersColor[1], answersColor[2], answersColor[3], answersColor[4], answersColor[5], answersColor[6], answersColor[7]);
                }

                // Write current step message
                TextWriterColor.W(currentStepMessage, "input");
                answerColor = TermReader.Read();

                // Checks the user input if colors exist, and then try to put it into a temporary array.
                if (i != 8)
                {
                    if (answerColor == "RESET")
                    {
                        // Give a signal to the command that the colors are resetting. 
                        TextWriterColor.W("Are you sure that you want to reset your colors to the defaults? <y/n> ", "input");
                        string answerreset = Convert.ToString(Console.ReadKey().KeyChar);
                        if (answerreset == "y")
                        {
                            Console.WriteLine();
                            ResetFlag = true;
                            break;
                        }
                        else if (answerreset == "n")
                        {
                            Console.WriteLine();
                        }
                        else if (answerreset == "q")
                        {
                            TextWriterColor.Wln(Kernel.NewLine + "Color changing has been cancelled.", "neutralText");
                            return;
                        }
                    }
                    else if (answerColor == "THEME")
                    {
                        TemplateSet.TemplatePrompt();
                        if (Flags.templateSetExitFlag == true)
                        {
                            TextWriterColor.Wln("Theme changed.", "neutralText");
                            return;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else if (answerColor == "q")
                    {
                        TextWriterColor.Wln("Color changing has been cancelled.", "neutralText");
                        return;
                    }
                    else if (ColorInitialize.availableColors.Contains(answerColor))
                    {
                        answersColor[i] = answerColor;
                        advanceStep();
                    }
                    else if (string.IsNullOrEmpty(answerColor))
                    {
                        // Nothing written, use defaults.
                        UseDefaults();
                        advanceStep();
                    }
                    else
                    {
                        TextWriterColor.Wln("The {0} color is not found. Your answers is case-sensitive.", "neutralText", answerColor);
                        UseDefaults();
                        advanceStep();
                    }
                }
                else if (i == 8)
                {
                    if (answerColor == "y")
                    {
                        DoneFlag = true;
                        TextWriterColor.Wln("Colors changed.", "neutralText");
                    }
                    else if (answerColor == "n")
                    {
                        ResetColors();
                        stepCurrent = 0;
                        currentStepMessage = "Color for input: ";
                        break;
                    }
                    else
                    {
                        TextWriterColor.Wln("System colors are not changed because you wrote an invalid choice.", "neutralText");
                        return;
                    }
                }
            }
            if (ResetFlag == false & DoneFlag == false)
            {
                SetColorSteps();
            }
            else if (ResetFlag == true)
            {
                // Reset every color to their default settings and exit.
                ResetColors();
                TextWriterColor.Wln("Everything is reset to normal settings.", "neutralText");
                stepCurrent = 0;
                currentStepMessage = "Color for input: ";
            }

        }

        public static void advanceStep()
        {

            // Advance a step
            stepCurrent = stepCurrent + 1;
            if (stepCurrent == 1)
            {
                currentStepMessage = "Color for license: ";
            }
            else if (stepCurrent == 2)
            {
                currentStepMessage = "Color for continuable kernel error: ";
            }
            else if (stepCurrent == 3)
            {
                currentStepMessage = "Color for uncontinuable kernel error: ";
            }
            else if (stepCurrent == 4)
            {
                currentStepMessage = "Color for hostname on shell prompt: ";
            }
            else if (stepCurrent == 5)
            {
                currentStepMessage = "Color for username on shell prompt: ";
            }
            else if (stepCurrent == 6)
            {
                currentStepMessage = "Color for background: ";
            }
            else if (stepCurrent == 7)
            {
                currentStepMessage = "Color for texts: ";
            }
            else if (stepCurrent == 8)
            {
                currentStepMessage = "Is this information correct? <y/n> ";
            }

        }

        public static void ResetColors()
        {
            ColorInitialize.inputColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.inputColorDef)));
            ColorInitialize.licenseColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.licenseColorDef)));
            ColorInitialize.contKernelErrorColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.contKernelErrorColorDef)));
            ColorInitialize.uncontKernelErrorColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.uncontKernelErrorColorDef)));
            ColorInitialize.hostNameShellColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.hostNameShellColorDef)));
            ColorInitialize.userNameShellColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.userNameShellColorDef)));
            ColorInitialize.backgroundColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.backgroundColorDef)));
            ColorInitialize.neutralTextColor = (ConsoleColor)Convert.ToInt32(Enum.Parse(typeof(ConsoleColor), Convert.ToString(Templates.neutralTextColorDef)));
            LoadBackground.Load();
        }

    }
}
