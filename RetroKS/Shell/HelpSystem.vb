
'    RetroKS  Copyright (C) 2022  Aptivi
'
'    This file is part of RetroKS
'
'    RetroKS is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    RetroKS is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with this program.  If not, see <https://www.gnu.org/licenses/>.

Module HelpSystem

    Sub ShowHelp(Optional command As String = "")

        If command = "" Then

            If simHelp = False Then
                Wln("Help commands:" + NewLine + NewLine +
                    "adduser: Adds users (Only admins can access this command)" + NewLine +
                    "annoying-sound (Alias: beep): Console will beep in Hz and time in milliseconds" + NewLine +
                    "arginj: Injects arguments to the kernel (reboot required, admins only)" + NewLine +
                    "calc: Simple calculator (No prompt)" + NewLine +
                    "cdir (Alias: currentdir): Shows current directory" + NewLine +
                    "changedir (Aliases: chdir, cd): Changes directory" + NewLine +
                    "chhostname: Changes host name (Admins only)" + NewLine +
                    "chmotd: Changes MOTD, the Message Of The Day (Admins only)" + NewLine +
                    "choice: Makes user choices" + NewLine +
                    "chpwd: Changes password for current user" + NewLine +
                    "chusrname: Changes user name (Admins Only)" + NewLine +
                    "cls: Clears the screen" + NewLine +
                    "debuglog: Shows debug logs (Admins Only)" + NewLine +
                    "disco: A disco effect! (press ENTER to quit)" + NewLine +
                    "echo: Writes a text into a console" + NewLine +
                    "future-eyes-destroyer (Alias: fed): Like disco, but black/white version." + NewLine +
                    "help: Help page" + NewLine +
                    "hwprobe: Probe hardware manually (One time in 'nohwprobe' kernel)" + NewLine +
                    "list (Alias: ls): List file/folder contents in current folder" + NewLine +
                    "logout: Logs you out." + NewLine +
                    "lsdrivers: Lists drivers that is recognized by the kernel." + NewLine +
                    "md (Alias: mkdir): Creates a directory (No prompt)" + NewLine +
                    "netinfo: Lists information about all available interfaces" + NewLine +
                    "panicsim: Kernel Panic Simulator (real)" + NewLine +
                    "perm: Manage permissions for users (Only admins can access this command)" + NewLine +
                    "ping: Check to see if specified address is available" + NewLine +
                    "read: Writes file contents to the console" + NewLine +
                    "reboot: Restarts your computer (WARNING: No syncing, because it is not a final kernel)" + NewLine +
                    "reloadconfig: Reloads configuration file that is edited." + NewLine +
                    "rd (Alias: rmdir): Removes a directory (No prompt)" + NewLine +
                    "rmuser: Removes a user from the list (Admins Only)" + NewLine +
                    "scical: Scientific calculator. The unit converter is separated to another command (No prompt)" + NewLine +
                    "setcolors: Sets up kernel colors" + NewLine +
                    "setthemes: Sets up kernel themes" + NewLine +
                    "showmotd: Shows message of the day set by user or kernel" + NewLine +
                    "showtd: Shows date and time" + NewLine +
                    "shutdown: The kernel will be shut down" + NewLine +
                    "sysinfo: System information" + NewLine +
                    "unitconv: Unit converter that is separated from scicalc." + NewLine +
                    "version: Shows kernel version", "neutralText")
            Else
                Wln(String.Join(", ", availableCommands), "neutralText")
            End If

        ElseIf command.Contains("adduser") Then

            Wln("Usage: adduser <userName> [password] [confirm]" + NewLine +
                "       adduser: to be prompted about new username and password", "neutralText")

        ElseIf command.Contains("annoying-sound") Or command.Contains("beep") Then

            Wln("Usage: annoying-sound/beep <Frequency:Hz> <Time:Seconds>" + NewLine +
                "       annoying-sound/beep: to be prompted about beeping.", "neutralText")

        ElseIf command.Contains("arginj") Then

            Wln("Usage: arginj [Arguments separated by commas]" + NewLine +
                "       arginj: to be prompted about boot arguments.", "neutralText")

        ElseIf command.Contains("calc") Then

            Wln("Usage: calc <expression> ...", "neutralText")

        ElseIf command.Contains("cdir") Or command.Contains("currentdir") Then

            Wln("Usage: cdir/currentdir: to get current directory", "neutralText")

        ElseIf command.Contains("changedir") Or command.Contains("chdir") Or command.StartsWith("cd") Then

            Wln("Usage: chdir/changedir/cd <directory> OR ..", "neutralText")

        ElseIf command.Contains("chhostname") Then

            Wln("Usage: chhostname <HostName>" + NewLine +
                "       chhostname: to be prompted about changing host name.", "neutralText")

        ElseIf command.Contains("chmotd") Then

            Wln("Usage: chmotd <Message>", "neutralText")

        ElseIf command.Contains("choice") Then

            Wln("Usage: choice <Question> <sets>" + NewLine +
                "       choice: to be prompted about choices.", "neutralText")

        ElseIf command.Contains("chpwd") Then

            Wln("Usage: chpwd: to be prompted about changing passwords.", "neutralText")

        ElseIf command.Contains("chusrname") Then

            Wln("Usage: chusrname <oldUserName> <newUserName>" + NewLine +
                "       chusrname: to be prompted about changing usernames.", "neutralText")

        ElseIf command.Contains("cls") Then

            Wln("Usage: cls: to clear screen.", "neutralText")

        ElseIf command.Contains("debuglog") Then

            Wln("Usage: debuglog: Shows you debug logs so you can send the log to us.", "neutralText")

        ElseIf command.Contains("disco") Then

            Wln("Usage: disco: to get a disco effect on the console. True color support will come with GUI console.", "neutralText")

        ElseIf command.Contains("echo") Then

            Wln("Usage: echo <text>" + NewLine +
                "       echo: to be prompted about text printing.", "neutralText")

        ElseIf command.Contains("fed") Or command.Contains("future-eyes-destroyer") Then

            Wln("Usage: fed/future-eyes-destroyer: It will be removed in the future. Simulates a monochrome disco.", "neutralText")

        ElseIf command.Contains("hwprobe") Then

            Wln("Usage: hwprobe: Probes hardware (Only works when the hardware is not probed and hwprobe is not executed).", "neutralText")

        ElseIf command.Contains("ls") Or command.Contains("list") Then

            If command = "ls" Or command = "list" Then
                Wln("Usage: ls/list [oneDirectory]" + NewLine +
                    "       ls/list: to get current directory.", "neutralText")
            ElseIf command = "lsdrivers" Then
                Wln("Usage: lsdrivers: Lists probed drivers." + NewLine +
                    "       Friends of lsdrivers: sysinfo, version", "neutralText")
            ElseIf command = "lsnet" Then
                Wln("Usage: lsnet: Lists network information, as well as every computer connected to a network." + NewLine +
                    "       Friends of lsnet: lsnettree", "neutralText")
            ElseIf command = "lsnettree" Then
                Wln("Usage: lsnettree: Lists network information, as well as every computer connected to a network, in a tree form." + NewLine +
                    "       Friends of lsnettree: lsnet", "neutralText")
            End If

        ElseIf command.Contains("logout") Then

            Wln("Usage: logout: Logs you out of the user." + NewLine +
                "       Friends of logout: reboot, shutdown", "neutralText")

        ElseIf command.Contains("mkdir") Or command.Contains("md") Then

            Wln("Usage: md/mkdir <anything>", "neutralText")

        ElseIf command.Contains("netinfo") Then

            Wln("Usage: netinfo: Get every network information", "neutralText")

        ElseIf command.Contains("panicsim") Then

            Wln("Usage: panicsim <message> [S/F/D/[C]/U] [RebootTime:Seconds]" + NewLine +
                "       panicsim: to be prompted about panic simulator options.", "neutralText")

        ElseIf command.Contains("perm") Then

            Wln("Usage: perm <userName> <Admin/Disabled> <Allow/Disallow>" + NewLine +
                "       perm: to be prompted about permission setting.", "neutralText")

        ElseIf command.Contains("ping") Then

            Wln("Usage: ping <Address> [repeatTimes]" + NewLine +
                "       ping: to get prompted about writing address.", "neutralText")

        ElseIf command.Contains("rmdir") Or command.Contains("rd") Then

            Wln("Usage: rd/rmdir <directory>", "neutralText")

        ElseIf command.Contains("read") Then

            Wln("Usage: read <file>" + NewLine +
                "       read: to get prompted about reading file contents.", "neutralText")

        ElseIf command.Contains("reboot") Then

            Wln("Usage: reboot: Restarts your simulated computer." + NewLine +
                "       Friends of reboot: shutdown, logout", "neutralText")

        ElseIf command.Contains("reloadconfig") Then

            Wln("Usage: reloadconfig: Reloads the configuration that is changed by the end-user or by tool." + NewLine +
                "       Colors doesn't require a restart, but most of the settings require you to restart.", "neutralText")

        ElseIf command.Contains("rmuser") Then

            Wln("Usage: rmuser <Username>" + NewLine +
                "       rmuser: to get prompted about removing usernames.", "neutralText")

        ElseIf command.Contains("scical") Then

            Wln("Usage: scical <expression1|pi|e> <+|-|*|/|%> <expression2|pi|e> ..." + NewLine +
                "       scical <sqrt|tan|sin|cos> <number>", "neutralText")

        ElseIf command.Contains("setcolors") Then

            Wln("Usage: setcolors <inputColor/def> <licenseColor/def> <contKernelErrorColor/def> <uncontKernelErrorColor/def> <hostNameShellColor/def> <userNameShellColor/def> <backgroundColor/def> <neutralTextColor/def>" + NewLine +
                "       setcolors: to get prompted about setting colors." + NewLine +
                "       Friends of setcolors: setthemes", "neutralText")

        ElseIf command.Contains("setthemes") Then

            Wln("Usage: setthemes <Theme>" + NewLine +
                "       setthemes: to get prompted about setting themes." + NewLine +
                "       Friends of setthemes: setcolors", "neutralText")

        ElseIf command.Contains("showmotd") Then

            Wln("Usage: showmotd: Shows your current Message Of The Day.", "neutralText")

        ElseIf command.Contains("showtd") Then

            Wln("Usage: showtd: Shows the date and time.", "neutralText")

        ElseIf command.Contains("shutdown") Then

            Wln("Usage: shutdown: Shuts down your simulated computer." + NewLine +
                "       Friends of shutdown: reboot, logout", "neutralText")

        ElseIf command.Contains("sysinfo") Then

            Wln("Usage: sysinfo: Shows system information and versions." + NewLine +
                "       Friends of sysinfo: lsdrivers, version", "neutralText")

        ElseIf command.Contains("unitconv") Then

            Wln("Usage: unitconv <sourceUnit> <targetUnit> <value>" + NewLine +
                "Units: B, KB, MB, GB, TB, Bits, Octal, Binary, Decimal, Hexadecimal, mm, cm, m, km, Fahrenheit, Celsius, Kelvin, " +
                "j, kj, m/s, km/h, cm/ms, Kilograms, Grams, Tons, Kilotons, Megatons, kn, n, Hz, kHz, MHz, GHz, Number (source only), " +
                "Money (target only), Percent (target only), Centivolts, Volts, Kilovolts, Watts, Kilowatts, Milliliters, Liters, " +
                "Kiloliters, Gallons, Ounces, Feet, Inches, Yards and Miles.", "neutralText")

        ElseIf command.Contains("version") Then

            Wln("Usage: version: Shows kernel version." + NewLine +
                "       Friends of version: lsdrivers, sysinfo", "neutralText")

        End If

    End Sub

End Module
