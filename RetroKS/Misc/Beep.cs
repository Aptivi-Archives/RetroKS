
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

namespace RetroKS
{
    static class BeepType
    {

        public static void BeepFreq()
        {

            TextWriterColor.W("Beep Frequency in Hz that has the limit of 37-32767 Hz: ", "input");
            GetCommand.answerbeep = Console.ReadLine();
            if (Convert.ToDouble(GetCommand.answerbeep) > int.MaxValue)
            {
                TextWriterColor.Wln("Integer overflow on frequency.", "neutralText");
            }
            else if (GetCommand.answerbeep == "q")
            {
                TextWriterColor.Wln("Computer beeping has been cancelled.", "neutralText");
            }
            else
            {
                int argresult = (int)Math.Round(GetCommand.key);
                if (int.TryParse(GetCommand.answerbeep, out argresult))
                {
                    if (Convert.ToDouble(GetCommand.answerbeep) <= 36d | Convert.ToDouble(GetCommand.answerbeep) >= 32768d)
                    {
                        TextWriterColor.Wln("Invalid value for beep frequency.", "neutralText");
                    }
                    else if (Convert.ToDouble(GetCommand.answerbeep) > 2048d)
                    {
                        TextWriterColor.W("WARNING: Beep may be loud, depending on speaker. Setting values higher than 2048 might cause your ears to damage, " + "and more importantly, your motherboard speaker might deafen, or malfunction." + Kernel.NewLine + "Are you sure that you want to beep at this frequency, {0}? (y/N) ", "input", GetCommand.answerbeep);
                        char answerrape = Console.ReadKey().KeyChar;
                        if (Convert.ToString(answerrape) == "n" | Convert.ToString(answerrape) == "N" | Convert.ToString(answerrape) == "" | Convert.ToString(answerrape) == "q")
                        {
                            TextWriterColor.Wln(Kernel.NewLine + "High frequency. Please read documentation for more info why high frequency shouldn't be used.", "neutralText");
                        }
                        else if (Convert.ToString(answerrape) == "y" | Convert.ToString(answerrape) == "Y")
                        {
                            Console.WriteLine();
                            BeepSystem();
                        }
                    }
                    else
                    {
                        BeepSystem();
                    }
                }
            }

        }

        public static void BeepSystem()
        {

            TextWriterColor.W("Beep Time in seconds that has the limit of 1-3600: ", "input");
            GetCommand.answerbeepms = Console.ReadLine();
            if (double.TryParse(GetCommand.answerbeepms, out GetCommand.key))
            {
                if (Convert.ToDouble(GetCommand.answerbeepms) <= 0d | Convert.ToDouble(GetCommand.answerbeepms) >= 3601d)
                {
                    TextWriterColor.Wln("Invalid value for beep time.", "neutralText");
                }
                else if (GetCommand.answerbeepms == "q")
                {
                    TextWriterColor.Wln("Computer beeping has been cancelled.", "neutralText");
                }
                else
                {
                    Beep(Convert.ToInt32(GetCommand.answerbeep), Convert.ToDouble(GetCommand.answerbeepms));
                }
            }

        }

        public static void Beep(int freq, double s)
        {

            if (freq <= 36 | freq >= 32768)
            {
                TextWriterColor.Wln("Invalid value for beep frequency.", "neutralText");
            }
            else if (freq > 2048)
            {
                TextWriterColor.W("WARNING: Beep may be loud, depending on speaker. Setting values higher than 2048 might cause your ears to damage, " + "and more importantly, your motherboard speaker might deafen, or malfunction." + Kernel.NewLine + "Are you sure that you want to beep at this frequency, {0}? (y/N) ", "input", GetCommand.answerbeep);
                char answerrape = Console.ReadKey().KeyChar;
                if (Convert.ToString(answerrape) == "n" | Convert.ToString(answerrape) == "N" | Convert.ToString(answerrape) == "" | Convert.ToString(answerrape) == "q")
                {
                    TextWriterColor.Wln(Kernel.NewLine + "High frequency. Please read documentation for more info why high frequency shouldn't be used.", "neutralText");
                }
                else if (Convert.ToString(answerrape) == "y" | Convert.ToString(answerrape) == "Y")
                {
                    TextWriterColor.Wln(Kernel.NewLine + "Beeping in {0} seconds in {1} Hz...", "neutralText", s, freq);
#if NETFRAMEWORK
                    Console.Beep(freq, (int)Math.Round(s * 1000d));
#else
                    Console.Beep();
#endif
                    TextWriterColor.Wln("Beep complete.", "neutralText");
                }
            }
            else
            {
                TextWriterColor.Wln("Beeping in {0} seconds in {1} Hz...", "neutralText", s, freq);
#if NETFRAMEWORK
                Console.Beep(freq, (int)Math.Round(s * 1000d));
#else
                Console.Beep();
#endif
                TextWriterColor.Wln("Beep complete.", "neutralText");
            }

        }

    }
}