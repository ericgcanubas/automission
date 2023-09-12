Public Class FrmItemImageSetup
    Private Sub FrmItemImageSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        chkUseImageProduct.Checked = gsUseImageProduct
        txtImageSourceFolder.Text = gsImageSourceFolder
        txtImageDestinationFolder.Text = gsImageDestinationFolder

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        SetDBAccessValue("UseImageProduct", Val(chkUseImageProduct.Checked)) 'TEMPORARY
        SetDBAccessValue("ImageSourceFolder", txtImageSourceFolder.Text)
        SetDBAccessValue("ImageDestinationFolder", txtImageDestinationFolder.Text)
        MessageBoxInfo("Save = Please restart all running bms.")
    End Sub

    Private Sub BtnBrowse1_Click(sender As Object, e As EventArgs) Handles btnBrowse1.Click
        FolderBrowserDialog1.Description = "Please Select  Source File"
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            txtImageSourceFolder.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub BtnBrowse2_Click(sender As Object, e As EventArgs) Handles btnBrowse2.Click
        FolderBrowserDialog1.Description = "Please Select  Destination File"
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            txtImageDestinationFolder.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
End Class