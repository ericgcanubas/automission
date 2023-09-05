Public Class frmReportManagerComponent
    Public gsID As String
    Public gsSUB_ID As String
    Public fMain As Form
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim sQuery As String = fFieldCollector(Me)
        If gsID = "" Then
            gsID = fGetMaxField("ID", "report_components")
            fExecutedOnly("INSERT INTO report_components SET " & sQuery & ",SUB_ID = '" & gsSUB_ID & "',ID='" & gsID & "'")
            fMain.Text = gsID
            gsID = ""
            fCmb()
            numLINE_NO.Value = Val(fGetMaxField_LINE("LINE_NO", "report_components", "SUB_ID", gsSUB_ID))
        Else
            fExecutedOnly("UPDATE report_components SET " & sQuery & " WHERE ID='" & gsID & "'")
            Me.Close()
        End If



    End Sub
    Private Sub frmReportManagerComponent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fCmb()

        If gsID <> "" Then
            fExecutedUsingReading(Me, "select * from report_components where ID = '" & gsID & "'")
        Else
            numLINE_NO.Value = Val(fGetMaxField_LINE("LINE_NO", "report_components", "SUB_ID", gsSUB_ID))
        End If
    End Sub
    Private Sub fCmb()
        If gsID = "" Then
            fComboBox(cmbCOMPONENT_ID, "SELECT o.ID,o.NAME FROM COMPONENT AS o WHERE NOT EXISTS (SELECT c.ID,c.NAME FROM component AS c INNER JOIN report_components AS r ON r.COMPONENT_ID = c.ID WHERE o.ID = c.`ID` and r.SUB_ID = '" & gsSUB_ID & "')", "ID", "NAME")
        Else
            fComboBox(cmbCOMPONENT_ID, "SELECT o.ID,o.NAME FROM COMPONENT AS o WHERE NOT EXISTS (SELECT c.ID,c.NAME FROM component AS c INNER JOIN report_components AS r ON r.COMPONENT_ID = c.ID WHERE o.ID = c.`ID` and  r.ID <> '" & gsID & "' and r.SUB_ID = '" & gsSUB_ID & "')", "ID", "NAME")
        End If
    End Sub
End Class