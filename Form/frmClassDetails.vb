﻿
Public Class FrmClassDetails
    Public This_BS As BindingSource
    Public Dgv As DataGridView
    Public ID As Integer = 0
    Dim IsNew As Boolean = True
    Private Sub FrmClassDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
        If ID > 0 Then
            Try
                SqlExecutedUsingReading(Me, "select * from class where id = '" & ID & "' Limit 1")
                IsNew = False
            Catch ex As Exception
            End Try

        End If

    End Sub


    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtNAME.Text) = "" Then
            MessageBoxInfo("Please enter class name")
            Exit Sub
        End If

        If IsNew = False Then
            SqlExecuted("UPDATE `class` set " & SqlUpdate(Me) & " Where ID ='" & ID & "'")
        Else

            ID = ObjectTypeMapId("CLASS")
            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO `class` ({SQL_Field},ID) VALUES ({SQL_Value},{ID}) ")

        End If

        SaveNotify(Me, IsNew)
        BindingViewUpdate(Dgv, $"Select ID,`Name`, if (`Inactive`=0,'No','Yes') as `Inactive` from Class Where `ID` = '{ID}'", IsNew, This_BS)
        ClearAndRefresh(Me)

        ID = 0
        IsNew = True

        If SecurityAccessMode(FrmClass, IsNew) = False Then
            Me.Close()
        End If

    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class