Public Class UsersForm

    Private Sub UsersForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the '_0495_392_SteamTradingYellowDataSet.Users' table. You can move, or remove it, as needed.
        Me.UsersTableAdapter.Fill(Me._0495_392_SteamTradingYellowDataSet.Users)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class