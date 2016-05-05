Public Class TotalsForm

    Private Sub TotalsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TotalsDataSet.TotalsDataTable' table. You can move, or remove it, as needed.
        Me.TotalsDataTableTableAdapter.Fill(Me.TotalsDataSet.TotalsDataTable)

        Me.TotalsReportViewer.RefreshReport()
        Me.TotalsReportViewer.RefreshReport()
    End Sub
End Class