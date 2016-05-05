<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GamesForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.GamesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me._0495_392_SteamTradingYellowDataSet = New SteamTradingReport._0495_392_SteamTradingYellowDataSet()
        Me.GamesReportViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.GamesTableAdapter = New SteamTradingReport._0495_392_SteamTradingYellowDataSetTableAdapters.GamesTableAdapter()
        CType(Me.GamesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._0495_392_SteamTradingYellowDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GamesBindingSource
        '
        Me.GamesBindingSource.DataMember = "Games"
        Me.GamesBindingSource.DataSource = Me._0495_392_SteamTradingYellowDataSet
        '
        '_0495_392_SteamTradingYellowDataSet
        '
        Me._0495_392_SteamTradingYellowDataSet.DataSetName = "_0495_392_SteamTradingYellowDataSet"
        Me._0495_392_SteamTradingYellowDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GamesReportViewer
        '
        Me.GamesReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "GamesDataSet"
        ReportDataSource1.Value = Me.GamesBindingSource
        Me.GamesReportViewer.LocalReport.DataSources.Add(ReportDataSource1)
        Me.GamesReportViewer.LocalReport.ReportEmbeddedResource = "SteamTradingReport.GamesReport.rdlc"
        Me.GamesReportViewer.Location = New System.Drawing.Point(0, 0)
        Me.GamesReportViewer.Name = "GamesReportViewer"
        Me.GamesReportViewer.Size = New System.Drawing.Size(484, 262)
        Me.GamesReportViewer.TabIndex = 0
        '
        'GamesTableAdapter
        '
        Me.GamesTableAdapter.ClearBeforeFill = True
        '
        'GamesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 262)
        Me.Controls.Add(Me.GamesReportViewer)
        Me.Name = "GamesForm"
        Me.Text = "Steam Trading Games Report"
        CType(Me.GamesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._0495_392_SteamTradingYellowDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GamesReportViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents GamesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents _0495_392_SteamTradingYellowDataSet As SteamTradingReport._0495_392_SteamTradingYellowDataSet
    Friend WithEvents GamesTableAdapter As SteamTradingReport._0495_392_SteamTradingYellowDataSetTableAdapters.GamesTableAdapter
End Class
