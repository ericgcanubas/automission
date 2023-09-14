
Public Class FrmUnitofMeasureDetails
    Public ID As Integer
    Dim IsNew As Boolean = True
    Public This_BS As BindingSource
    Public Dgv As DataGridView
    Private Sub FrmShipViaDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ID > 0 Then
            Try
                SqlExecutedUsingReading(Me, "select * from unit_of_measure where id = '" & ID & "' Limit 1")
                IsNew = False
            Catch ex As Exception
                MessageBoxWarning(ex.Message)
            End Try
        End If

    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtNAME.Text) = "" Then
            MessageBoxInfo("Please enter unit of measure name")
            Exit Sub
        End If

        If Trim(txtSymbol.Text) = "" Then
            MessageBoxInfo("Please enter unit of measure symbol")
            Exit Sub
        End If

        If IsNew = False Then
            SqlExecuted("UPDATE unit_of_measure set " & SqlUpdate(Me) & " Where ID = '" & ID & "' Limit 1")
        Else
            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO unit_of_measure ({SQL_Field},ID) VALUES ({SQL_Value},{ID}) ")
        End If
        SaveNotify(Me, IsNew)
        BindingViewUpdate(Dgv, $"Select ID,`Name`,Symbol, If(Inactive=0,'No','Yes') as `Inactive` from Unit_of_measure Where ID = '{ID}' limit 1", IsNew, This_BS)
        ClearAndRefresh(Me)
        ID = 0
        IsNew = True
        If SecurityAccessMode(FrmUnitofMeasure, IsNew) = False Then
            Me.Close()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class