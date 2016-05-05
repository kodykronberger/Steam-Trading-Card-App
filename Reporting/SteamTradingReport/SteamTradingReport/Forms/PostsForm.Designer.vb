<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PostsForm
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
        Me.PostsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me._0495_392_SteamTradingYellowDataSet = New SteamTradingReport._0495_392_SteamTradingYellowDataSet()
        Me.PostsReportViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.PostsTableAdapter = New SteamTradingReport._0495_392_SteamTradingYellowDataSetTableAdapters.PostsTableAdapter()
        CType(Me.PostsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._0495_392_SteamTradingYellowDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PostsBindingSource
        '
        Me.PostsBindingSource.DataMember = "Posts"
        Me.PostsBindingSource.DataSource = Me._0495_392_SteamTradingYellowDataSet
        '
        '_0495_392_SteamTradingYellowDataSet
        '
        Me._0495_392_SteamTradingYellowDataSet.DataSetName = "_0495_392_SteamTradingYellowDataSet"
        Me._0495_392_SteamTradingYellowDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PostsReportViewer
        '
        Me.PostsReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "PostsDataSet"
        ReportDataSource1.Value = Me.PostsBindingSource
        Me.PostsReportViewer.LocalReport.DataSources.Add(ReportDataSource1)
        Me.PostsReportViewer.LocalReport.ReportEmbeddedResource = "SteamTradingReport.PostsReport.rdlc"
        Me.PostsReportViewer.Location = New System.Drawing.Point(0, 0)
        Me.PostsReportViewer.Name = "PostsReportViewer"
        Me.PostsReportViewer.Size = New System.Drawing.Size(484, 262)
        Me.PostsReportViewer.TabIndex = 0
        '
        'PostsTableAdapter
        '
        Me.PostsTableAdapter.ClearBeforeFill = True
        '
        'PostsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 262)
        Me.Controls.Add(Me.PostsReportViewer)
        Me.Name = "PostsForm"
        Me.Text = "Steam Trading Posts Report"
        CType(Me.PostsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._0495_392_SteamTradingYellowDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PostsReportViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents PostsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents _0495_392_SteamTradingYellowDataSet As SteamTradingReport._0495_392_SteamTradingYellowDataSet
    Friend WithEvents PostsTableAdapter As SteamTradingReport._0495_392_SteamTradingYellowDataSetTableAdapters.PostsTableAdapter
End Class
