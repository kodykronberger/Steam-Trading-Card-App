<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CardsForm
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
        Me.CardsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me._0495_392_SteamTradingYellowDataSet = New SteamTradingReport._0495_392_SteamTradingYellowDataSet()
        Me.CardsReportViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.CardsTableAdapter = New SteamTradingReport._0495_392_SteamTradingYellowDataSetTableAdapters.CardsTableAdapter()
        CType(Me.CardsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._0495_392_SteamTradingYellowDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CardsBindingSource
        '
        Me.CardsBindingSource.DataMember = "Cards"
        Me.CardsBindingSource.DataSource = Me._0495_392_SteamTradingYellowDataSet
        '
        '_0495_392_SteamTradingYellowDataSet
        '
        Me._0495_392_SteamTradingYellowDataSet.DataSetName = "_0495_392_SteamTradingYellowDataSet"
        Me._0495_392_SteamTradingYellowDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CardsReportViewer
        '
        Me.CardsReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.CardsBindingSource
        Me.CardsReportViewer.LocalReport.DataSources.Add(ReportDataSource1)
        Me.CardsReportViewer.LocalReport.ReportEmbeddedResource = "SteamTradingReport.CardsReport.rdlc"
        Me.CardsReportViewer.Location = New System.Drawing.Point(0, 0)
        Me.CardsReportViewer.Name = "CardsReportViewer"
        Me.CardsReportViewer.Size = New System.Drawing.Size(484, 262)
        Me.CardsReportViewer.TabIndex = 0
        '
        'CardsTableAdapter
        '
        Me.CardsTableAdapter.ClearBeforeFill = True
        '
        'CardsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 262)
        Me.Controls.Add(Me.CardsReportViewer)
        Me.Name = "CardsForm"
        Me.Text = "Steam Trading Cards Report"
        CType(Me.CardsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._0495_392_SteamTradingYellowDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CardsReportViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents CardsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents _0495_392_SteamTradingYellowDataSet As SteamTradingReport._0495_392_SteamTradingYellowDataSet
    Friend WithEvents CardsTableAdapter As SteamTradingReport._0495_392_SteamTradingYellowDataSetTableAdapters.CardsTableAdapter

End Class
