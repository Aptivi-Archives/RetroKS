
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

namespace RetroKS
{
    static class HelpSystem
    {

        public static void ShowHelp(string command = "")
        {

            if (string.IsNullOrEmpty(command))
            {

                if (Flags.simHelp == false)
                {
                    TextWriterColor.Wln("Help commands:" + Kernel.NewLine + Kernel.NewLine + "adduser: Adds users (Only admins can access this command)" + Kernel.NewLine + "annoying-sound (Alias: beep): Console will beep in Hz and time in milliseconds" + Kernel.NewLine + "arginj: Injects arguments to the kernel (reboot required, admins only)" + Kernel.NewLine + "calc: Simple calculator (No prompt)" + Kernel.NewLine + "cdir (Alias: currentdir): Shows current directory" + Kernel.NewLine + "changedir (Aliases: chdir, cd): Changes directory" + Kernel.NewLine + "chhostname: Changes host name (Admins only)" + Kernel.NewLine + "chmotd: Changes MOTD, the Message Of The Day (Admins only)" + Kernel.NewLine + "choice: Makes user choices" + Kernel.NewLine + "chpwd: Changes password for current user" + Kernel.NewLine + "chusrname: Changes user name (Admins Only)" + Kernel.NewLine + "cls: Clears the screen" + Kernel.NewLine + "debuglog: Shows debug logs (Admins Only)" + Kernel.NewLine + "disco: A disco effect! (press ENTER to quit)" + Kernel.NewLine + "echo: Writes a text into a console" + Kernel.NewLine + "future-eyes-destroyer (Alias: fed): Like disco, but black/white version." + Kernel.NewLine + "help: Help page" + Kernel.NewLine + "hwprobe: Probe hardware manually (One time in 'nohwprobe' kernel)" + Kernel.NewLine + "list (Alias: ls): List file/folder contents in current folder" + Kernel.NewLine + "logout: Logs you out." + Kernel.NewLine + "lsdrivers: Lists drivers that is recognized by the kernel." + Kernel.NewLine + "md (Alias: mkdir): Creates a directory (No prompt)" + Kernel.NewLine + "netinfo: Lists information about all available interfaces" + Kernel.NewLine + "panicsim: Kernel Panic Simulator (real)" + Kernel.NewLine + "perm: Manage permissions for users (Only admins can access this command)" + Kernel.NewLine + "ping: Check to see if specified address is available" + Kernel.NewLine + "read: Writes file contents to the console" + Kernel.NewLine + "reboot: Restarts your computer (WARNING: No syncing, because it is not a final kernel)" + Kernel.NewLine + "reloadconfig: Reloads configuration file that is edited." + Kernel.NewLine + "rd (Alias: rmdir): Removes a directory (No prompt)" + Kernel.NewLine + "rmuser: Removes a user from the list (Admins Only)" + Kernel.NewLine + "scical: Scientific calculator. The unit converter is separated to another command (No prompt)" + Kernel.NewLine + "setcolors: Sets up kernel colors" + Kernel.NewLine + "setthemes: Sets up kernel themes" + Kernel.NewLine + "showmotd: Shows message of the day set by user or kernel" + Kernel.NewLine + "showtd: Shows date and time" + Kernel.NewLine + "shutdown: The kernel will be shut down" + Kernel.NewLine + "sysinfo: System information" + Kernel.NewLine + "unitconv: Unit converter that is separated from scicalc." + Kernel.NewLine + "version: Shows kernel version", "neutralText");
                }
                else
                {
                    TextWriterColor.Wln(string.Join(", ", Shell.availableCommands), "neutralText");
                }
            }

            else if (command.Contains("adduser"))
            {

                TextWriterColor.Wln("Usage: adduser <userName> [password] [confirm]" + Kernel.NewLine + "       adduser: to be prompted about new username and password", "neutralText");
            }

            else if (command.Contains("annoying-sound") | command.Contains("beep"))
            {

                TextWriterColor.Wln("Usage: annoying-sound/beep <Frequency:Hz> <Time:Seconds>" + Kernel.NewLine + "       annoying-sound/beep: to be prompted about beeping.", "neutralText");
            }

            else if (command.Contains("arginj"))
            {

                TextWriterColor.Wln("Usage: arginj [Arguments separated by commas]" + Kernel.NewLine + "       arginj: to be prompted about boot arguments.", "neutralText");
            }

            else if (command.Contains("calc"))
            {

                TextWriterColor.Wln("Usage: calc <expression> ...", "neutralText");
            }

            else if (command.Contains("cdir") | command.Contains("currentdir"))
            {

                TextWriterColor.Wln("Usage: cdir/currentdir: to get current directory", "neutralText");
            }

            else if (command.Contains("changedir") | command.Contains("chdir") | command.StartsWith("cd"))
            {

                TextWriterColor.Wln("Usage: chdir/changedir/cd <directory> OR ..", "neutralText");
            }

            else if (command.Contains("chhostname"))
            {

                TextWriterColor.Wln("Usage: chhostname <HostName>" + Kernel.NewLine + "       chhostname: to be prompted about changing host name.", "neutralText");
            }

            else if (command.Contains("chmotd"))
            {

                TextWriterColor.Wln("Usage: chmotd <Message>", "neutralText");
            }

            else if (command.Contains("choice"))
            {

                TextWriterColor.Wln("Usage: choice <Question> <sets>" + Kernel.NewLine + "       choice: to be prompted about choices.", "neutralText");
            }

            else if (command.Contains("chpwd"))
            {

                TextWriterColor.Wln("Usage: chpwd: to be prompted about changing passwords.", "neutralText");
            }

            else if (command.Contains("chusrname"))
            {

                TextWriterColor.Wln("Usage: chusrname <oldUserName> <newUserName>" + Kernel.NewLine + "       chusrname: to be prompted about changing usernames.", "neutralText");
            }

            else if (command.Contains("cls"))
            {

                TextWriterColor.Wln("Usage: cls: to clear screen.", "neutralText");
            }

            else if (command.Contains("debuglog"))
            {

                TextWriterColor.Wln("Usage: debuglog: Shows you debug logs so you can send the log to us.", "neutralText");
            }

            else if (command.Contains("disco"))
            {

                TextWriterColor.Wln("Usage: disco: to get a disco effect on the console. True color support will come with GUI console.", "neutralText");
            }

            else if (command.Contains("echo"))
            {

                TextWriterColor.Wln("Usage: echo <text>" + Kernel.NewLine + "       echo: to be prompted about text printing.", "neutralText");
            }

            else if (command.Contains("fed") | command.Contains("future-eyes-destroyer"))
            {

                TextWriterColor.Wln("Usage: fed/future-eyes-destroyer: It will be removed in the future. Simulates a monochrome disco.", "neutralText");
            }

            else if (command.Contains("hwprobe"))
            {

                TextWriterColor.Wln("Usage: hwprobe: Probes hardware (Only works when the hardware is not probed and hwprobe is not executed).", "neutralText");
            }

            else if (command.Contains("ls") | command.Contains("list"))
            {

                if (command == "ls" | command == "list")
                {
                    TextWriterColor.Wln("Usage: ls/list [oneDirectory]" + Kernel.NewLine + "       ls/list: to get current directory.", "neutralText");
                }
                else if (command == "lsdrivers")
                {
                    TextWriterColor.Wln("Usage: lsdrivers: Lists probed drivers." + Kernel.NewLine + "       Friends of lsdrivers: sysinfo, version", "neutralText");
                }
                else if (command == "lsnet")
                {
                    TextWriterColor.Wln("Usage: lsnet: Lists network information, as well as every computer connected to a network." + Kernel.NewLine + "       Friends of lsnet: lsnettree", "neutralText");
                }
                else if (command == "lsnettree")
                {
                    TextWriterColor.Wln("Usage: lsnettree: Lists network information, as well as every computer connected to a network, in a tree form." + Kernel.NewLine + "       Friends of lsnettree: lsnet", "neutralText");
                }
            }

            else if (command.Contains("logout"))
            {

                TextWriterColor.Wln("Usage: logout: Logs you out of the user." + Kernel.NewLine + "       Friends of logout: reboot, shutdown", "neutralText");
            }

            else if (command.Contains("mkdir") | command.Contains("md"))
            {

                TextWriterColor.Wln("Usage: md/mkdir <anything>", "neutralText");
            }

            else if (command.Contains("netinfo"))
            {

                TextWriterColor.Wln("Usage: netinfo: Get every network information", "neutralText");
            }

            else if (command.Contains("panicsim"))
            {

                TextWriterColor.Wln("Usage: panicsim <message> [S/F/D/[C]/U] [RebootTime:Seconds]" + Kernel.NewLine + "       panicsim: to be prompted about panic simulator options.", "neutralText");
            }

            else if (command.Contains("perm"))
            {

                TextWriterColor.Wln("Usage: perm <userName> <Admin/Disabled> <Allow/Disallow>" + Kernel.NewLine + "       perm: to be prompted about permission setting.", "neutralText");
            }

            else if (command.Contains("ping"))
            {

                TextWriterColor.Wln("Usage: ping <Address> [repeatTimes]" + Kernel.NewLine + "       ping: to get prompted about writing address.", "neutralText");
            }

            else if (command.Contains("rmdir") | command.Contains("rd"))
            {

                TextWriterColor.Wln("Usage: rd/rmdir <directory>", "neutralText");
            }

            else if (command.Contains("read"))
            {

                TextWriterColor.Wln("Usage: read <file>" + Kernel.NewLine + "       read: to get prompted about reading file contents.", "neutralText");
            }

            else if (command.Contains("reboot"))
            {

                TextWriterColor.Wln("Usage: reboot: Restarts your simulated computer." + Kernel.NewLine + "       Friends of reboot: shutdown, logout", "neutralText");
            }

            else if (command.Contains("reloadconfig"))
            {

                TextWriterColor.Wln("Usage: reloadconfig: Reloads the configuration that is changed by the end-user or by tool." + Kernel.NewLine + "       Colors doesn't require a restart, but most of the settings require you to restart.", "neutralText");
            }

            else if (command.Contains("rmuser"))
            {

                TextWriterColor.Wln("Usage: rmuser <Username>" + Kernel.NewLine + "       rmuser: to get prompted about removing usernames.", "neutralText");
            }

            else if (command.Contains("scical"))
            {

                TextWriterColor.Wln("Usage: scical <expression1|pi|e> <+|-|*|/|%> <expression2|pi|e> ..." + Kernel.NewLine + "       scical <sqrt|tan|sin|cos> <number>", "neutralText");
            }

            else if (command.Contains("setcolors"))
            {

                TextWriterColor.Wln("Usage: setcolors <inputColor/def> <licenseColor/def> <contKernelErrorColor/def> <uncontKernelErrorColor/def> <hostNameShellColor/def> <userNameShellColor/def> <backgroundColor/def> <neutralTextColor/def>" + Kernel.NewLine + "       setcolors: to get prompted about setting colors." + Kernel.NewLine + "       Friends of setcolors: setthemes", "neutralText");
            }

            else if (command.Contains("setthemes"))
            {

                TextWriterColor.Wln("Usage: setthemes <Theme>" + Kernel.NewLine + "       setthemes: to get prompted about setting themes." + Kernel.NewLine + "       Friends of setthemes: setcolors", "neutralText");
            }

            else if (command.Contains("showmotd"))
            {

                TextWriterColor.Wln("Usage: showmotd: Shows your current Message Of The Day.", "neutralText");
            }

            else if (command.Contains("showtd"))
            {

                TextWriterColor.Wln("Usage: showtd: Shows the date and time.", "neutralText");
            }

            else if (command.Contains("shutdown"))
            {

                TextWriterColor.Wln("Usage: shutdown: Shuts down your simulated computer." + Kernel.NewLine + "       Friends of shutdown: reboot, logout", "neutralText");
            }

            else if (command.Contains("sysinfo"))
            {

                TextWriterColor.Wln("Usage: sysinfo: Shows system information and versions." + Kernel.NewLine + "       Friends of sysinfo: lsdrivers, version", "neutralText");
            }

            else if (command.Contains("unitconv"))
            {

                TextWriterColor.Wln("Usage: unitconv <sourceUnit> <targetUnit> <value>" + Kernel.NewLine + "Units: B, KB, MB, GB, TB, Bits, Octal, Binary, Decimal, Hexadecimal, mm, cm, m, km, Fahrenheit, Celsius, Kelvin, " + "j, kj, m/s, km/h, cm/ms, Kilograms, Grams, Tons, Kilotons, Megatons, kn, n, Hz, kHz, MHz, GHz, Number (source only), " + "Money (target only), Percent (target only), Centivolts, Volts, Kilovolts, Watts, Kilowatts, Milliliters, Liters, " + "Kiloliters, Gallons, Ounces, Feet, Inches, Yards and Miles.", "neutralText");
            }

            else if (command.Contains("version"))
            {

                TextWriterColor.Wln("Usage: version: Shows kernel version." + Kernel.NewLine + "       Friends of version: lsdrivers, sysinfo", "neutralText");

            }

        }

    }
}