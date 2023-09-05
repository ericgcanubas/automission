Module modMsgForm

    Public Function fRefreshMessage() As Integer
        Dim N As Integer = 0
        frmRefreshMsg.ShowDialog()
        N = frmRefreshMsg.gsSelect
        frmRefreshMsg.Dispose()

        Return N
    End Function
End Module
