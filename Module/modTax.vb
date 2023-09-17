Imports System.Data.Odbc
Module modTax
    Public gsTax_ID(1000) As Integer
    Public gsTax_Rate(1000) As Double
    Public Sub GS_Tax_Rate_Load()


        For n As Integer = 0 To 999
            gsTax_ID(n) = 0
            gsTax_Rate(n) = 0
        Next
        Dim i As Integer
        Dim rd As OdbcDataReader = SqlReader("select `id`,`rate` from `tax` order by `id` ")
        While rd.Read
            gsTax_ID(i) = GF_NumIsNull(rd("id"))
            gsTax_Rate(i) = GF_NumIsNull(rd("rate"))
            i += 1
        End While
    End Sub
    Public Function GS_Tax_Rate_Find(ByVal prID As Integer) As Double
        Dim rate As Double = 0
        For i As Integer = 0 To 999
            If gsTax_ID(i) = prID Then
                rate = gsTax_Rate(i)
                Exit For
            ElseIf gsTax_ID(i) = 0 Then
                rate = 0
            End If
        Next
        Return rate
    End Function
    Public Sub GS_Tax_Computation(ByVal prTax_Type As ComboBox, prAmount As Double, ByVal prTaxable As Boolean, ByVal prROW As DataGridViewRow)

        Dim Taxable_Amount As Double = 0
        Dim Tax_Amount As Double = 0

        If prTaxable = True Then
            'add tax

            Dim dVat As Double = GS_Tax_Rate_Find(GF_NumIsNull(prTax_Type.SelectedValue))
            Tax_Amount = (dVat / 100) * prAmount
            Taxable_Amount = Tax_Amount + prAmount
            If prTax_Type.SelectedValue = 12 Then
                'inclusive only
                Dim t As Double = (100 / 112)
                Tax_Amount = t * Tax_Amount

                prAmount -= Tax_Amount

                Taxable_Amount = prAmount
            ElseIf prTax_Type.SelectedValue = 13 Then
                Taxable_Amount = prAmount
            Else
            End If
        End If
        prROW.Cells("Tax_Amount").Value = NumberFormatFixed(Tax_Amount)
        prROW.Cells("Taxable_Amount").Value = NumberFormatFixed(Taxable_Amount)

    End Sub

End Module
