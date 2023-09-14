Imports System.Management

Module mod_serial

    Public Function IsHaveSerialNumber() As Boolean
        Dim B As Boolean = False
        Dim KEY_SERIAL As String = ""
        Dim mos As New ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB' ")

        For Each mo As ManagementObject In mos.Get()
            If KEY_SERIAL = mo.Properties.Item("SerialNumber").Value Then
                B = True
            End If
        Next
        Return B
    End Function
End Module
