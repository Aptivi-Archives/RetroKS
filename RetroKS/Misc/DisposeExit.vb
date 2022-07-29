
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

Imports System.Diagnostics.Process

Module DisposeExit

    Private Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" (hProcess As IntPtr, dwMinimumWorkingSetSize As Int32, dwMaximumWorkingSetSize As Int32) As Int32

    Sub DisposeAll()

        On Error GoTo RAMError

        GC.Collect()
        GC.WaitForPendingFinalizers()
        If (Environment.OSVersion.Platform = PlatformID.Win32NT) Then
            SetProcessWorkingSetSize(GetCurrentProcess().Handle, -1, -1)
        End If
        Exit Sub
RAMError:
        Wln("Error trying to free RAM: {0} - Continuing...", "neutralText", Err.Description)
        Resume Next

    End Sub

End Module
