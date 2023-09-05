
Public Class frmReportComponentItems
    Public gsID As String
    Private Sub frmReportComponentItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        fComboBox(cmbTYPE, "SELECT * FROM COMPONENT_TYPE ", "ID", "DESCRIPTION")
        fComboBox(cmbPARAMETER_ID1, "select ID,`NAME` FROM COMPONENT ", "ID", "NAME")
        fComboBox(cmbPARAMETER_ID2, "select ID,`NAME` FROM COMPONENT ", "ID", "NAME")
        fComboBox(cmbPARAMETER_ID3, "select ID,`NAME` FROM COMPONENT ", "ID", "NAME")
        fExecutedUsingReading(Me, "select * FROM COMPONENT WHERE ID = '" & gsID & "' limit 1")

    End Sub

    Private Sub btnCANCEL_Click(sender As Object, e As EventArgs) Handles btnCANCEL.Click
        Me.Close()
    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click
        If txtNAME.Text = "" Then
            fMessageboxWarning("Please enter name")
            Exit Sub
        End If

        Dim sQUery As String = fFieldCollector(Me)
        If gsID = "" Then
            gsID = fGetMaxField("ID", "COMPONENT")
            fExecutedOnly("INSERT INTO component SET " & sQUery & ",ID ='" & gsID & "'")
        Else
            fExecutedOnly("UPDATE component SET " & sQUery & " WHERE ID ='" & gsID & "'")
        End If

        Me.Close()

    End Sub
End Class