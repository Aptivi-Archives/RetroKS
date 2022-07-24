
'    Kernel Simulator  Copyright (C) 2018  EoflaOE
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

Imports System.Reflection

Public Module EntryPoint

    ''' <summary>
    ''' Initializes RetroKS and calls <see cref="Main()"/> to start the legacy kernel up. This can only be used on parent KS, which is 0.0.24.0
    ''' or later.
    ''' </summary>
    Public Sub Main()
        If Assembly.GetCallingAssembly().GetName.Name = "Kernel Simulator" And
           Assembly.GetCallingAssembly().GetName.Version >= New Version(0, 0, 24, 0) Then
            KernelMain()
        Else
            Wln("RetroKS should be run from Kernel Simulator 0.0.24.0 or later.", "uncontError")
        End If
    End Sub

End Module
