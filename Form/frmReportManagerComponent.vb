Public Class frmReportManagerComponent
    Public ID As Integer
    Public SUB_ID As Integer
    Public FormMain As Form
    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If ID = 0 Then

            ID = GetMaxField("ID", "report_components")

            SqlCreate(Me, SQL_Field, SQL_Value)

            SqlExecuted($"INSERT INTO report_components ({SQL_Field},SUB_ID,ID) VLAUES({SQL_Value},{SUB_ID},{ID})")
            FormMain.Text = ID
            ID = 0
            LoadComponents()
            numLINE_NO.Value = Val(GetMaxFieldLine("LINE_NO", "report_components", "SUB_ID", SUB_ID))
        Else
            Dim SQL As String = SqlUpdate(Me)
            SqlExecuted("UPDATE report_components SET " & SQL & " WHERE ID='" & ID & "' limit 1")
            Me.Close()
        End If

    End Sub
    Private Sub ReportManagerComponent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadComponents()

        If ID > 0 Then
            SqlExecutedUsingReading(Me, "select * from report_components where ID = '" & ID & "'")
        Else
            numLINE_NO.Value = Val(GetMaxFieldLine("LINE_NO", "report_components", "SUB_ID", SUB_ID))
        End If
    End Sub
    Private Sub LoadComponents()
        If ID = 0 Then
            ComboBoxLoad(cmbCOMPONENT_ID, "SELECT o.ID,o.NAME FROM COMPONENT AS o WHERE NOT EXISTS (SELECT c.ID,c.NAME FROM component AS c INNER JOIN report_components AS r ON r.COMPONENT_ID = c.ID WHERE o.ID = c.`ID` and r.SUB_ID = '" & SUB_ID & "')", "ID", "NAME")
        Else
            ComboBoxLoad(cmbCOMPONENT_ID, "SELECT o.ID,o.NAME FROM COMPONENT AS o WHERE NOT EXISTS (SELECT c.ID,c.NAME FROM component AS c INNER JOIN report_components AS r ON r.COMPONENT_ID = c.ID WHERE o.ID = c.`ID` and  r.ID <> '" & ID & "' and r.SUB_ID = '" & SUB_ID & "')", "ID", "NAME")
        End If
    End Sub
End Class