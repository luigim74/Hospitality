Public Class Trova
    Inherits System.Windows.Forms.Form

#Region " Codice generato da Progettazione Windows Form "

    Public Sub New()
        MyBase.New()

        'Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()

        'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()

    End Sub

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form.
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents TestoRicerca As System.Windows.Forms.TextBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.TestoRicerca = New System.Windows.Forms.TextBox
      Me.Label1 = New System.Windows.Forms.Label
      Me.SuspendLayout()
      '
      'TestoRicerca
      '
      Me.TestoRicerca.Location = New System.Drawing.Point(8, 27)
      Me.TestoRicerca.Name = "TestoRicerca"
      Me.TestoRicerca.Size = New System.Drawing.Size(232, 20)
      Me.TestoRicerca.TabIndex = 0
      Me.TestoRicerca.Text = ""
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.ForeColor = System.Drawing.SystemColors.Desktop
      Me.Label1.Location = New System.Drawing.Point(8, 11)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(85, 16)
      Me.Label1.TabIndex = 1
      Me.Label1.Text = "Testo di ricerca:"
      '
      'Trova
      '
      Me.AllowDrop = True
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(250, 56)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.TestoRicerca)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "Trova"
      Me.ShowInTaskbar = False
      Me.Text = "Trova"
      Me.TopMost = True
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private Sub TestoRicerca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestoRicerca.TextChanged
      Dim sql As String

      ' b_todo: inserire il nome della tabella dinamicamente.
      If TestoRicerca.Text <> "" Then
         ' Crea la stringa sql.
         sql = String.Format("SELECT TOP {0} * FROM {1} WHERE {2} LIKE '" & TestoRicerca.Text & "%' ORDER BY Id", dimPagina, "Clienti", Me.Tag)
      Else

         sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Id", dimPagina, "Clienti")
      End If

      ' Legge i dati e ottiene il numero totale dei record.
      g_frmClienti.LeggiDati("Clienti", sql)

      ' Se nella tabella non ci sono record disattiva i pulsanti.
      g_frmClienti.ConvalidaDati()

      ' Aggiorna l'intestazione della griglia dati.
      g_frmClienti.AggIntGriglia()

      ' Aggiorna il titolo della finestra.
      'g_frmClienti.AggTitoloFinestra(TitoloFinestra)
   End Sub

   Private Sub Trova_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' b_todo: modificare...
      Me.Text = "Trova " & Me.Tag
   End Sub
End Class
