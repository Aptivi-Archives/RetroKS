﻿
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

Module Login

    'Variables
    Public userword As New Dictionary(Of String, String)()      'List of usernames and passwords
    Public answeruser As String                                 'Input of username
    Public answerpass As String                                 'Input of password
    Public password As String                                   'Password for user we're logging in to
    Public signedinusrnm As String                              'Username that is signed in

    Sub LoginPrompt()

        'Prompts user to log-in
        If clsOnLogin = True Then
            Console.Clear()
        End If
        If showMOTD = False Then
            W(NewLine + "Username: ", "input")
        Else
            W(NewLine + MOTD + NewLine + NewLine + "Username: ", "input")
        End If
        answeruser = Console.ReadLine()
        If InStr(answeruser, " ") > 0 Then
            Wln("Spaces are not allowed.", "neutralText")
            LoginPrompt()
        ElseIf answeruser.IndexOfAny("[~`!@#$%^&*()-+=|{}':;.,<>/?]".ToCharArray) <> -1 Then
            Wln("Special characters are not allowed.", "neutralText")
            LoginPrompt()
        Else
            showPasswordPrompt(answeruser)
        End If

    End Sub

    Sub showPasswordPrompt(usernamerequested As String)

        'Variables and error handler
        Dim DoneFlag As Boolean = False
        On Error Resume Next

        'Prompts user to enter a user's password
        For Each availableUsers As String In userword.Keys.ToArray
            If availableUsers = answeruser And disabledList(availableUsers) = False Then
                Wdbg("ASSERT({0} = {1}, {2} = False) = True, True", True, availableUsers, answeruser, disabledList(availableUsers))
                DoneFlag = True
                password = userword.Item(usernamerequested)
                'Check if there's the password
                If Not password = Nothing Then
                    W("{0}'s password: ", "input", usernamerequested)
                    answerpass = Console.ReadLine()
                    If InStr(answerpass, " ") > 0 Then
                        Wln("Spaces are not allowed.", "neutralText")
                        If maintenance = False Then
                            LoginPrompt()
                        Else
                            showPasswordPrompt(usernamerequested)
                        End If
                    ElseIf answerpass.IndexOfAny("[~`!@#$%^&*()-+=|{}':;.,<>/?]".ToCharArray) <> -1 Then
                        Wln("Special characters are not allowed.", "neutralText")
                        If maintenance = False Then
                            LoginPrompt()
                        Else
                            showPasswordPrompt(usernamerequested)
                        End If
                    Else
                        If userword.TryGetValue(usernamerequested, password) AndAlso password = answerpass Then
                            Wdbg("ASSERT(Parse({0}, {1})) = True | ASSERT({1} = {2}) = True", True, usernamerequested, password, answerpass)
                            signIn(usernamerequested)
                        Else
                            Wln(NewLine + "Wrong password.", "neutralText")
                            If maintenance = False Then
                                LoginPrompt()
                            Else
                                showPasswordPrompt(usernamerequested)
                            End If
                        End If
                    End If
                Else
                    'Log-in instantly
                    signIn(usernamerequested)
                End If
            ElseIf availableUsers = answeruser And disabledList(availableUsers) = True Then
                Wln("User is disabled.", "neutralText")
                LoginPrompt()
            End If
            If ShuttingDown Then Exit Sub
        Next
        If DoneFlag = False Then
            Wln(NewLine + "Wrong username.", "neutralText")
            LoginPrompt()
        End If

    End Sub

    Sub signIn(signedInUser As String)

        'Initialize shell, and sign in to user.
        Wln(NewLine + "Logged in successfully as {0}!", "neutralText", signedInUser)
        signedinusrnm = signedInUser
        initializeShell()

    End Sub

End Module
