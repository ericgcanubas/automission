Imports System.Data.Odbc
Public Class frmPOSSetting
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub fRefresh()

        ClearAndRefresh(Me)

        SqlExecutedUsingReading(Me, "select * from pos_machine where ID = '" & xnumID.Value & "' limit 1")

        ' Dim squery As String = fFieldCollector(Me)
    End Sub
    Private Sub frmPOSSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  fBackGroundImageStyle(Me)

        Dim sQueryAccount As String = "SELECT a.ID, CONCAT(a.NAME ,' / ', atm.Description)  AS T FROM account AS a INNER JOIN account_type_map AS atm ON  atm.ID = a.TYPE  ORDER by FIELD(a.TYPE,'12','14','0','1','2','3','4','5','6','7','8','9','10','11','13'), a.NAME"
        ComboBoxLoad(cmbACCOUNT_ID, sQueryAccount, "ID", "T")
        ComboBoxLoad(cmbTYPE, "select  ID,DESCRIPTION from pos_machine_type_map where INACTIVE = '0'", "ID", "DESCRIPTION")
        ComboBoxLoad(cmbDINE_IN_ID, "select ID,DESCRIPTION from ship_via ", "ID", "DESCRIPTION")
        ComboBoxLoad(cmbTAKE_OUT_ID, "select ID,DESCRIPTION from ship_via ", "ID", "DESCRIPTION")
        ComboBoxLoad(cmbDELIVERY_ID, "select ID,DESCRIPTION from ship_via ", "ID", "DESCRIPTION")






        xnumID.Value = fPOS_MACHINE_ID()
    End Sub

    Private Sub xnumID_ValueChanged(sender As Object, e As EventArgs) Handles xnumID.ValueChanged
        fRefresh()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click


        Dim rd As OdbcDataReader = SqlReader("select * from pos_machine where ID = '" & xnumID.Value & "'")
        Dim SqlStr As String
        Dim myMsg As String
        If rd.Read Then

            SqlStr = "Update pos_machine set " & SqlUpdate(Me) & "  Where ID = '" & xnumID.Value & "'"
            myMsg = "Edit POS mechine?"
        Else

            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlStr = $"INSERT pos_machine ({SQL_Field},ID) VALUES ({SQL_Value},'{xnumID.Value}')"
            myMsg = "New POS mechine?"
        End If
        rd.Close()

        If MessageBoxQuestion(myMsg) = True Then
            SqlExecuted(SqlStr)
            MessageBoxInfo("Save")
        End If

    End Sub
End Class