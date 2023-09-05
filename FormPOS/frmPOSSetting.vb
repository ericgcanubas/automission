Imports System.Data.Odbc
Public Class frmPOSSetting
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub fRefresh()

        fCLean_and_refresh(Me)

        fExecutedUsingReading(Me, "select * from pos_machine where ID = '" & xnumID.Value & "' limit 1")

        ' Dim squery As String = fFieldCollector(Me)
    End Sub
    Private Sub frmPOSSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  fBackGroundImageStyle(Me)

        Dim sQueryAccount As String = "SELECT a.ID, CONCAT(a.NAME ,' / ', atm.Description)  AS T FROM account AS a INNER JOIN account_type_map AS atm ON  atm.ID = a.TYPE  ORDER by FIELD(a.TYPE,'12','14','0','1','2','3','4','5','6','7','8','9','10','11','13'), a.NAME"
        fComboBox(cmbACCOUNT_ID, sQueryAccount, "ID", "T")
        fComboBox(cmbTYPE, "select  ID,DESCRIPTION from pos_machine_type_map where INACTIVE = '0'", "ID", "DESCRIPTION")
        fComboBox(cmbDINE_IN_ID, "select ID,DESCRIPTION from ship_via ", "ID", "DESCRIPTION")
        fComboBox(cmbTAKE_OUT_ID, "select ID,DESCRIPTION from ship_via ", "ID", "DESCRIPTION")
        fComboBox(cmbDELIVERY_ID, "select ID,DESCRIPTION from ship_via ", "ID", "DESCRIPTION")






        xnumID.Value = fPOS_MACHINE_ID()
    End Sub

    Private Sub xnumID_ValueChanged(sender As Object, e As EventArgs) Handles xnumID.ValueChanged
        fRefresh()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim squery As String = fFieldCollector(Me)
        Dim rd As OdbcDataReader = fReader("select * from pos_machine where ID = '" & xnumID.Value & "'")
        Dim gsNew As Boolean = True
        Dim sql As String = ""
        Dim myMsg As String = ""
        If rd.Read Then
            sql = "Update pos_machine set " & squery & "  Where ID = '" & xnumID.Value & "'"
            myMsg = "Edit POS mechine?"
        Else
            sql = "INSERT pos_machine set " & squery & ",ID = '" & xnumID.Value & "'"
            myMsg = "New POS mechine?"
        End If
        rd.Close()
        If fMessageBoxQuestion(myMsg) = True Then
            fExecutedOnly(sql)
            fMessageboxInfo("Save")
        End If

    End Sub
End Class