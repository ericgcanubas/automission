
Module modData
    Public Sub fDoEvents()
        Try
            Application.DoEvents()
        Catch ex As Exception
            '      MessageBoxExclamation(ex.Message)
        End Try

    End Sub
    Public Sub fSleep(ByVal i As Integer)
        Threading.Thread.Sleep(i)
    End Sub



End Module
