Public Class FrmItemImageSetup
    Private Sub FrmItemImageSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        chkUseImageProduct.Checked = gsUseImageProduct
        txtImageSourceFolder.Text = gsImageSourceFolder
        txtImageDestinationFolder.Text = gsImageDestinationFolder

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        fSET_SYSTEM_VALUE("UseImageProduct", Val(chkUseImageProduct.Checked)) 'TEMPORARY
        fSET_SYSTEM_VALUE("ImageSourceFolder", txtImageSourceFolder.Text)
        fSET_SYSTEM_VALUE("ImageDestinationFolder", txtImageDestinationFolder.Text)
        MessageBoxInfo("Save = Please restart all running bms.")
    End Sub

    Private Sub btnBrowse1_Click(sender As Object, e As EventArgs) Handles btnBrowse1.Click
        FolderBrowserDialog1.Description = "Please Select  Source File"
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            txtImageSourceFolder.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub btnBrowse2_Click(sender As Object, e As EventArgs) Handles btnBrowse2.Click
        FolderBrowserDialog1.Description = "Please Select  Destination File"
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            txtImageDestinationFolder.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
End Class