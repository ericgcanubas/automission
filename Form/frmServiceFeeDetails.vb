
Public Class frmServiceFeeDetails
    Public gsID As String
    Public gsNew As Boolean = True
    Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        Me.Close()
    End Sub

    Private Sub frmServiceFeeDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fBackGroundImageStyle(Me)
        fYear(cmbYEAR_SF)
        fMonth(cmbMONTH_SF)
        If gsID <> "" Then
            fRefresh()
            gsNew = False
        End If

    End Sub
    Private Sub fRefresh()

        Try

            Dim sQuery As String = "select * from service_fee where id = '" & gsID & "' Limit 1"
            fExecutedUsingReading(Me, sQuery)

        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fRefresh()
            Else
                End
            End If

        End Try
    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click
        If txtDESCRIPTION.Text = "" Then
            fMessageboxWarning("Description is required!")
            Exit Sub
        End If
        If numSERVICE_FEE_PCT.Value = 0 Then
            fMessageboxWarning("Please enter service fee percentage")
        End If

        Dim sQuery As String = fFieldCollector(Me)

        If gsNew = False Then
            fExecutedOnly("UPDATE service_fee SET " & sQuery & "  Where ID = '" & gsID & "'")

        Else
            gsID = fGetMaxField("ID", "`SERVICE_FEE`")
            fExecutedOnly("INSERT INTO service_fee SET " & sQuery & ",ID = '" & gsID & "'")
        End If

        fCLean_and_refresh(Me)
        gsID = ""
        gsNew = True
        cmbMONTH_SF.SelectedValue = Now.Date.Month
        cmbYEAR_SF.SelectedValue = Now.Date.Year
    End Sub

    Private Sub numSERVICE_FEE_PCT_ValueChanged(sender As Object, e As EventArgs) Handles numSERVICE_FEE_PCT.ValueChanged
        numSERVICE_FEE_PCT.DecimalPlaces = 0
    End Sub
End Class