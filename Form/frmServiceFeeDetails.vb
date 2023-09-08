
Public Class FrmServiceFeeDetails
    Public ID As Integer
    Public IsNew As Boolean = True
    Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        Me.Close()
    End Sub

    Private Sub frmServiceFeeDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        YearlyComboBoxLoad(cmbYEAR_SF)
        MonthlyComboBoxLoad(cmbMONTH_SF)
        If ID > 0 Then
            fRefresh()
            IsNew = False
        End If

    End Sub
    Private Sub fRefresh()

        Try

            Dim sQuery As String = "select * from service_fee where id = '" & ID & "' Limit 1"
            SqlExecutedUsingReading(Me, sQuery)

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                fRefresh()
            Else
                End
            End If

        End Try
    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click
        If txtDESCRIPTION.Text = "" Then
            MessageBoxWarning("Description is required!")
            Exit Sub
        End If
        If numSERVICE_FEE_PCT.Value = 0 Then
            MessageBoxWarning("Please enter service fee percentage")
        End If



        If IsNew = False Then
            SqlExecuted("UPDATE service_fee SET " & SqlUpdate(Me) & "  Where ID = '" & ID & "'")
        Else
            ID = GetMaxField("ID", "`SERVICE_FEE`")
            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO service_fee ({SQL_Field},ID) VALUES ({SQL_Value},{ID}) ")

        End If

        ClearAndRefresh(Me)
        ID = 0
        IsNew = True
        cmbMONTH_SF.SelectedValue = Now.Date.Month
        cmbYEAR_SF.SelectedValue = Now.Date.Year
    End Sub

    Private Sub numSERVICE_FEE_PCT_ValueChanged(sender As Object, e As EventArgs) Handles numSERVICE_FEE_PCT.ValueChanged
        numSERVICE_FEE_PCT.DecimalPlaces = 0
    End Sub
End Class