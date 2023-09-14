
Module modData
    Public Sub GS_DoEvents()
        Try
            Application.DoEvents()
        Catch ex As Exception
            '      MessageBoxExclamation(ex.Message)
        End Try

    End Sub
    Public Sub GF_Sleep(ByVal i As Integer)
        Threading.Thread.Sleep(i)
    End Sub



End Module
