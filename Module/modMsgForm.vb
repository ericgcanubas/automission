Module modMsgForm

    Public Function GF_RefreshMessage() As Integer
        Dim N As Integer
        FrmRefreshMsg.ShowDialog()
        N = FrmRefreshMsg.gsSelect
        FrmRefreshMsg.Dispose()

        Return N
    End Function
End Module
