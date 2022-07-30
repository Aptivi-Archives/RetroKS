
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

Module ChangeMOTD

    Sub ChangeMessage()

        'New message of the day
        W("Write a new Message Of The Day: ", "input")
        Dim newmotd As String = Console.ReadLine()
        If newmotd = "" Then
            Wln("Blank message of the day.", "neutralText")
        ElseIf newmotd = "q" Then
            Wln("MOTD changing has been cancelled.", "neutralText")
        Else
            W("Changing MOTD...", "neutralText")
            My.Settings.MOTD = newmotd
            Wln(" Done!" + vbNewLine + "Please log-out, or use 'showmotd' to see the changes", "neutralText")
        End If

    End Sub

End Module
