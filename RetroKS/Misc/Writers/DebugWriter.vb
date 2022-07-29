
'    RetroKS  Copyright (C) 2018  EoflaOE
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

Imports System.IO

Module DebugWriter

    Public dbgWriter As New StreamWriter(AppDataPath + "\kernelDbg.log")

    Sub Wdbg(text As String, line As Boolean, ParamArray vars() As Object)

        If (DebugMode = True) Then
            If (line = False) Then
                dbgWriter.Write(FormatDateTime(CDate(strKernelTimeDate), DateFormat.ShortDate) + " " + FormatDateTime(CDate(strKernelTimeDate), DateFormat.ShortTime) + ": " + text, vars)
            ElseIf (line = True) Then
                dbgWriter.WriteLine(FormatDateTime(CDate(strKernelTimeDate), DateFormat.ShortDate) + " " + FormatDateTime(CDate(strKernelTimeDate), DateFormat.ShortTime) + ": " + text, vars)
            End If
        End If

    End Sub

End Module
