using System;
using System.Threading;

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

    static class KernelTools
    {

        /// <summary>
    /// Indicates that there's something wrong with the kernel.
    /// </summary>
    /// <param name="ErrorType">Specifies whether the error is serious, fatal, unrecoverable, or double panic. C/S/D/F/U</param>
    /// <param name="Reboot">Optional. Specifies whether to reboot on panic or to show the message to press any key to shut down</param>
    /// <param name="RebootTime">Optional. Specifies seconds before reboot. 0 is instant. Negative numbers not allowed.</param>
    /// <param name="Description">Optional. Explanation of what happened when it errored.</param>
    /// <remarks></remarks>
        public static void KernelError(char ErrorType, bool Reboot = true, long RebootTime = 30L, string Description = "General kernel error.")
        {
            try
            {
                // Check error types and its capabilities
                if (Convert.ToString(ErrorType) == "S" | Convert.ToString(ErrorType) == "F" | Convert.ToString(ErrorType) == "U" | Convert.ToString(ErrorType) == "D" | Convert.ToString(ErrorType) == "C")
                {
                    if (Convert.ToString(ErrorType) == "U" & RebootTime > 5L | Convert.ToString(ErrorType) == "D" & RebootTime > 5L)
                    {
                        // If the error type is unrecoverable, or double, and the reboot time exceeds 5 seconds, then
                        // generate a second kernel error stating that there is something wrong with the reboot time.
                        KernelError('D', true, 5L, "DOUBLE PANIC: Reboot Time exceeds maximum allowed " + Convert.ToString(ErrorType) + " error reboot time. You found a kernel bug.");
                        Flags.StopPanicAndGoToDoublePanic = true;
                    }
                    else if (Convert.ToString(ErrorType) == "U" & Reboot == false | Convert.ToString(ErrorType) == "D" & Reboot == false)
                    {
                        // If the error type is unrecoverable, or double, and the rebooting is false where it should
                        // not be false, then it can deal with this issue by enabling reboot.
                        TextWriterColor.Wln("[{0}] panic: Reboot enabled due to error level being {0}.", "uncontError", ErrorType);
                        Reboot = true;
                    }
                    if (RebootTime > 3600L)
                    {
                        // If the reboot time exceeds 1 hour, then it will set the time to 1 minute.
                        TextWriterColor.Wln("[{0}] panic: Time to reboot: {1} seconds, exceeds 1 hour. It is set to 1 minute.", "uncontError", ErrorType, RebootTime.ToString());
                        RebootTime = 60L;
                    }
                }
                else
                {
                    // If the error type is other than D/F/C/U/S, then it will generate a second error.
                    KernelError('D', true, 5L, "DOUBLE PANIC: Error Type " + Convert.ToString(ErrorType) + " invalid.");
                    Flags.StopPanicAndGoToDoublePanic = true;
                }

                // Check error capabilities
                if (Description.Contains("DOUBLE PANIC: ") & Convert.ToString(ErrorType) == "D")
                {
                    // If the description has a double panic tag and the error type is Double
                    TextWriterColor.Wln("[{0}] dpanic: {1} -- Rebooting in {2} seconds...", "uncontError", ErrorType, Description, RebootTime.ToString());
                    Thread.Sleep((int)(RebootTime * 1000L));
                    Console.Clear();
                    ResetEverything();
                    EntryPoint.Main();
                }
                else if (Flags.StopPanicAndGoToDoublePanic == true)
                {
                    // Switch to Double Panic
                    return;
                }
                else if (Convert.ToString(ErrorType) == "C" & Reboot == true)
                {
                    // Check if error is Continuable and reboot is enabled
                    Reboot = false;
                    TextWriterColor.Wln("[{0}] panic: Reboot disabled due to error level being {0}." + Kernel.NewLine + "[{0}] panic: {1} -- Press any key to continue using the kernel.", "contError", ErrorType, Description);
                    char answercontpanic = Console.ReadKey().KeyChar;
                }
                else if (Convert.ToString(ErrorType) == "C" & Reboot == false)
                {
                    // Check if error is Continuable and reboot is disabled
                    TextWriterColor.Wln("[{0}] panic: {1} -- Press any key to continue using the kernel.", "contError", ErrorType, Description);
                    char answercontpanic = Console.ReadKey().KeyChar;
                }
                else if (Reboot == false & Convert.ToString(ErrorType) != "D" | Reboot == false & Convert.ToString(ErrorType) != "C")
                {
                    // If rebooting is disabled and the error type does not equal Double or Continuable
                    TextWriterColor.Wln("[{0}] panic: {1} -- Press any key to shutdown.", "uncontError", ErrorType, Description);
                    char answerpanic = Console.ReadKey().KeyChar;
                    Environment.Exit(0);
                }
                else
                {
                    // Everything else.
                    TextWriterColor.Wln("[{0}] panic: {1} -- Rebooting in {2} seconds...", "uncontError", ErrorType, Description, RebootTime.ToString());
                    Thread.Sleep((int)(RebootTime * 1000L));
                    Console.Clear();
                    ResetEverything();
                    EntryPoint.Main();
                }
            }
            catch (Exception ex)
            {
                if (Flags.DebugMode == true)
                {
                    TextWriterColor.Wln(ex.StackTrace, "uncontError");
                    DebugWriter.Wdbg(ex.StackTrace, true);
                    KernelError('D', true, 5L, "DOUBLE PANIC: Kernel bug: " + ex.Message);
                }
                else
                {
                    KernelError('D', true, 5L, "DOUBLE PANIC: Kernel bug: " + ex.Message);
                }
            }

        }

        public static void ResetEverything()
        {

            // Reset every variable that is resettable
            if (Flags.argsInjected == false)
            {
                ArgumentPrompt.answerargs = null;
            }
            Kernel.BootArgs = null;
            GetCommand.answerbeep = null;
            GetCommand.answerbeepms = null;
            GetCommand.answerecho = null;
            Flags.argsFlag = false;
            Flags.ProbeFlag = true;
            Flags.GPUProbeFlag = false;
            Flags.Quiet = false;
            Flags.StopPanicAndGoToDoublePanic = false;
            Shell.strcommand = null;
            Kernel.slotsUsedName = null;
            Kernel.slotsUsedNum = 0;
            Kernel.totalSlots = 0;
            DebugWriter.Wdbg("General variables reset", true);

            // Reset users
            UserManagement.resetUsers();
            DebugWriter.Wdbg("User variables reset", true);

            // Release RAM used
            DisposeExit.DisposeAll();
            DebugWriter.Wdbg("Garbage collector finished", true);

            // Disable Debugger
            if (Flags.DebugMode == true)
            {
                Flags.DebugMode = false;
            }

        }

    }
}