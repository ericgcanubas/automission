Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Module modReportExport
    Public gsExportPDFLocation As String
    Public Sub fReportExporPDF(ByVal cryRpt As ReportDocument, ByVal prfileName As String)
        If Trim(gsExportPDFLocation) = "" Then
            Exit Sub
        End If
        Try
            Dim CrExportOptions As ExportOptions
            Dim filex As String = prfileName.Replace("/", "")
            filex = filex.Replace("\", "")
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
            Dim thisFile As String = filex.Replace(" ", "") & Format(Date.Now, "yyyyMMddhhmmss")
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
            CrDiskFileDestinationOptions.DiskFileName = gsExportPDFLocation & "\" & thisFile & ".pdf"

            CrExportOptions = cryRpt.ExportOptions

            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With

            cryRpt.Export()
        Catch ex As Exception
            fMessageboxExclamation(ex.Message)
        End Try

    End Sub
End Module
