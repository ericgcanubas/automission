Imports System.Drawing.Printing
Module modPrinter

    Public Sub SystemLoadPrinter(ByVal cmb As ComboBox)
        Dim strInstalledPrinters As String
        cmb.DropDownStyle = ComboBoxStyle.DropDownList
        If PrinterSettings.InstalledPrinters.Count = 0 Then
            MsgBox("No printer installed")
            Exit Sub
        End If

        'display installed printer into combobox list item
        For Each strInstalledPrinters In PrinterSettings.InstalledPrinters
            cmb.Items.Add(strInstalledPrinters)
        Next strInstalledPrinters



    End Sub
    Private Sub SystemPOSRefreshPrinter(ByVal cmb As ComboBox)
        SystemLoadPrinter(cmb)
    End Sub
    Public Sub SystemSetDefaultPrinter(ByVal SelectPrinter As String)

        Dim Selected_Printer As String = SelectPrinter

        If Selected_Printer = "" Then
            Selected_Printer = gsPOS_WINDOWS_PRINTER
        End If

        If SetDefaultPrinter(Selected_Printer) = True Then

            'Do nothing is default
        Else
            MsgBox("Printer name " & Selected_Printer & " is not valid!")
        End If

    End Sub
    'Function to set a printer as default
    Private Function SetDefaultPrinter(ByVal strPrinterName As String) As Boolean
        Dim strCurrPrinter As String
        Dim WsNetwork As Object
        Dim prntDoc As New PrintDocument

        strCurrPrinter = prntDoc.PrinterSettings.PrinterName
        WsNetwork = Microsoft.VisualBasic.CreateObject("WScript.Network")

        Try
            WsNetwork.SetDefaultPrinter(strPrinterName)
            prntDoc.PrinterSettings.PrinterName = strPrinterName

            'set default if selected printer name is a valid installed printer
            If prntDoc.PrinterSettings.IsValid Then
                Return True
            Else
                WsNetwork.SetDefaultPrinter(strCurrPrinter)
                Return False
            End If
        Catch ex As Exception
            WsNetwork.SetDefaultPrinter(strCurrPrinter)
            Return False
        Finally
            WsNetwork = Nothing
            prntDoc = Nothing
        End Try
    End Function
End Module
