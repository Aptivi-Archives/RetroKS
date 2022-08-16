
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

    static class Flags
    {

        // Variables
        public static bool ProbeFlag = true;                          // Check to see if the hardware can be probed
        public static bool GPUProbeFlag = false;                      // No GPU probe (Probe GPU = 'gpuprobe' kernel argument)
        public static bool Quiet = false;                             // Quiet mode
        public static bool TimeDateIsSet = false;                     // To fix a bug after reboot
        public static bool StopPanicAndGoToDoublePanic;               // Double panic mode in kernel error
        public static bool DebugMode = false;                         // Toggle Debugging mode
        public static bool LoginFlag;                                 // Flag for log-in
        public static bool MainUserDone;                              // Main users initialization is done
        public static bool CommandFlag = false;                       // A signal for command kernel argument
        public static bool templateSetExitFlag = false;               // A signal for checking if the template was set
        public static bool CruserFlag = false;                        // A signal to the kernel where user has to be created
        public static bool argsFlag;                                  // A flag for checking for an argument later
        public static bool argsInjected;                              // A flag for checking for an argument on reboot
        public static bool customColor = false;                       // Enable custom colors
        public static bool enableDemo = true;                         // Enable Demo Account
        public static bool setRootPasswd = false;                     // Set Root Password
        public static string RootPasswd = "";                            // Set Root Password
        public static bool maintenance = false;                       // Maintenance Mode
        public static bool argsOnBoot = false;                        // Arguments On Boot
        public static bool clsOnLogin = false;                        // Clear Screen On Log-in
        public static bool showMOTD = true;                           // Show MOTD on log-in
        public static bool simHelp = false;                           // Simplified Help Command
        public static bool slotProbe = true;                          // Probe slots
        public static bool quietProbe = false;                        // Probe quietly
        public static bool ShuttingDown = false;                      // Shutting down

    }
}