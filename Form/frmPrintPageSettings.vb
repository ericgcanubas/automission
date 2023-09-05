Public Class FrmPrintPageSettings
    Public ThisForm As String
    Public gsClickOK As Boolean = False

    Private Sub FrmPrintPageSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gsClickOK = False



    End Sub
    Private Sub btnNewReport_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        gsClickOK = True
        txtFILE_NAME.Clear()
        txtPRINT_TITLE.Clear()

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        gsClickOK = False
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        gsClickOK = True
        Dim cn As New OleDb.OleDbConnection(fMS_Con)
        Try
            cn.Open()
            Dim cmd As New OleDb.OleDbCommand($"select *  from tblprint where [File_NAME] = '{txtFILE_NAME.Text}' and [form_name] = '{ThisForm}' ", cn)
            Dim rd As OleDb.OleDbDataReader = cmd.ExecuteReader
            If rd.Read Then

                fMS_execute($"UPDATE tblprint SET [print_title] = '{txtPRINT_TITLE.Text}'  WHERE [FILE_NAME] = '{txtFILE_NAME.Text}' and [FORM_NAME] = '{ThisForm}'")
                fPop_Up_Msg(Me.Text, gsUpdateStr, True)
                Me.Close()
            Else
                If fMessageBoxQuestion("New Print Page. Do you want to create as new print page") = True Then
                    fMS_execute($"INSERT INTO [tblprint]  ([print_title],[FILE_NAME],[FORM_NAME],[print_default]) VALUES ('{txtPRINT_TITLE.Text}','{txtFILE_NAME.Text}','{ThisForm}','0')")
                    fPop_Up_Msg(Me.Text, gsSaveStr, True)
                    Me.Close()
                End If
            End If
            rd.Close()
            cn.Close()
        Catch ex As Exception
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            MessageBox.Show(ex.Message)
        End Try


    End Sub
End Class