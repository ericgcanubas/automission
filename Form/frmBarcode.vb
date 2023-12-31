﻿Imports ZXing
Imports System.Text.RegularExpressions
Public Class FrmBarcode
    Public dgv As DataGridView
    Private Function CropBitmap(ByRef bmp As Bitmap, ByVal cropX As Integer, ByVal cropY As Integer, ByVal cropWidth As Integer, ByVal cropHeight As Integer) As Bitmap
        Dim rect As New Rectangle(cropX, cropY, cropWidth, cropHeight)
        Dim cropped As Bitmap = bmp.Clone(rect, bmp.PixelFormat)
        Return cropped
    End Function

    Private Sub BtnAuto_Click(sender As Object, e As EventArgs) Handles btnAuto.Click
        For I As Integer = 0 To dgv.Rows.Count - 1
            Dim BCODE As String = dgv.Rows(I).Cells("CODE").Value
            Dim BarWrite As New BarcodeWriter With {
                .Format = BarcodeFormat.CODE_128
            }
            PictureBox1.Image = BarWrite.Write(BCODE)
            PictureBox1.Image.Save(Application.StartupPath & $"/image/barcode/{BCODE}.png")

        Next
        MessageBoxInfo("Auto save image complete.")
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Process.Start(Application.StartupPath & $"/image/barcode")
    End Sub
End Class