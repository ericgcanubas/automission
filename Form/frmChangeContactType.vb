﻿Public Class frmChangeContactType
    Public gsID As Integer = 0
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmChangeContactType_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        fComboBox(cmbTYPE, "Select * from contact_type_map where id in('1','5','6')", "ID", "DESCRIPTION")
        cmbTYPE.SelectedValue = gsID
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If cmbTYPE.SelectedValue = gsID Then
            fMessageboxInfo(cmbTYPE.Text & " type  already used!")
            Exit Sub
        End If
        gsID = cmbTYPE.SelectedValue
        Me.Close()
    End Sub
End Class