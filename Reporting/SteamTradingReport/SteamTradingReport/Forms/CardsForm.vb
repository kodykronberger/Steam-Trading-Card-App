Public Class CardsForm

    Private Sub CardsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the '_0495_392_SteamTradingYellowDataSet.Cards' table. You can move, or remove it, as needed.
        Me.CardsTableAdapter.Fill(Me._0495_392_SteamTradingYellowDataSet.Cards)

        Me.CardsReportViewer.RefreshReport()
    End Sub
End Class
