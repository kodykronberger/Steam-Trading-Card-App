<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TotalsForm
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
        Me.TotalsDataTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TotalsDataSet = New SteamTradingReport.TotalsDataSet()
        Me.TotalsDataTableTableAdapter = New SteamTradingReport.TotalsDataSetTableAdapters.TotalsDataTableTableAdapter()
        Me.TotalsReportViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.TotalsDataTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotalsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TotalsDataTableBindingSource
        '
        Me.TotalsDataTableBindingSource.DataMember = "TotalsDataTable"
        Me.TotalsDataTableBindingSource.DataSource = Me.TotalsDataSet
        '
        'TotalsDataSet
        '
        Me.TotalsDataSet.DataSetName = "TotalsDataSet"
        Me.TotalsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TotalsDataTableTableAdapter
        '
        Me.TotalsDataTableTableAdapter.ClearBeforeFill = True
        '
        'TotalsReportViewer
        '
        Me.TotalsReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "TotalsDataSet"
        ReportDataSource1.Value = Me.TotalsDataTableBindingSource
        Me.TotalsReportViewer.LocalReport.DataSources.Add(ReportDataSource1)
        Me.TotalsReportViewer.LocalReport.ReportEmbeddedResource = "SteamTradingReport.TotalsReport.rdlc"
        Me.TotalsReportViewer.Location = New System.Drawing.Point(0, 0)
        Me.TotalsReportViewer.Name = "TotalsReportViewer"
        Me.TotalsReportViewer.Size = New System.Drawing.Size(484, 262)
        Me.TotalsReportViewer.TabIndex = 0
        '
        'TotalsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 262)
        Me.Controls.Add(Me.TotalsReportViewer)
        Me.Name = "TotalsForm"
        Me.Text = "Steam Trading Totals Report"
        CType(Me.TotalsDataTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotalsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TotalsDataTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TotalsDataSet As SteamTradingReport.TotalsDataSet
    Friend WithEvents TotalsDataTableTableAdapter As SteamTradingReport.TotalsDataSetTableAdapters.TotalsDataTableTableAdapter
    Friend WithEvents TotalsReportViewer As Microsoft.Reporting.WinForms.ReportViewer
End Class
