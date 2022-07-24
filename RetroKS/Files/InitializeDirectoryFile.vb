
'    RetroKS  Copyright (C) 2022  EoflaOE
'
'    This file is part of Kernel Simulator
'
'    Kernel Simulator is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    Kernel Simulator is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with this program.  If not, see <https://www.gnu.org/licenses/>.

Module InitializeDirectoryFile

    ''' <summary>
    ''' Platform-dependent home path
    ''' </summary>
    Public ReadOnly Property HomePath As String
        Get
            If IsOnUnix() Then
                Return Environment.GetEnvironmentVariable("HOME")
            Else
                Return Environment.GetEnvironmentVariable("USERPROFILE").Replace("\", "/")
            End If
        End Get
    End Property

    ''' <summary>
    ''' Platform-dependent application data path
    ''' </summary>
    Public ReadOnly Property AppDataPath As String
        Get
            If IsOnUnix() Then
                Return Environment.GetEnvironmentVariable("HOME") + "/.config/retroks/"
            Else
                Return (Environment.GetEnvironmentVariable("LOCALAPPDATA") + "/RetroKS/").Replace("\", "/")
            End If
        End Get
    End Property

    Sub Init()
        AvailableDirs.AddRange({"boot", "bin", "dev", "etc", "lib", "proc", "usr", "var"})
    End Sub

End Module
