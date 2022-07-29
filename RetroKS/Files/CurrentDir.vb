
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

Module CurrentDir

    'Variables
    Public currDir As String = "/"

    Sub setCurrDir(dir As String)

        If (AvailableDirs.Contains(dir)) Then
            currDir = "/" + dir
        ElseIf (dir = "") Then
            currDir = "/"
        Else
            Wln("Cannot change directory to /{0} because that directory leads nowhere.", "neutralText", dir)
        End If

    End Sub

End Module
