
'    RetroKS  Copyright (C) 2022  EoflaOE
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
                Wln("Help commands:" + vbNewLine + vbNewLine +
                    "adduser: Adds users (Only admins can access this command)" + vbNewLine +
                    "annoying-sound (Alias: beep): Console will beep in Hz and time in milliseconds" + vbNewLine +
                    "arginj: Injects arguments to the kernel (reboot required, admins only)" + vbNewLine +
                    "calc: Simple calculator (No prompt)" + vbNewLine +
                    "cdir (Alias: currentdir): Shows current directory" + vbNewLine +
                    "changedir (Aliases: chdir, cd): Changes directory" + vbNewLine +
                    "chhostname: Changes host name (Admins only)" + vbNewLine +
                    "chmotd: Changes MOTD, the Message Of The Day (Admins only)" + vbNewLine +
                    "choice: Makes user choices" + vbNewLine +
                    "chpwd: Changes password for current user" + vbNewLine +
                    "chusrname: Changes user name (Admins Only)" + vbNewLine +
                    "cls: Clears the screen" + vbNewLine +
                    "debuglog: Shows debug logs (Admins Only)" + vbNewLine +
                    "disco: A disco effect! (press ENTER to quit)" + vbNewLine +
                    "echo: Writes a text into a console" + vbNewLine +
                    "future-eyes-destroyer (Alias: fed): Like disco, but black/white version." + vbNewLine +
                    "help: Help page" + vbNewLine +
                    "hwprobe: Probe hardware manually (One time in 'nohwprobe' kernel)" + vbNewLine +
                    "list (Alias: ls): List file/folder contents in current folder" + vbNewLine +
                    "logout: Logs you out." + vbNewLine +
                    "lsdrivers: Lists drivers that is recognized by the kernel." + vbNewLine +
                    "lsnet: Lists all network addresses on host" + vbNewLine +
                    "lsnettree: Lists all network addresses on host using the tree" + vbNewLine +
                    "md (Alias: mkdir): Creates a directory (No prompt)" + vbNewLine +
                    "netinfo: Lists information about all available interfaces" + vbNewLine +
                    "panicsim: Kernel Panic Simulator (real)" + vbNewLine +
                    "perm: Manage permissions for users (Only admins can access this command)" + vbNewLine +
                    "ping: Check to see if specified address is available" + vbNewLine +
                    "read: Writes file contents to the console" + vbNewLine +
                    "reboot: Restarts your computer (WARNING: No syncing, because it is not a final kernel)" + vbNewLine +
                    "reloadconfig: Reloads configuration file that is edited." + vbNewLine +
                    "rd (Alias: rmdir): Removes a directory (No prompt)" + vbNewLine +
                    "rmuser: Removes a user from the list (Admins Only)" + vbNewLine +
                    "scical: Scientific calculator. The unit converter is separated to another command (No prompt)" + vbNewLine +
                    "setcolors: Sets up kernel colors" + vbNewLine +
                    "setthemes: Sets up kernel themes" + vbNewLine +
                    "showmotd: Shows message of the day set by user or kernel" + vbNewLine +
                    "showtd: Shows date and time" + vbNewLine +
                    "shutdown: The kernel will be shut down" + vbNewLine +
                    "sysinfo: System information" + vbNewLine +
                    "unitconv: Unit converter that is separated from scicalc." + vbNewLine +
                    "version: Shows kernel version", "neutralText")
            Else
                Wln(String.Join(", ", availableCommands), "neutralText")
            End If

        ElseIf command.Contains("adduser") Then

            Wln("Usage: adduser <userName> [password] [confirm]" + vbNewLine +
                "       adduser: to be prompted about new username and password", "neutralText")

        ElseIf command.Contains("annoying-sound") Or command.Contains("beep") Then

            Wln("Usage: annoying-sound/beep <Frequency:Hz> <Time:Seconds>" + vbNewLine +
                "       annoying-sound/beep: to be prompted about beeping.", "neutralText")

        ElseIf command.Contains("arginj") Then

            Wln("Usage: arginj [Arguments separated by commas]" + vbNewLine +
                "       arginj: to be prompted about boot arguments.", "neutralText")

        ElseIf command.Contains("calc") Then

            Wln("Usage: calc <expression> ...", "neutralText")

        ElseIf command.Contains("cdir") Or command.Contains("currentdir") Then

            Wln("Usage: cdir/currentdir: to get current directory", "neutralText")

        ElseIf command.Contains("changedir") Or command.Contains("chdir") Or command.StartsWith("cd") Then

            Wln("Usage: chdir/changedir/cd <directory> OR ..", "neutralText")

        ElseIf command.Contains("chhostname") Then

            Wln("Usage: chhostname <HostName>" + vbNewLine +
                "       chhostname: to be prompted about changing host name.", "neutralText")

        ElseIf command.Contains("chmotd") Then

            Wln("Usage: chmotd <Message>", "neutralText")

        ElseIf command.Contains("choice") Then

            Wln("Usage: choice <Question> <sets>" + vbNewLine +
                "       choice: to be prompted about choices.", "neutralText")

        ElseIf command.Contains("chpwd") Then

            Wln("Usage: chpwd: to be prompted about changing passwords.", "neutralText")

        ElseIf command.Contains("chusrname") Then

            Wln("Usage: chusrname <oldUserName> <newUserName>" + vbNewLine +
                "       chusrname: to be prompted about changing usernames.", "neutralText")

        ElseIf command.Contains("cls") Then

            Wln("Usage: cls: to clear screen.", "neutralText")

        ElseIf command.Contains("debuglog") Then

            Wln("Usage: debuglog: Shows you debug logs so you can send the log to us.", "neutralText")

        ElseIf command.Contains("disco") Then

            Wln("Usage: disco: to get a disco effect on the console. True color support will come with GUI console.", "neutralText")

        ElseIf command.Contains("echo") Then

            Wln("Usage: echo <text>" + vbNewLine +
                "       echo: to be prompted about text printing.", "neutralText")

        ElseIf command.Contains("fed") Or command.Contains("future-eyes-destroyer") Then

            Wln("Usage: fed/future-eyes-destroyer: It will be removed in the future. Simulates a monochrome disco.", "neutralText")

        ElseIf command.Contains("hwprobe") Then

            Wln("Usage: hwprobe: Probes hardware (Only works when the hardware is not probed and hwprobe is not executed).", "neutralText")

        ElseIf command.Contains("ls") Or command.Contains("list") Then

            If command = "ls" Or command = "list" Then
                Wln("Usage: ls/list [oneDirectory]" + vbNewLine +
                    "       ls/list: to get current directory.", "neutralText")
            ElseIf command = "lsdrivers" Then
                Wln("Usage: lsdrivers: Lists probed drivers." + vbNewLine +
                    "       Friends of lsdrivers: sysinfo, version", "neutralText")
            ElseIf command = "lsnet" Then
                Wln("Usage: lsnet: Lists network information, as well as every computer connected to a network." + vbNewLine +
                    "       Friends of lsnet: lsnettree", "neutralText")
            ElseIf command = "lsnettree" Then
                Wln("Usage: lsnettree: Lists network information, as well as every computer connected to a network, in a tree form." + vbNewLine +
                    "       Friends of lsnettree: lsnet", "neutralText")
            End If

        ElseIf command.Contains("logout") Then

            Wln("Usage: logout: Logs you out of the user." + vbNewLine +
                "       Friends of logout: reboot, shutdown", "neutralText")

        ElseIf command.Contains("mkdir") Or command.Contains("md") Then

            Wln("Usage: md/mkdir <anything>", "neutralText")

        ElseIf command.Contains("netinfo") Then

            Wln("Usage: netinfo: Get every network information", "neutralText")

        ElseIf command.Contains("panicsim") Then

            Wln("Usage: panicsim <message> [S/F/D/[C]/U] [RebootTime:Seconds]" + vbNewLine +
                "       panicsim: to be prompted about panic simulator options.", "neutralText")

        ElseIf command.Contains("perm") Then

            Wln("Usage: perm <userName> <Admin/Disabled> <Allow/Disallow>" + vbNewLine +
                "       perm: to be prompted about permission setting.", "neutralText")

        ElseIf command.Contains("ping") Then

            Wln("Usage: ping <Address> [repeatTimes]" + vbNewLine +
                "       ping: to get prompted about writing address.", "neutralText")

        ElseIf command.Contains("rmdir") Or command.Contains("rd") Then

            Wln("Usage: rd/rmdir <directory>", "neutralText")

        ElseIf command.Contains("read") Then

            Wln("Usage: read <file>" + vbNewLine +
                "       read: to get prompted about reading file contents.", "neutralText")

        ElseIf command.Contains("reboot") Then

            Wln("Usage: reboot: Restarts your simulated computer." + vbNewLine +
                "       Friends of reboot: shutdown, logout", "neutralText")

        ElseIf command.Contains("reloadconfig") Then

            Wln("Usage: reloadconfig: Reloads the configuration that is changed by the end-user or by tool." + vbNewLine +
                "       Colors doesn't require a restart, but most of the settings require you to restart.", "neutralText")

        ElseIf command.Contains("rmuser") Then

            Wln("Usage: rmuser <Username>" + vbNewLine +
                "       rmuser: to get prompted about removing usernames.", "neutralText")

        ElseIf command.Contains("scical") Then

            Wln("Usage: scical <expression1|pi|e> <+|-|*|/|%> <expression2|pi|e> ..." + vbNewLine +
                "       scical <sqrt|tan|sin|cos> <number>", "neutralText")

        ElseIf command.Contains("setcolors") Then

            Wln("Usage: setcolors <inputColor/def> <licenseColor/def> <contKernelErrorColor/def> <uncontKernelErrorColor/def> <hostNameShellColor/def> <userNameShellColor/def> <backgroundColor/def> <neutralTextColor/def>" + vbNewLine +
                "       setcolors: to get prompted about setting colors." + vbNewLine +
                "       Friends of setcolors: setthemes", "neutralText")

        ElseIf command.Contains("setthemes") Then

            Wln("Usage: setthemes <Theme>" + vbNewLine +
                "       setthemes: to get prompted about setting themes." + vbNewLine +
                "       Friends of setthemes: setcolors", "neutralText")

        ElseIf command.Contains("showmotd") Then

            Wln("Usage: showmotd: Shows your current Message Of The Day.", "neutralText")

        ElseIf command.Contains("showtd") Then

            Wln("Usage: showtd: Shows the date and time.", "neutralText")

        ElseIf command.Contains("shutdown") Then

            Wln("Usage: shutdown: Shuts down your simulated computer." + vbNewLine +
                "       Friends of shutdown: reboot, logout", "neutralText")

        ElseIf command.Contains("sysinfo") Then

            Wln("Usage: sysinfo: Shows system information and versions." + vbNewLine +
                "       Friends of sysinfo: lsdrivers, version", "neutralText")

        ElseIf command.Contains("unitconv") Then

            Wln("Usage: unitconv <sourceUnit> <targetUnit> <value>" + vbNewLine +
                "Units: B, KB, MB, GB, TB, Bits, Octal, Binary, Decimal, Hexadecimal, mm, cm, m, km, Fahrenheit, Celsius, Kelvin, " +
                "j, kj, m/s, km/h, cm/ms, Kilograms, Grams, Tons, Kilotons, Megatons, kn, n, Hz, kHz, MHz, GHz, Number (source only), " +
                "Money (target only), Percent (target only), Centivolts, Volts, Kilovolts, Watts, Kilowatts, Milliliters, Liters, " +
                "Kiloliters, Gallons, Ounces, Feet, Inches, Yards and Miles.", "neutralText")

        ElseIf command.Contains("version") Then

            Wln("Usage: version: Shows kernel version." + vbNewLine +
                "       Friends of version: lsdrivers, sysinfo", "neutralText")

        End If

    End Sub

End Module
