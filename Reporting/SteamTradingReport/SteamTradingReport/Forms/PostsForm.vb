Public Class PostsForm

    Private Sub PostsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the '_0495_392_SteamTradingYellowDataSet.Posts' table. You can move, or remove it, as needed.
        Me.PostsTableAdapter.Fill(Me._0495_392_SteamTradingYellowDataSet.Posts)

        Me.PostsReportViewer.RefreshReport()
    End Sub
End Class