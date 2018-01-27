<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaDocumenti
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
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.lvwPiatti = New System.Windows.Forms.ListView()
      Me.clnData = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnOra = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnNumero = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnDocumento = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnStato = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnTotale = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.eui_cmdImporta = New Elegant.Ui.Button()
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      Me.clnCodice = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.SuspendLayout()
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'lvwPiatti
      '
      Me.lvwPiatti.CheckBoxes = True
      Me.lvwPiatti.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clnNumero, Me.clnData, Me.clnOra, Me.clnDocumento, Me.clnCliente, Me.clnStato, Me.clnTotale, Me.clnCodice})
      Me.lvwPiatti.FullRowSelect = True
      Me.lvwPiatti.Location = New System.Drawing.Point(1, 0)
      Me.lvwPiatti.MultiSelect = False
      Me.lvwPiatti.Name = "lvwPiatti"
      Me.lvwPiatti.ShowGroups = False
      Me.lvwPiatti.Size = New System.Drawing.Size(726, 431)
      Me.lvwPiatti.TabIndex = 1
      Me.lvwPiatti.UseCompatibleStateImageBehavior = False
      Me.lvwPiatti.View = System.Windows.Forms.View.Details
      '
      'clnData
      '
      Me.clnData.Text = "Data"
      Me.clnData.Width = 80
      '
      'clnOra
      '
      Me.clnOra.Text = "Ora"
      '
      'clnNumero
      '
      Me.clnNumero.Text = "Numero"
      Me.clnNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'clnDocumento
      '
      Me.clnDocumento.Text = "Documento"
      Me.clnDocumento.Width = 100
      '
      'clnCliente
      '
      Me.clnCliente.Text = "Cliente"
      Me.clnCliente.Width = 200
      '
      'clnStato
      '
      Me.clnStato.Text = "Stato"
      Me.clnStato.Width = 100
      '
      'clnTotale
      '
      Me.clnTotale.Text = "Totale"
      Me.clnTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.clnTotale.Width = 100
      '
      'eui_cmdImporta
      '
      Me.eui_cmdImporta.Id = "abaed722-854b-4d92-af0e-42b09a2d6a9e"
      Me.eui_cmdImporta.Location = New System.Drawing.Point(534, 434)
      Me.eui_cmdImporta.Name = "eui_cmdImporta"
      Me.eui_cmdImporta.Size = New System.Drawing.Size(88, 32)
      Me.eui_cmdImporta.TabIndex = 3
      Me.eui_cmdImporta.Text = "&Importa"
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Id = "a9af5fe5-2ead-4b3e-b9c6-13c65e252819"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(630, 434)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(88, 32)
      Me.eui_cmdAnnulla.TabIndex = 4
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'clnCodice
      '
      Me.clnCodice.Text = "Codice"
      Me.clnCodice.Width = 0
      '
      'ListaDocumenti
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(727, 473)
      Me.Controls.Add(Me.eui_cmdImporta)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.lvwPiatti)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ListaDocumenti"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Seleziona documenti"
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents lvwPiatti As ListView
   Friend WithEvents clnNumero As ColumnHeader
   Friend WithEvents clnData As ColumnHeader
   Friend WithEvents clnDocumento As ColumnHeader
   Friend WithEvents clnCliente As ColumnHeader
   Friend WithEvents clnStato As ColumnHeader
   Friend WithEvents clnTotale As ColumnHeader
   Friend WithEvents eui_cmdImporta As Elegant.Ui.Button
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents clnOra As ColumnHeader
   Friend WithEvents clnCodice As ColumnHeader
End Class
