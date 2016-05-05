<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UsersForm
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
        Me.UsersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me._0495_392_SteamTradingYellowDataSet = New SteamTradingReport._0495_392_SteamTradingYellowDataSet()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.UsersTableAdapter = New SteamTradingReport._0495_392_SteamTradingYellowDataSetTableAdapters.UsersTableAdapter()
        CType(Me.UsersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._0495_392_SteamTradingYellowDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UsersBindingSource
        '
        Me.UsersBindingSource.DataMember = "Users"
        Me.UsersBindingSource.DataSource = Me._0495_392_SteamTradingYellowDataSet
        '
        '_0495_392_SteamTradingYellowDataSet
        '
        Me._0495_392_SteamTradingYellowDataSet.DataSetName = "_0495_392_SteamTradingYellowDataSet"
        Me._0495_392_SteamTradingYellowDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "UsersDataSet"
        ReportDataSource1.Value = Me.UsersBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SteamTradingReport.UsersReport.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(484, 262)
        Me.ReportViewer1.TabIndex = 0
        '
        'UsersTableAdapter
        '
        Me.UsersTableAdapter.ClearBeforeFill = True
        '
        'UsersForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 262)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "UsersForm"
        Me.Text = "Steam Trading Users Report"
        CType(Me.UsersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._0495_392_SteamTradingYellowDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents UsersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents _0495_392_SteamTradingYellowDataSet As SteamTradingReport._0495_392_SteamTradingYellowDataSet
    Friend WithEvents UsersTableAdapter As SteamTradingReport._0495_392_SteamTradingYellowDataSetTableAdapters.UsersTableAdapter
End Class
