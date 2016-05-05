Public Class GamesForm

    Private Sub GamesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the '_0495_392_SteamTradingYellowDataSet.Games' table. You can move, or remove it, as needed.
        Me.GamesTableAdapter.Fill(Me._0495_392_SteamTradingYellowDataSet.Games)

        Me.GamesReportViewer.RefreshReport()
    End Sub
End Class