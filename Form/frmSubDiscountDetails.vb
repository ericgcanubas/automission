Imports System.Data.Odbc
Public Class FrmSubDiscountDetails
    Public ID As Integer
    Public IsNew As Boolean = True

    Private Sub frmSubDiscountDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With dgvSub.Columns
            .Add("ID", "ID")
            .Item(0).Visible = False
            .Add("FROM", "From")
            .Add("TO", "To")
            .Add("PERCENT", "Percent")

        End With
        DatagridViewMode(dgvSub)

        If IsNew = False Then
            fRefreshDetials()
        End If
    End Sub
    Private Sub fRefreshDetials()
        dgvSub.Rows.Clear()

        Try

            SqlExecutedUsingReading(Me, "select * from sub_discount where id = '" & ID & "'")

            Dim rd As OdbcDataReader = SqlReader("select ID,AMOUNT_FROM,AMOUNT_TO,PERCENT FROM SUB_DISCOUNT_DETAILS WHERE sub_discount_ID = '" & ID & "' ")
            While rd.Read
                dgvSub.Rows.Add(NumIsNull(rd("ID")), NumIsNull(rd("AMOUNT_FROM")), NumIsNull(rd("AMOUNT_TO")), NumIsNull(rd("PERCENT")))
            End While

            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshDetials()
            Else
                End
            End If

        End Try
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click
        If txtCODE.Text = "" Then
            MessageBoxInfo("Please enter code")
            Exit Sub
        End If

        If txtDESCRIPTION.Text = "" Then
            MessageBoxInfo("Please enter description")
            Exit Sub
        End If
        Try

            If IsNew = True Then
                ID = GetMaxField("ID", "sub_discount")
                SqlCreate(Me, SQL_Field, SQL_Value)
                SqlExecuted($"INSERT INTO sub_discount ({SQL_Field},ID) VALUES ({SQL_Value},{ID}) ")
            Else
                SqlExecuted("UPDATE sub_discount SET " & SqlUpdate(Me) & " Where ID = '" & ID & "'")
            End If

            For i As Integer = 0 To dgvSub.Rows.Count - 1
                With dgvSub.Rows(i)
                    If IsNew = True Then

                        SqlExecuted("INSERT INTO sub_discount_details SET sub_discount_id = '" & ID & "',AMOUNT_FROM = '" & NumIsNull(.Cells(1).Value) & "',AMOUNT_TO = '" & NumIsNull(.Cells(2).Value) & "',PERCENT='" & NumIsNull(.Cells(3).Value) & "'")
                    Else
                        If .Visible = False Then
                            SqlExecuted("DELETE FROM sub_discount_details WHERE id = '" & .Cells(0).Value & "'and sub_discount_id = '" & ID & "'")
                        ElseIf NumIsNull(.Cells(0).Value) = 0 Then

                            SqlExecuted("INSERT INTO sub_discount_details SET sub_discount_id = '" & ID & "',AMOUNT_FROM = '" & NumIsNull(.Cells(1).Value) & "',AMOUNT_TO = '" & NumIsNull(.Cells(2).Value) & "',PERCENT='" & NumIsNull(.Cells(3).Value) & "'")
                        Else
                            SqlExecuted("UPDATE sub_discount_details SET AMOUNT_FROM = '" & NumIsNull(.Cells(1).Value) & "',AMOUNT_TO = '" & NumIsNull(.Cells(2).Value) & "',PERCENT='" & NumIsNull(.Cells(3).Value) & "'WHERE id = '" & .Cells(0).Value & "'and sub_discount_id = '" & ID & "'")
                        End If

                    End If
                End With

            Next


            Me.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        Me.Close()
    End Sub

    Private Sub numAMOUNT_FROM_ValueChanged(sender As Object, e As EventArgs) Handles numAMOUNT_FROM.ValueChanged

    End Sub

    Private Sub numAMOUNT_FROM_KeyDown(sender As Object, e As KeyEventArgs) Handles numAMOUNT_FROM.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub numTO_AMOUNT_ValueChanged(sender As Object, e As EventArgs) Handles numTO_AMOUNT.ValueChanged

    End Sub

    Private Sub numTO_AMOUNT_KeyDown(sender As Object, e As KeyEventArgs) Handles numTO_AMOUNT.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub numPercent_ValueChanged(sender As Object, e As EventArgs) Handles numPercent.ValueChanged

    End Sub

    Private Sub numPercent_KeyDown(sender As Object, e As KeyEventArgs) Handles numPercent.KeyDown
        If e.KeyCode = Keys.Enter Then
            If numAMOUNT_FROM.Value = 0 And numTO_AMOUNT.Value = 0 Then
                MessageBoxInfo("Volume not set")
                Exit Sub
            End If
            If numPercent.Value = 0 Then
                MessageBoxInfo("Please enter percent")
            End If
            If dgvSub.Enabled = False Then
                Dim i As Integer = dgvSub.CurrentRow.Index
                With dgvSub.Rows(i)
                    .Cells(0).Value = IIf(NumIsNull(.Cells(0).Value) = 0, "A", .Cells(0).Value)
                    .Cells(1).Value = numAMOUNT_FROM.Value
                    .Cells(2).Value = numTO_AMOUNT.Value
                    .Cells(3).Value = numPercent.Value

                End With
            Else
                dgvSub.Rows.Add("A", numAMOUNT_FROM.Value, numTO_AMOUNT.Value, numPercent.Value)
            End If
            dgvSub.Enabled = True
            ClearAndRefresh(GroupBox1)
            numAMOUNT_FROM.Focus()
        End If
    End Sub

    Private Sub dgvSub_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSub.CellContentClick

    End Sub

    Private Sub dgvSub_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSub.CellDoubleClick
        If dgvSub.Rows.Count <> 0 Then

            numAMOUNT_FROM.Value = dgvSub.Rows(e.RowIndex).Cells(1).Value
            numTO_AMOUNT.Value = dgvSub.Rows(e.RowIndex).Cells(2).Value
            numPercent.Value = dgvSub.Rows(e.RowIndex).Cells(3).Value
            dgvSub.Enabled = False

        End If
    End Sub

    Private Sub dgvSub_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvSub.KeyDown
        If e.KeyCode = Keys.Delete Then
            If dgvSub.Rows.Count <> 0 Then
                Dim i As Integer = dgvSub.CurrentRow.Index
                If NumIsNull(dgvSub.Rows(i).Cells(0).Value) = 0 Then
                    dgvSub.Rows.RemoveAt(i)
                Else
                    dgvSub.Rows(i).Visible = False
                End If





            End If
        End If

    End Sub
End Class