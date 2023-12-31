﻿
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Module modReports

    Public gscryRpt As ReportDocument
    Public gsPOS_TYPE As Integer = 0
    Public gsReportName As String
    Public gsReportTabName As String
    Public gsToolPanelView As Boolean = True

    Public Function PublicReportPath() As String
        Try
            Dim path As String = AppDomain.CurrentDomain.BaseDirectory
            Dim file_path As String = path & "Reports\"
            Return file_path
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
        Return ""
    End Function


    Private Function IsFileInUse(ByVal sFile As String) As Boolean
        Dim IsFileIsUse As Boolean = False
        If System.IO.File.Exists(sFile) Then
            Try
                Dim F As Short = FreeFile()
                FileOpen(F, sFile, OpenMode.Binary, OpenAccess.ReadWrite, OpenShare.LockReadWrite)
                FileClose(F)
            Catch
                IsFileIsUse = True
            End Try
        End If
        Return IsFileIsUse
    End Function

    Public Function ReportDocumentOneParameterNumberOnly(ByVal prReportName As String) As ReportDocument
        Try


            Dim cryRpt As New ReportDocument
            Try
                Dim FilePath As String = PublicReportPath() & prReportName
                If IsFileInUse(FilePath) = False Then
                    cryRpt.Load(FilePath, OpenReportMethod.OpenReportByTempCopy)
                Else
                    MessageBoxWarning($"File {prReportName}  not exists")
                End If

                If cryRpt Is Nothing Then
                    MessageBoxExclamation("Rpt file not found.")
                    Return Nothing
                    Exit Function
                End If

                cryRpt.DataSourceConnections(0).SetConnection(db_name, db_name, db_username, db_password)

            Catch ex As Exception
                cryRpt = ReportDocumentOneParameterNumberOnly(prReportName)
            End Try

            Return cryRpt

        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
            Return Nothing
        End Try

    End Function
    Public Sub GlobalPreviewReport(ByVal prTabname As String)
        GS_CursorLoadingOn(True)
        gsReportTabName = prTabname
        gsMenuSubID = "31"
        gsRefresh = True
        ' MenuSet()
        Dim folder As String = $"{New Uri(CurrentPath).LocalPath}\image\sub\"
        Dim img As Image = Image.FromFile(folder & "report.png")
        Dim R As New FrmReportViewer With {
            .Text = prTabname & " Preview"
        }
        R.AccessibleDescription = R.Text

        For I As Integer = 0 To FrmMainMenu.MyTab.TabPages.Count - 1

            Dim F As Form = FrmMainMenu.MyTab.TabPages.Item(I).Form
            If F.AccessibleDescription = R.AccessibleDescription Then
                F.Close()
                Exit For
            End If
        Next


        TabFormOpen(R, FrmMainMenu.MyTab, img)

        GS_CursorLoadingOn(False)
        gsMenuSubID = 0
    End Sub
    Public Sub CryParameterInsertValue(ByRef cryRpt As ReportDocument, ByVal prValue As String, ByVal prName As String)
        Try

            Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            Dim crParameterFieldDefinition As ParameterFieldDefinition
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue With {
                .Value = prValue
            }
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(prName)
            crParameterValues = crParameterFieldDefinition.CurrentValues

            crParameterValues.Clear()
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try


    End Sub



End Module
