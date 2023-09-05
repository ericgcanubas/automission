Public Class frmDuplicateJournalAccounts
    Private Sub frmDuplicateJournalAccounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        fRefresh()

    End Sub
    Private Sub fRefresh()

        fDataGridView(dgvList, $"SELECT 
aj.`ID`,
a.`NAME` AS `Account Name`,
aj.`OBJECT_DATE` AS `Entry date`,
 COUNT( aj.`JOURNAL_NO`) AS `No. Duplicate`,
 l.`NAME` AS `Location`,
 m.`NAME` AS `Type`,
 aj.`AMOUNT`

FROM
  account_journal AS aj
  INNER JOIN location AS l
  ON l.`ID` = aj.`LOCATION_ID`
  INNER JOIN account AS a
  ON a.`ID`  = aj.`ACCOUNT_ID`
  INNER JOIN object_type_map AS m
  ON m.`ID` = aj.`OBJECT_TYPE`
GROUP BY aj.`JOURNAL_NO`,
  aj.`ACCOUNT_ID`,
  aj.`OBJECT_ID`,
  aj.`OBJECT_DATE`,
  aj.`OBJECT_TYPE`,
  aj.`ENTRY_TYPE`,
  aj.`AMOUNT`,
  aj.`LOCATION_ID`,
  aj.`SEQUENCE_GROUP`,
  aj.`SUBSIDIARY_ID` 
  HAVING  COUNT(aj.`JOURNAL_NO`) > 1
    AND COUNT(aj.`ACCOUNT_ID`) > 1
    AND COUNT(aj.`OBJECT_ID`) > 1
    AND COUNT(aj.`OBJECT_DATE`) > 1
    AND COUNT(aj.`OBJECT_TYPE`) > 1
    AND COUNT(aj.`ENTRY_TYPE`) > 1
    AND COUNT(aj.`AMOUNT`) > 1
    AND COUNT(aj.`LOCATION_ID`) > 1
    AND COUNT( aj.`SEQUENCE_GROUP`) > 1
    AND COUNT( aj.`SUBSIDIARY_ID`) > 1
                     ")
    End Sub
    Private Sub RemoveAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveAllToolStripMenuItem.Click
        If dgvList.Rows.Count = 0 Then
            fMessageboxInfo("Data not found")
            Exit Sub
        End If

        If fMessageBoxQuestion("Do you want to remove this duplicate journal?") = True Then
            For I As Integer = 0 To dgvList.Rows.Count - 1
                fRemoveAccountJournal(dgvList.Rows(I).Cells("ID").Value)
            Next

            fMessageboxInfo("Successfully remove.")
            fRefresh()
        End If



    End Sub
    Private Sub fRemoveAccountJournal(ByVal ID As Integer)

        fExecutedOnly($"Delete from account_journal Where ID = '{ID}' limit 1;")

    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        fRefresh()
    End Sub
End Class