
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

Imports System.Environment
Imports System.IO

Module CommandLineArgsParse

    Sub parseCMDArguments(arg As String)

        Try
            If GetCommandLineArgs.Length <> 0 And availableCMDLineArgs.Contains(arg) = True Then
                If arg = "createConf" Then
                    createConfig(True)
                ElseIf arg = "promptArgs" Then
                    PromptArgs()
                    If argsFlag = True Then
                        ParseArguments()
                    End If
                End If
            End If
        Catch ex As Exception
            If DebugMode = True Then
                Wln("Error while parsing real command-line arguments: {0} " + vbNewLine + _
                    "{1}", "neutralText", Err.Description, ex.StackTrace) : Wdbg(ex.StackTrace, True)
            End If
        End Try

    End Sub

End Module
