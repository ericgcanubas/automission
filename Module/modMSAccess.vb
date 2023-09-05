Imports System.Net.Mail
Imports Microsoft.Office.Core
Module modMSAccess

    Public Sub fMS_ComboBox(ByVal cmb As ComboBox, ByVal sqlQuery As String, ByVal xValue As String, ByVal xDisplay As String)

        Dim cn As New OleDb.OleDbConnection(fMS_Con)
        Try
            cn.Open()
            Dim cmd As New OleDb.OleDbCommand(sqlQuery, cn)
            Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(cmd)
            Dim dt As New DataTable("1")

            da.Fill(dt)
            cmb.DataSource = dt
            cmb.DisplayMember = xDisplay
            cmb.ValueMember = xValue

            cn.Close()

            If cmb.DropDownStyle = ComboBoxStyle.DropDown Then
                cmb.AutoCompleteMode = AutoCompleteMode.Suggest
                cmb.AutoCompleteSource = AutoCompleteSource.ListItems
                cmb.SelectedIndex = -1
                cmb.DropDownHeight = 100
                ' cmb.DropDownWidth = 400
            End If


        Catch ex As Exception
            fMessageboxWarning(ex.Message)
            If cn.State = ConnectionState.Open Then
                cn.Close()

            End If

        End Try
    End Sub
    Public Function fMS_Con() As String
        Dim path As String = AppDomain.CurrentDomain.BaseDirectory
        Dim file_path As String = path & "temp_db"
        Return "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" & file_path & ";Jet OLEDB:Database Password=admin123;"
    End Function

    Public Sub fMS_execute(ByVal xQuery As String)

        Dim cn As New OleDb.OleDbConnection(fMS_Con)
        Try
            cn.Open()
            Dim cmd As New OleDb.OleDbCommand(xQuery, cn)
            Dim rd As OleDb.OleDbDataReader = cmd.ExecuteReader
            rd.Read()
            cn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try


    End Sub

    Public Function fMSgetField(ByVal xReturn_Filed As String, ByVal xTable As String, ByVal xCondition As String, ByVal zValue As String) As String
        Dim xValue As String = ""

        Dim cn As New OleDb.OleDbConnection(fMS_Con)
        Try
            cn.Open()
            Dim cmd As New OleDb.OleDbCommand("select [" & xReturn_Filed & "] as t from " & xTable & " where [" & xCondition & "] = '" & zValue & "'", cn)
            Dim rd As OleDb.OleDbDataReader = cmd.ExecuteReader
            While rd.Read
                xValue = rd("t").ToString
            End While
            cn.Close()
        Catch ex As Exception
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            MessageBox.Show(ex.Message)
        End Try
        Return xValue
    End Function

    Public Sub fMSgetFieldGetReports(ByRef prPrint_Title As String, ByRef prFile_name As String, ByVal prForm As String)


        Dim cn As New OleDb.OleDbConnection(fMS_Con)
        Try
            cn.Open()
            Dim cmd As New OleDb.OleDbCommand($"select [file_name],[print_title] from tblprint Where [form_name] ='{prForm}' and [print_default] = '1' ", cn)
            Dim rd As OleDb.OleDbDataReader = cmd.ExecuteReader
            If rd.Read Then
                prPrint_Title = rd("print_title").ToString
                prFile_name = rd("file_name")
            Else
                prPrint_Title = ""
                prFile_name = ""
            End If
            cn.Close()
        Catch ex As Exception
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Function fMSgetReader(ByVal xQuery As String, ByVal cn As OleDb.OleDbConnection) As OleDb.OleDbDataReader
        Try
            Dim cmd As New OleDb.OleDbCommand(xQuery, cn)
            Return cmd.ExecuteReader
        Catch ex As Exception
            fMessageboxWarning(ex.Message)
        End Try
        Return Nothing
    End Function
End Module
