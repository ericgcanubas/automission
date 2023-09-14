Imports System.Security.Principal
Module modAdministrator

    Public Function GF_IsRunAdministrator() As Boolean
        Dim identity = WindowsIdentity.GetCurrent()
        Dim principal = New WindowsPrincipal(identity)
        Dim isElevated As Boolean = principal.IsInRole(WindowsBuiltInRole.Administrator)

        Return isElevated

    End Function
End Module
