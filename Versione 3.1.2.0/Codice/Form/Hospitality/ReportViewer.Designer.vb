<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportViewer
   Inherits System.Windows.Forms.Form

   'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

   'Richiesto da Progettazione Windows Form
   Private components As System.ComponentModel.IContainer

   'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
   'Può essere modificata in Progettazione Windows Form.  
   'Non modificarla mediante l'editor del codice.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
      Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
      Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
      Me.DettagliDocBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.HospitalityDataSet = New Hospitality_Solution.HospitalityDataSet()
      Me.AziendaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.DocumentiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
      Me.DettagliDocTableAdapter = New Hospitality_Solution.HospitalityDataSetTableAdapters.DettagliDocTableAdapter()
      Me.AziendaTableAdapter = New Hospitality_Solution.HospitalityDataSetTableAdapters.AziendaTableAdapter()
      Me.DocumentiTableAdapter = New Hospitality_Solution.HospitalityDataSetTableAdapters.DocumentiTableAdapter()
      CType(Me.DettagliDocBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.HospitalityDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.AziendaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DocumentiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'DettagliDocBindingSource
      '
      Me.DettagliDocBindingSource.DataMember = "DettagliDoc"
      Me.DettagliDocBindingSource.DataSource = Me.HospitalityDataSet
      '
      'HospitalityDataSet
      '
      Me.HospitalityDataSet.DataSetName = "HospitalityDataSet"
      Me.HospitalityDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'AziendaBindingSource
      '
      Me.AziendaBindingSource.DataMember = "Azienda"
      Me.AziendaBindingSource.DataSource = Me.HospitalityDataSet
      '
      'DocumentiBindingSource
      '
      Me.DocumentiBindingSource.DataMember = "Documenti"
      Me.DocumentiBindingSource.DataSource = Me.HospitalityDataSet
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.Form = Me
      '
      'ReportViewer1
      '
      Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
      ReportDataSource1.Name = "DettagliDoc"
      ReportDataSource1.Value = Me.DettagliDocBindingSource
      ReportDataSource2.Name = "Azienda"
      ReportDataSource2.Value = Me.AziendaBindingSource
      ReportDataSource3.Name = "Documenti"
      ReportDataSource3.Value = Me.DocumentiBindingSource
      Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
      Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
      Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
      Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Hospitality_Solution.Fattura A4_Doppia.rdlc"
      Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
      Me.ReportViewer1.Name = "ReportViewer1"
      Me.ReportViewer1.Size = New System.Drawing.Size(752, 277)
      Me.ReportViewer1.TabIndex = 1
      '
      'DettagliDocTableAdapter
      '
      Me.DettagliDocTableAdapter.ClearBeforeFill = True
      '
      'AziendaTableAdapter
      '
      Me.AziendaTableAdapter.ClearBeforeFill = True
      '
      'DocumentiTableAdapter
      '
      Me.DocumentiTableAdapter.ClearBeforeFill = True
      '
      'ReportViewer
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(752, 277)
      Me.Controls.Add(Me.ReportViewer1)
      Me.Name = "ReportViewer"
      Me.Text = "Anteprima di stampa"
      CType(Me.DettagliDocBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.HospitalityDataSet, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.AziendaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DocumentiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
   Friend WithEvents DettagliDocBindingSource As BindingSource
   Friend WithEvents HospitalityDataSet As HospitalityDataSet
   Friend WithEvents AziendaBindingSource As BindingSource
   Friend WithEvents DocumentiBindingSource As BindingSource
   Friend WithEvents DettagliDocTableAdapter As HospitalityDataSetTableAdapters.DettagliDocTableAdapter
   Friend WithEvents AziendaTableAdapter As HospitalityDataSetTableAdapters.AziendaTableAdapter
   Friend WithEvents DocumentiTableAdapter As HospitalityDataSetTableAdapters.DocumentiTableAdapter
End Class
