﻿
Public Class FrmReportComponentItems
    Public ID As Integer
    Private Sub FrmReportComponentItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GS_ComboBoxLoad(cmbTYPE, "SELECT * FROM COMPONENT_TYPE ", "ID", "DESCRIPTION")
        GS_ComboBoxLoad(cmbPARAMETER_ID1, "select ID,`NAME` FROM COMPONENT ", "ID", "NAME")
        GS_ComboBoxLoad(cmbPARAMETER_ID2, "select ID,`NAME` FROM COMPONENT ", "ID", "NAME")
        GS_ComboBoxLoad(cmbPARAMETER_ID3, "select ID,`NAME` FROM COMPONENT ", "ID", "NAME")
        SqlExecutedUsingReading(Me, "select * FROM COMPONENT WHERE ID = '" & ID & "' limit 1")

    End Sub

    Private Sub BtnCANCEL_Click(sender As Object, e As EventArgs) Handles btnCANCEL.Click
        Me.Close()
    End Sub

    Private Sub BtnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click
        If txtNAME.Text = "" Then
            MessageBoxWarning("Please enter name")
            Exit Sub
        End If

        If ID = 0 Then
            ID = GF_GetMaxField("ID", "COMPONENT")

            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO COMPONENT ({SQL_Field},ID) VALUES ({SQL_Value},{ID}) ")

        Else
            SqlExecuted("UPDATE component SET " & SqlUpdate(Me) & " WHERE ID ='" & ID & "'")
        End If

        Me.Close()

    End Sub
End Class