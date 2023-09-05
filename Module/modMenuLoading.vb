
Module modMenuLoading
    Public gsPBLoading As ToolStripProgressBar
    Public Sub fSetPB(ByVal prMIN As Integer, ByVal prMAX As Integer)

        gsPBLoading.Maximum = prMAX
        gsPBLoading.Minimum = prMIN

    End Sub

    Public Sub fGetPB(ByVal prValue As Integer)
        gsPBLoading.Value = prValue

    End Sub

End Module
